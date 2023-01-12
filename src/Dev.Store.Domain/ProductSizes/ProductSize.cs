using Dev.Store.Products;
using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace Dev.Store.ProductSizes
{
    public class ProductSize : FullAuditedEntity<Guid>
    {
        public Guid ProductId { get; set; }
        public Product Product { get; set; }
        public double Height { get; set; }
        public double Width { get; set; }
        public double Price { get; set; }
        public bool IsDefault { get; set; }
    }
}
