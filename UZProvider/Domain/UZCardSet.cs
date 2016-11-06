using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UZProvider.Domain
{
    public class UZCardSet : UZSet
    {
        public string Cookies;

        [JsonProperty(PropertyName = "value")]
        public UZCard Card;
    }
}
