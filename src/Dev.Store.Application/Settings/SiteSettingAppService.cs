using Dev.Store.UploadFiles;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.SettingManagement;
using Volo.Abp.Settings;

namespace Dev.Store.Settings
{
    public class SiteSettingAppService : ApplicationService, ISiteSettingAppService
    {
        protected ISettingManager SettingManager { get; }
        private readonly IUploadFileAppService uploadFileAppService;
        public SiteSettingAppService(ISettingManager settingManager, IUploadFileAppService uploadFileAppService)
        {
            SettingManager = settingManager;
            this.uploadFileAppService = uploadFileAppService;
        }
        public async Task<SiteSettingDto> GetAsync()
        {
            await CheckFeatureAsync();
            var settingsDto = new SiteSettingDto
            {
                SiteSettingTitle = await SettingProvider.GetOrNullAsync(StoreSettings.SiteSettingTitle),
                SiteSettingLogo = await SettingProvider.GetOrNullAsync(StoreSettings.SiteSettingLogo),
                SiteSettingLogoReverse = await SettingProvider.GetOrNullAsync(StoreSettings.SiteSettingLogoReverse),
                SiteSettingIcon = await SettingProvider.GetOrNullAsync(StoreSettings.SiteSettingIcon.Replace("http", "https")),
                SiteSettingDescription = await SettingProvider.GetOrNullAsync(StoreSettings.SiteSettingDescription),
                SiteSettingAddress = await SettingProvider.GetOrNullAsync(StoreSettings.SiteSettingAddress),
                SiteSettingEmail = await SettingProvider.GetOrNullAsync(StoreSettings.SiteSettingEmail),
                SiteSettingPhoneNumber = await SettingProvider.GetOrNullAsync(StoreSettings.SiteSettingPhoneNumber),
            };
            return settingsDto;
        }
        protected virtual async Task CheckFeatureAsync()
        {
            await FeatureChecker.IsEnabledAsync(SettingManagementFeatures.Enable);
        }
        public async Task<SiteSettingDto> UpdateAsync([FromForm] SiteSettingUpdateDto input)
        {
            await SettingManager.SetGlobalAsync(StoreSettings.SiteSettingTitle, input.SiteSettingTitle?.ToString());
            await SettingManager.SetGlobalAsync(StoreSettings.SiteSettingDescription, input.SiteSettingDescription?.ToString());
            await SettingManager.SetGlobalAsync(StoreSettings.SiteSettingAddress, input.SiteSettingAddress?.ToString());
            await SettingManager.SetGlobalAsync(StoreSettings.SiteSettingEmail, input.SiteSettingEmail?.ToString());
            await SettingManager.SetGlobalAsync(StoreSettings.SiteSettingPhoneNumber, input.SiteSettingPhoneNumber?.ToString());
            if (input.SiteSettingLogo != null)
            {
                var result = await uploadFileAppService.CreateAsync(new UploadFiles.Dtos.CreateUpdateUploadFileDto
                {
                    File = input.SiteSettingLogo,
                });
                await SettingManager.SetGlobalAsync(StoreSettings.SiteSettingLogo, result.FilePath.Replace("http", "https"));
            }
            if (input.SiteSettingLogoReverse != null)
            {
                var result = await uploadFileAppService.CreateAsync(new UploadFiles.Dtos.CreateUpdateUploadFileDto
                {
                    File = input.SiteSettingLogoReverse,
                });
                await SettingManager.SetGlobalAsync(StoreSettings.SiteSettingLogoReverse, result.FilePath);
            }
            if (input.SiteSettingIcon != null)
            {
                var result = await uploadFileAppService.CreateAsync(new UploadFiles.Dtos.CreateUpdateUploadFileDto
                {
                    File = input.SiteSettingIcon,
                });
                await SettingManager.SetGlobalAsync(StoreSettings.SiteSettingIcon, result.FilePath);
            }
            return await GetAsync();
        }
    }
}