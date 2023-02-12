using Dev.Store.UploadFiles.Dtos;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Dev.Store.UploadFiles.Providers
{
    public class LocalFileProvider : ILocalFileProvider
    {
        public async Task<IEnumerable<UploadFileDto>> CreateAsync(IEnumerable<IFormFile> files)
        {
            string folderPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Files");
            if (!files.Any()) throw new NullReferenceException();
            if (!Directory.Exists(folderPath))
            {
                if (!Directory.CreateDirectory(folderPath).Exists)
                {
                    Directory.CreateDirectory(folderPath).Create();
                }
            }

            var rObject = new List<UploadFileDto>();

            foreach (var file in files)
            {
                var uniqueFileName = GetUniqueFileName(file.FileName);
                var filePath = Path.Combine(folderPath, uniqueFileName);
                using (var fs = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(fs);
                }

                rObject.Add(new UploadFileDto
                {
                    FileName = uniqueFileName,
                    FilePath = filePath
                });
            }
            return rObject;
        }

        public async Task DeleteAsync(string path)
        {

            if (!File.Exists(path))
            {
                throw new NullReferenceException(path);
            }
            try
            {
                File.Delete(path);
            }
            catch (IOException e)
            {
                Console.WriteLine($"File could not be deleted:");
                Console.WriteLine(e.Message);
                throw e;
            }
          
            await Task.CompletedTask;
        }

        public Task<UploadFileDto> GetFileAsync(string path)
        {
            throw new NotImplementedException();
        }
        private static string GetUniqueFileName(string fileName)
        {
            fileName = Path.GetFileName(fileName);
            return Path.GetFileNameWithoutExtension(fileName)
                      + "_"
                      + Guid.NewGuid().ToString().Substring(0, 4)
                      + Path.GetExtension(fileName);
        }
    }
}