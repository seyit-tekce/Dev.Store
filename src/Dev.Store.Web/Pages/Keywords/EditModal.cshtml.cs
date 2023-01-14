using Dev.Store.Keywords;
using Dev.Store.Keywords.Dtos;
using Dev.Store.Web.Pages.Keywords.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Dev.Store.Web.Pages.Keywords;

public class EditModalModel : StorePageModel
{
    [HiddenInput]
    [BindProperty(SupportsGet = true)]
    public Guid Id { get; set; }

    [BindProperty]
    public CreateEditKeywordViewModel ViewModel { get; set; }

    private readonly IKeywordAppService _service;

    public EditModalModel(IKeywordAppService service)
    {
        _service = service;
    }

    public virtual async Task OnGetAsync()
    {
        var dto = await _service.GetAsync(Id);
        ViewModel = ObjectMapper.Map<KeywordDto, CreateEditKeywordViewModel>(dto);
    }

    public virtual async Task<IActionResult> OnPostAsync()
    {
        var dto = ObjectMapper.Map<CreateEditKeywordViewModel, CreateUpdateKeywordDto>(ViewModel);
        await _service.UpdateAsync(Id, dto);
        return NoContent();
    }
}