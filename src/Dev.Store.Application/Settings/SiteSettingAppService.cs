using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.SettingManagement;
namespace Dev.Store.Settings
{
    public class SiteSettingAppService : ApplicationService, ISiteSettingAppService
    {
        protected ISettingManager SettingManager { get; }
        public SiteSettingAppService(ISettingManager settingManager)
        {
            SettingManager = settingManager;
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
        public async Task<SiteSettingDto> UpdateAsync(SiteSettingDto input)
        {
            await SettingManager.SetGlobalAsync(StoreSettings.SiteSettingTitle, input.SiteSettingTitle.ToString());
            await SettingManager.SetGlobalAsync(StoreSettings.SiteSettingLogo, input.SiteSettingLogo.ToString());
            await SettingManager.SetGlobalAsync(StoreSettings.SiteSettingLogoReverse, input.SiteSettingLogoReverse.ToString());
            return await GetAsync();
        }
    }
}