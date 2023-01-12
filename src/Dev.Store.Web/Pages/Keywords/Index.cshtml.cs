using System;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;

namespace Dev.Store.Web.Pages.Keywords.Keyword;

public class IndexModel : StorePageModel
{
    public KeywordFilterInput KeywordFilter { get; set; }
    
    public virtual async Task OnGetAsync()
    {
        await Task.CompletedTask;
    }
}

public class KeywordFilterInput
{
    [FormControlSize(AbpFormControlSize.Small)]
    [Display(Name = "KeywordName")]
    public string Name { get; set; }
}
