using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CITR.UZBookingProvider.Domain
{
    public class UZTrainSet : UZSet
    {
        public UZTrainsRequest OwnerRequest;

        [JsonProperty(PropertyName = "value")]
        public List<UZTrain> Trains;
    }
}
