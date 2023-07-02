using System;

namespace Dev.Store.CartProducts.Dtos;

[Serializable]
public class CreateUpdateCartProductDto
{
    /// <summary>
    /// 
    /// </summary>
    public Guid ProductId { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public double Amount { get; set; }

    ///// <summary>
    ///// 
    ///// </summary>
    //public Product Product { get; set; }

    ///// <summary>
    ///// 
    ///// </summary>
    //public IEnumerable<CartSize> CartSizes { get; set; }

    ///// <summary>
    ///// 
    ///// </summary>
    //public IEnumerable<CartSet> CartSets { get; set; }
}