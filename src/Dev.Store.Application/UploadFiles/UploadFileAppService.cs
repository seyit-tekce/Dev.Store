using System;
using System.Linq;
using System.Threading.Tasks;
using Dev.Store.Permissions;
using Dev.Store.UploadFiles.Dtos;
using Volo.Abp.Application.Services;

namespace Dev.Store.UploadFiles;


public class UploadFileAppService : CrudAppService<UploadFile, UploadFileDto, Guid, UploadFileGetListInput, CreateUpdateUploadFileDto, CreateUpdateUploadFileDto>,
    IUploadFileAppService
{
    protected override string GetPolicyName { get; set; } = StorePermissions.UploadFile.Default;
    protected override string GetListPolicyName { get; set; } = StorePermissions.UploadFile.Default;
    protected override string CreatePolicyName { get; set; } = StorePermissions.UploadFile.Create;
    protected override string UpdatePolicyName { get; set; } = StorePermissions.UploadFile.Update;
    protected override string DeletePolicyName { get; set; } = StorePermissions.UploadFile.Delete;

    private readonly IUploadFileRepository _repository;

    public UploadFileAppService(IUploadFileRepository repository) : base(repository)
    {
        _repository = repository;
    }

    protected override async Task<IQueryable<UploadFile>> CreateFilteredQueryAsync(UploadFileGetListInput input)
    {
        // TODO: AbpHelper generated
        return (await base.CreateFilteredQueryAsync(input))
            .WhereIf(!input.FileName.IsNullOrWhiteSpace(), x => x.FileName.Contains(input.FileName))
            .WhereIf(!input.FilePath.IsNullOrWhiteSpace(), x => x.FilePath.Contains(input.FilePath))
            .WhereIf(!input.PublicId.IsNullOrWhiteSpace(), x => x.PublicId.Contains(input.PublicId))
            .WhereIf(!input.Description.IsNullOrWhiteSpace(), x => x.Description.Contains(input.Description))
            ;
    }
}
