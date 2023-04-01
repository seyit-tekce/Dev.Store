using JetBrains.Annotations;
using Volo.Abp.Ui.Branding;

namespace Dev.Store.Web.UI.Branding
{
    public interface IDevBrandingProvider : IBrandingProvider
    {
        public string SiteIcon { get; }
        public string SiteDescription { get; }
        public string PhoneNumber { get; }
        public string Email { get; }
        public string Address { get; }

    }
}
