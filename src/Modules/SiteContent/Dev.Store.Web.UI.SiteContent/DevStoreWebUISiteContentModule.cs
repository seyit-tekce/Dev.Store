using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.AspNetCore.Mvc.UI;
using Volo.Abp.Modularity;

namespace Dev.Store.Web.UI
{
    [DependsOn(typeof(AbpAspNetCoreMvcUiModule))]
    public class DevStoreWebUISiteContentModule: AbpModule
    {
        public override void PreConfigureServices(ServiceConfigurationContext context)
        {
            PreConfigure<IMvcBuilder>(mvcBuilder =>
            {
                mvcBuilder.AddApplicationPartIfNotExists(typeof(DevStoreWebUISiteContentModule).Assembly);
            });
        }
    }
}