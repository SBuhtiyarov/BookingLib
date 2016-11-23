using System.Threading.Tasks;

namespace UZBookingProvider.Http
{
    interface IHttpRequestExecutor<T>
    {
        string Cookies { get; }

        Task InitConnection();

        Task<string> GetAsync(string addressSuffix);

        Task<string> PostAsync(string addressSuffix, T model);
    }
}
