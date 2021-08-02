using System.Threading.Tasks;
using LightWeatherCore.Models;

namespace LightWeatherCore.ExternalServices
{
    public interface IForecaApiClient
    {
        Task<string> GetToken(string username, string password);
        Task<LocationSearchResults> GetLocationInfoByCoords(string coords, string token);
        Task<CurrentWeatherData> GetWeatherDataByLocationId(int locationId, string token);
        Task<LocationPhraseSearchResults> GetLocationInfoBySearchPhrase(string locationSearchPhrase, string token);
    }
}