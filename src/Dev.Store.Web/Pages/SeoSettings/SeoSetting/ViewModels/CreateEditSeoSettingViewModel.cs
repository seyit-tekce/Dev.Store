using Dev.Store.Products.Dtos;
using System;
using System.ComponentModel.DataAnnotations;

namespace Dev.Store.Web.Pages.SeoSettings.SeoSetting.ViewModels;

public class CreateEditSeoSettingViewModel
{
    [Display(Name = "SeoSettingTitle")]
    public string Title { get; set; }

    [Display(Name = "SeoSettingDescription")]
    public string Description { get; set; }

    [Display(Name = "SeoSettingKeywords")]
    public string Keywords { get; set; }

    [Display(Name = "SeoSettingProductId")]
    public Guid ProductId { get; set; }


    public ProductDto Product { get; set; }
}
