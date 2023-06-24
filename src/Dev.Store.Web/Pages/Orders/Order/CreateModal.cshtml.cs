using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Dev.Store.Orders;
using Dev.Store.Orders.Dtos;
using Dev.Store.Web.Pages.Orders.Order.ViewModels;

namespace Dev.Store.Web.Pages.Orders.Order;

public class CreateModalModel : StorePageModel
{
    [BindProperty]
    public CreateEditOrderViewModel ViewModel { get; set; }

    private readonly IOrderAppService _service;

    public CreateModalModel(IOrderAppService service)
    {
        _service = service;
    }

    public virtual async Task<IActionResult> OnPostAsync()
    {
        var dto = ObjectMapper.Map<CreateEditOrderViewModel, CreateUpdateOrderDto>(ViewModel);
        await _service.CreateAsync(dto);
        return NoContent();
    }
}