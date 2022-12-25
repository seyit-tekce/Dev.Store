using System;
using Volo.Abp.Application.Dtos;

namespace Dev.Store.Entities.Dtos;

[Serializable]
public class CategoryDto : AuditedEntityDto<Guid>
{
    public string Name { get; set; }

    public string Link { get; set; }

    public string Description { get; set; }

    public Guid? Pid { get; set; }

    public System.Collections.Generic.List<CategoryDto> Categories { get; set; }
}