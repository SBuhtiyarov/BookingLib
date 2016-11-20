using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UZBookingProvider.Domain;

namespace UZBookingProvider.DataAccess
{
    class UZDomainTranslator: IUZDomainTranslator
    {
        private Ticket _ticket;

        #region Constructors: Public

        public UZDomainTranslator(Ticket ticket) {
            _ticket = ticket;
        }

        #endregion

        #region Methods: Public

        public UZTrainsRequest GetTrainRequest() {
            return new UZTrainsRequest {
                StationFromId = _ticket.StartingPointId,
                StationTillId = _ticket.DestinationPointId,
                DepartureDate = _ticket.DepartureDate,
                StationFromName = _ticket.StartingPointName,
                StationTillName = _ticket.DestinationPointName,
            };
        }

        public UZCoachesRequest GetCoachesRequest(UZTrain train, UZCoachType coach) {
            return new UZCoachesRequest {
                StationFromId = _ticket.StartingPointId,
                StationTillId = _ticket.DestinationPointId,
                DepartureDate = train.From.DepartureDate,
                TrainNumber = train.Number,
                CoachType = coach.TypeLetter
            };
        }

        public UZPlacesRequest GetPlacesRequest(UZCoachSet coachSet, UZCoach coach) {
            return new UZPlacesRequest {
                StationFromId = _ticket.StartingPointId,
                StationTillId = _ticket.DestinationPointId,
                DepartureDate = coachSet.OwnerRequest.DepartureDate,
                TrainNumber = coachSet.OwnerRequest.TrainNumber,
                CoachNumber = coach.Number,
                CoachClass = coach.CoachClass,
                CoachTypeId = coach.SchemeId
            };
        }

        public UZCardRequest GetCardRequest(int placeNumber, UZPlacesSet placesSet) {
            return new UZCardRequest {
                StationFromId = _ticket.StartingPointId,
                StationTillId = _ticket.DestinationPointId,
                TrainNumber = placesSet.OwnerRequest.TrainNumber,
                DepartureDate = DateTime.Parse(_ticket.DepartureDate).ToString("yyyy-MM-dd"),
                Charline = placesSet.Places.AvaliablePlaceNumbers.First().Key,
                CoachNumber = placesSet.OwnerRequest.CoachNumber,
                CoachClass = placesSet.OwnerRequest.CoachClass,
                CoachType = UZCoachTypeMapper.GetCoachLetter(placesSet.OwnerRequest.CoachTypeId),
                FirstName = _ticket.FirstName,
                LastName = _ticket.LastName,
                IsTransp = "0",
                IsBedding = "1",
                PlaceNumber = placeNumber
            };
        }

        #endregion

    }
}
