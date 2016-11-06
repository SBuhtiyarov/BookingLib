using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UZProvider.Domain
{
    public class UZSet
    {
        [JsonProperty(PropertyName = "error")]
        public bool? IsError;
    }
}
