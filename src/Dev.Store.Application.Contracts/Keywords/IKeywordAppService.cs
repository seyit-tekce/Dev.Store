using Dev.Store.Keywords.Dtos;
using Kendo.Mvc.UI;
using System;
using System.Threading.Tasks;
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
    Task<DataSourceResult> DataSource(DataSourceRequest request);
}