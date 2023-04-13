using System;
using System.Linq;
using System.Threading.Tasks;
using Dev.Store.Permissions;
using Dev.Store.HomeSliders.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp;
using Dev.Store.UploadFiles;
using Volo.Abp.ObjectMapping;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Volo.Abp.Threading;
using Volo.Abp.Validation;
using System.Collections.Generic;

namespace Dev.Store.HomeSliders;


public class HomeSliderAppService : CrudAppService<HomeSlider, HomeSliderDto, Guid, HomeSliderGetListInput, CreateUpdateHomeSliderDto, CreateUpdateHomeSliderDto>,
    IHomeSliderAppService
{
    protected override string GetPolicyName { get; set; } = StorePermissions.HomeSlider.Default;
    protected override string GetListPolicyName { get; set; } = StorePermissions.HomeSlider.Default;
    protected override string CreatePolicyName { get; set; } = StorePermissions.HomeSlider.Create;
    protected override string UpdatePolicyName { get; set; } = StorePermissions.HomeSlider.Update;
    protected override string DeletePolicyName { get; set; } = StorePermissions.HomeSlider.Delete;

    private readonly IHomeSliderRepository _repository;
    private readonly IUploadFileAppService _uploadFileAppService;


    public HomeSliderAppService(IHomeSliderRepository repository, IUploadFileAppService uploadFileAppService) : base(repository)
    {
        _repository = repository;
        _uploadFileAppService = uploadFileAppService;
    }
    [IgnoreAntiforgeryToken(Order = 2000)]
    [HttpPost]
    [DisableValidation]
    public async override Task<HomeSliderDto> CreateAsync([FromForm] CreateUpdateHomeSliderDto input)
    {
        if (!input.File.ContentType.ToLower().Contains("image"))
        {
            throw new UserFriendlyException(L["FileIsNotImage"]);
        }
        var upload = await _uploadFileAppService.CreateAsync(new UploadFiles.Dtos.CreateUpdateUploadFileDto
        {
            File = input.File
        });

        var map = ObjectMapper.Map<CreateUpdateHomeSliderDto, HomeSlider>(input);
        map.UploadFileId = upload.Id;
        return ObjectMapper.Map<HomeSlider, HomeSliderDto>(await _repository.InsertAsync(map));


    }

    public async Task<IEnumerable<HomeSliderDto>> GetListByType(HomeSliderType type)
    {
        return ObjectMapper.Map<IEnumerable<HomeSlider>, IEnumerable<HomeSliderDto>>((await _repository.WithDetailsAsync(type)));
    }
}
