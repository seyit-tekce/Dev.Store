using Dev.Store.Permissions;
using Dev.Store.ProductImages.Dtos;
using Dev.Store.Products.Dtos;
using Dev.Store.UploadFiles;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net.WebSockets;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Services;

namespace Dev.Store.ProductImages;


public class ProductImageAppService : CrudAppService<ProductImage, ProductImageDto, Guid, ProductImageGetListInput, CreateUpdateProductImageDto, CreateUpdateProductImageDto>,
    IProductImageAppService
{
    protected override string GetPolicyName { get; set; } = StorePermissions.ProductImage.Default;
    protected override string GetListPolicyName { get; set; } = StorePermissions.ProductImage.Default;
    protected override string CreatePolicyName { get; set; } = StorePermissions.ProductImage.Create;
    protected override string UpdatePolicyName { get; set; } = StorePermissions.ProductImage.Update;
    protected override string DeletePolicyName { get; set; } = StorePermissions.ProductImage.Delete;

    private readonly IProductImageRepository _repository;
    private readonly IUploadFileAppService _uploadFileAppService;
    public ProductImageAppService(IProductImageRepository repository, IUploadFileAppService uploadFileAppService) : base(repository)
    {
        _repository = repository;
        _uploadFileAppService = uploadFileAppService;
    }
    [HttpGet]
    [Authorize(StorePermissions.ProductImage.Default)]
    public async Task<DataSourceResult> DataSource([DataSourceRequest] DataSourceRequest request)
    {
        return (await _repository.WithDetailsAsync(x => x.UploadFile)).ToDataSourceResult(request, x => ObjectMapper.Map<ProductImage, ProductImageDto>(x));
    }

    [HttpPost]
    [IgnoreAntiforgeryToken(Order = 2000)]
    public async Task Upload(IFormFile file, Guid productId)
    {
        if (!file.ContentType.ToLower().Contains("image"))
        {
            throw new UserFriendlyException(L["FileIsNotImage"]);
        }

        var upload = await _uploadFileAppService.CreateAsync(new UploadFiles.Dtos.CreateUpdateUploadFileDto
        {
            File = file
        });

        await _repository.InsertAsync(new ProductImage
        {
            ProductId = productId,
            UploadFileId = upload.Id,
            IsMain = false
        });

    }
    public override async Task DeleteAsync(Guid id)
    {
        var findRecord = await _repository.GetAsync(id);
        await _uploadFileAppService.DeleteAsync(findRecord.UploadFileId);
        await base.DeleteAsync(id);
    }


}
