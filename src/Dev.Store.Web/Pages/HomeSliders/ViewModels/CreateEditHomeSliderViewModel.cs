using Dev.Store.HomeSliders;
using System;
using System.ComponentModel.DataAnnotations;

namespace Dev.Store.Web.Pages.HomeSliders.ViewModels;

public class CreateEditHomeSliderViewModel
{
    [Display(Name = "HomeSliderUploadFileId")]
    public Guid UploadFileId { get; set; }

    [Display(Name = "HomeSliderTitle")]
    public string Title { get; set; }

    [Display(Name = "HomeSliderSubtitle")]
    public string Subtitle { get; set; }

    [Display(Name = "HomeSliderButtonLink")]
    public string ButtonLink { get; set; }

    [Display(Name = "HomeSliderButtonText")]
    public string ButtonText { get; set; }

    [Display(Name = "HomeSliderOrder")]
    public int Order { get; set; }

    [Display(Name = "HomeSliderType")]
    public HomeSliderType Type { get; set; }

}
