using Dev.Store.Permissions;
using Dev.Store.Settings;
using Dev.Store.UploadFiles.Dtos;
using Dev.Store.UploadFiles.Providers;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
    private IFileProvider fileProvider;
    private readonly IFileUploaderSettingAppService _fileUploaderSettingAppService;

    public UploadFileAppService(IUploadFileRepository repository, IFileUploaderSettingAppService fileUploaderSettingAppService) : base(repository)
    {
        _repository = repository;
        _fileUploaderSettingAppService = fileUploaderSettingAppService;
    }

    public override async Task<UploadFileDto> CreateAsync(CreateUpdateUploadFileDto input)
    {
        var getFileSetting = await _fileUploaderSettingAppService.GetAsync();
        if (getFileSetting.FileSettingCloudinaryEnabled && input.File.ContentType.ToLower().Contains("image"))
        {
            fileProvider = new CloudinaryFileProvider(_fileUploaderSettingAppService);
        }
        else
        {
            fileProvider = new LocalFileProvider();
        }
        var fileResult = (await fileProvider.CreateAsync(new List<IFormFile> { input.File })).FirstOrDefault();
        var rResult = await _repository.InsertAsync(new UploadFile
        {
            FileName = fileResult.FileName,
            FilePath = fileResult.FilePath,
            PublicId = fileResult.PublicId,
        });
        return ObjectMapper.Map<UploadFile, UploadFileDto>(rResult);
    }
    public override async Task DeleteAsync(Guid id)
    {
        var getFileSetting = await _fileUploaderSettingAppService.GetAsync();
        var file = await _repository.GetAsync(id);
        if (getFileSetting.FileSettingCloudinaryEnabled)
        {
            fileProvider = new CloudinaryFileProvider(_fileUploaderSettingAppService);
            await fileProvider.DeleteAsync(file.PublicId);
        }
        else
        {
            fileProvider = new LocalFileProvider();
            await fileProvider.DeleteAsync(file.FilePath);

        }
        await base.DeleteAsync(id);
    }
}