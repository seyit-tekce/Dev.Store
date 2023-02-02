using System.ComponentModel.DataAnnotations;

namespace Dev.Store.Web.Pages.CloudinarySettings.ViewModels;

public class CreateEditCloudinarySettingViewModel
{
    [Display(Name = "CloudinarySettingCloudName")]
    [Required]
    public string CloudName { get; set; }

    [Display(Name = "CloudinarySettingApiKey")]
    [Required]

    public string ApiKey { get; set; }

    [Display(Name = "CloudinarySettingApiSecret")]
    [Required]

    public string ApiSecret { get; set; }

    [Display(Name = "CloudinarySettingIsEnabled")]
    [Required]
    public bool IsEnabled { get; set; }
}
