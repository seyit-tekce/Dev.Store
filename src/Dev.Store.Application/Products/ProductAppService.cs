using Dev.Store.Permissions;
using Dev.Store.Products.Dtos;
using Dev.Store.SeoSettings;
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
    private static object lockobject = null;
    private readonly SeoSettingAppService seoSettingAppService;
    private readonly IDistributedCache<IEnumerable<ProductGridListDto>, string> _cache;
    public ProductAppService(IRepository<Product, Guid> repository, IDistributedCache<IEnumerable<ProductGridListDto>, string> cache, IProductRepository repo, SeoSettingAppService seoSettingAppService) : base(repository)
    {
        _cache = cache;
        _repository = repo;
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
        return (await _repository.WithDetailsAsync(x => x.Brand, x => x.Category, x => x.ProductImages, x => x.ProductSizes)).ToDataSourceResult(request, x => ObjectMapper.Map<Product, ProductListDto>(x));
    }
    public override async Task<ProductDto> GetAsync(Guid id)
    {
        var q = await _repository.GetProductById(id);
        return ObjectMapper.Map<Product, ProductDto>(q);
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
        return await _cache.GetOrAddAsync(categoryId.ToString() + skip.ToString() + take.ToString(), async () => await GetProductByCategoryIdPagingFromDataBase(categoryId, skip, take)
        , () => new DistributedCacheEntryOptions
        {
            AbsoluteExpiration = DateTimeOffset.Now.AddHours(1)
        });
    }
    private async Task<IEnumerable<ProductGridListDto>> GetProductByCategoryIdPagingFromDataBase(Guid categoryId, int skip, int take)
    {
        var result = await _repository.GetProductsByCategoryId(categoryId, skip, take);
        await Task.CompletedTask;
        return ObjectMapper.Map<IEnumerable<Product>, IEnumerable<ProductGridListDto>>(result);
    }
    public async Task<int> GetProductCount(Guid categoryId)
    {
        return await _repository.GetCountByCategoryId(categoryId);
    }
    public async Task<ProductDto> GetProductDetail(Guid categoryId, string productLink)
    {
        return ObjectMapper.Map<Product, ProductDto>(await _repository.GetProductWithDetailsByCategoryAndCode(categoryId, productLink));
    }
    public async Task<IEnumerable<ProductGridListDto>> GetNewProducts()
    {
        return await _cache.GetOrAddAsync("newestproducts", async () =>
        {
            var result = await _repository.GetNewestProductList();
            await Task.CompletedTask;
            return ObjectMapper.Map<IEnumerable<Product>, IEnumerable<ProductGridListDto>>(result);
        }, () => new DistributedCacheEntryOptions
        {
            AbsoluteExpiration = DateTimeOffset.Now.AddHours(1)
        });
    }
    public async Task<IEnumerable<ProductGridListDto>> GetBestSellerProducts()
    {
        return await _cache.GetOrAddAsync("bestSellerProducts", async () =>
        {
            var result = await _repository.GetBestSellerProductList();
            await Task.CompletedTask;
            return ObjectMapper.Map<IEnumerable<Product>, IEnumerable<ProductGridListDto>>(result);
        }, () => new DistributedCacheEntryOptions
        {
            AbsoluteExpiration = DateTimeOffset.Now.AddHours(1)
        });
    }
}