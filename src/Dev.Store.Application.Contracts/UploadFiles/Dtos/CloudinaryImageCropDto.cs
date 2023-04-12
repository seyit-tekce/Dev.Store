using Dev.Store.Settings;
using Dev.Store.UploadFiles.Dtos;
using System;
using System.Threading.Tasks;
namespace Dev.Store
{
    public static partial class CloudinaryImageDtoCropExtention
    {
        private static FileUploaderSettingDto _setting { get; set; }
        public static async Task Configure(IFileUploaderSettingAppService fileUploadAppService)
        {
            _setting = await fileUploadAppService.GetAsync();
        }
        private static string Parse(UploadFileDto file, double scale)
        {
            var a = file.FilePath;
            var d = "https://res.cloudinary.com/";
            var b = a.Split('/');
            var imageScale = (scale / 100).ToString().Replace(",", ".");
            var compression = "";
            if (_setting.FileSettingCompressionEnabled)
            {
                if (_setting.FileSettingCompressionRate.IsBetween(0, 25))
                {
                    compression = "/q_auto:best";
                }
                else if (_setting.FileSettingCompressionRate.IsBetween(26, 50))
                {
                    compression = "/q_auto:good";
                }
                else if (_setting.FileSettingCompressionRate.IsBetween(51, 75))
                {
                    compression = "/q_auto:eco";
                }
                else
                {
                    compression = "/q_auto:low";
                }
            }
            for (var i = 3; i < b.Length; i++)
            {
                if (i == 6) d += $"w_{imageScale},c_scale{compression}/";
                if (b.Length != i + 1)
                    d += b[i] + "/";
                else
                    d += b[i];
            }
            return d;
        }
        public static string Big(this UploadFileDto file)
        {
            return Parse(file, _setting.FileSettingBigImageScale);
        }
        public static string Medium(this UploadFileDto file)
        {
            return Parse(file, _setting.FileSettingMediumImageScale);
        }
        public static string Mobile(this UploadFileDto file)
        {
            return Parse(file, _setting.FileSettingMobileImageScale);
        }
        public static string Small(this UploadFileDto file)
        {
            return Parse(file, _setting.FileSettingSmallImageScale);
        }
    }
}