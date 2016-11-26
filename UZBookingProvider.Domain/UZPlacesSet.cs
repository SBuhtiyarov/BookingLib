using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CITR.UZBookingProvider.Domain
{
    public class UZPlacesSet: UZSet
    {
        public UZPlacesRequest OwnerRequest;

        [JsonProperty(PropertyName = "value")]
        public UZPlaces Places;
    }
}
