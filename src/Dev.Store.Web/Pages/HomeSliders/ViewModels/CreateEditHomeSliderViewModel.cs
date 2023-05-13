using Dev.Store.HomeSliders;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;

namespace Dev.Store.Web.Pages.HomeSliders.ViewModels;

public class CreateEditHomeSliderViewModel
{
    [Display(Name = "Image")]
    public IFormFile File { get; set; }

    [Display(Name = "HomeSliderTitle")]
    [Required]
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
    [HiddenInput]
    [Required]
    public HomeSliderType Type { get; set; }
    [Display(Name = "HomeSliderType")]
    [HiddenInput]
    public Guid UploadFileId { get; set; }

}
