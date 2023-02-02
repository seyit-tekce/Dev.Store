using System;
using System.Threading.Tasks;
using Dev.Store.CloudinarySettings.Dtos;
using Volo.Abp.Application.Services;

namespace Dev.Store.CloudinarySettings;

public interface ICloudinarySettingAppService :
    ICrudAppService< 
        CloudinarySettingDto, 
        Guid, 
        CloudinarySettingGetListInput,
        CreateUpdateCloudinarySettingDto,
        CreateUpdateCloudinarySettingDto>
{
    public Task<CloudinarySettingDto> GetDefault();
}