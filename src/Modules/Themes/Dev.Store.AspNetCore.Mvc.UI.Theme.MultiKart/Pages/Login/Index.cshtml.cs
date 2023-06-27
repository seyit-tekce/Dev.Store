using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;
using Volo.Abp.Account.Web;

namespace Dev.Store.AspNetCore.Mvc.UI.Theme.MultiKart.Pages.Login
{
    public class IndexModel : Volo.Abp.Account.Web.Pages.Account.LoginModel
    {
        public IndexModel(IAuthenticationSchemeProvider schemeProvider, IOptions<AbpAccountOptions> accountOptions, IOptions<IdentityOptions> identityOptions) : base(schemeProvider, accountOptions, identityOptions)
        {
        }
        public override Task<IActionResult> OnPostAsync(string action)
        {
            return base.OnPostAsync(action);
        }
    }
}
