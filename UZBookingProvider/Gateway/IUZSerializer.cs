using System.Net.Http;
using UZBookingProvider.Domain;

namespace UZBookingProvider.Gateway
{
    interface IUZSerializer
    {
        FormUrlEncodedContent SerializeRequest(object request);

        T DeserializeResponse<T>(string response) where T : UZSet, new();
    }
        
}
