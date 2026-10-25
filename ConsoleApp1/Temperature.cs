using System;
using System.Collections.Generic;
using System.Text;

namespace TemperatureConverted
{
    public class Temperature
    {
        private float _temp;
        public enum Unit
        {
            Celsius,
            Kelvin,
            Fahrenheit
        }

        public float Temp { get; set; }

        public (float Fahrenheit, float Kelvin) TempConverter(float celsius)
        {
            float Fahrenheit = (celsius * 9f / 5f) + 32f;
            float kelvin = celsius + 273.15f;
            return (Fahrenheit, kelvin);
        }

        public (float Temp1, Unit Unit1, float Temp2, Unit Unit2) TempConverter(float temp, Unit unit)
        {
            float celsius = unit switch
            {
                Unit.Celsius => temp,
                Unit.Kelvin => temp -273.15f,
                Unit.Fahrenheit => (temp - 32f) * 5f / 9f,
                _ => throw new ArgumentOutOfRangeException(nameof(unit))
            };
            float fahrenheit = (celsius * 9f / 5f) + 32f;
            float kelvin = celsius + 273.15f;

            return unit switch
            {
                Unit.Celsius =>
                    (fahrenheit, Unit.Fahrenheit, kelvin, Unit.Kelvin),

                Unit.Kelvin =>
                    (celsius, Unit.Celsius, fahrenheit, Unit.Fahrenheit),

                Unit.Fahrenheit =>
                    (celsius, Unit.Celsius, kelvin, Unit.Kelvin),

                _ => throw new ArgumentOutOfRangeException(nameof(unit))
            };
        }
    }
}
