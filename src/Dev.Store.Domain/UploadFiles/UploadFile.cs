using System;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace Dev.Store.UploadFiles
{
    public class UploadFile : FullAuditedEntity<Guid>, IMultiTenant
    {
        public virtual Guid? TenantId { get; set; }
        public virtual string FileName { get; set; }
        public virtual string FilePath { get; set; }
        public virtual string PublicId { get; set; }

        protected UploadFile()
        {
        }

        public UploadFile(
            Guid id,
            Guid? tenantId,
            string fileName,
            string filePath
        ) : base(id)
        {
            TenantId = tenantId;
            FileName = fileName;
            FilePath = filePath;
        }
    }
}
