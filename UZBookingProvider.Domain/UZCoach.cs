using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UZBookingProvider.Domain
{
    public class UZCoach
    {
        [JsonProperty(PropertyName = "allow_bonus")]
        public bool IsAllowBonus;

        [JsonProperty(PropertyName = "coach_class")]
        public string CoachClass;

        [JsonProperty(PropertyName = "has_bedding")]
        public string IsHasBedding;

        [JsonProperty(PropertyName = "num")]
        public string Number;

        [JsonProperty(PropertyName = "places_cnt")]
        public int PlacesCount;

        [JsonProperty(PropertyName = "prices")]
        public Dictionary<string, string> Prices;

        [JsonProperty(PropertyName = "reserve_price")]
        public string ReservePrice;

        [JsonProperty(PropertyName = "scheme_id")]
        public string SchemeId;

        [JsonProperty(PropertyName = "type")]
        public string CoachType;

        [JsonProperty(PropertyName = "services")]
        public List<string> Services;
    }
}
