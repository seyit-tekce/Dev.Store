using Dev.Store.Keywords.Dtos;
using Dev.Store.Permissions;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace Dev.Store.Keywords;


public class KeywordAppService : CrudAppService<Keyword, KeywordDto, Guid, KeywordGetListInput, CreateUpdateKeywordDto, CreateUpdateKeywordDto>,
    IKeywordAppService
{
    protected override string GetPolicyName { get; set; } = StorePermissions.Keyword.Default;
    protected override string GetListPolicyName { get; set; } = StorePermissions.Keyword.Default;
    protected override string CreatePolicyName { get; set; } = StorePermissions.Keyword.Create;
    protected override string UpdatePolicyName { get; set; } = StorePermissions.Keyword.Update;
    protected override string DeletePolicyName { get; set; } = StorePermissions.Keyword.Delete;

    private readonly IKeywordRepository _repository;

    public KeywordAppService(IKeywordRepository repository) : base(repository)
    {
        _repository = repository;
    }

    protected override async Task<IQueryable<Keyword>> CreateFilteredQueryAsync(KeywordGetListInput input)
    {
        // TODO: AbpHelper generated
        return (await base.CreateFilteredQueryAsync(input))
            .WhereIf(!input.Name.IsNullOrWhiteSpace(), x => x.Name.Contains(input.Name))
            ;
    }
    [HttpGet]
    [Authorize(StorePermissions.Category.Default)]
    public async Task<DataSourceResult> DataSource([DataSourceRequest] DataSourceRequest request)
    {
        return (await _repository.GetQueryableAsync()).ToDataSourceResult(request, x => ObjectMapper.Map<Keyword, KeywordDto>(x));
    }
}
