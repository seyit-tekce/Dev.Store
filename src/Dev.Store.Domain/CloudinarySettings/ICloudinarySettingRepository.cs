using System;
using Volo.Abp.Domain.Repositories;

namespace Dev.Store.CloudinarySettings;

public interface ICloudinarySettingRepository : IRepository<CloudinarySetting, Guid>
{
}
