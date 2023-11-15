using System;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Dev.Store.Categories;

public interface ICategoryRepository : IRepository<Category, Guid>
{
    Task<Category> GetCategoryWithChildrenById(Guid categoryId);
    public Task<Category> GetCategoryWithFileByLinkAndParentId(string name, Guid? parentId);
}
