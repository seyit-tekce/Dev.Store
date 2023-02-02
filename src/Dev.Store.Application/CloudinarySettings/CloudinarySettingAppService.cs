using Dev.Store.CloudinarySettings.Dtos;
using Dev.Store.Permissions;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace Dev.Store.CloudinarySettings;


public class CloudinarySettingAppService : CrudAppService<CloudinarySetting, CloudinarySettingDto, Guid, CloudinarySettingGetListInput, CreateUpdateCloudinarySettingDto, CreateUpdateCloudinarySettingDto>,
    ICloudinarySettingAppService
{
    protected override string GetPolicyName { get; set; } = StorePermissions.CloudinarySetting.Default;
    protected override string GetListPolicyName { get; set; } = StorePermissions.CloudinarySetting.Default;
    protected override string CreatePolicyName { get; set; } = StorePermissions.CloudinarySetting.Create;
    protected override string UpdatePolicyName { get; set; } = StorePermissions.CloudinarySetting.Update;
    protected override string DeletePolicyName { get; set; } = StorePermissions.CloudinarySetting.Delete;

    private readonly ICloudinarySettingRepository _repository;

    public CloudinarySettingAppService(ICloudinarySettingRepository repository) : base(repository)
    {
        _repository = repository;
    }

    [HttpGet]
    [Authorize(StorePermissions.CloudinarySetting.Default)]
    public async Task<DataSourceResult> DataSource([DataSourceRequest] DataSourceRequest request)
    {
        return (await _repository.GetQueryableAsync()).ToDataSourceResult(request, x => ObjectMapper.Map<CloudinarySetting, CloudinarySettingDto>(x));
    }

    public async Task<CloudinarySettingDto> GetDefault()
    {
        return ObjectMapper.Map<CloudinarySetting, CloudinarySettingDto>(await _repository.FindAsync(x => x.IsEnabled));
    }
}
