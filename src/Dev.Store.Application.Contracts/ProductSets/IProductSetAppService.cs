using System;
using Dev.Store.ProductSets.Dtos;
using Volo.Abp.Application.Services;

namespace Dev.Store.ProductSets;

public interface IProductSetAppService :
    ICrudAppService< 
        ProductSetDto, 
        Guid, 
        ProductSetGetListInput,
        CreateUpdateProductSetDto,
        CreateUpdateProductSetDto>
{

}