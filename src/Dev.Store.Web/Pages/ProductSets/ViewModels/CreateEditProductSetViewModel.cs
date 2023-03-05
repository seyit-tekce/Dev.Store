using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;

namespace Dev.Store.Web.Pages.ProductSets.ViewModels;

public class CreateEditProductSetViewModel
{
    [Display(Name = "ProductSetProductId")]
    [HiddenInput]
    [Required]
    public Guid ProductId { get; set; }

    [Display(Name = "ProductSetCode")]
    [Required]
    public string Code { get; set; }

    [Display(Name = "ProductSetSetName")]
    [Required]
    public string SetName { get; set; }

    [Display(Name = "ProductSetPrice")]
    [DataType(DataType.Currency)]
    [Required]
    public double Price { get; set; }

    [Required]
    [Display(Name = "ProductSetAmount")]
    public int Amount { get; set; } = 0;

    [Display(Name = "ProductSetIsOptional")]
    public bool IsOptional { get; set; } = true;
}