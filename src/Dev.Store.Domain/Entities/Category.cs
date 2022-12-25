using System;
using System.Collections.Generic;
using Volo.Abp.Domain.Entities.Auditing;

namespace Dev.Store.Entities
{
    public class Category : AuditedEntity<Guid>
    {
        public string Name { get; set; }
        public string Link { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Category> Categories { get; set; }

    protected Category()
    {
    }

    public Category(
        Guid id,
        string name,
        string link,
        string description,
        ICollection<Category> categories
    ) : base(id)
    {
        Name = name;
        Link = link;
        Description = description;
        Categories = categories;
    }
    }
}
