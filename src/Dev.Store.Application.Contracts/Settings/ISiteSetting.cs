using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace Dev.Store.Settings
{
    public interface ISiteSettingAppService : IApplicationService
    {
        public Task<SiteSettingDto> GetAsync();
        public Task<SiteSettingDto> UpdateAsync(SiteSettingDto input);

    }
}
