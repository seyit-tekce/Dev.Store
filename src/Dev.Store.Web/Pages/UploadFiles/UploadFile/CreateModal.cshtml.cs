using Dev.Store.UploadFiles;
using Dev.Store.UploadFiles.Dtos;
using Dev.Store.Web.Pages.UploadFiles.UploadFile.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Dev.Store.Web.Pages.UploadFiles.UploadFile;

public class CreateModalModel : StorePageModel
{
    [BindProperty]
    public CreateEditUploadFileViewModel ViewModel { get; set; }

    private readonly IUploadFileAppService _service;

    public CreateModalModel(IUploadFileAppService service)
    {
        _service = service;
    }

    public virtual async Task<IActionResult> OnPostAsync()
    {
        var dto = ObjectMapper.Map<CreateEditUploadFileViewModel, CreateUpdateUploadFileDto>(ViewModel);
        await _service.CreateAsync(dto);
        return NoContent();
    }
}