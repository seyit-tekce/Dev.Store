using System;
using System.ComponentModel.DataAnnotations;

namespace Dev.Store.Web.Pages.Products.Product.ViewModels;

public class CreateEditProductViewModel
{
    [Display(Name = "ProductName")]
    public string Name { get; set; }

    [Display(Name = "ProductCode")]
    public string Code { get; set; }

    [Display(Name = "ProductDescription")]
    public string Description { get; set; }

    [Display(Name = "ProductCategoryId")]
    public Guid CategoryId { get; set; }


    [Display(Name = "ProductBrandId")]
    public Guid BrandId { get; set; }

    [Display(Name = "ProductBrand")]

    public bool IsEnabled { get; set; }

}
