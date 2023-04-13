using System;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Dev.Store.HomeSliders;

public interface IHomeSliderRepository : IRepository<HomeSlider, Guid>
{
    Task<IQueryable<HomeSlider>> WithDetailsAsync(HomeSliderType type);
}
