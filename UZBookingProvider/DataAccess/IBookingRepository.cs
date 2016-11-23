using System.Collections.Generic;
using System.Threading.Tasks;

namespace UZBookingProvider.DataAccess
{
    interface IBookingRepository
    {
        Dictionary<CoachType, int> GetAvaliablePlacesCount(CoachType coachType);

        Task<Dictionary<CoachType, IEnumerable<int>>> GetAvaliablePlaces(CoachType coachType);
        
        Task<string> AddPlaceToCard(int place);
    }
}
