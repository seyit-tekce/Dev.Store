using System;
using Volo.Abp.Domain.Repositories;

namespace Dev.Store.HomeSliders;

public interface IHomeSliderRepository : IRepository<HomeSlider, Guid>
{
}
