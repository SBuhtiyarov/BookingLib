using System;
using System.Threading.Tasks;

namespace UZBookingProvider
{
    interface IHttpRequestExecutor<T>: IDisposable
    {
        string Cookies { get; }

        Task InitConnection();

        Task<string> GetAsync(string addressSuffix);

        Task<string> PostAsync(string addressSuffix, T model);
    }
}
