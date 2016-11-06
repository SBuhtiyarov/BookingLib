using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UZProvider.Domain
{
    public class UZCoachType
    {
        [JsonProperty(PropertyName = "title")]
        public string Title;

        [JsonProperty(PropertyName = "letter")]
        public string Letter;

        [JsonProperty(PropertyName = "places")]
        public int Places;
    }
}
