using Newtonsoft.Json;
using System.Collections.Generic;

namespace UZBookingProvider.Domain
{
    public class UZStationSet: UZSet
    {
        [JsonProperty(PropertyName = "value")]
        public List<UZStation> Stations;
    }
}
