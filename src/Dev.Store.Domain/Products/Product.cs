using Dev.Store.Brands;
using Dev.Store.Categories;
using Dev.Store.ProductImages;
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
        public virtual string Name { get; set; }
        public virtual string Code { get; set; }
        public virtual string Description { get; set; }
        public virtual Guid CategoryId { get; set; }
        public virtual Guid? BrandId { get; set; }
        public virtual bool IsEnabled { get; set; }
        public virtual double Price { get; set; }

        public Category Category { get; set; }
        public Brand Brand { get; set; }

        public List<ProductSet> ProductSets { get; set; }
        public List<ProductSize> ProductSizes { get; set; }
        public List<ProductImage> ProductImages { get; set; }
        public SeoSetting SeoSetting { get; set; }



        protected Product()
        {
        }

        public Product(Guid id, string name, string code, string description, double price, Guid categoryId, Category category, Guid? brandId, Brand brand, bool ýsEnabled, List<ProductSet> productSets, List<ProductSize> productSizes, List<ProductImage> productImages, SeoSetting seoSetting)
        {
            Id = id;
            Name = name;
            Code = code;
            Description = description;
            Price = price;
            CategoryId = categoryId;
            Category = category;
            BrandId = brandId;
            Brand = brand;
            IsEnabled = ýsEnabled;
            ProductSets = productSets;
            ProductSizes = productSizes;
            ProductImages = productImages;
            SeoSetting = seoSetting;
        }
    }
}
