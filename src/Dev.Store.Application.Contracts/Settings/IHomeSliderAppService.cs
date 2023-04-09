using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace Dev.Store.Settings
{
    public interface IHomeSliderAppService : IApplicationService
    {
        public Task<IEnumerable<HomeSliderSettingDto>> GetAsync();
        public Task UpdateAsync(HomeSliderSettingUpdateDto[] files);

    }
    
}
