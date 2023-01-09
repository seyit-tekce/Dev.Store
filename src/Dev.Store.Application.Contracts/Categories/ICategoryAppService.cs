using Dev.Store.Categories.Dtos;
using Kendo.Mvc.UI;
using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Dev.Store.Categories;

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