using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Dev.Store.Orders;
using Dev.Store.Orders.Dtos;
using Dev.Store.Web.Pages.Orders.Order.ViewModels;

namespace Dev.Store.Web.Pages.Orders.Order;

public class EditModalModel : StorePageModel
{
    [HiddenInput]
    [BindProperty(SupportsGet = true)]
    public Guid Id { get; set; }

    [BindProperty]
    public CreateEditOrderViewModel ViewModel { get; set; }

    private readonly IOrderAppService _service;

    public EditModalModel(IOrderAppService service)
    {
        _service = service;
    }

    public virtual async Task OnGetAsync()
    {
        var dto = await _service.GetAsync(Id);
        ViewModel = ObjectMapper.Map<OrderDto, CreateEditOrderViewModel>(dto);
    }

    public virtual async Task<IActionResult> OnPostAsync()
    {
        var dto = ObjectMapper.Map<CreateEditOrderViewModel, CreateUpdateOrderDto>(ViewModel);
        await _service.UpdateAsync(Id, dto);
        return NoContent();
    }
}