using System.Collections.Generic;
using System.Linq;

namespace Dev.Store.CartProducts.Dtos;

public class CartDto
{
    public double? Total { get { return SubTotal; } }

    public double? SubTotal
    {
        get
        {
            return this.Products.Sum(x => x.CartSizes.Sum(a => a.Quantity * a.ProductSize.Price) + x.CartSets.Sum(a => a.Quantity * a.ProductSet.Price) + (x.Price * x.Amount));
        }
    }
    public IEnumerable<CartProductListDto> Products { get; set; }

}



