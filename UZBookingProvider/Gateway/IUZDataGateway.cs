using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UZBookingProvider.Domain;

namespace UZBookingProvider
{
    interface IUZDataGateway
    {
        Task<UZTrainSet> GetTrains(UZTrainsRequest request);

        Task<UZCoachSet> GetCoaches(UZCoachesRequest request);

        Task<UZPlacesSet> GetPlaces(UZPlacesRequest request);

        Task<UZCardSet> AddPlaceToCard(UZCardRequest request);
    }
}
