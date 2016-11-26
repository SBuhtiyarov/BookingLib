using Newtonsoft.Json;
using System.Collections.Generic;

namespace CITR.UZBookingProvider.Domain
{
    public class UZStationSet: UZSet
    {
        [JsonProperty(PropertyName = "value")]
        public List<UZStation> Stations;
    }
}
