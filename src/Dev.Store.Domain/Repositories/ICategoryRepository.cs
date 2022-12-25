using System;
using Dev.Store.Entities;
using Volo.Abp.Domain.Repositories;

namespace Dev.Store.Repositories;

public interface ICategoryRepository : IRepository<Category, Guid>
{
}
