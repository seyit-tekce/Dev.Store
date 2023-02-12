using Microsoft.AspNetCore.Http;
using System;

namespace Dev.Store.UploadFiles.Dtos;

[Serializable]
public class CreateUpdateUploadFileDto
{
    public IFormFile File { get; set; }
    public string Description { get; set; }
}