using Dev.Store.Products;
using System;
using System.Collections.Generic;
using Volo.Abp.Domain.Entities.Auditing;

namespace Dev.Store.Brands
{
    public class Brand : FullAuditedEntity<Guid>
    {
        public virtual string Name { get; set; }
        public virtual string Code { get; set; }
        public virtual string Description { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
