using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Dev.Store.Keywords;
using Dev.Store.Keywords.Dtos;
using Dev.Store.Web.Pages.Keywords.Keyword.ViewModels;

namespace Dev.Store.Web.Pages.Keywords.Keyword;

public class CreateModalModel : StorePageModel
{
    [BindProperty]
    public CreateEditKeywordViewModel ViewModel { get; set; }

    private readonly IKeywordAppService _service;

    public CreateModalModel(IKeywordAppService service)
    {
        _service = service;
    }

    public virtual async Task<IActionResult> OnPostAsync()
    {
        var dto = ObjectMapper.Map<CreateEditKeywordViewModel, CreateUpdateKeywordDto>(ViewModel);
        await _service.CreateAsync(dto);
        return NoContent();
    }
}