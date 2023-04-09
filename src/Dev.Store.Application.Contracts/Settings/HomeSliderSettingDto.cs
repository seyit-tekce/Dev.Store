using Dev.Store.UploadFiles.Dtos;
using Microsoft.AspNetCore.Http;

namespace Dev.Store.Settings
{
    public class HomeSliderSettingDto
    {
        public string Image { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string ButtonLink { get; set; }
        public string ButtonText { get; set; }
    }
    public class HomeSliderSettingUpdateDto
    {
        public IFormFile Files { get; set; }
       
    }
}