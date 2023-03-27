using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;

namespace Dev.Store.Web.Pages.SeoSettings.SeoSetting;

public class IndexModel : StorePageModel
{
    public SeoSettingFilterInput SeoSettingFilter { get; set; }

    public virtual async Task OnGetAsync()
    {
        await Task.CompletedTask;
    }
}

public class SeoSettingFilterInput
{
    [FormControlSize(AbpFormControlSize.Small)]
    [Display(Name = "SeoSettingTitle")]
    public string Title { get; set; }

    [FormControlSize(AbpFormControlSize.Small)]
    [Display(Name = "SeoSettingDescription")]
    public string Description { get; set; }

    [FormControlSize(AbpFormControlSize.Small)]
    [Display(Name = "SeoSettingKeywords")]
    public string Keywords { get; set; }

    [FormControlSize(AbpFormControlSize.Small)]
    [Display(Name = "SeoSettingProductId")]
    public Guid? ProductId { get; set; }


}
