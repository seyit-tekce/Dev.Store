using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace Dev.Store
{
    public class Brand : AuditedEntity<Guid>
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }

    }
}
