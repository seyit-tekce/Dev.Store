using System;
using System.Linq;
using System.Threading.Tasks;
using Dev.Store.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Dev.Store.UploadFiles;

public class UploadFileRepository : EfCoreRepository<StoreDbContext, UploadFile, Guid>, IUploadFileRepository
{
    public UploadFileRepository(IDbContextProvider<StoreDbContext> dbContextProvider) : base(dbContextProvider)
    {
    }

    public override async Task<IQueryable<UploadFile>> WithDetailsAsync()
    {
        return (await GetQueryableAsync()).IncludeDetails();
    }
}