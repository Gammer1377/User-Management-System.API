using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace User_Management_System.Common.Utilities
{
    public static class DateTimeTools
    {
        
        public static string ToShamsi(this DateTime value)
        {
            PersianCalendar pc = new PersianCalendar();
            return pc.GetYear(value)+"/" + pc.GetMonth(value).ToString("00") +"/"+ pc.GetDayOfMonth(value).ToString("00");
        }
    }
}
