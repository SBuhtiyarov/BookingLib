using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CITR.UZBookingProvider.Domain
{
    public class UZCardSet : UZSet
    {
        public UZCardRequest OwnerRequest;

        public string Cookies;

        [JsonProperty(PropertyName = "value")]
        public UZCard Card;
    }
}
