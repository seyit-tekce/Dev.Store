using System;
using System.ComponentModel.DataAnnotations;

namespace Dev.Store.Web.Pages.ProductSizes.ProductSize.ViewModels;

public class CreateEditProductSizeViewModel
{
    [Display(Name = "ProductSizeProductId")]
    public Guid ProductId { get; set; }

   

    [Display(Name = "ProductSizeHeight")]
    public double Height { get; set; }

    [Display(Name = "ProductSizeWidth")]
    public double Width { get; set; }

    [Display(Name = "ProductSizePrice")]
    public double Price { get; set; }

    [Display(Name = "ProductSizeIsDefault")]
    public bool IsDefault { get; set; }
}
