using System;
using Volo.Abp.Domain.Repositories;

namespace Dev.Store.Category;

public interface ICategoryRepository : IRepository<Category, Guid>
{
}
