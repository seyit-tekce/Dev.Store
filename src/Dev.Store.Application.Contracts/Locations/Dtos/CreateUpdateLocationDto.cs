using System;

namespace Dev.Store.Locations.Dtos;

[Serializable]
public class CreateUpdateLocationDto
{
    public string Name { get; set; }
    public string Code { get; set; }
    public Guid? LocationParentId { get; set; }
}