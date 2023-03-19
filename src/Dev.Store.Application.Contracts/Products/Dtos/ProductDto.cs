using Dev.Store.Brands.Dtos;
using Dev.Store.Categories.Dtos;
using Dev.Store.ProductSets.Dtos;
using Dev.Store.ProductSizes.Dtos;
using Dev.Store.SeoSettings.Dtos;
using System;
using System.Collections.Generic;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Caching;

namespace Dev.Store.Products.Dtos;

[Serializable]
public class ProductDto : FullAuditedEntityDto<Guid>
{
    public string Name { get; set; }
    public string Code { get; set; }
    public string Description { get; set; }
    public Guid CategoryId { get; set; }
    public CategoryDto Category { get; set; }
    public Guid BrandId { get; set; }
    public BrandDto Brand { get; set; }
    public bool IsEnabled { get; set; }
    public ICollection<ProductSetDto> ProductSets { get; set; }
    public ICollection<ProductSizeDto> ProductSizes { get; set; }
    public SeoSettingDto SeoSetting { get; set; }
}

[CacheName("ProductList")]
public class ProductGridListDto
{
    public string Name { get; set; }
    public string Code { get; set; }
    public Guid CategoryId { get; set; }
    public string CategoryName { get; set; }
    public Guid? BrandId { get; set; }
    public string BrandName { get; set; }
    public string MainImagePath { get; set; }
    public double Price { get; set; }
}