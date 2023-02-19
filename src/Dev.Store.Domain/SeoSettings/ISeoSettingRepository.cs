using System;
using Volo.Abp.Domain.Repositories;

namespace Dev.Store.SeoSettings;

public interface ISeoSettingRepository : IRepository<SeoSetting, Guid>
{
}
