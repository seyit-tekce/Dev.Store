using Dev.Store.Categories.Dtos;
using Kendo.Mvc.UI;
using System;
using System.Collections.Generic;
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

    Task MoveUp(Guid id);
    Task MoveDown(Guid id);

    Task<IEnumerable<CategoryDto>> GetCategoriesAsync(bool includeDisabled = false);

    Task<CategoryDto> GetCategoryByMainAndSubName(string mainCategory, string subCategory);


}