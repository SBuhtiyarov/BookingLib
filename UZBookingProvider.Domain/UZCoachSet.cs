using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UZBookingProvider.Domain
{
    public class UZCoachSet : UZSet
    {
        public UZCoachesRequest OwnerRequest;

        [JsonProperty(PropertyName = "coach_type_id")]
        public string CoachTypeId;

        [JsonProperty(PropertyName = "coaches")]
        public List<UZCoach> Coaches;
    }
}
