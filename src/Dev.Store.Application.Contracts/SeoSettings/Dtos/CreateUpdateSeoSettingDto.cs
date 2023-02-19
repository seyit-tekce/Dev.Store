using System;

namespace Dev.Store.SeoSettings.Dtos;

[Serializable]
public class CreateUpdateSeoSettingDto
{
    public string Title { get; set; }

    public string Description { get; set; }

    public string Keywords { get; set; }

    public Guid ProductId { get; set; }

}