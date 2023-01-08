using System;
using System.Collections.Generic;
using System.Globalization;
using Volo.Abp.AspNetCore.Mvc.UI.Bundling;
using Volo.Abp.AspNetCore.Mvc.UI.Packages.JQuery;
using Volo.Abp.Modularity;

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
