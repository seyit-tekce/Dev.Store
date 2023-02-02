using System;

namespace Dev.Store.CloudinarySettings.Dtos;

[Serializable]
public class CreateUpdateCloudinarySettingDto
{
    public string CloudName { get; set; }

    public string ApiKey { get; set; }

    public string ApiSecret { get; set; }

    public bool IsEnabled { get; set; }
}