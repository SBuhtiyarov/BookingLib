using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UZProvider.Domain
{
    public class UZTrainsRequestConfig : UZBaseRequestConfig
    {
        [JsonProperty(PropertyName = "station_from")]
        public string StationFromName;

        [JsonProperty(PropertyName = "station_till")]
        public string StationTillName;

        [JsonProperty(PropertyName = "time_dep")]
        public string DepartureFromTime = "00:00";

        [JsonProperty(PropertyName = "time_dep_till")]
        public string DepartureTillTime;

        [JsonProperty(PropertyName = "another_ec")]
        public int AnotherEc;

        [JsonProperty(PropertyName = "search")]
        public string Search;
    }
}
