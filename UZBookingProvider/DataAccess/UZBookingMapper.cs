using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UZBookingProvider.Domain;

namespace UZBookingProvider.DataAccess
{
    class UZBookingMapper: IUZBookingMapper
    {
        private Trip _road;

        public UZBookingMapper(Trip road) {
            _road = road;
        }

        public UZTrainsRequest GetTrainRequest() {
            return new UZTrainsRequest {
                StationFromId = _road.StartingPointId,
                StationTillId = _road.DestinationPointId,
                DepartureDate = _road.DepartureDate,
                StationFromName = _road.StartingPointName,
                StationTillName = _road.DestinationPointName,
            };
        }

        public UZCoachesRequest GetCoachesRequest(UZTrain train, UZCoachType coach) {
            return new UZCoachesRequest {
                StationFromId = _road.StartingPointId,
                StationTillId = _road.DestinationPointId,
                DepartureDate = train.From.DepartureDate,
                TrainNumber = train.Number,
                CoachType = coach.TypeLetter
            };
        }

        public UZPlacesRequest GetPlacesRequest(UZCoachSet coachSet, UZCoach coach) {
            return new UZPlacesRequest {
                StationFromId = _road.StartingPointId,
                StationTillId = _road.DestinationPointId,
                DepartureDate = coachSet.OwnerRequest.DepartureDate,
                TrainNumber = coachSet.OwnerRequest.TrainNumber,
                CoachNumber = coach.Number,
                CoachClass = coach.CoachClass,
                CoachTypeId = coach.SchemeId
            };
        }

        public UZCardRequest GetCardRequest(int placeNumber, UZPlacesSet placesSet) {
            return new UZCardRequest {
                StationFromId = _road.StartingPointId,
                StationTillId = _road.DestinationPointId,
                TrainNumber = placesSet.OwnerRequest.TrainNumber,
                DepartureDate = placesSet.OwnerRequest.DepartureDate,
                Charline = placesSet.Places.AvaliablePlaceNumbers.First().Key,
                CoachNumber = placesSet.OwnerRequest.CoachNumber,
                CoachClass = placesSet.OwnerRequest.CoachClass,
                CoachType = placesSet.OwnerRequest.CoachTypeId,
                FirstName = _road.FirstName,
                LastName = _road.LastName,
                IsBedding = "1",
                PlaceNumber = placeNumber
            };
        }

    }
}
