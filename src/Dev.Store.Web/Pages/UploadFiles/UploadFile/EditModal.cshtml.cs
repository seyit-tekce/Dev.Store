using Dev.Store.UploadFiles;
using Dev.Store.UploadFiles.Dtos;
using Dev.Store.Web.Pages.UploadFiles.UploadFile.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Dev.Store.Web.Pages.UploadFiles.UploadFile;

public class EditModalModel : StorePageModel
{
    [HiddenInput]
    [BindProperty(SupportsGet = true)]
    public Guid Id { get; set; }

    [BindProperty]
    public CreateEditUploadFileViewModel ViewModel { get; set; }

    private readonly IUploadFileAppService _service;

    public EditModalModel(IUploadFileAppService service)
    {
        _service = service;
    }

    public virtual async Task OnGetAsync()
    {
        var dto = await _service.GetAsync(Id);
        ViewModel = ObjectMapper.Map<UploadFileDto, CreateEditUploadFileViewModel>(dto);
    }

    public virtual async Task<IActionResult> OnPostAsync()
    {
        var dto = ObjectMapper.Map<CreateEditUploadFileViewModel, CreateUpdateUploadFileDto>(ViewModel);
        await _service.UpdateAsync(Id, dto);
        return NoContent();
    }
}