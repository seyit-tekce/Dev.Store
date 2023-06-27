using Dev.Store.Orders;
using System;
using System.ComponentModel.DataAnnotations;

namespace Dev.Store.Web.Pages.Orders.Order.ViewModels;

public class CreateEditOrderViewModel
{
    [Display(Name = "OrderCode")]
    public string Code { get; set; }

    [Display(Name = "OrderUserId")]
    public Guid UserId { get; set; }

    [Display(Name = "OrderOrderAddressId")]
    public Guid OrderAddressId { get; set; }

    [Display(Name = "OrderMethod")]
    public OrderMethod Method { get; set; }

}
