using System;

namespace Dev.Store.Utils
{
    public static class RandomCode
    {
        private static Random rnd = new Random();
        public static string GetRandomCode()
        {
            var rndCode = "";
            for (int i = 0; i < 4; i++)
            {
                rndCode += rnd.Next(0, 9).ToString();

            }
            var date = DateTime.Now;
            return date.Year.ToString() + date.Month.ToString() + date.Day.ToString() + rndCode;
        }
    }
}
