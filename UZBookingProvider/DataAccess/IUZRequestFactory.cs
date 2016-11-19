using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UZBookingProvider.Domain;

namespace UZBookingProvider.DataAccess
{
    interface IUZRequestFactory
    {
        UZTrainsRequest GetTrainRequest();

        UZCoachesRequest GetCoachesRequest(UZTrain train, UZCoachType coach);

        UZPlacesRequest GetPlacesRequest(UZCoachSet coachSet, UZCoach coach);

        UZCardRequest GetCardRequest(int placeNumber, UZPlacesSet placesSet);
    }
}
