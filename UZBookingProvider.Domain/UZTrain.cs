using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UZBookingProvider.Domain
{
    public class UZTrain
    {
        [JsonProperty(PropertyName = "num")]
        public string Number;

        [JsonProperty(PropertyName = "model")]
        public int Model;

        [JsonProperty(PropertyName = "category")]
        public int Category;

        [JsonProperty(PropertyName = "travel_time")]
        public string TravelTime;

        [JsonProperty(PropertyName = "types")]
        public List<UZCoachType> AvaliableCoachTypes;
    }
}
