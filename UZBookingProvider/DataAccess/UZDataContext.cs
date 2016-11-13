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

        private UZTrainSet _trainSet;
        private UZCoachSet _coachSet;
        private UZPlacesSet _placesSet;
        private UZCardSet _cardSet;

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

        public async Task<UZTrainSet> GetTrains() {
            var requestConfig = new UZTrainsRequest {
                StationFromName = _road.StartingPointName,
                StationFromId = _road.StartingPointId,
                StationTillName = _road.DestinationPointName,
                StationTillId = _road.DestinationPointId,
                DepartureDate = _road.DepartureDate
            };
            return await _gateway.GetTrains(requestConfig);
        }

        public async Task<UZCoachSet> GetCoaches() {
            var trainSet = await GetTrains();
            return null;
        }

        public async Task<UZPlacesSet> GetPlaces() {
            throw new NotImplementedException();
        }

        public void Dispose() {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
