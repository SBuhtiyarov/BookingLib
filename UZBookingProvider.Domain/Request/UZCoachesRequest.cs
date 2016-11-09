using Newtonsoft.Json;

namespace UZBookingProvider.Domain
{
    public class UZCoachesRequest : UZBaseRequest
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
