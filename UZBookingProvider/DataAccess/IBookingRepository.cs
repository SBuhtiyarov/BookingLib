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

        Dictionary<CoachType, int[]> GetAvaliablePlaces(CoachType coachType);

        //for returned cookies
        string AddPlaceToCard(int place);
    }
}
