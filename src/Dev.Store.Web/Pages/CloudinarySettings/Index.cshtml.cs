using System;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;

namespace Dev.Store.Web.Pages.CloudinarySettings;

public class IndexModel : StorePageModel
{
    
    public virtual async Task OnGetAsync()
    {
        await Task.CompletedTask;
    }
}

