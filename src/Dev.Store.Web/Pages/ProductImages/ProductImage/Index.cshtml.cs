using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;

namespace Dev.Store.Web.Pages.ProductImages.ProductImage;

public class IndexModel : StorePageModel
{
    public ProductImageFilterInput ProductImageFilter { get; set; }

    public virtual async Task OnGetAsync()
    {
        await Task.CompletedTask;
    }
}

public class ProductImageFilterInput
{
    [FormControlSize(AbpFormControlSize.Small)]
    [Display(Name = "ProductImageProductId")]
    public Guid? ProductId { get; set; }

    [FormControlSize(AbpFormControlSize.Small)]
    [Display(Name = "ProductImageUploadFileId")]
    public Guid? UploadFileId { get; set; }

    [FormControlSize(AbpFormControlSize.Small)]
    [Display(Name = "ProductImageIsMain")]
    public bool? IsMain { get; set; }

}
