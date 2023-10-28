using Dev.Store.Products.Dtos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;

namespace Dev.Store.Web.Pages.SeoSettings.SeoSetting.ViewModels;

public class CreateEditSeoSettingViewModel
{
    [Display(Name = "SeoSettingTitle")]
    [Required]
    public string Title { get; set; }

    [Display(Name = "SeoSettingDescription")]
    [DataType(DataType.MultilineText)]
    [TextArea]
    [Required]

    public string Description { get; set; }

    [Display(Name = "SeoSettingKeywords")]
    public string Keywords { get; set; }
    public List<string> _Keywords { get; set; }

    [Display(Name = "SeoSettingProductId")]
    public Guid ProductId { get; set; }
    public ProductDto Product { get; set; }
}
