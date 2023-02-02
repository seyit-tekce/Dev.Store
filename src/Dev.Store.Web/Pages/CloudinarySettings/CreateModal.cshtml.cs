using Dev.Store.CloudinarySettings;
using Dev.Store.CloudinarySettings.Dtos;
using Dev.Store.Web.Pages.CloudinarySettings.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Dev.Store.Web.Pages.CloudinarySettings;

public class CreateModalModel : StorePageModel
{
    [BindProperty]
    public CreateEditCloudinarySettingViewModel ViewModel { get; set; }

    private readonly ICloudinarySettingAppService _service;

    public CreateModalModel(ICloudinarySettingAppService service)
    {
        _service = service;
    }

    public virtual async Task<IActionResult> OnPostAsync()
    {
        var dto = ObjectMapper.Map<CreateEditCloudinarySettingViewModel, CreateUpdateCloudinarySettingDto>(ViewModel);
        await _service.CreateAsync(dto);
        return NoContent();
    }
}