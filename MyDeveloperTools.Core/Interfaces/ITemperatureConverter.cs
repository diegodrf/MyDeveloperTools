namespace MyDeveloperTools.Core.Interfaces
{
    public interface ITemperatureConverter
    {
        double CelsiusToFahrenheit(double temperature);
        double FahrenheitToCelsius(double temperature);
    }
}
