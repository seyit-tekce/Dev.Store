using System;
using Volo.Abp.Application.Dtos;

namespace Dev.Store.OrderActions.Dtos;

/// <summary>
/// 
/// </summary>
[Serializable]
public class OrderActionDto : FullAuditedEntityDto<Guid>
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