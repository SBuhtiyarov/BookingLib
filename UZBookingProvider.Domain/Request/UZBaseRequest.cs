using Newtonsoft.Json;

namespace CITR.UZBookingProvider.Domain
{											
    public class UZBaseRequest
    {
        [JsonProperty(PropertyName = "station_id_from")]
        public string StationFromId;

        [JsonProperty(PropertyName = "station_id_till")]
        public string StationTillId;

        [JsonProperty(PropertyName = "date_dep")]
        public string DepartureDate;
    }
}
