using System;
using System.Threading.Tasks;
using UZBookingProvider.Domain;

namespace UZBookingProvider.Gateway
{
    public interface IUZDataGatewaySlim: IDisposable
    {
        Task<UZStationSet> GetStations(string request);
    }
}
