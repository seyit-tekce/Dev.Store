using System;
using Volo.Abp.Application.Dtos;

namespace Dev.Store.Categories.Dtos;

[Serializable]
public class CategoryDto : AuditedEntityDto<Guid>
{
    public string Name { get; set; }

    public string Link { get; set; }

    public string Description { get; set; }
    public int Order { get; set; }

    public Guid? CategoryParentId { get; set; }
    public bool IsVisible { get; set; }

    public System.Collections.Generic.List<CategoryDto> Categories { get; set; }
    public CategoryDto CategoryParent { get; set; }
}


public class CategoryListDto : AuditedEntityDto<Guid>
{
    public string Name { get; set; }

    public string Link { get; set; }

    public string Description { get; set; }

    public Guid? CategoryParentId { get; set; }
    public CategoryDto CategoryParent { get; set; }
    public bool IsVisible { get; set; }
    public int CategoryChildrenCount { get; set; }
}