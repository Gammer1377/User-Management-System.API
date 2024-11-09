using System.Globalization;

namespace User_Management_System.Common.Utilities;

public static class DateTimeTools
{
    public static string ToShamsi(this DateTime value)
    {
        var pc = new PersianCalendar();
        return pc.GetYear(value) + "/" + pc.GetMonth(value).ToString("00") + "/" +
               pc.GetDayOfMonth(value).ToString("00");
    }
}