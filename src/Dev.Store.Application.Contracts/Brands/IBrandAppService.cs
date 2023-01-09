using Dev.Store.Brands.Dtos;
using Kendo.Mvc.UI;
using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Dev.Store.Brands;

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