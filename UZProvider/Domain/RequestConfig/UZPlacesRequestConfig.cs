using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UZProvider.Domain
{
    public class UZPlacesRequestConfig : UZBaseRequestConfig
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
