using Dev.Store.Categories;
using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace Dev.Store.UploadFiles
{
    public class UploadFile : FullAuditedEntity<Guid>
    {
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public string PublicId { get; set; }
        public string Description { get; set; }
        public Category Category { get; set; }

    public UploadFile()
    {
    }

    public UploadFile(
        Guid id,
        string fileName,
        string filePath,
        string publicId,
        string description
    ) : base(id)
    {
        FileName = fileName;
        FilePath = filePath;
        PublicId = publicId;
        Description = description;
    }
    }
}
