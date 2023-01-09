using System;
using Volo.Abp.Domain.Repositories;

namespace Dev.Store.Categories;

public interface ICategoryRepository : IRepository<Category, Guid>
{
}
