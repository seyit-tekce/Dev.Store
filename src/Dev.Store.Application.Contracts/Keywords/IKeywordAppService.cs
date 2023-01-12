using System;
using Dev.Store.Keywords.Dtos;
using Volo.Abp.Application.Services;

namespace Dev.Store.Keywords;

public interface IKeywordAppService :
    ICrudAppService< 
        KeywordDto, 
        Guid, 
        KeywordGetListInput,
        CreateUpdateKeywordDto,
        CreateUpdateKeywordDto>
{

}