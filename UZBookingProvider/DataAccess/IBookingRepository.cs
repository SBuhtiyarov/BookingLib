using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UZBookingProvider
{
    interface IBookingRepository
    {
        Dictionary<CoachType, int> GetAvaliablePlacesCount(CoachType coachType);

        Task<Dictionary<CoachType, int[]>> GetAvaliablePlaces(CoachType coachType);

        //for returned cookies
        Task<string> AddPlaceToCard(int place);
    }
}
