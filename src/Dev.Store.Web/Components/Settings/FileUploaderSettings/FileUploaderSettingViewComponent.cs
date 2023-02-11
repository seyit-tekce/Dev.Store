using Dev.Store.Settings;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc.UI.Widgets;

namespace Dev.Store.Web.Components.Settings.FileUploaderSettings
{
    [Widget(ScriptFiles = new[] { "/Components/Settings/FileUploaderSettings/defult.js" })]
    public class FileUploaderSettingViewComponent : AbpViewComponent
    {
        private readonly IFileUploaderSettingAppService fileUploaderSetting;

        public FileUploaderSettingViewComponent(IFileUploaderSettingAppService fileUploaderSetting)
        {
            this.fileUploaderSetting = fileUploaderSetting;
        }

        public virtual async Task<IViewComponentResult> InvokeAsync()
        {
            return View("~/Components/Settings/FileUploaderSettings/Default.cshtml", await fileUploaderSetting.GetAsync());
        }
    }




}
