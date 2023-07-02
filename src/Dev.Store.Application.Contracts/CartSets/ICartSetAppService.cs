using System;
using Dev.Store.CartSets.Dtos;
using Volo.Abp.Application.Services;

namespace Dev.Store.CartSets;


/// <summary>
/// 
/// </summary>
public interface ICartSetAppService :
    ICrudAppService< 
        CartSetDto, 
        Guid, 
        CartSetGetListInput,
        CreateUpdateCartSetDto,
        CreateUpdateCartSetDto>
{

}