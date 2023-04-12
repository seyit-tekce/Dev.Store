using System;
using System.Linq;
using System.Threading.Tasks;
using Dev.Store.Permissions;
using Dev.Store.HomeSliders.Dtos;
using Volo.Abp.Application.Services;

namespace Dev.Store.HomeSliders;


public class HomeSliderAppService : CrudAppService<HomeSlider, HomeSliderDto, Guid, HomeSliderGetListInput, CreateUpdateHomeSliderDto, CreateUpdateHomeSliderDto>,
    IHomeSliderAppService
{
    protected override string GetPolicyName { get; set; } = StorePermissions.HomeSlider.Default;
    protected override string GetListPolicyName { get; set; } = StorePermissions.HomeSlider.Default;
    protected override string CreatePolicyName { get; set; } = StorePermissions.HomeSlider.Create;
    protected override string UpdatePolicyName { get; set; } = StorePermissions.HomeSlider.Update;
    protected override string DeletePolicyName { get; set; } = StorePermissions.HomeSlider.Delete;

    private readonly IHomeSliderRepository _repository;

    public HomeSliderAppService(IHomeSliderRepository repository) : base(repository)
    {
        _repository = repository;
    }

    
}
