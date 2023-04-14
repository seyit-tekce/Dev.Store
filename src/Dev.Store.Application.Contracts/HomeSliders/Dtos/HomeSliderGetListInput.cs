using Dev.Store.UploadFiles.Dtos;
using System;
using Volo.Abp.Application.Dtos;

namespace Dev.Store.HomeSliders.Dtos;

[Serializable]
public class HomeSliderGetListInput : PagedAndSortedResultRequestDto
{
    public Guid? UploadFileId { get; set; }

    public string Title { get; set; }

    public string Subtitle { get; set; }

    public string ButtonLink { get; set; }

    public string ButtonText { get; set; }

    public int? Order { get; set; }

    public HomeSliderType? Type { get; set; }

    public UploadFileDto? UploadFile { get; set; }
}