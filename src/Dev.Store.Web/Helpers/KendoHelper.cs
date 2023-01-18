using System.Globalization;

namespace Dev.Store
{
    public class KendoHelper
    {
        public static string DateTimeShortFormat
        {
            get
            {
                var vl = DateTimeFormatInfo.CurrentInfo.ShortDatePattern;
                return "{0:" + vl + "}";
            }
        }
        public static string DateTimeLongFormat
        {
            get
            {
                var vl = DateTimeFormatInfo.CurrentInfo.LongDatePattern;
                return "{0:" + vl + "}";
            }
        }


    }
}