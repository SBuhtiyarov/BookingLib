using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using CITR.UZBookingProvider.Domain;

namespace CITR.UZBookingProvider.Gateway
{
    class UZSerializer: IUZSerializer
    {
        public FormUrlEncodedContent SerializeRequest(object request) {
            var json = JsonConvert.SerializeObject(request);
            var jsonDict = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);
            return new FormUrlEncodedContent(jsonDict.ToArray());
        }

        public T DeserializeResponse<T>(string response) where T : UZSet, new() {
            try {
                var jsonDict = JsonConvert.DeserializeObject<Dictionary<string, object>>(response);
                object error;
                if (jsonDict.TryGetValue("error", out error) && Convert.ToBoolean(error)) {
                    throw new Exception(jsonDict["value"].ToString());
                }
                return JsonConvert.DeserializeObject<T>(response);
            } catch (Exception e) {
                var errorResponse = new T();
                errorResponse.ErrorMessage = e.Message;
                errorResponse.IsError = true;
                return errorResponse;
            }
        }
    }
}
