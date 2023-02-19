using Dev.Store.Products;
using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace Dev.Store.ProductSets
{
    public class ProductSet : FullAuditedEntity<Guid>
    {
        public string Code { get; set; }
        public Guid ProductId { get; set; }
        public Product Product { get; set; }
        public double Price { get; set; }
        public int Amount { get; set; }
        public bool IsOptional { get; set; }

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
