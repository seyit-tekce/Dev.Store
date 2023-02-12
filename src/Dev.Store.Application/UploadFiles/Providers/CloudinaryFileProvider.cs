using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Dev.Store.Settings;
using Dev.Store.UploadFiles.Dtos;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dev.Store.UploadFiles.Providers
{
    public class CloudinaryFileProvider : ICloudinaryFileProvider
    {
        private readonly Cloudinary _cloudinary;
        private FileUploaderSettingDto FileUploadSetting { get; }

        public CloudinaryFileProvider(IFileUploaderSettingAppService fileUploaderSettingAppService)
        {
            FileUploadSetting = fileUploaderSettingAppService.GetAsync().GetAwaiter().GetResult();
            var account = new Account(FileUploadSetting.FileSettingCloudinaryCloudName, FileUploadSetting.FileSettingCloudinaryApiKey, FileUploadSetting.FileSettingCloudinarApiSecret);
            _cloudinary = new Cloudinary(account);
        }

        public async Task<IEnumerable<UploadFileDto>> CreateAsync(IEnumerable<IFormFile> files)
        {
            var rResult = new List<UploadFileDto>();
            foreach (var file in files)
            {
                await using var stream = file.OpenReadStream();
                var uploadParams = new ImageUploadParams
                {
                    File = new FileDescription(file.FileName, stream),
                };
                var uploadResult = await _cloudinary.UploadAsync(uploadParams);
                lock (rResult)
                {
                    rResult.Add(new UploadFileDto
                    {
                        FileName = file.FileName,
                        FilePath = uploadResult.Url.ToString(),
                        PublicId = uploadResult.PublicId,
                    });
                }
            }
            return rResult;
        }

        public async Task DeleteAsync(string path)
        {
            await _cloudinary.DeleteResourcesAsync(path);
        }

        public Task<UploadFileDto> GetFileAsync(string path)
        {
            throw new NotImplementedException();
        }
    }
}