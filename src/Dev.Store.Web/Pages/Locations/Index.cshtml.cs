using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;

namespace Dev.Store.Web.Pages.Location.Location;

public class IndexModel : StorePageModel
{
    public LocationFilterInput LocationFilter { get; set; }

    public virtual async Task OnGetAsync()
    {
        await Task.CompletedTask;
    }
}

public class LocationFilterInput
{
    [FormControlSize(AbpFormControlSize.Small)]
    [Display(Name = "LocationName")]
    public string Name { get; set; }

    [FormControlSize(AbpFormControlSize.Small)]
    [Display(Name = "LocationCode")]
    public string Code { get; set; }


    [FormControlSize(AbpFormControlSize.Small)]
    [Display(Name = "LocationLocationParentId")]
    public Guid? LocationParentId { get; set; }


}
