using System;
using Dev.Store.ProductImages.Dtos;
using Volo.Abp.Application.Services;

namespace Dev.Store.ProductImages;

public interface IProductImageAppService :
    ICrudAppService< 
        ProductImageDto, 
        Guid, 
        ProductImageGetListInput,
        CreateUpdateProductImageDto,
        CreateUpdateProductImageDto>
{

}