using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace Dev.Store.Brands
{
    public class Brand : FullAuditedEntity<Guid>
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }

    }
}
