using Dev.Store.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Dev.Store.Categories;

public class CategoryRepository : EfCoreRepository<StoreDbContext, Category, Guid>, ICategoryRepository
{
    public CategoryRepository(IDbContextProvider<StoreDbContext> dbContextProvider) : base(dbContextProvider)
    {
    }

    public async Task<Category> GetCategoryWithFileByLinkAndParentId(string name, Guid? parentId)
    {
        return await (await GetQueryableAsync()).Include(x => x.File).Where(x => x.Link == name && x.CategoryParentId == parentId).FirstOrDefaultAsync();
    }

    public override async Task<IQueryable<Category>> WithDetailsAsync()
    {
        return (await GetQueryableAsync()).Include(x => x.CategoryChildren).Include(a => a.CategoryParent);
    }
}