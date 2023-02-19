using System;
using Volo.Abp.Application.Dtos;

namespace Dev.Store.ProductSizes.Dtos;

[Serializable]
public class ProductSizeDto : FullAuditedEntityDto<Guid>
{
    public Guid ProductId { get; set; }


    public double Height { get; set; }

    public double Width { get; set; }

    public double Price { get; set; }

    public bool IsDefault { get; set; }
}