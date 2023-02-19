using Dev.Store.Permissions;
using Dev.Store.ProductSets.Dtos;
using System;
using Volo.Abp.Application.Services;

namespace Dev.Store.ProductSets;


public class ProductSetAppService : CrudAppService<ProductSet, ProductSetDto, Guid, ProductSetGetListInput, CreateUpdateProductSetDto, CreateUpdateProductSetDto>,
    IProductSetAppService
{
    protected override string GetPolicyName { get; set; } = StorePermissions.ProductSet.Default;
    protected override string GetListPolicyName { get; set; } = StorePermissions.ProductSet.Default;
    protected override string CreatePolicyName { get; set; } = StorePermissions.ProductSet.Create;
    protected override string UpdatePolicyName { get; set; } = StorePermissions.ProductSet.Update;
    protected override string DeletePolicyName { get; set; } = StorePermissions.ProductSet.Delete;

    private readonly IProductSetRepository _repository;

    public ProductSetAppService(IProductSetRepository repository) : base(repository)
    {
        _repository = repository;
    }
}
