using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UZBookingProvider.Domain;

namespace UZBookingProvider.DataAccess
{
    class UZDataContext: IDisposable
    {
        private bool _disposed = false;
        private Trip _road;
        private IUZDataGateway _gateway;

        private void Dispose(bool disposing) {
            if (!_disposed && disposing) {
                if (_gateway != null) {
                    var gw = (IDisposable)_gateway;
                    _gateway = null;
                    gw.Dispose();
                }
                _disposed = true;
            }
        }

        public UZDataContext(Trip road, UZAPIConfig apiConfig) {
            _road = road;
            _gateway = new UZDataGateway(apiConfig);
        }

        //TODO: filtering from some date interval
        public async Task<UZTrainSet> GetTrains() {
            var request = new UZTrainsRequest {
                StationFromId = _road.StartingPointId,
                StationTillId = _road.DestinationPointId,
                DepartureDate = _road.DepartureDate,
                StationFromName = _road.StartingPointName,
                StationTillName = _road.DestinationPointName,
            };
            var trainSet = await _gateway.GetTrains(request);
            return trainSet;
        }

        public async Task<List<UZCoachSet>> GetCoaches(UZTrain train, CoachType coachType = CoachType.Any) {
            var coaches = coachType != CoachType.Any
                ? train.AvaliableCoaches.Where(it => it.TypeLetter.Equals(CoachTypes.Mapping[coachType]))
                : train.AvaliableCoaches;
            var coachSets = new List<UZCoachSet>();
            foreach (var coach in coaches) {
                var requestConfig = new UZCoachesRequest {
                    StationFromId = _road.StartingPointId,
                    StationTillId = _road.DestinationPointId,
                    DepartureDate = train.From.DepartureDate,
                    TrainNumber = train.Number,
                    CoachType = coach.TypeLetter
                };
                var coachesSet = await _gateway.GetCoaches(requestConfig);
                coachSets.Add(coachesSet);
            }
            return coachSets;
        }

        public async Task<List<UZPlacesSet>> GetPlaces(UZCoachSet coachSet) {
            var placesSets = new List<UZPlacesSet>();
            foreach (var coach in coachSet.Coaches) {
                var requestConfig = new UZPlacesRequest {
                    StationFromId = _road.StartingPointId,
                    StationTillId = _road.DestinationPointId,
                    DepartureDate = coachSet.OwnerRequest.DepartureDate,
                    TrainNumber = coachSet.OwnerRequest.TrainNumber,
                    CoachNumber = coach.Number,
                    CoachClass = coach.CoachClass,
                    CoachTypeId = coach.CoachType
                };
                var placeSet = await _gateway.GetPlaces(requestConfig);
                placesSets.Add(placeSet);
            }
            return placesSets;
        }


        public void Dispose() {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
