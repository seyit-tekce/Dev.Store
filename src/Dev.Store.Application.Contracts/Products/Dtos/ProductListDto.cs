using Dev.Store.Brands.Dtos;
using Dev.Store.Categories.Dtos;
using Dev.Store.ProductImages.Dtos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using Volo.Abp.Application.Dtos;

namespace Dev.Store.Products.Dtos;

[Serializable]
public class ProductListDto : FullAuditedEntityDto<Guid>
{
    public string Name { get; set; }
    public string Code { get; set; }
    public CategoryDto Category { get; set; }
    public BrandDto BrandDto { get; set; }
    public bool? IsEnabled { get; set; }
    public IEnumerable<ProductImageDto> ProductImages { get; set; }
}