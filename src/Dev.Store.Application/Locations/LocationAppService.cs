using Dev.Store.Locations.Dtos;
using Dev.Store.Permissions;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace Dev.Store.Locations;


public class LocationAppService : CrudAppService<Location, LocationDto, Guid, LocationGetListInput, CreateUpdateLocationDto, CreateUpdateLocationDto>,
    ILocationAppService
{
    protected override string GetPolicyName { get; set; } = StorePermissions.Location.Default;
    protected override string GetListPolicyName { get; set; } = StorePermissions.Location.Default;
    protected override string CreatePolicyName { get; set; } = StorePermissions.Location.Create;
    protected override string UpdatePolicyName { get; set; } = StorePermissions.Location.Update;
    protected override string DeletePolicyName { get; set; } = StorePermissions.Location.Delete;

    private readonly ILocationRepository _repository;

    public LocationAppService(ILocationRepository repository) : base(repository)
    {
        _repository = repository;
    }


    [HttpGet]
    [Authorize(StorePermissions.Location.Default)]
    public async Task<DataSourceResult> DataSource([DataSourceRequest] DataSourceRequest request)
    {
        return (await _repository.GetQueryableAsync()).ToDataSourceResult(request, x => ObjectMapper.Map<Location, LocationDto>(x));
    }
}
