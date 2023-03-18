using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
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
    public Task<IEnumerable<ProductGridListDto>> GetProductByCategoryIdPaging(Guid categoryId,int skip,int take);
    Task<int> GetProductCount(Guid categoryId);
}