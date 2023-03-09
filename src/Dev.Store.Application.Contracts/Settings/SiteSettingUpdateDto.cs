using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Dev.Store.Settings
{
    public class SiteSettingUpdateDto
    {
        [Required]
        public string SiteSettingTitle { get; set; }

        public IFormFile SiteSettingLogo { get; set; }

        public IFormFile SiteSettingLogoReverse { get; set; }
    }
}