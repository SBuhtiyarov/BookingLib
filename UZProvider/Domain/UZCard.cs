using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UZProvider.Domain
{
    public class UZCard
    {
        [JsonProperty(PropertyName = "page")]
        public string Page;

        [JsonProperty(PropertyName = "places_count")]
        public int PlacesCount;
    }
}
