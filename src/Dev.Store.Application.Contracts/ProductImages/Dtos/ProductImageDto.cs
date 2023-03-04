using Dev.Store.UploadFiles.Dtos;
using System;
using Volo.Abp.Application.Dtos;

namespace Dev.Store.ProductImages.Dtos;

[Serializable]
public class ProductImageDto : FullAuditedEntityDto<Guid>
{
    public Guid ProductId { get; set; }

    public Guid UploadFileId { get; set; }

    public bool IsMain { get; set; }
    public UploadFileDto UploadFile { get; set; }

}