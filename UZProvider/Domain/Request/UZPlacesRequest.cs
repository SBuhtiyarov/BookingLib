using Newtonsoft.Json;

namespace UZProvider.Domain
{
    public class UZPlacesRequest : UZBaseRequest
    {
        [JsonProperty(PropertyName = "train")]
        public string TrainNumber;

        [JsonProperty(PropertyName = "coach_num")]
        public string CoachNumber;

        [JsonProperty(PropertyName = "coach_class")]
        public string CoachClass;

        [JsonProperty(PropertyName = "coach_type_id")]
        public string CoachTypeId;

        [JsonProperty(PropertyName = "scheme_id")]
        public string SchemeId;
    }
}
