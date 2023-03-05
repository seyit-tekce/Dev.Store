using System;

namespace Dev.Store.ProductSets.Dtos;

[Serializable]
public class CreateUpdateProductSetDto
{
    public string Code { get; set; }
    public string SetName { get; set; }
    public Guid ProductId { get; set; }
    public double Price { get; set; }
    public int Amount { get; set; }
    public bool IsOptional { get; set; }
}