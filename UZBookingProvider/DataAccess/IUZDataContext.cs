using System.Collections.Generic;
using System.Threading.Tasks;
using CITR.UZBookingProvider.Domain;

namespace CITR.UZBookingProvider.DataAccess
{
    interface IUZDataContext
    {
        Task<UZTrainSet> GetTrains();

        Task<List<UZCoachSet>> GetCoaches(UZTrain train, CoachType coachType);

        Task<List<UZPlacesSet>> GetPlaces(UZCoachSet coachSet);

        Task<UZCardSet> AddPlaceToCard(int placeNumber, UZPlacesSet placeSet);
    }
}
