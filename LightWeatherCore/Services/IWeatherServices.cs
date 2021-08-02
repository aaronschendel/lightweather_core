using System.Threading.Tasks;
using LightWeatherCore.Models;

namespace LightWeatherCore.Services
{
    public interface IWeatherServices
    {
        Task<CurrentWeatherData> GetCurrentWeatherDataByCoords(string coords, string token);
        Task<CurrentWeatherData> GetCurrentWeatherDataByLocationSearchPhrase(string locationSearchPhrase, string token);
    }
}