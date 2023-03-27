using Dev.Store.SeoSettings;
using Dev.Store.SeoSettings.Dtos;
using Dev.Store.Web.Pages.SeoSettings.SeoSetting.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Dev.Store.Web.Pages.SeoSettings.SeoSetting;

public class CreateModalModel : StorePageModel
{
    [BindProperty]
    public CreateEditSeoSettingViewModel ViewModel { get; set; }

    private readonly ISeoSettingAppService _service;

    public CreateModalModel(ISeoSettingAppService service)
    {
        _service = service;
    }

    public virtual async Task<IActionResult> OnPostAsync()
    {
        var dto = ObjectMapper.Map<CreateEditSeoSettingViewModel, CreateUpdateSeoSettingDto>(ViewModel);
        await _service.CreateAsync(dto);
        return NoContent();
    }
}