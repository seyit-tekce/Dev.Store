using System;
using Dev.Store.ProductSizes.Dtos;
using Volo.Abp.Application.Services;

namespace Dev.Store.ProductSizes;

public interface IProductSizeAppService :
    ICrudAppService< 
        ProductSizeDto, 
        Guid, 
        ProductSizeGetListInput,
        CreateUpdateProductSizeDto,
        CreateUpdateProductSizeDto>
{

}