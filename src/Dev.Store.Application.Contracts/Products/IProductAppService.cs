using Dev.Store.Products.Dtos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
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
    public Task<IEnumerable<ProductGridListDto>> GetProductByCategoryIdPaging(Guid categoryId, int skip, int take);
    public Task<ProductDto> GetProductDetail(Guid categoryId, string productLink);
    Task<int> GetProductCount(Guid categoryId);
}