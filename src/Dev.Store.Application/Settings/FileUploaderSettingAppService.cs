using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.SettingManagement;
namespace Dev.Store.Settings
{
    public class FileUploaderSettingAppService : ApplicationService, IFileUploaderSettingAppService
    {
        protected ISettingManager SettingManager { get; }
        public FileUploaderSettingAppService(ISettingManager settingManager)
        {
            SettingManager = settingManager;
        }
        public async Task<FileUploaderSettingDto> GetAsync()
        {
            await CheckFeatureAsync();
            var settingsDto = new FileUploaderSettingDto
            {
                FileSettingCloudinaryEnabled = Convert.ToBoolean(await SettingProvider.GetOrNullAsync(StoreSettings.FileSettingCloudinaryEnabled)),
                FileSettingCloudinaryCloudName = Convert.ToString(await SettingProvider.GetOrNullAsync(StoreSettings.FileSettingCloudinaryCloudName)),
                FileSettingCloudinaryApiKey = Convert.ToString(await SettingProvider.GetOrNullAsync(StoreSettings.FileSettingCloudinaryApiKey)),
                FileSettingCloudinarApiSecret = Convert.ToString(await SettingProvider.GetOrNullAsync(StoreSettings.FileSettingCloudinarApiSecret)),
                FileSettingCompressionEnabled = Convert.ToBoolean(await SettingProvider.GetOrNullAsync(StoreSettings.FileSettingCompressionEnabled)),
                FileSettingCompressionRate = Convert.ToDouble(await SettingProvider.GetOrNullAsync(StoreSettings.FileSettingCompressionRate)),
                FileSettingBigImageScale = Convert.ToDouble(await SettingProvider.GetOrNullAsync(StoreSettings.FileSettingBigImageScale)),
                FileSettingMediumImageScale = Convert.ToDouble(await SettingProvider.GetOrNullAsync(StoreSettings.FileSettingMediumImageScale)),
                FileSettingSmallImageScale = Convert.ToDouble(await SettingProvider.GetOrNullAsync(StoreSettings.FileSettingSmallImageScale)),
                FileSettingMobileImageScale = Convert.ToDouble(await SettingProvider.GetOrNullAsync(StoreSettings.FileSettingMobileImageScale)),
            };
            return settingsDto;
        }
        protected virtual async Task CheckFeatureAsync()
        {
            await FeatureChecker.IsEnabledAsync(SettingManagementFeatures.Enable);
        }
        public async Task<FileUploaderSettingDto> UpdateAsync(FileUploaderSettingDto input)
        {
            await SettingManager.SetGlobalAsync(StoreSettings.FileSettingCloudinaryEnabled, input.FileSettingCloudinaryEnabled.ToString());
            await SettingManager.SetGlobalAsync(StoreSettings.FileSettingCloudinaryCloudName, input.FileSettingCloudinaryCloudName.ToString());
            await SettingManager.SetGlobalAsync(StoreSettings.FileSettingCloudinaryApiKey, input.FileSettingCloudinaryApiKey.ToString());
            await SettingManager.SetGlobalAsync(StoreSettings.FileSettingCloudinarApiSecret, input.FileSettingCloudinarApiSecret.ToString());
            await SettingManager.SetGlobalAsync(StoreSettings.FileSettingCompressionEnabled, input.FileSettingCompressionEnabled.ToString());
            await SettingManager.SetGlobalAsync(StoreSettings.FileSettingCompressionRate, input.FileSettingCompressionRate.ToString());
            await SettingManager.SetGlobalAsync(StoreSettings.FileSettingBigImageScale, input.FileSettingBigImageScale.ToString());
            await SettingManager.SetGlobalAsync(StoreSettings.FileSettingMediumImageScale, input.FileSettingMediumImageScale.ToString());
            await SettingManager.SetGlobalAsync(StoreSettings.FileSettingSmallImageScale, input.FileSettingSmallImageScale.ToString());
            await SettingManager.SetGlobalAsync(StoreSettings.FileSettingMobileImageScale, input.FileSettingMobileImageScale.ToString());
            return await GetAsync();
        }
    }
}