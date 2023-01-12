using Dev.Store.Brands;
using Dev.Store.Categories;
using Dev.Store.ProductSets;
using Dev.Store.ProductSizes;
using Dev.Store.SeoSettings;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace Dev.Store.Products
{
    public class Product : FullAuditedEntity<Guid>
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public double UnitPrice { get; set; }
        public Guid CategoryId { get; set; }
        public Category Category { get; set; }
        public Guid BrandId { get; set; }
        public Brand Brand { get; set; }
        public bool IsEnabled { get; set; }

        public ICollection<ProductSet> ProductSets { get; set; }
        public ICollection<ProductSize> ProductSizes { get; set; }
        public virtual SeoSetting SeoSetting { get; set; }
            

    }
}
