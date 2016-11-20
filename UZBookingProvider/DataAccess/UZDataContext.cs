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
        private IUZDomainTranslator _translator;
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

        public UZDataContext(Ticket ticket, UZAPIConfig apiConfig) {
            _translator = new UZDomainTranslator(ticket);
            _gateway = new UZDataGateway(apiConfig);
        }

        //TODO: filtering from date interval
        public async Task<UZTrainSet> GetTrains() {
            var request = _translator.GetTrainRequest();
            var trainSet = await _gateway.GetTrains(request);
            return trainSet;
        }

        public async Task<List<UZCoachSet>> GetCoaches(UZTrain train, CoachType coachType) {
            var coaches = coachType != CoachType.Any
                ? train.AvaliableCoaches.Where(it => it.TypeLetter.Equals(UZCoachTypeMapper.GetCoachLetter(coachType)))
                : train.AvaliableCoaches;
            var coachSets = new List<UZCoachSet>();
            foreach (var coach in coaches) {
                var requestConfig = _translator.GetCoachesRequest(train, coach);
                var coachesSet = await _gateway.GetCoaches(requestConfig);
                coachSets.Add(coachesSet);
            }
            return coachSets;
        }

        //TODO: filtering from price
        public async Task<List<UZPlacesSet>> GetPlaces(UZCoachSet coachSet) {
            var placesSets = new List<UZPlacesSet>();
            foreach (var coach in coachSet.Coaches) {
                var requestConfig = _translator.GetPlacesRequest(coachSet, coach);
                var placeSet = await _gateway.GetPlaces(requestConfig);
                placesSets.Add(placeSet);
            }
            return placesSets;
        }

        public async Task<UZCardSet> AddPlaceToCard(int placeNumber, UZPlacesSet placeSet) {
            var requestConfig = _translator.GetCardRequest(placeNumber, placeSet);
            var cardSet = await _gateway.AddPlaceToCard(requestConfig);
            return cardSet;
        }

        public void Dispose() {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
