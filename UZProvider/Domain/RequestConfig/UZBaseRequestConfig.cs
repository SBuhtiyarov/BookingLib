using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UZProvider.Domain
{											
    public class UZBaseRequestConfig
    {
        [JsonProperty(PropertyName = "station_id_from")]
        public string StationFromId;

        [JsonProperty(PropertyName = "station_id_till")]
        public string StationTillId;

        [JsonProperty(PropertyName = "date_dep")]
        public string DepartureDate;
    }
}
