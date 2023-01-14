using System;
using Volo.Abp.Application.Dtos;

namespace Dev.Store.Keywords.Dtos;

[Serializable]
public class KeywordGetListInput : PagedAndSortedResultRequestDto
{
    public string Name { get; set; }
}