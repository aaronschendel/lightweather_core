namespace LightWeatherCore.Models
{
    public class CurrentWeatherData
    {
        public WeatherData Current { get; set; }
        
    }

    public class WeatherData
    {
        public string Time { get; set; }
        public string Symbol { get; set; }
        public string SymbolPhrase { get; set; }
        public double Temperature { get; set; }
        public double FeelsLikeTemp { get; set; }
        public double RelHumidity { get; set; }
        public double DewPoint { get; set; }
        public double WindSpeed { get; set; }
        public string WindDirString { get; set; }
        public double WindGust { get; set; }
        public double PrecipProb { get; set; }
        public double PrecipRate { get; set; }
        public double Cloudiness { get; set; }
        public double ThunderProb { get; set; }
        public double UvIndex { get; set; }
        public double Pressure { get; set; }
        public double Visibility { get; set; }
    }
}