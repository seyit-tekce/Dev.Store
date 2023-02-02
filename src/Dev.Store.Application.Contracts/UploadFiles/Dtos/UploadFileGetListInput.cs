using System;
using System.ComponentModel;
using Volo.Abp.Application.Dtos;

namespace Dev.Store.UploadFiles.Dtos;

[Serializable]
public class UploadFileGetListInput : PagedAndSortedResultRequestDto
{
    public string FileName { get; set; }

    public string FilePath { get; set; }
}