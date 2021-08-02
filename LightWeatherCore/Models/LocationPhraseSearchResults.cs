using System.Collections.Generic;

namespace LightWeatherCore.Models
{
    public class LocationPhraseSearchResults
    {
        public string query { get; set; }
        public string language { get; set; }
        public List<Result> results { get; set; }
    }
    
    public class WarningSources
    {
        public string hurricanes { get; set; }
    }

    public class Result
    {
        public string id { get; set; }
        public double lon { get; set; }
        public double lat { get; set; }
        public string type { get; set; }
        public string adm1_id { get; set; }
        public string adm2_id { get; set; }
        public string adm3_id { get; set; }
        public double population { get; set; }
        public string countryId { get; set; }
        public string timezone { get; set; }
        public double preference { get; set; }
        public WarningSources warningSources { get; set; }
        public string name { get; set; }
        public string countryName { get; set; }
        public string defaultName { get; set; }
        public string defaultCountryName { get; set; }
        public string defaultAdmName { get; set; }
        public string adm1Name { get; set; }
        public string admName { get; set; }
    }

   
}