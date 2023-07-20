using System;

namespace Dev.Store.CartSets.Dtos;

[Serializable]
public class CreateUpdateCartSetDto
{
    public Guid SetId { get; set; }
    public int Quantity { get; set; }
}