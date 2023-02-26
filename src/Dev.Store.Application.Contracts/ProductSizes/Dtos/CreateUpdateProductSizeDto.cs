using System;

namespace Dev.Store.ProductSizes.Dtos;

[Serializable]
public class CreateUpdateProductSizeDto
{
    public Guid ProductId { get; set; }
    public string Code { get; set; }
    public double Height { get; set; }

    public double Width { get; set; }
    public double? Depth { get; set; }
    public double Price { get; set; }
    public bool IsDefault { get; set; }
}