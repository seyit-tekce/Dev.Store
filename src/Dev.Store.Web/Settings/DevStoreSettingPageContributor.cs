using Dev.Store.Localization;
using Dev.Store.Permissions;
using Dev.Store.Web.Components.Settings.FileUploaderSettings;
using Dev.Store.Web.Components.Settings.SiteSettings;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Localization;
using System.Threading.Tasks;
using Volo.Abp.Localization;
using Volo.Abp.SettingManagement.Web.Pages.SettingManagement;

namespace Dev.Store.Web.Settings
{
    public class DevStoreSettingPageContributor : ISettingPageContributor
    {
        public async Task<bool> CheckPermissionsAsync(SettingPageCreationContext context)
        {
            var authorizationService = (IAuthorizationService)context.ServiceProvider.GetService(typeof(IAuthorizationService));
            return await authorizationService.IsGrantedAsync(StorePermissions.FileSettings.Default);
        }

        public Task ConfigureAsync(SettingPageCreationContext context)
        {
            var stringLocalizerFactory = (IStringLocalizerFactory)context.ServiceProvider.GetService(typeof(IStringLocalizerFactory));
            context.Groups.Add(
            new SettingPageGroup(
                "Dev.Store.FileUploaderSetting",
                new LocalizableString(typeof(StoreResource), "FileUploaderSetting").Localize(stringLocalizerFactory),
                typeof(FileUploaderSettingViewComponent)
            )
        );

            context.Groups.Add(
            new SettingPageGroup(
                "Dev.Store.SiteSetting",
                new LocalizableString(typeof(StoreResource), "SiteSetting").Localize(stringLocalizerFactory),
                typeof(SiteSettingViewComponent)
            )
        );
            context.Groups.Add(
            new SettingPageGroup(
                "Dev.Store.HomeSliderSetting",
                new LocalizableString(typeof(StoreResource), "HomeSliderSetting").Localize(stringLocalizerFactory),
                typeof(HomeSliderSettingViewComponent)
            )
        );
            return Task.CompletedTask;
        }
    }
}
