﻿using Newtonsoft.Json;

namespace CITR.UZBookingProvider.Domain
{
    public class UZStation
    {
        [JsonProperty(PropertyName = "station_id")]
        public int StationId;

        [JsonProperty(PropertyName = "title")]
        public string StationName;
    }
}