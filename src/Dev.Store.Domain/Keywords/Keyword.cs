using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace Dev.Store.Keywords
{
    public class Keyword : FullAuditedEntity<Guid>
    {
        public string Name { get; set; }

        protected Keyword()
        {
        }

        public Keyword(
            Guid id,
            string name
        ) : base(id)
        {
            Name = name;
        }
    }
}
