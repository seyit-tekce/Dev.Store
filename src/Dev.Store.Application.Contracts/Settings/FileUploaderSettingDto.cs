using System.ComponentModel.DataAnnotations;

namespace Dev.Store.Settings
{
    public class FileUploaderSettingDto
    {
        [Required]
        public bool FileSettingCloudinaryEnabled { get; set; }

        [Required]
        public string FileSettingCloudinaryCloudName { get; set; }

        [Required]
        public string FileSettingCloudinaryApiKey { get; set; }

        [Required]
        public string FileSettingCloudinarApiSecret { get; set; }

        [Required]
        public bool FileSettingCompressionEnabled { get; set; }

        [Required]
        [Range(0, 100)]
        public double FileSettingCompressionRate { get; set; }

        [Required]
        [Range(0, 100)]
        public double FileSettingBigImageScale { get; set; }

        [Required]
        [Range(0, 100)]
        public double FileSettingMediumImageScale { get; set; }

        [Required]
        [Range(0, 100)]
        public double FileSettingSmallImageScale { get; set; }

        [Required]
        [Range(0, 100)]
        public double FileSettingMobileImageScale { get; set; }
    }
}