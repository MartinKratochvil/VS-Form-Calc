using System;
using WinFormCalc.Convertors.Area;
using WinFormCalc.Convertors.Data;
using WinFormCalc.Convertors.Length;
using WinFormCalc.Convertors.Speed;
using WinFormCalc.Convertors.Temperature;
using WinFormCalc.Convertors.Time;
using WinFormCalc.Convertors.Volume;

namespace WinFormCalc.Convertors
{
    public static class Convertor
    {

        
        public static double Convert(double value, AreaEnum from, AreaEnum to)
        {
            return Area.Area.Convert(value, from, to);
        }


        public static double Convert<T>(double value, T from, T to) where T : Enum
        {
            return Data.Data.Convert(value, (DataEnum)(Enum)from, (DataEnum)(Enum)to);
        }


        public static Double Convert(double value, LengthEnum from, LengthEnum to)
        {
            return Length.Length.Convert(value, from, to);
        }


        public static Double Convert(double value, SpeedEnum from, SpeedEnum to)
        {
            return Speed.Speed.Convert(value, from, to);
        }


        public static double Convert(double value, TemperatureEnum from, TemperatureEnum to)
        {
            return Temperature.Temperature.Convert(value, from, to);
        }


        public static double Convert(double value, TimeEnum from, TimeEnum to)
        {
            return Time.Time.Convert(value, from, to);
        }


        public static Double Convert(double value, VolumeEnum from, VolumeEnum to)
        {
            return Volume.Volume.Convert(value, from, to);
        }
    }
}