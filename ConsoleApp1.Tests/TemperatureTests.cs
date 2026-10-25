
using System;
using TemperatureConverted;
using Xunit;

namespace ConsoleApp1.Tests
{
    public class TemperatureTests
    {
        private readonly Temperature _converter = new();

        // Helper to compare floating values within a tolerance.
        private static void AssertClose(float expected, float actual)
        {
            Assert.InRange(MathF.Abs(expected - actual), 0f, 0.01f);
        }

        [Fact]
        public void TempConverter_CelsiusOverload_ReturnsFahrenheitAndKelvin()
        {
            // Arrange
            float celsius = 25f;

            // Act
            var result = _converter.TempConverter(celsius);

            // Assert
            AssertClose(77f, result.Fahrenheit);
            AssertClose(298.15f, result.Kelvin);
        }

        [Fact]
        public void TempConverter_CelsiusInput_ReturnsFahrenheitAndKelvin()
        {
            // Arrange
            float celsius = 25f;

            // Act
            var result = _converter.TempConverter(
                celsius, Temperature.Unit.Celsius);

            // Assert
            Assert.Equal(Temperature.Unit.Fahrenheit, result.Unit1);
            AssertClose(77f, result.Temp1);

            Assert.Equal(Temperature.Unit.Kelvin, result.Unit2);
            AssertClose(298.15f, result.Temp2);
        }

        [Fact]
        public void TempConverter_KelvinInput_ReturnsCelsiusAndFahrenheit()
        {
            // Arrange
            float kelvin = 300f;

            // Act
            var result = _converter.TempConverter(
                kelvin, Temperature.Unit.Kelvin);

            // Assert
            Assert.Equal(Temperature.Unit.Celsius, result.Unit1);
            AssertClose(26.85f, result.Temp1);

            Assert.Equal(Temperature.Unit.Fahrenheit, result.Unit2);
            AssertClose(80.33f, result.Temp2);
        }

        [Fact]
        public void TempConverter_FahrenheitInput_ReturnsCelsiusAndKelvin()
        {
            // Arrange
            float fahrenheit = 32f;

            // Act
            var result = _converter.TempConverter(
                fahrenheit, Temperature.Unit.Fahrenheit);

            // Assert
            Assert.Equal(Temperature.Unit.Celsius, result.Unit1);
            AssertClose(0f, result.Temp1);

            Assert.Equal(Temperature.Unit.Kelvin, result.Unit2);
            AssertClose(273.15f, result.Temp2);
        }

        [Fact]
        public void TempConverter_RejectsInvalidUnit()
        {
            // Arrange
            var invalidUnit = (Temperature.Unit)99;

            // Act and Assert
            Assert.Throws<ArgumentOutOfRangeException>(
                () => _converter.TempConverter(25f, invalidUnit));
        }

        [Fact]
        public void TempConverter_MinusFortyCelsius_ReturnsMinusFortyFahrenheit()
        {
            // Arrange
            float celsius = -40f;

            // Act
            var result = _converter.TempConverter(celsius);

            // Assert
            AssertClose(-40f, result.Fahrenheit);
            AssertClose(233.15f, result.Kelvin);
        }

        [Fact]
        public void TempConverter_ZeroKelvin_ReturnsAbsoluteZeroInOtherUnits()
        {
            // Arrange
            float kelvin = 0f;

            // Act
            var result = _converter.TempConverter(
                kelvin, Temperature.Unit.Kelvin);

            // Assert
            AssertClose(-273.15f, result.Temp1);
            AssertClose(-459.67f, result.Temp2);
        }

        [Fact]
        public void TempConverter_CelsiusOverloads_ReturnConsistentResults()
        {
            // Arrange
            float celsius = 25f;

            // Act
            var simpleResult = _converter.TempConverter(celsius);
            var explicitResult = _converter.TempConverter(
                celsius, Temperature.Unit.Celsius);

            // Assert
            AssertClose(simpleResult.Fahrenheit, explicitResult.Temp1);
            AssertClose(simpleResult.Kelvin, explicitResult.Temp2);

            Assert.Equal(Temperature.Unit.Fahrenheit, explicitResult.Unit1);
            Assert.Equal(Temperature.Unit.Kelvin, explicitResult.Unit2);
        }
    }
}
