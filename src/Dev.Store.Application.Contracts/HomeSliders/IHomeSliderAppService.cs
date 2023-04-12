using System;
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

}