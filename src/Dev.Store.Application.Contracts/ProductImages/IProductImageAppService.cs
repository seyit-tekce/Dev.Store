using System;
using System.Threading.Tasks;
using Dev.Store.ProductImages.Dtos;
using Microsoft.AspNetCore.Http;
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
    Task Upload(IFormFile file, Guid productId);
    Task SetMain(Guid imageId, Guid productId);
}