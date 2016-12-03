using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CITR.UZBookingProvider.Domain;
using CITR.UZBookingProvider.Gateway;

namespace CITR.UZBookingProvider.DataAccess
{
    class UZBookingRepository: IBookingRepository, IDisposable
    {
        #region Fields: Private

        private bool _disposed = false;
        
        private IUZDataContext _dataContext;

        private List<UZPlacesSet> _placesSets;

        #endregion

        #region Methods: Private

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

        #endregion

        #region Methods: Public

        public UZBookingRepository(Ticket ticket, UZAPIConfig apiConfig) {
            //TODO: maybe possible to instanse context whith Trip and forward it to repository?
            _dataContext = new UZDataContext(ticket, apiConfig);
            _placesSets = new List<UZPlacesSet>();
        }

        public async Task<Dictionary<string, int>> GetAvaliablePlacesCount(CoachType coachType) {
            var trainSet = await _dataContext.GetTrains();
            var placesCount = trainSet.Trains.SelectMany(train => train.AvaliableCoaches)
                .GroupBy(coach => coach.TypeLetter)
                    .ToDictionary(gcoach => gcoach.Key, gcoach => gcoach
                        .Sum(it => it.PlacesCount));
            return placesCount;
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

        #endregion
    }
}
