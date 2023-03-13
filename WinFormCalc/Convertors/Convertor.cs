using System;
using System.Collections.Generic;
using System.Windows.Forms;
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

        private delegate double ConvertorDel(double value, Enum from, Enum to);
        
        private static readonly Dictionary<Type, ConvertorDel> Convertors = new(){
            {typeof(AreaEnum), (value, from, to) => {
                return Area.Area.Convert(value, (AreaEnum)from, (AreaEnum)to);
            }},
            {typeof(DataEnum), (value, from, to) => {
                return Data.Data.Convert(value, (DataEnum)from, (DataEnum)to);
            }},
            {typeof(LengthEnum), (value, from, to) => {
                return Length.Length.Convert(value, (LengthEnum)from, (LengthEnum)to);
            }},
            {typeof(SpeedEnum), (value, from, to) => {
                return Speed.Speed.Convert(value, (SpeedEnum)from, (SpeedEnum)to);
            }},
            {typeof(TemperatureEnum), (value, from, to) => {
                return Temperature.Temperature.Convert(value, (TemperatureEnum)from, (TemperatureEnum)to);
            }},
            {typeof(TimeEnum), (value, from, to) => {
                return Time.Time.Convert(value, (TimeEnum)from, (TimeEnum)to);
            }},
            {typeof(VolumeEnum), (value, from, to) => {
                return Volume.Volume.Convert(value, (VolumeEnum)from, (VolumeEnum)to);
            }}
        };


        public static double Convert<T>(double value, T from, T to) where T : Enum
        {
            return Convertors[typeof(T)].Invoke(value, from, to);
        }
    }
}