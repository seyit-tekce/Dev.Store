using Dev.Store.HomeSliders;
using Dev.Store.HomeSliders.Dtos;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dev.Store.Web.Pages.HomeSliders;

public class IndexModel : StorePageModel
{
    private readonly IHomeSliderAppService homeSliderAppService;
    public IEnumerable<HomeSliderDto> HomeSliders { get; set; }

    [BindProperty(SupportsGet =true)]
    public HomeSliderType Type { get; set; }
    public IndexModel(IHomeSliderAppService homeSliderAppService)
    {
        this.homeSliderAppService = homeSliderAppService;
    }

    public virtual async Task OnGetAsync()
    {
        HomeSliders = await homeSliderAppService.GetListByType(Type);
        await Task.CompletedTask;
    }
}
