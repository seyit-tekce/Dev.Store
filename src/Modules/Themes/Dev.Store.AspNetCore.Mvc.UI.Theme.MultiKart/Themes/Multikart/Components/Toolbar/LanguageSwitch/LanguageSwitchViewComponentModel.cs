using System.Collections.Generic;
using Volo.Abp.Localization;

namespace Dev.Store.AspNetCore.Mvc.UI.Theme.MultiKart.Themes.Basic.Components.Toolbar.LanguageSwitch;

public class LanguageSwitchViewComponentModel
{
    public LanguageInfo CurrentLanguage { get; set; }

    public List<LanguageInfo> OtherLanguages { get; set; }
}
