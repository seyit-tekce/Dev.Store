using System;
using System.Linq;
using System.Threading.Tasks;
using Dev.Store.Permissions;
using Dev.Store.SeoSettings.Dtos;
using Volo.Abp.Application.Services;

namespace Dev.Store.SeoSettings;


public class SeoSettingAppService : CrudAppService<SeoSetting, SeoSettingDto, Guid, SeoSettingGetListInput, CreateUpdateSeoSettingDto, CreateUpdateSeoSettingDto>,
    ISeoSettingAppService
{
    protected override string GetPolicyName { get; set; } = StorePermissions.SeoSetting.Default;
    protected override string GetListPolicyName { get; set; } = StorePermissions.SeoSetting.Default;
    protected override string CreatePolicyName { get; set; } = StorePermissions.SeoSetting.Create;
    protected override string UpdatePolicyName { get; set; } = StorePermissions.SeoSetting.Update;
    protected override string DeletePolicyName { get; set; } = StorePermissions.SeoSetting.Delete;

    private readonly ISeoSettingRepository _repository;

    public SeoSettingAppService(ISeoSettingRepository repository) : base(repository)
    {
        _repository = repository;
    }

  
}
