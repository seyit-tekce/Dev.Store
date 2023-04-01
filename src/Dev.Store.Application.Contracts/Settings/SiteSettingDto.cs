using System.ComponentModel.DataAnnotations;

namespace Dev.Store.Settings
{
    public class SiteSettingDto
    {
        [Required]
        public string SiteSettingTitle { get; set; }

        [Required]
        public string SiteSettingLogo { get; set; }

        [Required]
        
        public string SiteSettingDescription { get; set; }
        [Required]
        public string SiteSettingIcon { get; set; }

        public string SiteSettingLogoReverse { get; set; }

    }
}