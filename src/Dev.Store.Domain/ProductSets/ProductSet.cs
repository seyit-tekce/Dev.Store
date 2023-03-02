using Dev.Store.Products;
using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace Dev.Store.ProductSets
{
    public class ProductSet : FullAuditedEntity<Guid>
    {
        public virtual string Code { get; set; }
        public virtual string SetName { get; set; }
        public virtual Guid ProductId { get; set; }
        public virtual double Price { get; set; }
        public virtual int Amount { get; set; }
        public virtual bool IsOptional { get; set; }
        public Product Product { get; set; }
        protected ProductSet()
        {
        }

        public ProductSet(
            Guid id,
            Guid productId,
            Product product,
            double price,
            int amount,
            bool isOptional
        ) : base(id)
        {
            ProductId = productId;
            Product = product;
            Price = price;
            Amount = amount;
            IsOptional = isOptional;
        }
    }
}
