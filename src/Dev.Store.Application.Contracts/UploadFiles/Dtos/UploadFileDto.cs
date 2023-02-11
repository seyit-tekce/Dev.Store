using System;
using Volo.Abp.Application.Dtos;

namespace Dev.Store.UploadFiles.Dtos;

[Serializable]
public class UploadFileDto : FullAuditedEntityDto<Guid>
{
    public string FileName { get; set; }

    public string FilePath { get; set; }

    public string PublicId { get; set; }

    public string Description { get; set; }
}