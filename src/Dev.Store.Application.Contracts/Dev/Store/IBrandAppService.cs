using System;
using System.Threading.Tasks;
using Dev.Store.Dtos;
using Kendo.Mvc.UI;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Dev.Store;

public interface IBrandAppService :
    ICrudAppService<
                BrandDto,
        Guid,
        PagedAndSortedResultRequestDto,
        CreateUpdateBrandDto,
        CreateUpdateBrandDto>
{
    Task<DataSourceResult> DataSource(DataSourceRequest request);
}