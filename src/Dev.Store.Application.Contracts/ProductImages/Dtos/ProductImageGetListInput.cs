using System;
using System.ComponentModel;
using Volo.Abp.Application.Dtos;

namespace Dev.Store.ProductImages.Dtos;

[Serializable]
public class ProductImageGetListInput : PagedAndSortedResultRequestDto
{
    public Guid? ProductId { get; set; }

    public Guid? UploadFileId { get; set; }

    public bool? IsMain { get; set; }

}