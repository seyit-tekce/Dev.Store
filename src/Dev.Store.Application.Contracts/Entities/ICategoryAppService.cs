using System;
using System.Threading.Tasks;
using Dev.Store.Entities.Dtos;
using Kendo.Mvc.UI;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Dev.Store.Entities;

public interface ICategoryAppService :
    ICrudAppService< 
                CategoryDto, 
        Guid, 
        PagedAndSortedResultRequestDto,
        CreateUpdateCategoryDto,
        CreateUpdateCategoryDto>
{
    Task<DataSourceResult> DataSource(DataSourceRequest request);
}