using System;
using System.ComponentModel;
using Volo.Abp.Application.Dtos;

namespace Dev.Store.OrderActions.Dtos;

[Serializable]
public class OrderActionGetListInput : PagedAndSortedResultRequestDto
{
    /// <summary>
    /// 
    /// </summary>
    public Guid? OrderId { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public OrderActionStatus? Status { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public string Note { get; set; }
}