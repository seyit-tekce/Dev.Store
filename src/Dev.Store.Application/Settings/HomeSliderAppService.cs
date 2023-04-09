using Dev.Store.UploadFiles;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.SettingManagement;

namespace Dev.Store.Settings
{
    public class HomeSliderAppService : ApplicationService, IHomeSliderAppService
    {
        protected ISettingManager _settingManager { get; }
        private readonly IUploadFileAppService _uploadFileAppService;

        public HomeSliderAppService(ISettingManager settingManager, IUploadFileAppService uploadFileAppService)
        {
            _settingManager = settingManager;
            _uploadFileAppService = uploadFileAppService;
        }

        public async Task<IEnumerable<HomeSliderSettingDto>> GetAsync()
        {
            var data = await SettingProvider.GetOrNullAsync(StoreSettings.HomeSliderSettings);
            if (string.IsNullOrEmpty(data))
            {
                return new List<HomeSliderSettingDto>();
            }
            return JsonSerializer.Deserialize<IEnumerable<HomeSliderSettingDto>>(data);
        }

        public async Task UpdateAsync([FromForm] HomeSliderSettingUpdateDto[] files)
        {
            var list = new List<HomeSliderSettingDto>();

            //foreach (var item in files)
            //{
            //    if (item.Image != null)
            //    {
            //        var result = await _uploadFileAppService.CreateAsync(new UploadFiles.Dtos.CreateUpdateUploadFileDto
            //        {
            //            File = item.Image,
            //        });
            //        list.Add(new HomeSliderSettingDto
            //        {
            //            ButtonLink = item.ButtonLink,
            //            ButtonText = item.ButtonText,
            //            Image = result.Big(),
            //            SubTitle = item.SubTitle,
            //            Title = item.Title
            //        });
            //    }
            //}
            await _settingManager.SetGlobalAsync(StoreSettings.HomeSliderSettings, JsonSerializer.Serialize(list));
        }

    }
}