using Dev.Store.UploadFiles.Dtos;

namespace Dev.Store
{
    public static partial class CloudinaryImageCropExtention
    {
        public static string Big(this UploadFileDto file)
        {
            var a = file.FilePath;
            var d = "https://res.cloudinary.com/";
            var b = a.Split('/');
            for (var i = 3; i < b.Length; i++)
            {
                if (i == 6) d += "w_1.0,c_scale/q_auto:best/";
                if (b.Length != i + 1)
                    d += b[i] + "/";
                else
                    d += b[i];
            }
            return d;
        }

        public static string Medium(this UploadFileDto file)
        {
            var a = file.FilePath;
            var d = "https://res.cloudinary.com/";
            var b = a.Split('/');
            for (var i = 3; i < b.Length; i++)
            {
                if (i == 6) d += "w_0.75,c_scale/q_auto:best/";
                if (b.Length != i + 1)
                    d += b[i] + "/";
                else
                    d += b[i];
            }
            return d;
        }

        public static string Mobile(this UploadFileDto file)
        {
            var a = file.FilePath;
            var d = "https://res.cloudinary.com/";
            var b = a.Split('/');
            for (var i = 3; i < b.Length; i++)
            {
                if (i == 6) d += "w_0.50,c_scale/q_auto:best/";
                if (b.Length != i + 1)
                    d += b[i] + "/";
                else
                    d += b[i];
            }
            return d;
        }

        public static string Small(this UploadFileDto file)
        {
            var a = file.FilePath;
            var d = "https://res.cloudinary.com/";
            var b = a.Split('/');
            for (var i = 3; i < b.Length; i++)
            {
                if (i == 6) d += "w_0.25,c_scale/q_auto:best/";
                if (b.Length != i + 1)
                    d += b[i] + "/";
                else
                    d += b[i];
            }
            return d;
        }


     
    }
}