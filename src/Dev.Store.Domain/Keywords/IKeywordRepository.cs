using System;
using Volo.Abp.Domain.Repositories;

namespace Dev.Store.Keywords;

public interface IKeywordRepository : IRepository<Keyword, Guid>
{
}
