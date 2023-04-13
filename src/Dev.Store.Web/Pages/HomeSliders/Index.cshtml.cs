using Dev.Store.HomeSliders;
using Dev.Store.HomeSliders.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dev.Store.Web.Pages.HomeSliders;

public class IndexModel : StorePageModel
{
    private readonly IHomeSliderAppService homeSliderAppService;
    public IEnumerable<HomeSliderDto> HomeSliders { get; set; }
    public IndexModel(IHomeSliderAppService homeSliderAppService)
    {
        this.homeSliderAppService = homeSliderAppService;
    }

    public virtual async Task OnGetAsync()
    {
        HomeSliders = await homeSliderAppService.GetListByType(HomeSliderType.HomeSlider);
        await Task.CompletedTask;
    }
}
