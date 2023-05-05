using Dev.Store.Products;
using System;
using System.Drawing;
using Volo.Abp.Domain.Entities.Auditing;

namespace Dev.Store.CartProducts
{
    public class CartProduct : FullAuditedEntity<Guid>
    {
        public virtual Guid ProductId { get; set; }
        public virtual Guid SizeId { get; set; }
        public virtual double Price { get; set; }
        public virtual double Amount { get; set; }

        public Product Product { get; set; }
        public Size Size { get; set; }
    }
}
