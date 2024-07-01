using System;
using System.Globalization;

namespace EvSef.Core.Convertors
{
    public static class DateConvertor
    {
        [System.Runtime.Versioning.SupportedOSPlatform("windows")]
        public static string ToShamsi(this DateTime value)
        {
            PersianCalendar pc = new PersianCalendar();
            return pc.GetYear(value) + "/" + pc.GetMonth(value).ToString("00") + "/" +
                   pc.GetDayOfMonth(value).ToString("00");
        }


        public static string ToMiladi(this string value)
        {
            return value.Replace("/", "-");
        }


    }
}
