using System;

namespace tsogosun.com.MSPatronDetails.Shared.Utils
{
    public static class DateUtil
    {

        public static DateTime StartOfDay(this DateTime date)
        {
            return new DateTime(date.Year, date.Month, date.Day, 0, 0, 0, 0);
        }

        public static DateTime EndOfDay(this DateTime date)
        {
            return new DateTime(date.Year, date.Month, date.Day, 23, 59, 59, 999);
        }
     
        public static int TimeDifferenceInMinutes(DateTime startTime, DateTime endTime)
        {
            return (int)(endTime - startTime).TotalMinutes;
        }
    }
}
