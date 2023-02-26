using System;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;

namespace Dev.Store.Web.Pages.ProductSizes;

public class IndexModel : StorePageModel
{
    public ProductSizeFilterInput ProductSizeFilter { get; set; }

    public virtual async Task OnGetAsync()
    {
        await Task.CompletedTask;
    }
}

public class ProductSizeFilterInput
{
    [FormControlSize(AbpFormControlSize.Small)]
    [Display(Name = "ProductSizeProductId")]
    public Guid? ProductId { get; set; }



    [FormControlSize(AbpFormControlSize.Small)]
    [Display(Name = "ProductSizeHeight")]
    public double? Height { get; set; }

    [FormControlSize(AbpFormControlSize.Small)]
    [Display(Name = "ProductSizeWidth")]
    public double? Width { get; set; }

    [FormControlSize(AbpFormControlSize.Small)]
    [Display(Name = "ProductSizePrice")]
    public double? Price { get; set; }

    [FormControlSize(AbpFormControlSize.Small)]
    [Display(Name = "ProductSizeIsDefault")]
    public bool? IsDefault { get; set; }
}
