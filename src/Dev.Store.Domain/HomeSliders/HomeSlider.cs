using System;

namespace Dev.Store.HomeSliders
{
    public class HomeSlider
    {
        public Guid UploadFile { get; set; }
        public string Title { get; set; }
        public string Subtitle { get; set; }
        public string ButtonLink { get; set; }
        public string ButtonText { get; set; }
        public int Order { get; set; }
        public HomeSliderType Type { get; set; }
    }
}