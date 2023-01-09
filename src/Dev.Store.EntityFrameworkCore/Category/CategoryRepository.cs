using Dev.Store.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Dev.Store.Categories;

public class CategoryRepository : EfCoreRepository<StoreDbContext, Category, Guid>, ICategoryRepository
{
    public CategoryRepository(IDbContextProvider<StoreDbContext> dbContextProvider) : base(dbContextProvider)
    {
    }

    public override async Task<IQueryable<Category>> WithDetailsAsync()
    {
        return (await GetQueryableAsync()).IncludeDetails();
    }
}