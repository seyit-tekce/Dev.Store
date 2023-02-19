using System;
using System.Linq;
using System.Threading.Tasks;
using Dev.Store.Locations.Dtos;
using Dev.Store.Permissions;
using Dev.Store.Products.Dtos;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.Application.Services;

namespace Dev.Store.Products;


public class ProductAppService : CrudAppService<Product, ProductDto, Guid, ProductListDto, CreateUpdateProductDto, CreateUpdateProductDto>,
    IProductAppService
{
    protected override string GetPolicyName { get; set; } = StorePermissions.Product.Default;
    protected override string GetListPolicyName { get; set; } = StorePermissions.Product.Default;
    protected override string CreatePolicyName { get; set; } = StorePermissions.Product.Create;
    protected override string UpdatePolicyName { get; set; } = StorePermissions.Product.Update;
    protected override string DeletePolicyName { get; set; } = StorePermissions.Product.Delete;

    private readonly IProductRepository _repository;

    public ProductAppService(IProductRepository repository) : base(repository)
    {
        _repository = repository;
    }


    [HttpGet]
    [Authorize(StorePermissions.Product.Default)]
    public async Task<DataSourceResult> DataSource([DataSourceRequest] DataSourceRequest request)
    {
        return (await _repository.WithDetailsAsync(x=>x.Brand,x=>x.Category)).ToDataSourceResult(request,x=> ObjectMapper.Map<Product, ProductListDto>(x));
    }
}
