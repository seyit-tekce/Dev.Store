using Dev.Store.UploadFiles.Dtos;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Dev.Store.FileUploaders
{
    public interface IFileUploader
    {
        Task UploadFileAsync(IFormFile file);
        Task DeleteFileAsync(UploadFileDto file);
        
    }
}
