using System.Threading.Tasks;
using UZBookingProvider.Domain;

namespace UZBookingProvider.Gateway
{
    interface IUZDataGateway
    {
        Task<UZStationSet> GetStations(string request);

        Task<UZTrainSet> GetTrains(UZTrainsRequest request);

        Task<UZCoachSet> GetCoaches(UZCoachesRequest request);

        Task<UZPlacesSet> GetPlaces(UZPlacesRequest request);

        Task<UZCardSet> AddPlaceToCard(UZCardRequest request);
    }
}
