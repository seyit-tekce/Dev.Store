using Dev.Store.Categories.Dtos;
using Dev.Store.Permissions;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.ObjectMapping;

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


    public CategoryAppService(ICategoryRepository repository) : base(repository)
    {
        _repository = repository;
    }

    [HttpGet]
    [Authorize(StorePermissions.Category.Default)]
    public async Task<DataSourceResult> DataSource([DataSourceRequest] DataSourceRequest request)
    {
        return (await _repository.GetQueryableAsync()).ToDataSourceResult(request, x => ObjectMapper.Map<Category, CategoryDto>(x));
    }
    public override async Task<CategoryDto> GetAsync(Guid id)
    {
        return  ObjectMapper.Map<Category,CategoryDto>( (await _repository.WithDetailsAsync()).Where(a => a.Id == id).FirstOrDefault());
    }

    public override async Task<CategoryDto> CreateAsync(CreateUpdateCategoryDto input)
    {
        var currentOrder = (await _repository.GetQueryableAsync());
        var lastAdded = currentOrder.Where(x => x.CategoryParentId == input.CategoryParentId).OrderByDescending(x => x.Order).FirstOrDefault();
        if (lastAdded != null)
        {
            input.Order = lastAdded.Order + 1;
        }
        else
        {
            input.Order = 1;
        }
        return await base.CreateAsync(input);
    }

    public async Task MoveUp(Guid id)
    {
        var find = await _repository.GetAsync(id);
        find.Order = find.Order - 1;
        var currentOrder = await _repository.FindAsync(x => x.Order == find.Order);
        if (currentOrder != null)
        {
            currentOrder.Order = find.Order + 1;
            await this.UpdateAsync(currentOrder.Id, new CreateUpdateCategoryDto
            {
                CategoryParentId = currentOrder.CategoryParentId,
                Description = currentOrder.Description,
                isVisible = currentOrder.IsVisible,
                Link = currentOrder.Link,
                Name = currentOrder.Name,
                Order = currentOrder.Order
            });
        }
        await this.UpdateAsync(find.Id, new CreateUpdateCategoryDto
        {
            CategoryParentId = find.CategoryParentId,
            Description = find.Description,
            isVisible = find.IsVisible,
            Link = find.Link,
            Name = find.Name,
            Order = find.Order
        });
    }

    public async Task MoveDown(Guid id)
    {
        var find = await _repository.GetAsync(id);
        find.Order = find.Order + 1;
        var currentOrder = await _repository.FindAsync(x => x.Order == find.Order);
        if (currentOrder != null)
        {
            currentOrder.Order = find.Order - 1;
            await this.UpdateAsync(currentOrder.Id, new CreateUpdateCategoryDto
            {
                CategoryParentId = currentOrder.CategoryParentId,
                Description = currentOrder.Description,
                isVisible = currentOrder.IsVisible,
                Link = currentOrder.Link,
                Name = currentOrder.Name,
                Order = currentOrder.Order
            });
        }
        await this.UpdateAsync(find.Id, new CreateUpdateCategoryDto
        {
            CategoryParentId = find.CategoryParentId,
            Description = find.Description,
            isVisible = find.IsVisible,
            Link = find.Link,
            Name = find.Name,
            Order = find.Order
        });
    }
}