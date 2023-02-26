using System;
using System.ComponentModel.DataAnnotations;

namespace Dev.Store.Web.Pages.Products.Product.ViewModels;

public class CreateEditProductViewModel
{
    [Display(Name = "ProductName")]
    [Required]
    public string Name { get; set; }


    [Display(Name = "ProductCode")]
    [Required]
    public string Code { get; set; }

    [Display(Name = "ProductDescription")]
    [Required]
    public string Description { get; set; }

    [Required]
    [Display(Name = "ProductCategoryId")]
    public Guid CategoryId { get; set; }

    [Display(Name = "ProductBrandId")]
    public Guid? BrandId { get; set; }

    [Display(Name = "ProductIsEnabled")]
    public bool IsEnabled { get; set; } = true;

}
