using Dev.Store.Categories.Dtos;
using Dev.Store.Permissions;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

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
}
