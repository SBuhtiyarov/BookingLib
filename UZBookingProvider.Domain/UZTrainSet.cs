using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UZBookingProvider.Domain
{
    public class UZTrainSet : UZSet
    {
        [JsonProperty(PropertyName = "value")]
        public List<UZTrain> Trains;
    }
}
