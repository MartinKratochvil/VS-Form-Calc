using System;

namespace WinFormCalc.Convertors
{
    public class Time
    {

        public static double Convert(double value, TimeEnum from, TimeEnum to)
        {
            TimeSpan time = ConvertToTimeSpan(value, (int)from);
            
            return ConvertFromTimeSpan(time, (int)to);
        }


        private static TimeSpan ConvertToTimeSpan(double value, int type)
        {
            switch (type)
            {
                case -1:
                {
                    return TimeSpan.FromMilliseconds(value);
                }

                case 0:
                {
                    return TimeSpan.FromSeconds(value);
                }

                case 1:
                {
                    return TimeSpan.FromMinutes(value);
                }

                case 2:
                {
                    return TimeSpan.FromHours(value);
                }

                default:
                {
                    return TimeSpan.FromDays(value * (type / 1000000f));
                }
            }
        }

        private static Double ConvertFromTimeSpan(TimeSpan time, int type)
        {
            switch (type)
            {
                case -1:
                {
                    return time.Milliseconds;
                }

                case 0:
                {
                    return time.Seconds;
                }

                case 1:
                {
                    return time.Minutes;
                }

                case 2:
                {
                    return time.Hours;
                }

                default:
                {
                    return time.Days / (type / 1000000f);
                }
            }
        }
    }
}
