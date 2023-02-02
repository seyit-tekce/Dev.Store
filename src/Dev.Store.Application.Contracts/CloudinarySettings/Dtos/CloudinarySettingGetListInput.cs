using System;
using System.ComponentModel;
using Volo.Abp.Application.Dtos;

namespace Dev.Store.CloudinarySettings.Dtos;

[Serializable]
public class CloudinarySettingGetListInput : PagedAndSortedResultRequestDto
{
    public string CloudName { get; set; }

    public string ApiKey { get; set; }

    public string ApiSecret { get; set; }

    public bool? IsEnabled { get; set; }
}