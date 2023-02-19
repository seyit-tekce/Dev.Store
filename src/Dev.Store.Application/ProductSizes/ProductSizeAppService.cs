using System;
using System.Linq;
using System.Threading.Tasks;
using Dev.Store.Permissions;
using Dev.Store.ProductSizes.Dtos;
using Volo.Abp.Application.Services;

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

}
