using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UZBookingProvider.Domain
{
    public class UZPlacesSet: UZSet
    {
        [JsonProperty(PropertyName = "value")]
        public UZPlaces Places;
    }
}
