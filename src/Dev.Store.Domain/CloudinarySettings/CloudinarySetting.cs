using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace Dev.Store.CloudinarySettings
{
    public class CloudinarySetting : FullAuditedEntity<Guid>
    {
        public virtual string CloudName { get; set; }
        public virtual string ApiKey { get; set; }
        public virtual string ApiSecret { get; set; }
        public virtual bool IsEnabled { get; set; }

    protected CloudinarySetting()
    {
    }

    public CloudinarySetting(
        Guid id,
        string cloudName,
        string apiKey,
        string apiSecret,
        bool isEnabled
    ) : base(id)
    {
        CloudName = cloudName;
        ApiKey = apiKey;
        ApiSecret = apiSecret;
        IsEnabled = isEnabled;
    }
    }
}
