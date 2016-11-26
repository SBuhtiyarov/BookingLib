using CITR.UZBookingProvider.Domain;

namespace CITR.UZBookingProvider.DataAccess
{
    interface IUZDomainTranslator
    {
        UZTrainsRequest GetTrainRequest();

        UZCoachesRequest GetCoachesRequest(UZTrain train, UZCoachType coach);

        UZPlacesRequest GetPlacesRequest(UZCoachSet coachSet, UZCoach coach);

        UZCardRequest GetCardRequest(int placeNumber, UZPlacesSet placesSet);
    }
}
