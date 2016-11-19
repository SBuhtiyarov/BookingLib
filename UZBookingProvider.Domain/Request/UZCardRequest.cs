using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UZBookingProvider.Domain
{
    public class UZCardRequest
    {
        [JsonProperty(PropertyName = "from")]
        public string StationFromId;

        [JsonProperty(PropertyName = "to")]
        public string StationTillId;

        [JsonProperty(PropertyName = "train")]
        public string TrainNumber;

        [JsonProperty(PropertyName = "date")]
        public string DepartureDate;    

        [JsonProperty(PropertyName = "round_trip")]
        public int RoundTrip = 0;

        [JsonProperty(PropertyName = "places[0][ord]")]
        public int Order;

        [JsonProperty(PropertyName = "places[0][charline]")]
        public string Charline;

        [JsonProperty(PropertyName = "places[0][wagon_num]")]
        public string CoachNumber;

        [JsonProperty(PropertyName = "places[0][wagon_class]")]
        public string CoachClass;

        [JsonProperty(PropertyName = "places[0][wagon_type]")]
        public string CoachType;

        [JsonProperty(PropertyName = "places[0][firstname]")]
        public string FirstName;

        [JsonProperty(PropertyName = "places[0][lastname]")]
        public string LastName;

        [JsonProperty(PropertyName = "places[0][bedding]")]
        public string IsBedding = "1";

        [JsonProperty(PropertyName = "places[0][child]")]
        public string IsChild;

        [JsonProperty(PropertyName = "places[0][stud]")]
        public string IsStud;

        [JsonProperty(PropertyName = "places[0][transportation]")]
        public string IsTransp;

        [JsonProperty(PropertyName = "places[0][reserve]")]
        public int IsReserve;

        [JsonProperty(PropertyName = "places[0][place_num]")]
        public int PlaceNumber;
    }
}
