using System;

namespace Dev.Store.UploadFiles.Dtos;

[Serializable]
public class CreateUpdateUploadFileDto
{
    public string FileName { get; set; }

    public string FilePath { get; set; }

    public string PublicId { get; set; }

    public string Description { get; set; }
}