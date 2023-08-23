using MyDeveloperTools.Core.Interfaces;
using System.Text;

namespace MyDeveloperTools.Core.Services
{
    public class ToolService : IBase64Converter, ITemperatureConverter
    {
        public string Base64ToText(string base64Text)
        {
            var base64AsBytes = Convert.FromBase64String(base64Text);
            return Encoding.UTF8.GetString(base64AsBytes);
        }

        public string TextToBase64(string text)
        {
            var textAsBytes = Encoding.UTF8.GetBytes(text);
            return Convert.ToBase64String(textAsBytes);
        }

        public double CelsiusToFahrenheit(double temperature)
        {
            return (temperature * 9 / 5) + 32;

        }

        public double FahrenheitToCelsius(double temperature)
        {
            return Math.Round((temperature - 32) * 5 / 9, 5);
        }


    }
}
