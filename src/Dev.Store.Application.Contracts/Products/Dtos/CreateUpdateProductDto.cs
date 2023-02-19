using Dev.Store.Brands.Dtos;
using Dev.Store.Categories.Dtos;
using System;

namespace Dev.Store.Products.Dtos;

[Serializable]
public class CreateUpdateProductDto
{
    public string Name { get; set; }

    public string Code { get; set; }

    public string Description { get; set; }

    public Guid CategoryId { get; set; }

    public Guid BrandId { get; set; }

    public bool IsEnabled { get; set; }
}