using Dev.Store.CartSets.Dtos;
using Dev.Store.CartSizes.Dtos;
using System;
using System.Collections.Generic;

namespace Dev.Store.CartProducts.Dtos;

public class CartProductListDto
{
    public Guid ProductId { get; set; }
    public Guid SessionId { get; set; }
    public double Amount { get; set; }
    public string Name { get; set; }
    public string Code { get; set; }
    public string MainImagePath { get; set; }
    public double Price { get; set; }
    public double TotalPrice { get; set; }
    public IEnumerable<CartSizeDto> CartSizes { get; set; }
    public IEnumerable<CartSetDto> CartSets { get; set; }
}



