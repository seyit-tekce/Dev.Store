using System;
using System.Collections.Generic;
using Volo.Abp.Application.Dtos;

namespace Dev.Store.Locations.Dtos;

[Serializable]
public class LocationDto : AuditedEntityDto<Guid>
{
    public string Name { get; set; }

    public string Code { get; set; }

    public Guid? Pid { get; set; }

    public Guid? LocationParentId { get; set; }

    public LocationDto LocationParent { get; set; }

    public List<LocationDto> LocationChildren { get; set; }
}