using Dev.Store.Localization;
using Dev.Store.Settings;
using Dev.Store.Web.Components.Settings.FileUploaderSettings;
using Microsoft.Extensions.Localization;
using System.Threading.Tasks;
using Volo.Abp.Localization;
using Volo.Abp.SettingManagement.Web.Pages.SettingManagement;

namespace Dev.Store.Web.Settings
{
    public class DevStoreSettingPageContributor : ISettingPageContributor
    {
        public Task<bool> CheckPermissionsAsync(SettingPageCreationContext context)
        {
            return Task.FromResult(true);
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
            return Task.CompletedTask;
        }
    }
}
