using Dev.Store.CloudinarySettings;
using Dev.Store.CloudinarySettings.Dtos;
using Dev.Store.Web.Pages.CloudinarySettings.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Dev.Store.Web.Pages.CloudinarySettings;

public class EditModalModel : StorePageModel
{
    [HiddenInput]
    [BindProperty(SupportsGet = true)]
    public Guid Id { get; set; }

    [BindProperty]
    public CreateEditCloudinarySettingViewModel ViewModel { get; set; }

    private readonly ICloudinarySettingAppService _service;

    public EditModalModel(ICloudinarySettingAppService service)
    {
        _service = service;
    }

    public virtual async Task OnGetAsync()
    {
        var dto = await _service.GetAsync(Id);
        ViewModel = ObjectMapper.Map<CloudinarySettingDto, CreateEditCloudinarySettingViewModel>(dto);
    }

    public virtual async Task<IActionResult> OnPostAsync()
    {
        var dto = ObjectMapper.Map<CreateEditCloudinarySettingViewModel, CreateUpdateCloudinarySettingDto>(ViewModel);
        await _service.UpdateAsync(Id, dto);
        return NoContent();
    }
}