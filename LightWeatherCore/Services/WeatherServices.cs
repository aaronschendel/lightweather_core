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

        public async Task<CurrentWeatherData> GetCurrentWeatherDataByLocationSearchPhrase(string locationSearchPhrase, string token)
        {
            if (string.IsNullOrEmpty(locationSearchPhrase) || string.IsNullOrEmpty(token))
            {
                return null;
            }

            LocationPhraseSearchResults locationPhraseSearchResults =
                await forecaApi.GetLocationInfoBySearchPhrase(locationSearchPhrase, token);

            if (locationPhraseSearchResults == null)
            {
                return null;
            }

            CurrentWeatherData weatherData =
                await forecaApi.GetWeatherDataByLocationId(Convert.ToInt32(locationPhraseSearchResults.results[0].id), token);

            return weatherData;
        }
    }
}
