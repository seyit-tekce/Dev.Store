using System;
using Dev.Store.SeoSettings.Dtos;
using Volo.Abp.Application.Services;

namespace Dev.Store.SeoSettings;

public interface ISeoSettingAppService :
    ICrudAppService< 
        SeoSettingDto, 
        Guid, 
        SeoSettingGetListInput,
        CreateUpdateSeoSettingDto,
        CreateUpdateSeoSettingDto>
{

}