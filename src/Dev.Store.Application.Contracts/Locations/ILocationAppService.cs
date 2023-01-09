using Dev.Store.Locations.Dtos;
using Kendo.Mvc.UI;
using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace Dev.Store.Locations;

public interface ILocationAppService :
    ICrudAppService<
        LocationDto,
        Guid,
        LocationGetListInput,
        CreateUpdateLocationDto,
        CreateUpdateLocationDto>
{
    Task<DataSourceResult> DataSource(DataSourceRequest request);
}