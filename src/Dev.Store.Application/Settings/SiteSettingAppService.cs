using Dev.Store.UploadFiles;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.SettingManagement;
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

            };
            return settingsDto;
        }
        protected virtual async Task CheckFeatureAsync()
        {
            await FeatureChecker.IsEnabledAsync(SettingManagementFeatures.Enable);
        }
        public async Task<SiteSettingDto> UpdateAsync(SiteSettingUpdateDto input)
        {
            await SettingManager.SetGlobalAsync(StoreSettings.SiteSettingTitle, input.SiteSettingTitle.ToString());
            if (input.SiteSettingLogo != null)
            {
                var result = await uploadFileAppService.CreateAsync(new UploadFiles.Dtos.CreateUpdateUploadFileDto
                {
                    File = input.SiteSettingLogo,
                });
                await SettingManager.SetGlobalAsync(StoreSettings.SiteSettingLogo, result.FilePath);
            }
            if (input.SiteSettingLogoReverse != null)
            {
                var result = await uploadFileAppService.CreateAsync(new UploadFiles.Dtos.CreateUpdateUploadFileDto
                {
                    File = input.SiteSettingLogoReverse,
                });
                await SettingManager.SetGlobalAsync(StoreSettings.SiteSettingLogoReverse, result.FilePath);
            }
            return await GetAsync();
        }
    }
}