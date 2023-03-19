using Dev.Store.Products;
using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace Dev.Store.SeoSettings
{
    public class SeoSetting : FullAuditedEntity<Guid>
    {
        public virtual string Title { get; set; }
        public virtual string Description { get; set; }
        public virtual string Keywords { get; set; }
        public virtual Guid ProductId { get; set; }
        public Product Product { get; set; }


        public SeoSetting()
        {
        }

        public SeoSetting(
            Guid id,
            string title,
            string description,
            string keywords,
            Guid productId,
            Product product
        ) : base(id)
        {
            Title = title;
            Description = description;
            Keywords = keywords;
            ProductId = productId;
            Product = product;
        }
    }
}
