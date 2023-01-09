using Dev.Store.Locations;
using Dev.Store.Locations.Dtos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Dev.Store.Web.Pages.Locations;

public class IndexModel : StorePageModel
{
    [BindProperty(SupportsGet = true)]
    public Guid? Id { get; set; }

    private readonly ILocationAppService locationAppService;

    public IndexModel(ILocationAppService locationAppService)
    {
        this.locationAppService = locationAppService;
    }

    public LocationDto Location { get; set; }

    public virtual async Task OnGetAsync()
    {
        if (this.Id.HasValue)
        {
            this.Location = await locationAppService.GetAsync(this.Id.Value);
        }
        await Task.CompletedTask;
    }
}

