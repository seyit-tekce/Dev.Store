using Dev.Store.Brands;
using Dev.Store.Categories;
using Dev.Store.ProductSets;
using Dev.Store.ProductSizes;
using Dev.Store.SeoSettings;
using System;
using System.Collections.Generic;
using Volo.Abp.Domain.Entities.Auditing;

namespace Dev.Store.Products
{
    public class Product : FullAuditedEntity<Guid>
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public Guid CategoryId { get; set; }
        public Category Category { get; set; }
        public Guid BrandId { get; set; }
        public Brand Brand { get; set; }
        public bool IsEnabled { get; set; }


        public ICollection<ProductSet> ProductSets { get; set; }
        public ICollection<ProductSize> ProductSizes { get; set; }
        public virtual SeoSetting SeoSetting { get; set; }



    protected Product()
    {
    }

    public Product(
        Guid id,
        string name,
        string code,
        string description,
        Guid categoryId,
        Category category,
        Guid brandId,
        Brand brand,
        bool isEnabled,
        ICollection<ProductSet> productSets,
        ICollection<ProductSize> productSizes,
        SeoSetting seoSetting
    ) : base(id)
    {
        Name = name;
        Code = code;
        Description = description;
        CategoryId = categoryId;
        Category = category;
        BrandId = brandId;
        Brand = brand;
        IsEnabled = isEnabled;
        ProductSets = productSets;
        ProductSizes = productSizes;
        SeoSetting = seoSetting;
    }
    }
}
