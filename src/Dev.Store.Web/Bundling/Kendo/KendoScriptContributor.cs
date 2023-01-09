using System.Collections.Generic;
using Volo.Abp.AspNetCore.Mvc.UI.Bundling;

namespace Dev.StoreAbp.Web.Bundling.Kendo
{
    public class KendoScriptContributor : BundleContributor
    {
        public override void ConfigureBundle(BundleConfigurationContext context)
        {

            base.ConfigureBundle(context);
        }
    }

    public class KendoStyleContributor : BundleContributor
    {
        public override void ConfigureBundle(BundleConfigurationContext context)
        {
            context.Files.AddIfNotContains("/kendo/styles/kendo.common-bootstrap.min.css");
            context.Files.AddIfNotContains("/kendo/styles/kendo.bootstrap-v4.min.css");
        }
    }


}
