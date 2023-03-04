using Dev.Store.Permissions;
using Dev.Store.ProductImages.Dtos;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace Dev.Store.ProductImages;


public class ProductImageAppService : CrudAppService<ProductImage, ProductImageDto, Guid, ProductImageGetListInput, CreateUpdateProductImageDto, CreateUpdateProductImageDto>,
    IProductImageAppService
{
    protected override string GetPolicyName { get; set; } = StorePermissions.ProductImage.Default;
    protected override string GetListPolicyName { get; set; } = StorePermissions.ProductImage.Default;
    protected override string CreatePolicyName { get; set; } = StorePermissions.ProductImage.Create;
    protected override string UpdatePolicyName { get; set; } = StorePermissions.ProductImage.Update;
    protected override string DeletePolicyName { get; set; } = StorePermissions.ProductImage.Delete;

    private readonly IProductImageRepository _repository;

    public ProductImageAppService(IProductImageRepository repository) : base(repository)
    {
        _repository = repository;
    }
    [HttpGet]
    [Authorize(StorePermissions.ProductImage.Default)]
    public async Task<DataSourceResult> DataSource([DataSourceRequest] DataSourceRequest request)
    {
        return (await _repository.GetQueryableAsync()).ToDataSourceResult(request, x => ObjectMapper.Map<ProductImage, ProductImageDto>(x));
    }

}
