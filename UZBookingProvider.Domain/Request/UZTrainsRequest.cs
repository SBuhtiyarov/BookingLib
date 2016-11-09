using Newtonsoft.Json;

namespace UZBookingProvider.Domain
{
    public class UZTrainsRequest : UZBaseRequest
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
