using System;
using Dev.Store.UploadFiles.Dtos;
using Volo.Abp.Application.Services;

namespace Dev.Store.UploadFiles;

public interface IUploadFileAppService :
    ICrudAppService< 
        UploadFileDto, 
        Guid, 
        UploadFileGetListInput,
        CreateUpdateUploadFileDto,
        CreateUpdateUploadFileDto>
{

}