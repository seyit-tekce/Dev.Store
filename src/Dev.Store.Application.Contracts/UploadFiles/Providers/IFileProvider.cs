using Dev.Store.UploadFiles.Dtos;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dev.Store.UploadFiles.Providers
{
    public interface IFileProvider
    {
        public Task<UploadFileDto> GetFileAsync(string path);

        public Task<IEnumerable<UploadFileDto>> CreateAsync(IEnumerable<IFormFile> files);

        public Task DeleteAsync(string path);
    }
}