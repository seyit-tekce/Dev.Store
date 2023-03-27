using Dev.Store.Permissions;
using Dev.Store.ProductSizes.Dtos;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace Dev.Store.ProductSizes;


public class ProductSizeAppService : CrudAppService<ProductSize, ProductSizeDto, Guid, ProductSizeGetListInput, CreateUpdateProductSizeDto, CreateUpdateProductSizeDto>,
    IProductSizeAppService
{
    protected override string GetPolicyName { get; set; } = StorePermissions.ProductSize.Default;
    protected override string GetListPolicyName { get; set; } = StorePermissions.ProductSize.Default;
    protected override string CreatePolicyName { get; set; } = StorePermissions.ProductSize.Create;
    protected override string UpdatePolicyName { get; set; } = StorePermissions.ProductSize.Update;
    protected override string DeletePolicyName { get; set; } = StorePermissions.ProductSize.Delete;

    private readonly IProductSizeRepository _repository;

    public ProductSizeAppService(IProductSizeRepository repository) : base(repository)
    {
        _repository = repository;
    }
    [HttpGet]
    [Authorize(StorePermissions.ProductSize.Default)]
    public async Task<DataSourceResult> DataSource([DataSourceRequest] DataSourceRequest request)
    {
        return (await _repository.GetQueryableAsync()).ToDataSourceResult(request, x => ObjectMapper.Map<ProductSize, ProductSizeDto>(x));
    }

    public override async Task<ProductSizeDto> CreateAsync(CreateUpdateProductSizeDto input)
    {
        var codeExist = await _repository.AnyAsync(x => x.Code == input.Code && x.ProductId == input.ProductId);
        if (codeExist)
        {
            throw new UserFriendlyException("Daha önce ayný kod girilmiþtir");
        }

        var findMaster = await _repository.FindAsync(x => x.IsDefault);
        if (findMaster != null && input.IsDefault)
        {
            findMaster.IsDefault = false;
            await _repository.UpdateAsync(findMaster);
        }

        return await base.CreateAsync(input);
    }

    public override async Task<ProductSizeDto> UpdateAsync(Guid id, CreateUpdateProductSizeDto input)
    {
        var codeExist = await _repository.AnyAsync(x => x.Code == input.Code && x.ProductId == input.ProductId && x.Id != id);
        if (codeExist)
        {
            throw new UserFriendlyException("Daha önce ayný kod girilmiþtir");
        }
        return await base.UpdateAsync(id, input);
    }

}
