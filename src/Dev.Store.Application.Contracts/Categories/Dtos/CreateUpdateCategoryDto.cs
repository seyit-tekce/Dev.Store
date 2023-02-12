using Microsoft.AspNetCore.Http;
using System;

namespace Dev.Store.Categories.Dtos;

[Serializable]
public class CreateUpdateCategoryDto
{
    public string Name { get; set; }

    public string Link { get; set; }

    public string Description { get; set; }
    public Guid? CategoryParentId { get; set; }
    public bool isVisible { get; set; }
    public int Order { get; set; }
    public IFormFileCollection Files { get; set; }
    public Guid FileId { get; set; }
}