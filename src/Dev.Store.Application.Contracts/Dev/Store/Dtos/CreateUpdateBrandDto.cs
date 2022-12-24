using System;

namespace Dev.Store.Dtos;

[Serializable]
public class CreateUpdateBrandDto
{
    public string Name { get; set; }

    public string Code { get; set; }

    public string Description { get; set; }
}