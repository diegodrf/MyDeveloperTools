using MyDeveloperTools.Core.Interfaces;
using MyDeveloperTools.Core.Services;

namespace MyDeveloperTools.UnitTest.MyDeveloperTools.Core.Test.Services.Test
{
    public class ToolServiceTest
    {
        private readonly IBase64Converter _base64Converter = new ToolService();
        private readonly ITemperatureConverter _temperatureConverter = new ToolService();

        [Theory]
        [Trait("Base64", null)]
        [InlineData("Hello World!", "SGVsbG8gV29ybGQh")]
        [InlineData("email@email.com", "ZW1haWxAZW1haWwuY29t")]
        [InlineData("%*#)1sssh$$23¬l{┤;è↓", "JSojKTFzc3NoJCQyM8KsbHvilKQ7w6jihpM=")]
        public void GivenAText_WhenConvertedToBase64_ShouldReturnABase64Text(string text, string result)
        {
            var textAsBase64 = _base64Converter.TextToBase64(text);
            
            Assert.Equal(result, textAsBase64);
        }

        [Theory]
        [Trait("Base64", null)]
        [InlineData("SGVsbG8gV29ybGQh", "Hello World!")]
        [InlineData("ZW1haWxAZW1haWwuY29t", "email@email.com")]
        [InlineData("JSojKTFzc3NoJCQyM8KsbHvilKQ7w6jihpM=", "%*#)1sssh$$23¬l{┤;è↓")]
        public void GivenABase64String_WhenDecode_ShouldReturnAValidPlainText(string text, string result)
        {
            var textAsBase64 = _base64Converter.Base64ToText(text);

            Assert.Equal(result, textAsBase64);
        }

        [Fact]
        [Trait("Base64", null)]
        public void GivenAnInvalidBase64String_WhenDecode_ShouldReturnFormatException()
        {
            var invalidBase64 = "4rdHFh%2BHYoS8oLdVvbUzEVqB8Lvm7kSPnuwF0AAABYQ%3D";

            Assert.Throws<FormatException>(() => _base64Converter.Base64ToText(invalidBase64));
        }

        [Theory]
        [Trait("Temperature", null)]
        [InlineData(0, 32)]
        [InlineData(1, 33.8)]
        [InlineData(-100.3, -148.54)]
        [InlineData(500, 932)]
        [InlineData(10.334, 50.6012)]
        public void GivenATemperatureInCelsius_WhenConvertedToFahrenheit_ShouldReturnAValidConversionValue(double celsius, double fahrenheit)
        {
            var result = _temperatureConverter.CelsiusToFahrenheit(celsius);

            Assert.Equal(fahrenheit, result);
        }

        [Theory]
        [Trait("Temperature", null)]
        [InlineData(0, -17.77778)]
        [InlineData(33.8, 1)]
        [InlineData(500, 260)]
        [InlineData(-27, -32.77778)]
        [InlineData(-273.6, -169.77778)]
        public void GivenATemperatureInFahrenheit_WhenConvertedToCelsius_ShouldReturnAValidConversionValue(double fahrenheit, double celsius)
        {
            var result = _temperatureConverter.FahrenheitToCelsius(fahrenheit);

            Assert.Equal(celsius, result);
        }
    }
}
