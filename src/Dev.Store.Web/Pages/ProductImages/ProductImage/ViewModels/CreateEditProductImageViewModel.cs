using System;
using System.ComponentModel.DataAnnotations;

namespace Dev.Store.Web.Pages.ProductImages.ProductImage.ViewModels;

public class CreateEditProductImageViewModel
{
    [Display(Name = "ProductImageProductId")]
    public Guid ProductId { get; set; }

    [Display(Name = "ProductImageUploadFileId")]
    public Guid UploadFileId { get; set; }

    [Display(Name = "ProductImageIsMain")]
    public bool IsMain { get; set; }


}
