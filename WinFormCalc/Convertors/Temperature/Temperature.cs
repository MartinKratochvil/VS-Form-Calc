

namespace WinFormCalc.Convertors
{
    public class Temperature
    {
        public static double Convert(double value, TemperatureEnum from, TemperatureEnum to)
        {
            double temperature = ConvertToCelsius(value, from);
            return ConvertFromCelsius(temperature, to);
        }


        private static double ConvertToCelsius(double value, TemperatureEnum type)
        {
            if (type.ToString() == "Kelvin")
            {
                return value + ((int)type / 100f);
            }

            if (type.ToString() == "Fahrenheit")
            {
                return (value - 32) / ((int)type / 10f);
            }

            return value;
        }


        private static double ConvertFromCelsius(double value, TemperatureEnum type)
        {
            if (type.ToString() == "Kelvin")
            {
                return value - ((int)type / 100f);
            }

            if (type.ToString() == "Fahrenheit")
            {
                return value * ((int)type / 10f) + 32;
            }

            return value;
        }
    }
}
