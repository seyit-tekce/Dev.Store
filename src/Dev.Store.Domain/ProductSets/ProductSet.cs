using Dev.Store.Products;
using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace Dev.Store.ProductSets
{
    public class ProductSet : FullAuditedEntity<Guid>
    {
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public double Price { get; set; }
        public int Amount { get; set; }
        public bool IsOptional { get; set; }
    }
}
