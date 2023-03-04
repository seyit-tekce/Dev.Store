using Dev.Store.Products;
using Dev.Store.UploadFiles;
using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace Dev.Store.ProductImages
{
    public class ProductImage:FullAuditedAggregateRoot<Guid>
    {
        public virtual Guid ProductId { get; set; }
        public virtual Guid UploadFileId { get; set; }
        public virtual bool IsMain { get; set; }
       
        public Product Product { get; set; }
        public UploadFile UploadFile { get; set; }

    public ProductImage()
    {
    }

    public ProductImage(
        Guid id,
        Guid productId,
        Guid uploadFileId,
        bool isMain,
        Product product,
        UploadFile uploadFile
    ) : base(id)
    {
        ProductId = productId;
        UploadFileId = uploadFileId;
        IsMain = isMain;
        Product = product;
        UploadFile = uploadFile;
    }
    }
}
