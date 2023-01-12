using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace Dev.Store.SeoSettings
{
    public class SeoSetting:FullAuditedEntity<Guid>
    {
        public string SiteTitle { get; set; }
        public string SiteDescription { get; set; }
        public string KeyWords { get; set; }
        public int ProductId { get; set; }

    }
}
