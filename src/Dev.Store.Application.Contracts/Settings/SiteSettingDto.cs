using System.ComponentModel.DataAnnotations;

namespace Dev.Store.Settings
{
    public class SiteSettingDto
    {
        [Required]
        public string SiteSettingTitle { get; set; }

        [Required]
        public string SiteSettingLogo { get; set; }

        public string SiteSettingLogoReverse { get; set; }


    }
}