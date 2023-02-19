using System;
using Dev.Store.Products.Dtos;
using Volo.Abp.Application.Services;

namespace Dev.Store.Products;

public interface IProductAppService :
    ICrudAppService< 
        ProductDto, 
        Guid,
        ProductListDto,
        CreateUpdateProductDto,
        CreateUpdateProductDto>
{

}