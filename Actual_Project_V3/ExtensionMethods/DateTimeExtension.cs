using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Actual_Project_V3.ExtensionMethods
{
    public static class DateTimeExtension
    {
        public static bool ThisDay(this DateTime date)
        {
            TimeSpan timedifference = DateTime.Now - date;
            if (timedifference.TotalDays <= 1)
            {
                return true;
            }
            else
                return false;
        }
        public static bool ThisWeek(this DateTime date)
        {
            TimeSpan timedifference= DateTime.Now - date;
            if (timedifference.TotalDays <=7) 
            {
                return true;
            }else
                return false;
        }
        public static bool ThisMonth(this DateTime date)
        {
            TimeSpan timedifference = DateTime.Now - date;
            if (timedifference.TotalDays <= 30)
            {
                return true;
            }
            else
                return false;
        }
        public static bool ThisYear(this DateTime date)
        {
            TimeSpan timedifference = DateTime.Now - date;
            if (timedifference.TotalDays <= 365)
            {
                return true;
            }
            else
                return false;
        }

    }
}
