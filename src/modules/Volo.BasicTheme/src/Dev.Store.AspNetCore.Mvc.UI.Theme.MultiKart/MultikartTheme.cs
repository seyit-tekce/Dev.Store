using Volo.Abp.AspNetCore.Mvc.UI.Theming;
using Volo.Abp.DependencyInjection;

namespace Dev.Store.AspNetCore.Mvc.UI.Theme.MultiKart;

[ThemeName(Name)]
public class MultikartTheme : ITheme, ITransientDependency
{
    public const string Name = "Multikart";

    public virtual string GetLayout(string name, bool fallbackToDefault = true)
    {
        switch (name)
        {
            case StandardLayouts.Application:
                return "~/Themes/Multikart/Layouts/Application.cshtml";
            case StandardLayouts.Account:
                return "~/Themes/Multikart/Layouts/Account.cshtml";
            case StandardLayouts.Empty:
                return "~/Themes/Multikart/Layouts/Empty.cshtml";
            default:
                return fallbackToDefault ? "~/Themes/Multikart/Layouts/Application.cshtml" : null;
        }
    }
}
