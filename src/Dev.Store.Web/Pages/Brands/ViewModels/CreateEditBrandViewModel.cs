using System.ComponentModel.DataAnnotations;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;

namespace Dev.Store.Web.Pages.Dev.Store.Brand.ViewModels;

public class CreateEditBrandViewModel
{
    [Display(Name = "BrandName")]
    [MaxLength(128)]
    [Placeholder("BrandNameHolder")]
    [Required]
    public string Name { get; set; }

    [Display(Name = "BrandCode")]
    [Placeholder("BrandCodeHolder")]
    [Required]
    [MaxLength(12)]
    public string Code { get; set; }

    [Display(Name = "BrandDescription")]
    [Placeholder("BrandDescriptionHolder")]
    [DataType(DataType.MultilineText)]
    [TextArea]
    public string Description { get; set; }
}
