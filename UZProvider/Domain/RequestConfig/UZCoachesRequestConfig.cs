using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UZProvider.Domain
{
    public class UZCoachesRequestConfig : UZBaseRequestConfig
    {
        [JsonProperty(PropertyName = "train")]
        public string TrainNumber;

        [JsonProperty(PropertyName = "coach_type")]
        public string CoachType;

        [JsonProperty(PropertyName = "model")]
        public int Model = 0;

        [JsonProperty(PropertyName = "round_trip")]
        public int RoundTrip = 0;

        [JsonProperty(PropertyName = "another_ec")]
        public int AnotherEc = 0;
    }
}
