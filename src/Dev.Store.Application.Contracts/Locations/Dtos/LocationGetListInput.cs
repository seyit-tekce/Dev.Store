using System;
using Volo.Abp.Application.Dtos;

namespace Dev.Store.Locations.Dtos;

[Serializable]
public class LocationGetListInput : PagedAndSortedResultRequestDto
{
    public string Name { get; set; }

    public string Code { get; set; }

    public Guid? Pid { get; set; }

    public Guid? LocationParentId { get; set; }

    public LocationDto? LocationParent { get; set; }

}