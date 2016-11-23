using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UZBookingProvider.DataAccess;
using UZBookingProvider.Domain;

namespace UZBookingProvider
{
    class UZBookingRepository: IBookingRepository, IDisposable
    {
        private bool _disposed = false;

        //TODO: interface
        private UZDataContext _dataContext;

        private List<UZPlacesSet> _placesSets;

        private void Dispose(bool disposing) {
            if (!_disposed && disposing) {
                if (_dataContext != null) {
                    var dc = (IDisposable)_dataContext;
                    _dataContext = null;
                    dc.Dispose();
                }
                _disposed = true;
            }
        }

        public UZBookingRepository(Ticket ticket, UZAPIConfig apiConfig) {
            //TODO: maybe possible to instanse context whith Trip and forward it to repository?
            _dataContext = new UZDataContext(ticket, apiConfig);
            _placesSets = new List<UZPlacesSet>();
        }

        public Dictionary<CoachType, int> GetAvaliablePlacesCount(CoachType coachType) {
            throw new NotImplementedException();
        }

        public async Task<Dictionary<CoachType, IEnumerable<int>>> GetAvaliablePlaces(CoachType coachType = CoachType.Any) {
            var trainSet = await _dataContext.GetTrains();
            var coachSets = new List<UZCoachSet>();
            foreach (var train in trainSet.Trains) {
                var coachSetsPart = await _dataContext.GetCoaches(train, coachType);
                coachSets.AddRange(coachSetsPart);
            }
            foreach (var coachSet in coachSets) {
                var placesSetPart = await _dataContext.GetPlaces(coachSet);
                _placesSets.AddRange(placesSetPart);
            }
            //TODO: Any
            var placesPerCoach = _placesSets.GroupBy(set => set.OwnerRequest.CoachTypeId)
                .ToDictionary(gset => UZCoachTypeMapper.GetCoachType(gset.Key), gset => gset
                    .SelectMany(set => set.Places.AvaliablePlaceNumbers.Values
                        .SelectMany(placeArray => placeArray))
                    .Distinct());
            return placesPerCoach;
        }

        public async Task<string> AddPlaceToCard(int place) {
            var placeSet = _placesSets
                .Where(set => set.Places.AvaliablePlaceNumbers.Values
                    .Any(placeArray => placeArray.Contains(place)));
            var cardSet = await _dataContext.AddPlaceToCard(place, placeSet.First());
            return cardSet.Cookies;
        }

        public void Dispose() {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
