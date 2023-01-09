using System;
using System.Collections.Generic;
using Volo.Abp.Domain.Entities.Auditing;

namespace Dev.Store.Locations
{
    public class Location : AuditedEntity<Guid>
    {
        public string Name { get; set; }
        public int Code { get; set; }
        public virtual Guid? LocationParentId { get; set; }
        public Location LocationParent { get; set; }
        public List<Location> LocationChildren { get; set; }

        protected Location()
        {
        }

        public Location(
            Guid id,
            string name,
            int code,
            Guid? locationParentId,
            Location locationParent,
            List<Location> locationChildren
        ) : base(id)
        {
            Name = name;
            Code = code;
            LocationParentId = locationParentId;
            LocationParent = locationParent;
            LocationChildren = locationChildren;
        }
    }
}
