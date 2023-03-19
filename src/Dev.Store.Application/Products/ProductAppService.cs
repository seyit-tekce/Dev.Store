using Dev.Store.Permissions;
using Dev.Store.ProductImages;
using Dev.Store.Products.Dtos;
using Dev.Store.ProductSizes;
using Dev.Store.SeoSettings;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Services;
using Volo.Abp.Caching;
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
    private readonly IProductImageRepository _productImageRepository;
    private readonly IProductSizeRepository _productSizeRepository;
    private readonly IDistributedCache<IEnumerable<ProductGridListDto>, Guid> _cache;

    public ProductAppService(IRepository<Product, Guid> repository, SeoSettingAppService seoSettingAppService, IProductImageRepository productImageRepository, IProductSizeRepository productSizeRepository, IDistributedCache<IEnumerable<ProductGridListDto>, Guid> cache, IProductRepository repo) : base(repository)
    {
        this.seoSettingAppService = seoSettingAppService;
        _productImageRepository = productImageRepository;
        _productSizeRepository = productSizeRepository;
        _cache = cache;
        _repository = repo;
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
        return (await _repository.WithDetailsAsync(x => x.Brand, x => x.Category, x => x.ProductImages, x => x.ProductSizes)).ToDataSourceResult(request, x => ObjectMapper.Map<Product, ProductListDto>(x));
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

    public async Task<IEnumerable<ProductGridListDto>> GetProductByCategoryIdPaging(Guid categoryId, int skip, int take)
    {
        return await _cache.GetOrAddAsync(categoryId, async () =>
        {
            var result = await _repository.GetProductsByCategoryId(categoryId, skip, take);
            return result.Select(product =>
            {
                var imagePath = product.ProductImages.FirstOrDefault(x => x.IsMain || true)?.UploadFile.FilePath;
                var productPrice = product.Price;
                return new ProductGridListDto
                {
                    BrandId = product.BrandId,
                    CategoryId = product.CategoryId,
                    BrandName = product?.Brand?.Name,
                    CategoryName = product.Category.Name,
                    Code = product.Code,
                    MainImagePath = imagePath,
                    Name = product.Name,
                    Price = productPrice
                };
            });
        }, () => new DistributedCacheEntryOptions
        {
            AbsoluteExpiration = DateTimeOffset.Now.AddHours(1)
        });
    }

    public async Task<int> GetProductCount(Guid categoryId)
    {
        return await _repository.GetCountByCategoryId(categoryId);
    }
}