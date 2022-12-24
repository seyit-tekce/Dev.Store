using System;
using System.Collections.Generic;
using Volo.Abp.Domain.Entities.Auditing;

namespace Dev.Store.Entities
{
    public class Category : FullAuditedAggregateRoot<Guid>
    {
        public string Name { get; set; }
        public string Link { get; set; }
        public string Description { get; set; }
        public Guid? Pid { get; set; }
        public virtual List<Category> Categories { get; set; }
    }
}