using System;
using Volo.Abp.Caching;

namespace Dev.Store.Products.Dtos;

[CacheName("ProductList")]
public class ProductGridListDto
{
    public string Name { get; set; }
    public string Code { get; set; }
    public Guid CategoryId { get; set; }
    public string CategoryName { get; set; }
    public string CategoryLink { get; set; }
    public string ParentCategoryLink { get; set; }
    public Guid? BrandId { get; set; }
    public string BrandName { get; set; }
    public string MainImagePath { get; set; } = "";
    public string SecondImagePath { get; set; } = "";
    public double Price { get; set; }
}