using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArch.Application.Utility
{
    public class DateManager
    {
        public static string M2ShWithTime(System.DateTime Date_Day)
        {
            string TimeString = null;
            TimeString = check_Time_Lenght(Date_Day.Hour.ToString()) + ":" + check_Time_Lenght(Date_Day.Minute.ToString());
            System.Globalization.PersianCalendar c = new System.Globalization.PersianCalendar();
            string y = c.GetYear(Date_Day).ToString();
            string m = c.GetMonth(Date_Day).ToString();
            string d = c.GetDayOfMonth(Date_Day).ToString();
            string Result = y + "/" + check_Time_Lenght(m) + "/" + check_Time_Lenght(d);
            return Result + " - " + TimeString;
        }

        public static System.DateTime SH2MWithTime(string Date_DaySH)
        {
            int Pyear = Convert.ToInt32(Date_DaySH.Substring(0, 4));
            // Shamsi Year
            int Pmonth = Convert.ToInt32(Date_DaySH.Substring(5, 2));
            // Shamsi Month
            int Pday = Convert.ToInt32(Date_DaySH.Substring(8, 2));
            // Shamdi Day
            //yyyy/mm/dd
            //dd/mm/yyyy
            try
            {
                string[] DateSplited = Date_DaySH.Split(' ');
                string time = DateSplited[1];
                string hour = time.Split(':')[0];
                string minitue = time.Split(':')[1];
                System.Globalization.PersianCalendar Mdate = new System.Globalization.PersianCalendar();
                return Mdate.ToDateTime(Pyear, Pmonth, Pday, Convert.ToInt32(hour), Convert.ToInt32(minitue), 1, 1, System.Globalization.GregorianCalendar.ADEra);
            }
            catch
            {
                return Convert.ToDateTime(null);
            }
        }

        public static System.DateTime SH2M(string Date_DaySH)
        {

            int Pyear = Convert.ToInt32(Date_DaySH.Substring(0, 4));
            // Shamsi Year
            int Pmonth = Convert.ToInt32(Date_DaySH.Substring(5, 2));
            // Shamsi Month
            int Pday = Convert.ToInt32(Date_DaySH.Substring(8, 2));
            // Shamdi Day
            System.Globalization.PersianCalendar Mdate = new System.Globalization.PersianCalendar();
            return Mdate.ToDateTime(Pyear, Pmonth, Pday, 1, 1, 1, 1, System.Globalization.GregorianCalendar.ADEra);
           
        }

        public static string M2Sh(System.DateTime Date_Day)
        {
            System.Globalization.PersianCalendar c = new System.Globalization.PersianCalendar();

            string y = c.GetYear(Date_Day).ToString();

            string m = c.GetMonth(Date_Day).ToString();

            string d = c.GetDayOfMonth(Date_Day).ToString();

            string Result = y + "/" + check_Time_Lenght(m) + "/" + check_Time_Lenght(d);

            return Result;
        }

        public static string check_Time_Lenght(string time)
        {
            string RTime = null;
            int len = time.ToString().Length;
            if (len < 2)
            {


                RTime = "0" + time.ToString();
            }
            else if (len == 2)
            {
                RTime = time.ToString();
            }

            return RTime;
        }
    }
}
