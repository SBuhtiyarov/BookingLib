using System.Net.Http;
using CITR.UZBookingProvider.Domain;

namespace CITR.UZBookingProvider.Gateway
{
    interface IUZSerializer
    {
        FormUrlEncodedContent SerializeRequest(object request);

        T DeserializeResponse<T>(string response) where T : UZSet, new();
    }
        
}
