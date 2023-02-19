using System;
using Volo.Abp.Application.Dtos;

namespace Dev.Store.SeoSettings.Dtos;

[Serializable]
public class SeoSettingDto : FullAuditedEntityDto<Guid>
{
    public string Title { get; set; }

    public string Description { get; set; }

    public string Keywords { get; set; }

    public Guid ProductId { get; set; }

}