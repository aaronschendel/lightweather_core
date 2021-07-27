using System;
namespace LightWeatherCore.Models
{
    public class LocationSearchResults
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public string Timezone { get; set; }
        public string State { get; set; }
        public string AdminArea { get; set; }
        public double Lon { get; set; }
        public double Lat { get; set; }
    }
}
