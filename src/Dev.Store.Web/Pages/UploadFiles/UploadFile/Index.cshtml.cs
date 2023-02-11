using System;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;

namespace Dev.Store.Web.Pages.UploadFiles.UploadFile;

public class IndexModel : StorePageModel
{
    public UploadFileFilterInput UploadFileFilter { get; set; }
    
    public virtual async Task OnGetAsync()
    {
        await Task.CompletedTask;
    }
}

public class UploadFileFilterInput
{
    [FormControlSize(AbpFormControlSize.Small)]
    [Display(Name = "UploadFileFileName")]
    public string FileName { get; set; }

    [FormControlSize(AbpFormControlSize.Small)]
    [Display(Name = "UploadFileFilePath")]
    public string FilePath { get; set; }

    [FormControlSize(AbpFormControlSize.Small)]
    [Display(Name = "UploadFilePublicId")]
    public string PublicId { get; set; }

    [FormControlSize(AbpFormControlSize.Small)]
    [Display(Name = "UploadFileDescription")]
    public string Description { get; set; }
}
