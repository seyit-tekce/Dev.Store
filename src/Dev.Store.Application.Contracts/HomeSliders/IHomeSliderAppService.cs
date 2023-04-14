using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Dev.Store.HomeSliders.Dtos;
using Volo.Abp.Application.Services;

namespace Dev.Store.HomeSliders;

public interface IHomeSliderAppService :
    ICrudAppService<
        HomeSliderDto,
        Guid,
        HomeSliderGetListInput,
        CreateUpdateHomeSliderDto,
        CreateUpdateHomeSliderDto>
{
    Task<IEnumerable<HomeSliderDto>> GetListByType(HomeSliderType type);
}