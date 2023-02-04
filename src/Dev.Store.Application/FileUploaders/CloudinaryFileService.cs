using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Dev.Store.CloudinarySettings;
using Dev.Store.CloudinarySettings.Dtos;
using Dev.Store.UploadFiles;
using Dev.Store.UploadFiles.Dtos;
using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;

namespace Dev.Store.FileUploaders
{
    public class CloudinaryFileService : ICloudinaryFileService
    {
        private readonly ICloudinarySettingAppService cloudinarySettingAppService;
        private readonly IUploadFileAppService uploadFileAppService;

        private CloudinarySettingDto DefaultCloudinarySetting { get; set; }

        private Account Account { get; set; }
        private Cloudinary Cloudinary { get; set; }

        public CloudinaryFileService(ICloudinarySettingAppService cloudinarySettingAppService, IUploadFileAppService uploadFileAppService)
        {
            this.cloudinarySettingAppService = cloudinarySettingAppService;
            this.uploadFileAppService = uploadFileAppService;
        }
        private async Task Load()
        {
            DefaultCloudinarySetting = await cloudinarySettingAppService.GetDefault();
            Account = new Account(DefaultCloudinarySetting.CloudName, DefaultCloudinarySetting.ApiKey, DefaultCloudinarySetting.ApiSecret);
            Cloudinary = new Cloudinary(Account);
        }

     
        public async Task UploadFileAsync(IFormFile file)
        {
            await Load();
            await using var stream = file.OpenReadStream();
            var uploadParams = new ImageUploadParams
            {
                File = new FileDescription(file.FileName, stream)
            };
            var uploadResult = Cloudinary.Upload(uploadParams);
            await uploadFileAppService.CreateAsync(new UploadFiles.Dtos.CreateUpdateUploadFileDto
            {
                FileName = file.FileName,
                FilePath = uploadResult.Url.ToString(),
                PublicId = uploadResult.PublicId
            });
        }

        public async Task DeleteFileAsync(UploadFileDto file)
        {
            await Load();
            await Cloudinary.DeleteResourcesAsync(new string[] { file.PublicId });
        }
    }
}
