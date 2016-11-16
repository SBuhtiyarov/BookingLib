using Newtonsoft.Json;

namespace UZBookingProvider.Domain
{
    public class UZTrainProperties
    {
        [JsonProperty(PropertyName = "date")]
        public string DepartureDate;
    }
}
