using Dev.Store.CartSets;
using Dev.Store.CartSizes;
using Dev.Store.Products;
using System;
using System.Collections.Generic;
using Volo.Abp.Domain.Entities.Auditing;

namespace Dev.Store.CartProducts
{
    public class CartProduct : FullAuditedEntity<Guid>
    {
        public virtual Guid ProductId { get; set; }
        public virtual double Amount { get; set; }
        public Product Product { get; set; }
        public Guid SessionId { get; set; }

        public IEnumerable<CartSize> CartSizes { get; set; }
        public IEnumerable<CartSet> CartSets { get; set; }

        protected CartProduct()
        {
        }

        public CartProduct(
            Guid id,
            Guid productId,
            double amount,
            Product product,
            IEnumerable<CartSize> cartSizes,
            IEnumerable<CartSet> cartSets
,
            Guid sessionId) : base(id)
        {
            ProductId = productId;
            Amount = amount;
            Product = product;
            CartSizes = cartSizes;
            CartSets = cartSets;
            SessionId = sessionId;
        }
    }
}
