using System.Globalization;

namespace Dev.Store
{
    public static class Extensions
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
                return "{0:" + DateTimeFormatInfo.CurrentInfo.ShortDatePattern + " " + DateTimeFormatInfo.CurrentInfo.ShortTimePattern + "}";
            }
        }
        public static string NumericFormat(int n = 2, bool kendoGrid = true)
        {
            var vl = "N" + n;

            if (kendoGrid)
            {
                return "{0:" + vl + "}";
            }

            return vl;
        }

        public static string MoneyFormat(string currency, int n = 2, bool kendoGrid = true)
        {
            var vl = "N" + n;

            if (kendoGrid)
            {
                return "{0:" + vl + "} " + currency;
            }

            return vl;
        }


    }
}