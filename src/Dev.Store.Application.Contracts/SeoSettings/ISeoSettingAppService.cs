using Dev.Store.SeoSettings.Dtos;
using System;
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