using System;
using Dev.Store.Entities.Dtos;
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

}