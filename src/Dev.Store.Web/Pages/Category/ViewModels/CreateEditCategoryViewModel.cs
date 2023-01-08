using Dev.Store.Entities.Dtos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;

namespace Dev.Store.Web.Pages.Entities.Category.ViewModels;

public class CreateEditCategoryViewModel
{
    [Display(Name = "CategoryName")]
    [MaxLength(50)]
    [Placeholder("CategoryNameHolder")]
    [Required]
    public string Name { get; set; }

    [Display(Name = "CategoryLink")]
    [Placeholder("CategoryCodeHolder")]
    [Required]
    public string Link { get; set; }

    [Placeholder("BrandDescriptionHolder")]
    [DataType(DataType.MultilineText)]
    [TextArea]
    [Required]
    [Display(Name = "CategoryDescription")]
    public string Description { get; set; }
    [Required]
    [Display(Name = "CategoryIsVisible")]

    public bool IsVisible { get; set; }

    [Display(Name = "CategoryPid")]
    [HiddenInput]
    public Guid? CategoryParentId { get; set; }

}
