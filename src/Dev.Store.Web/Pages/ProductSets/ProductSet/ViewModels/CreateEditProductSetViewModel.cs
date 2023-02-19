using System;
using System.ComponentModel.DataAnnotations;

namespace Dev.Store.Web.Pages.ProductSets.ProductSet.ViewModels;

public class CreateEditProductSetViewModel
{
    [Display(Name = "ProductSetProductId")]
    public int ProductId { get; set; }

    [Display(Name = "ProductSetPrice")]
    public double Price { get; set; }

    [Display(Name = "ProductSetAmount")]
    public int Amount { get; set; }

    [Display(Name = "ProductSetIsOptional")]
    public bool IsOptional { get; set; }
}
