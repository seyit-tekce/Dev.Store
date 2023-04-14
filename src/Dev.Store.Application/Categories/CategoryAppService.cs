using Dev.Store.Categories.Dtos;
using Dev.Store.Permissions;
using Dev.Store.UploadFiles;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Caching;

namespace Dev.Store.Categories;
public class CategoryAppService : CrudAppService<Category, CategoryDto, Guid, PagedAndSortedResultRequestDto, CreateUpdateCategoryDto, CreateUpdateCategoryDto>,
    ICategoryAppService
{
    protected override string GetPolicyName { get; set; } = StorePermissions.Category.Default;
    protected override string GetListPolicyName { get; set; } = StorePermissions.Category.Default;
    protected override string CreatePolicyName { get; set; } = StorePermissions.Category.Create;
    protected override string UpdatePolicyName { get; set; } = StorePermissions.Category.Update;
    protected override string DeletePolicyName { get; set; } = StorePermissions.Category.Delete;
    private readonly ICategoryRepository _repository;
    private readonly IUploadFileAppService uploadFileAppService;
    private readonly IDistributedCache<CategoryDto, string> _cache;

    public CategoryAppService(ICategoryRepository repository, IUploadFileAppService uploadFileAppService, IDistributedCache<CategoryDto, string> cache) : base(repository)
    {
        _repository = repository;
        this.uploadFileAppService = uploadFileAppService;
        _cache = cache;
    }
    [HttpGet]
    [Authorize(StorePermissions.Category.Default)]
    public async Task<DataSourceResult> DataSource([DataSourceRequest] DataSourceRequest request)
    {
        return (await _repository.GetQueryableAsync()).ToDataSourceResult(request, x => ObjectMapper.Map<Category, CategoryDto>(x));
    }
    [Authorize(StorePermissions.Category.Default)]
    public override async Task<CategoryDto> GetAsync(Guid id)
    {
        return ObjectMapper.Map<Category, CategoryDto>((await _repository.WithDetailsAsync(x => x.CategoryChildren, x => x.CategoryParent, x => x.File)).Where(a => a.Id == id).FirstOrDefault());
    }
    [Authorize(StorePermissions.Category.Create)]
    public override async Task<CategoryDto> CreateAsync(CreateUpdateCategoryDto input)
    {
        var queryable = (await _repository.GetQueryableAsync());
        var linkExist = queryable.Any(x => x.Link == input.Link);
        if (linkExist)
        {
            throw new UserFriendlyException(L["CategorySameLink"].Value);
        }
        var lastAdded = queryable.Where(x => x.CategoryParentId == input.CategoryParentId).OrderByDescending(x => x.Order).FirstOrDefault();
        if (lastAdded != null)
        {
            input.Order = lastAdded.Order + 1;
        }
        else
        {
            input.Order = 1;
        }
        if (input.Files.Count > 0)
        {
            var fileResult = await uploadFileAppService.CreateAsync(new UploadFiles.Dtos.CreateUpdateUploadFileDto
            {
                Description = input.Description,
                File = input.Files[0],
            });
            input.FileId = fileResult.Id;
        }
        return await base.CreateAsync(input);
    }
    [Authorize(StorePermissions.Category.Update)]
    public override async Task<CategoryDto> UpdateAsync(Guid id, CreateUpdateCategoryDto input)
    {
        var findCategory = await Repository.GetAsync(id);
        var queryable = (await _repository.GetQueryableAsync());
        var linkExist = queryable.Any(x => x.Link == input.Link && x.Id != id);
        if (linkExist)
        {
            throw new UserFriendlyException(L["CategorySameLink"].Value);
        }
        if (findCategory.FileId.HasValue)
        {
            input.FileId = findCategory.FileId.Value;
        }
        if (input.Files.Count > 0)
        {
            var fileResult = await uploadFileAppService.CreateAsync(new UploadFiles.Dtos.CreateUpdateUploadFileDto
            {
                Description = input.Description,
                File = input.Files[0],
            });
            input.FileId = fileResult.Id;
        }
        return await base.UpdateAsync(id, input);
    }
    [Authorize(StorePermissions.Category.Update)]
    public async Task MoveUp(Guid id)
    {
        var find = await _repository.GetAsync(id);
        find.Order = find.Order - 1;
        var currentOrder = await _repository.FindAsync(x => x.Order == find.Order && x.CategoryParentId == find.CategoryParentId);
        if (currentOrder != null)
        {
            currentOrder.Order = find.Order + 1;
            await Repository.UpdateAsync(currentOrder);
        }
        await Repository.UpdateAsync(find);
    }
    [Authorize(StorePermissions.Category.Update)]
    public async Task MoveDown(Guid id)
    {
        var find = await _repository.GetAsync(id);
        find.Order = find.Order + 1;
        var currentOrder = await _repository.FindAsync(x => x.Order == find.Order && x.CategoryParentId == find.CategoryParentId);
        if (currentOrder != null)
        {
            currentOrder.Order = find.Order - 1;
            await Repository.UpdateAsync(currentOrder);
        }
        await Repository.UpdateAsync(find);
    }
    public async Task<IEnumerable<CategoryDto>> GetCategoriesAsync(bool includeDisabled = false)
    {
        return (await _repository.WithDetailsAsync(x => x.File)).Select(a => ObjectMapper.Map<Category, CategoryDto>(a));
    }
    [AllowAnonymous]
    public async Task<CategoryDto> GetCategoryByMainAndSubName(string mainCategory, string subCategory)
    {
        return await _cache.GetOrAddAsync(mainCategory + "/" + subCategory,
            async () => await GetCategoryByMainAndSubNameFromDataBase(mainCategory, subCategory), () => new DistributedCacheEntryOptions
            {
                AbsoluteExpiration = DateTimeOffset.Now.AddHours(1)
            });
    }
    private async Task<CategoryDto> GetCategoryByMainAndSubNameFromDataBase(string mainCategory, string subCategory)
    {
        var main = await _repository.GetAsync(x => x.Link == mainCategory && x.CategoryParentId == null);
        var sub = await _repository.GetCategoryWithFileByLinkAndParentId(subCategory, main.Id);
        return ObjectMapper.Map<Category, CategoryDto>(sub);
    }
}