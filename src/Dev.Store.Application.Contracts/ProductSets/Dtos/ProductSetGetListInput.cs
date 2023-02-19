using System;
using System.ComponentModel;
using Volo.Abp.Application.Dtos;

namespace Dev.Store.ProductSets.Dtos;

[Serializable]
public class ProductSetGetListInput : PagedAndSortedResultRequestDto
{
    public int? ProductId { get; set; }


    public double? Price { get; set; }

    public int? Amount { get; set; }

    public bool? IsOptional { get; set; }
}