using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;

namespace Dev.Store.Web.Pages.ProductSizes.ViewModels;

public class CreateEditProductSizeViewModel
{
    [Required]
    [HiddenInput]
    [Display(Name = "ProductSizeProductId")]
    public Guid ProductId { get; set; }


    [Required]
    [Display(Name = "ProductSizeCode")]
    public string Code{ get; set; }
    
    [Required]
    [Display(Name = "ProductSizeHeight")]
    public double Height { get; set; }

    [Required]

    [Display(Name = "ProductSizeWidth")]
    public double Width { get; set; }

    [Display(Name = "ProductSizeDepth")]
    public double? Depth { get; set; }

    [Required]
    [Display(Name = "ProductSizePrice")]
    public double Price { get; set; }
    [Required]
    [Display(Name = "ProductSizeIsDefault")]
    public bool IsDefault { get; set; }
}
