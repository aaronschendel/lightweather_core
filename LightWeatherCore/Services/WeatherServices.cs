using System;
using System.Threading.Tasks;
using LightWeatherCore.ExternalServices;
using LightWeatherCore.Models;

namespace LightWeatherCore.Services
{
    public class WeatherServices : IWeatherServices
    {
        private readonly IForecaApiClient forecaApi;

        public WeatherServices(IForecaApiClient forecaApi)
        {
            this.forecaApi = forecaApi;
        }

        public async Task<CurrentWeatherData> GetCurrentWeatherDataByCoords(string coords, string token)
        {
            // Call api to search location to get location ID
            // Use location ID to call get current weather by ID
            if (string.IsNullOrEmpty(coords) || string.IsNullOrEmpty(token))
            {
                return null;
            }
            LocationSearchResults locationInfo = await forecaApi.GetLocationInfoByCoords(coords, token);

            if (locationInfo == null)
            {
                //bail out
            }

            CurrentWeatherData weatherData = await forecaApi.GetWeatherDataByLocationId(locationInfo.Id, token);

            if (weatherData == null)
            {
                //bail out
            }

            return weatherData;
        }
    }
}
