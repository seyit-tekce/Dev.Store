using System;

namespace Dev.Store.ProductImages.Dtos;

[Serializable]
public class CreateUpdateProductImageDto
{
    public Guid ProductId { get; set; }

    public Guid UploadFileId { get; set; }

    public bool IsMain { get; set; }

}