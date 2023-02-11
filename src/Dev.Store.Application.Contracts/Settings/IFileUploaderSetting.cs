using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace Dev.Store.Settings
{
    public interface IFileUploaderSettingAppService : IApplicationService
    {
        public Task<FileUploaderSettingDto> GetAsync();
        public Task<FileUploaderSettingDto> UpdateAsync(FileUploaderSettingDto input);

    }
}
