using Dev.Store.Permissions;
using Dev.Store.ProductSets.Dtos;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace Dev.Store.ProductSets;


public class ProductSetAppService : CrudAppService<ProductSet, ProductSetDto, Guid, ProductSetGetListInput, CreateUpdateProductSetDto, CreateUpdateProductSetDto>,
    IProductSetAppService
{
    protected override string GetPolicyName { get; set; } = StorePermissions.ProductSet.Default;
    protected override string GetListPolicyName { get; set; } = StorePermissions.ProductSet.Default;
    protected override string CreatePolicyName { get; set; } = StorePermissions.ProductSet.Create;
    protected override string UpdatePolicyName { get; set; } = StorePermissions.ProductSet.Update;
    protected override string DeletePolicyName { get; set; } = StorePermissions.ProductSet.Delete;

    private readonly IProductSetRepository _repository;

    public ProductSetAppService(IProductSetRepository repository) : base(repository)
    {
        _repository = repository;
    }

    [HttpGet]
    [Authorize(StorePermissions.ProductSet.Default)]
    public async Task<DataSourceResult> DataSource([DataSourceRequest] DataSourceRequest request)
    {
        return (await _repository.GetQueryableAsync()).ToDataSourceResult(request, x => ObjectMapper.Map<ProductSet, ProductSetDto>(x));
    }
}
