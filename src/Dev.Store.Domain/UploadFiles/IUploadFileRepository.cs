using System;
using Volo.Abp.Domain.Repositories;

namespace Dev.Store.UploadFiles;

public interface IUploadFileRepository : IRepository<UploadFile, Guid>
{
}
