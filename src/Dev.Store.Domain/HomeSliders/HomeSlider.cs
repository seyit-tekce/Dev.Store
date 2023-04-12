using Dev.Store.UploadFiles;
using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace Dev.Store.HomeSliders
{
    public class HomeSlider:FullAuditedEntity<Guid>
    {
        public virtual Guid UploadFileId { get; set; }
        public virtual string Title { get; set; }
        public virtual string Subtitle { get; set; }
        public virtual string ButtonLink { get; set; }
        public virtual string ButtonText { get; set; }
        public virtual int Order { get; set; }
        public virtual HomeSliderType Type { get; set; }

        public UploadFile UploadFile { get; set; }

    protected HomeSlider()
    {
    }

    public HomeSlider(
        Guid id,
        Guid uploadFileId,
        string title,
        string subtitle,
        string buttonLink,
        string buttonText,
        int order,
        HomeSliderType type,
        UploadFile uploadFile
    ) : base(id)
    {
        UploadFileId = uploadFileId;
        Title = title;
        Subtitle = subtitle;
        ButtonLink = buttonLink;
        ButtonText = buttonText;
        Order = order;
        Type = type;
        UploadFile = uploadFile;
    }
    }
}
