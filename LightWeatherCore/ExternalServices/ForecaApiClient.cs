using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using LightWeatherCore.Models;
using Newtonsoft.Json;

namespace LightWeatherCore.ExternalServices
{
    public class ForecaApiClient : IForecaApiClient
    {
        //private static readonly HttpClient client = new HttpClient();
        private static readonly string apiVersion = "1";

        public ForecaApiClient()
        {

            
        }

        public async Task<string> GetToken(string username, string password)
        {
            try
            {
                HttpClient myClient = new HttpClient();
                myClient.BaseAddress = new Uri("https://fnw-us.foreca.com/");
                var request = new HttpRequestMessage(HttpMethod.Post, "authorize/token?expire_hours=1");

                var creds = JsonConvert.SerializeObject(new Dictionary<string, string>
                {
                    { "user", username },
                    { "password", password }
                });

                request.Content = new StringContent(creds, Encoding.UTF8);

                var response = await myClient.SendAsync(request);
                if (response.StatusCode != HttpStatusCode.OK)
                {
                    return null;
                }

                var appResponse = response.Content.ReadAsStringAsync().Result;
                return appResponse;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<LocationSearchResults> GetLocationInfoByCoords(string coords, string token)
        {
            try
            {
                HttpClient myClient1 = new HttpClient();
                myClient1.BaseAddress = new Uri($"https://fnw-us.foreca.com/api/v{apiVersion}/");
                var request = new HttpRequestMessage(HttpMethod.Get, $"location/{ coords }?token={ token }");

                var response = await myClient1.SendAsync(request);
                if (response.StatusCode != HttpStatusCode.OK)
                {
                    return null;
                }

                var appResponse = response.Content.ReadAsStringAsync().Result;
                return JsonConvert.DeserializeObject<LocationSearchResults>(appResponse);
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<CurrentWeatherData> GetWeatherDataByLocationId(int locationId, string token)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"current/{ locationId }?token={ token }");

            HttpClient myClient2 = new HttpClient();
            myClient2.BaseAddress = new Uri($"https://fnw-us.foreca.com/api/v{apiVersion}/");
            var response = await myClient2.SendAsync(request);
            if (response.StatusCode != HttpStatusCode.OK)
            {
                return null;
            }

            var apiResponse = response.Content.ReadAsStringAsync().Result;
            var parsedResponse = JsonConvert.DeserializeObject<CurrentWeatherData>(apiResponse);
            return parsedResponse;
        }

        public async Task<LocationPhraseSearchResults> GetLocationInfoBySearchPhrase(string locationSearchPhrase, string token)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"locations/search/{ locationSearchPhrase }.json?lang=en");

            HttpClient myClient3 = new HttpClient();
            myClient3.BaseAddress = new Uri($"https://api.foreca.net/");
            var response = await myClient3.SendAsync(request);
            if (response.StatusCode != HttpStatusCode.OK)
            {
                return null;
            }

            var apiResponse = response.Content.ReadAsStringAsync().Result;
            var parsedResponse = JsonConvert.DeserializeObject<LocationPhraseSearchResults>(apiResponse);
            return parsedResponse;
        }
    }
}
