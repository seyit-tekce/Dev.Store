using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Dev.Store.SeoSettings;
using Dev.Store.SeoSettings.Dtos;
using Dev.Store.Web.Pages.SeoSettings.SeoSetting.ViewModels;

namespace Dev.Store.Web.Pages.SeoSettings.SeoSetting;

public class EditModalModel : StorePageModel
{
    [HiddenInput]
    [BindProperty(SupportsGet = true)]
    public Guid Id { get; set; }

    [BindProperty]
    public CreateEditSeoSettingViewModel ViewModel { get; set; }

    private readonly ISeoSettingAppService _service;

    public EditModalModel(ISeoSettingAppService service)
    {
        _service = service;
    }

    public virtual async Task OnGetAsync()
    {
        var dto = await _service.GetAsync(Id);
        ViewModel = ObjectMapper.Map<SeoSettingDto, CreateEditSeoSettingViewModel>(dto);
    }

    public virtual async Task<IActionResult> OnPostAsync()
    {
        var dto = ObjectMapper.Map<CreateEditSeoSettingViewModel, CreateUpdateSeoSettingDto>(ViewModel);
        await _service.UpdateAsync(Id, dto);
        return NoContent();
    }
}