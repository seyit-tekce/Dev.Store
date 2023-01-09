using System;
using System.Collections.Generic;
using Volo.Abp.Domain.Entities.Auditing;

namespace Dev.Store.Location
{
    public class Location : AuditedEntity<Guid>
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public Guid? Pid { get; set; }
        public virtual Guid? LocationParentId { get; set; }
        public Location LocationParent { get; set; }
        public List<Location> LocationChildren { get; set; }
    }
}