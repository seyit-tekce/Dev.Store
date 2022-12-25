using System;
using System.Collections.Generic;

namespace Dev.Store.Entities.Dtos;

[Serializable]
public class CreateUpdateCategoryDto
{
    public string Name { get; set; }

    public string Link { get; set; }

    public string Description { get; set; }

    public Guid? Pid { get; set; }

    public List<CategoryDto> Categories { get; set; }
}