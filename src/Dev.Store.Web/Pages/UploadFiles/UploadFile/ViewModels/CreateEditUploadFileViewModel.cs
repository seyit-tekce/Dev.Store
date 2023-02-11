using System;
using System.ComponentModel.DataAnnotations;

namespace Dev.Store.Web.Pages.UploadFiles.UploadFile.ViewModels;

public class CreateEditUploadFileViewModel
{
    [Display(Name = "UploadFileFileName")]
    public string FileName { get; set; }

    [Display(Name = "UploadFileFilePath")]
    public string FilePath { get; set; }

    [Display(Name = "UploadFilePublicId")]
    public string PublicId { get; set; }

    [Display(Name = "UploadFileDescription")]
    public string Description { get; set; }
}
