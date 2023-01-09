using System;
using Volo.Abp.Application.Dtos;

namespace Dev.Store.Brands.Dtos;

[Serializable]
public class BrandDto : FullAuditedEntityDto<Guid>
{
    public string Name { get; set; }

    public string Code { get; set; }

    public string Description { get; set; }
}