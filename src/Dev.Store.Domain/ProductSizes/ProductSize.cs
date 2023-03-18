using Dev.Store.Products;
using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace Dev.Store.ProductSizes
{
    public class ProductSize : FullAuditedEntity<Guid>
    {
        public virtual string Code { get; set; }
        public virtual Guid ProductId { get; set; }
        public virtual double Height { get; set; }
        public virtual double Width { get; set; }
        public virtual double? Depth { get; set; }
        public virtual double Price { get; set; }
        public virtual bool IsDefault { get; set; }

        public  Product Product { get; set; }

    }
}
