using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.SettingManagement;
namespace Dev.Store.Settings
{
    public class FileUploaderSettingAppService : ApplicationService, IFileUploaderSettingAppService
    {
        protected ISettingManager _settingManager { get; }
        public FileUploaderSettingAppService(ISettingManager settingManager)
        {
            _settingManager = settingManager;
        }
        public async Task<FileUploaderSettingDto> GetAsync()
        {
            

            await CheckFeatureAsync();
            var settingsDto = new FileUploaderSettingDto
            {
                FileSettingCloudinaryEnabled = Convert.ToBoolean(await _settingManager.GetOrNullGlobalAsync(StoreSettings.FileSettingCloudinaryEnabled)),
                FileSettingCloudinaryCloudName = Convert.ToString(await _settingManager.GetOrNullGlobalAsync(StoreSettings.FileSettingCloudinaryCloudName)),
                FileSettingCloudinaryApiKey = Convert.ToString(await _settingManager.GetOrNullGlobalAsync(StoreSettings.FileSettingCloudinaryApiKey)),
                FileSettingCloudinarApiSecret = Convert.ToString(await _settingManager.GetOrNullGlobalAsync(StoreSettings.FileSettingCloudinarApiSecret)),
                FileSettingCompressionEnabled = Convert.ToBoolean(await _settingManager.GetOrNullGlobalAsync(StoreSettings.FileSettingCompressionEnabled)),
                FileSettingCompressionRate = Convert.ToDouble(await _settingManager.GetOrNullGlobalAsync(StoreSettings.FileSettingCompressionRate)),
                FileSettingBigImageScale = Convert.ToDouble(await _settingManager.GetOrNullGlobalAsync(StoreSettings.FileSettingBigImageScale)),
                FileSettingMediumImageScale = Convert.ToDouble(await _settingManager.GetOrNullGlobalAsync(StoreSettings.FileSettingMediumImageScale)),
                FileSettingSmallImageScale = Convert.ToDouble(await _settingManager.GetOrNullGlobalAsync(StoreSettings.FileSettingSmallImageScale)),
                FileSettingMobileImageScale = Convert.ToDouble(await _settingManager.GetOrNullGlobalAsync(StoreSettings.FileSettingMobileImageScale)),
            };
            return settingsDto;
        }
        protected virtual async Task CheckFeatureAsync()
        {
            await FeatureChecker.IsEnabledAsync(SettingManagementFeatures.Enable);
        }
        public async Task<FileUploaderSettingDto> UpdateAsync(FileUploaderSettingDto input)
        {
            await _settingManager.SetGlobalAsync(StoreSettings.FileSettingCloudinaryEnabled, input.FileSettingCloudinaryEnabled.ToString());
            await _settingManager.SetGlobalAsync(StoreSettings.FileSettingCloudinaryCloudName, input.FileSettingCloudinaryCloudName.ToString());
            await _settingManager.SetGlobalAsync(StoreSettings.FileSettingCloudinaryApiKey, input.FileSettingCloudinaryApiKey.ToString());
            await _settingManager.SetGlobalAsync(StoreSettings.FileSettingCloudinarApiSecret, input.FileSettingCloudinarApiSecret.ToString());
            await _settingManager.SetGlobalAsync(StoreSettings.FileSettingCompressionEnabled, input.FileSettingCompressionEnabled.ToString());
            await _settingManager.SetGlobalAsync(StoreSettings.FileSettingCompressionRate, input.FileSettingCompressionRate.ToString());
            await _settingManager.SetGlobalAsync(StoreSettings.FileSettingBigImageScale, input.FileSettingBigImageScale.ToString());
            await _settingManager.SetGlobalAsync(StoreSettings.FileSettingMediumImageScale, input.FileSettingMediumImageScale.ToString());
            await _settingManager.SetGlobalAsync(StoreSettings.FileSettingSmallImageScale, input.FileSettingSmallImageScale.ToString());
            await _settingManager.SetGlobalAsync(StoreSettings.FileSettingMobileImageScale, input.FileSettingMobileImageScale.ToString());
            return await GetAsync();
        }
    }
}