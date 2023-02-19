using System;
using System.ComponentModel;
using Volo.Abp.Application.Dtos;

namespace Dev.Store.SeoSettings.Dtos;

[Serializable]
public class SeoSettingGetListInput : PagedAndSortedResultRequestDto
{
    public string Title { get; set; }

    public string Description { get; set; }

    public string Keywords { get; set; }

    public Guid? ProductId { get; set; }

}