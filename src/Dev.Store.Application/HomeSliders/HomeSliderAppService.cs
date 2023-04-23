using Dev.Store.HomeSliders.Dtos;
using Dev.Store.Permissions;
using Dev.Store.UploadFiles;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Services;
using Volo.Abp.Caching;
using Volo.Abp.Validation;

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
    private readonly IDistributedCache<IEnumerable<HomeSliderDto>, HomeSliderType> _cache;

    public HomeSliderAppService(IHomeSliderRepository repository, IUploadFileAppService uploadFileAppService, IDistributedCache<IEnumerable<HomeSliderDto>, HomeSliderType> cache) : base(repository)
    {
        _repository = repository;
        _uploadFileAppService = uploadFileAppService;
        _cache = cache;
    }

    [IgnoreAntiforgeryToken(Order = 2000)]
    [HttpPost]
    [DisableValidation]
    public override async Task<HomeSliderDto> CreateAsync([FromForm] CreateUpdateHomeSliderDto input)
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
        var result = ObjectMapper.Map<HomeSlider, HomeSliderDto>(await _repository.InsertAsync(map)); 
        await _cache.RefreshAsync(input.Type);


        return result;
    }

    public async Task<IEnumerable<HomeSliderDto>> GetListByType(HomeSliderType type)
    {
        return await _cache.GetOrAddAsync(type, async () =>
        {
            return ObjectMapper.Map<IEnumerable<HomeSlider>, IEnumerable<HomeSliderDto>>((await _repository.WithDetailsAsync(type)));
        }, () => new DistributedCacheEntryOptions
        {
            AbsoluteExpiration = DateTimeOffset.Now.AddHours(1)
        });
    }
}