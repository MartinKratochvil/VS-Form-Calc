using System;

namespace WinFormCalc.Convertors
{
    public static class Date
    {

        private const double year = 365.2425;

        private const double month = 30.436875;


        public static DateTime AddDate(DateTime date, int days, int months, int years)
        {
            date = date.AddDays(days);
            date = date.AddMonths(months);
            
            return date.AddYears(years);
        }


        public static TimeSpan CompareDate(DateTime origin, DateTime compare)
        {
            if (compare > origin)
            {
                throw new ArgumentException("Compare DateTime mustn't be greater than origin DateTime");
            }

            return origin - compare;
        }


        public static string ConvertTimeSpanToString(TimeSpan time)
        {
            int days = time.Days;

            return getYears(ref days) + " years " + getMonths(ref days) + " months " + days + " days";
        }

        
        private static int getYears(ref int days)
        {
            int years = (int)(days / year);
            days -= (int)(years * year);

            return years;
        }


        private static int getMonths(ref int days)
        {
            int months = (int)(days / month);
            days -= (int)(months * month);

            return months;
        }
    }
}
