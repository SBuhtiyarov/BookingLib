using Newtonsoft.Json;

namespace CITR.UZBookingProvider.Domain
{
    public class UZTrainProperties
    {
        [JsonProperty(PropertyName = "date")]
        public string DepartureDate;
    }
}
