using System;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;
using Dev.Store.HomeSliders;

namespace Dev.Store.Web.Pages.HomeSliders.HomeSlider;

public class IndexModel : StorePageModel
{

    
    public virtual async Task OnGetAsync()
    {
        await Task.CompletedTask;
    }
}
