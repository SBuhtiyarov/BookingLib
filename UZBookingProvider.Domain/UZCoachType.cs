using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CITR.UZBookingProvider.Domain
{
    public class UZCoachType
    {
        [JsonProperty(PropertyName = "title")]
        public string Title;

        [JsonProperty(PropertyName = "letter")]
        public string TypeLetter;

        [JsonProperty(PropertyName = "places")]
        public int PlacesCount;
    }
}
