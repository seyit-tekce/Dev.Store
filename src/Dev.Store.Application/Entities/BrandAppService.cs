using Dev.Store.Dtos;
using Dev.Store.Localization;
using Dev.Store.Permissions;
using Dev.Store.Repositories;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using System;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace Dev.Store.Entities;

public class BrandAppService : CrudAppService<Brand, BrandDto, Guid, PagedAndSortedResultRequestDto, CreateUpdateBrandDto, CreateUpdateBrandDto>,
    IBrandAppService
{
    protected override string GetPolicyName { get; set; } = StorePermissions.Brand.Default;
    protected override string GetListPolicyName { get; set; } = StorePermissions.Brand.Default;
    protected override string CreatePolicyName { get; set; } = StorePermissions.Brand.Create;
    protected override string UpdatePolicyName { get; set; } = StorePermissions.Brand.Update;
    protected override string DeletePolicyName { get; set; } = StorePermissions.Brand.Delete;

    private readonly IBrandRepository _repository;
    private IStringLocalizer<StoreResource> L { get; }


    public BrandAppService(IBrandRepository repository, IStringLocalizer<StoreResource> l) : base(repository)
    {
        _repository = repository;
        L = l;
    }

    [HttpGet]
    public async Task<DataSourceResult> DataSource([DataSourceRequest] DataSourceRequest request)
    {
        return (await _repository.GetQueryableAsync()).ToDataSourceResult(request, x => ObjectMapper.Map<Brand, BrandDto>(x));
    }

    public override async Task<BrandDto> CreateAsync(CreateUpdateBrandDto input)
    {
        var isExist = await _repository.AnyAsync(x => x.Code == input.Code);
        if (isExist)
        {
            throw new UserFriendlyException(L["BrandCodeExist"]);

        }
        return await base.CreateAsync(input);
    }
    public async override Task<BrandDto> UpdateAsync(Guid id, CreateUpdateBrandDto input)
    {
        var isExist = await _repository.AnyAsync(x => x.Code == input.Code && x.Id != id);
        if (isExist)
        {
            throw new UserFriendlyException(L["BrandCodeExist"]);

        }
        return await base.UpdateAsync(id, input);
    }

}