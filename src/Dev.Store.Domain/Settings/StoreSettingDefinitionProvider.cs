using Dev.Store.Localization;
using Volo.Abp.Localization;
using Volo.Abp.Settings;

namespace Dev.Store.Settings;

public class StoreSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        DefineFileSettings(context);
        DefineSiteSettings(context);
        DefineHomeSliderSetting(context);
    }

    private void DefineFileSettings(ISettingDefinitionContext context)
    {
        context.Add(new SettingDefinition(StoreSettings.FileSettingCloudinaryEnabled, "True", new LocalizableString(typeof(StoreResource), StoreSettings.FileSettingCloudinaryEnabled)));
        context.Add(new SettingDefinition(StoreSettings.FileSettingCloudinaryCloudName, "", new LocalizableString(typeof(StoreResource), StoreSettings.FileSettingCloudinaryCloudName), isEncrypted: true));
        context.Add(new SettingDefinition(StoreSettings.FileSettingCloudinaryApiKey, "", new LocalizableString(typeof(StoreResource), StoreSettings.FileSettingCloudinaryApiKey), isEncrypted: true));
        context.Add(new SettingDefinition(StoreSettings.FileSettingCloudinarApiSecret, "", new LocalizableString(typeof(StoreResource), StoreSettings.FileSettingCloudinarApiSecret), isEncrypted: true));
        context.Add(new SettingDefinition(StoreSettings.FileSettingCompressionEnabled, "True", new LocalizableString(typeof(StoreResource), StoreSettings.FileSettingCloudinarApiSecret), isEncrypted: false));
        context.Add(new SettingDefinition(StoreSettings.FileSettingCompressionRate, "80", new LocalizableString(typeof(StoreResource), StoreSettings.FileSettingCompressionRate), isEncrypted: false));
        context.Add(new SettingDefinition(StoreSettings.FileSettingBigImageScale, "100", new LocalizableString(typeof(StoreResource), StoreSettings.FileSettingBigImageScale), isEncrypted: false));
        context.Add(new SettingDefinition(StoreSettings.FileSettingMediumImageScale, "75", new LocalizableString(typeof(StoreResource), StoreSettings.FileSettingMediumImageScale), isEncrypted: false));
        context.Add(new SettingDefinition(StoreSettings.FileSettingSmallImageScale, "50", new LocalizableString(typeof(StoreResource), StoreSettings.FileSettingSmallImageScale), isEncrypted: false));
        context.Add(new SettingDefinition(StoreSettings.FileSettingMobileImageScale, "25", new LocalizableString(typeof(StoreResource), StoreSettings.FileSettingMobileImageScale), isEncrypted: false));

    }
    private void DefineSiteSettings(ISettingDefinitionContext context)
    {
        context.Add(new SettingDefinition(StoreSettings.SiteSettingLogo, "", new LocalizableString(typeof(StoreResource), StoreSettings.SiteSettingLogo)));
        context.Add(new SettingDefinition(StoreSettings.SiteSettingLogoReverse, "", new LocalizableString(typeof(StoreResource), StoreSettings.SiteSettingLogoReverse)));
        context.Add(new SettingDefinition(StoreSettings.SiteSettingTitle, "Yönetim Paneli", new LocalizableString(typeof(StoreResource), StoreSettings.SiteSettingTitle)));
        context.Add(new SettingDefinition(StoreSettings.SiteSettingDescription, "", new LocalizableString(typeof(StoreResource), StoreSettings.SiteSettingDescription)));
        context.Add(new SettingDefinition(StoreSettings.SiteSettingIcon, "", new LocalizableString(typeof(StoreResource), StoreSettings.SiteSettingIcon)));
        context.Add(new SettingDefinition(StoreSettings.SiteSettingAddress, "", new LocalizableString(typeof(StoreResource), StoreSettings.SiteSettingAddress)));
        context.Add(new SettingDefinition(StoreSettings.SiteSettingPhoneNumber, "", new LocalizableString(typeof(StoreResource), StoreSettings.SiteSettingPhoneNumber)));
        context.Add(new SettingDefinition(StoreSettings.SiteSettingEmail, "", new LocalizableString(typeof(StoreResource), StoreSettings.SiteSettingEmail)));

    }
    private void DefineHomeSliderSetting(ISettingDefinitionContext context)
    {
        context.Add(new SettingDefinition(StoreSettings.HomeSliderSettings, "", new LocalizableString(typeof(StoreResource), StoreSettings.HomeSliderSettings)));


    }
}
