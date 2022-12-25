using System;
using System.Collections.Generic;
using Volo.Abp.Domain.Entities.Auditing;

namespace Dev.Store
{
    public class Location : AuditedEntity<Guid>
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public Guid? Pid { get; set; }
        public virtual List<Location> Locations { get; set; }
    }
}