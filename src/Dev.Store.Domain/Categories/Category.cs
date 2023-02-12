using Dev.Store.UploadFiles;
using System;
using System.Collections.Generic;
using Volo.Abp.Domain.Entities.Auditing;

namespace Dev.Store.Categories
{
    public class Category : FullAuditedEntity<Guid>
    {
        public string Name { get; set; }
        public string Link { get; set; }
        public string Description { get; set; }
        public bool IsVisible { get; set; }
        public int Order { get; set; }
        public virtual Guid? CategoryParentId { get; set; }
        public virtual Guid? FileId { get; set; }
        public Category CategoryParent { get; set; }
        public List<Category> CategoryChildren { get; set; }
        public UploadFile File { get; set; }

        protected Category()
        {
        }

        public Category(
            Guid id,
            string name,
            string link,
            string description,
            Guid? categoryParentId,
            bool isVisible
,
            Guid? fileId) : base(id)
        {
            Name = name;
            Link = link;
            Description = description;
            CategoryParentId = categoryParentId;
            IsVisible = isVisible;
            FileId = fileId;
        }
    }
}