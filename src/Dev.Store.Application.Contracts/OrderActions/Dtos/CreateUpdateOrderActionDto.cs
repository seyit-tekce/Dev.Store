using System;

namespace Dev.Store.OrderActions.Dtos;

[Serializable]
public class CreateUpdateOrderActionDto
{
    /// <summary>
    /// 
    /// </summary>
    public Guid OrderId { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public OrderActionStatus Status { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public string Note { get; set; }
}