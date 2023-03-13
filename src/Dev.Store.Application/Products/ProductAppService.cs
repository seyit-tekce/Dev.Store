using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dev.Store.Locations.Dtos;
using Dev.Store.Permissions;
using Dev.Store.Products.Dtos;
using Dev.Store.SeoSettings;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

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
    private readonly SeoSettingAppService seoSettingAppService;

    public ProductAppService(IProductRepository repository, SeoSettingAppService seoSettingAppService) : base(repository)
    {
        _repository = repository;
        this.seoSettingAppService = seoSettingAppService;
    }


    [HttpGet]
    [Authorize(StorePermissions.Product.Default)]
    public async Task<DataSourceResult> DataSource([DataSourceRequest] DataSourceRequest request)
    {
        return (await _repository.WithDetailsAsync(x => x.Brand, x => x.Category)).ToDataSourceResult(request, x => ObjectMapper.Map<Product, ProductListDto>(x));
    }


    [HttpGet]
    [AllowAnonymous]
    public async Task<DataSourceResult> DataSourceGrid([DataSourceRequest] DataSourceRequest request)
    {
        return (await _repository.WithDetailsAsync(x => x.Brand, x => x.Category, x => x.ProductImages,x=>x.ProductSizes)).ToDataSourceResult(request, x => ObjectMapper.Map<Product, ProductListDto>(x));
    }



    public override async Task<ProductDto> GetAsync(Guid id)
    {
        var q = await _repository.WithDetailsAsync(x => x.Category, x => x.Brand);
        return ObjectMapper.Map<Product, ProductDto>(q.FirstOrDefault(a => a.Id == id));
    }


    public override async Task<ProductDto> CreateAsync(CreateUpdateProductDto input)
    {
        var getByCode = await _repository.AnyAsync(x => x.Code == input.Code);
        if (getByCode)
        {
            throw new UserFriendlyException(L["SameCodeExist"]);
        }
        var create = await base.CreateAsync(input);

        await seoSettingAppService.CreateAsync(new SeoSettings.Dtos.CreateUpdateSeoSettingDto
        {
            Description = "",
            Keywords = "Products",
            ProductId = create.Id,
            Title = create.Name

        });
        return create;
    }

    public async Task<IEnumerable<ProductDto>> GetFirst25ByCategoryId(Guid categoryId)
    {
        return (await _repository.WithDetailsAsync(x => x.Brand, x => x.Category,x=>x.ProductImages.Where(x=>x.IsMain))).OrderByDescending(x => x.CreationTime).Skip(0).Take(25).Select(a=>ObjectMapper.Map<Product,ProductDto>(a));
    }
}
