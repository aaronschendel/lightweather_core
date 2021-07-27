using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LightWeatherCore.ExternalServices;
using LightWeatherCore.Models;
using LightWeatherCore.Services;
using Microsoft.AspNetCore.Mvc;

namespace LightWeatherCore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherDataController : ControllerBase
    {
        private readonly IForecaApiClient forecaApi;
        private readonly IWeatherServices weatherServices;

        public WeatherDataController(IForecaApiClient forecaApi, IWeatherServices weatherServices)
        {
            this.forecaApi = forecaApi;
            this.weatherServices = weatherServices;
        }

        [HttpGet("token")]
        public async Task<string> GetToken()
        {
            var result = await forecaApi.GetToken(Environment.GetEnvironmentVariable("user"), Environment.GetEnvironmentVariable("password"));

            return result;
        }

        [HttpGet("coordinates/{coords}")]
        public async Task<WeatherData> GetWeatherDataByCoords([FromRoute] string coords, [FromQuery] string token)
        {
            try
            {
                CurrentWeatherData weatherData = await weatherServices.GetCurrentWeatherDataByCoords(coords, token);
                return weatherData.Current;
            }
            catch (Exception e)
            {
                return null;
            }
            
        }
    }
}
