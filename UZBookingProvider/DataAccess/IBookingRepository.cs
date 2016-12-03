using System.Collections.Generic;
using System.Threading.Tasks;

namespace CITR.UZBookingProvider.DataAccess
{
    interface IBookingRepository
    {
        Task<Dictionary<string, int>> GetAvaliablePlacesCount(CoachType coachType);

        Task<Dictionary<CoachType, IEnumerable<int>>> GetAvaliablePlaces(CoachType coachType);
        
        Task<string> AddPlaceToCard(int place);
    }
}
