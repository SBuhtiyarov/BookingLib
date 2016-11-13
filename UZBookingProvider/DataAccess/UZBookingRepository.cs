using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UZBookingProvider.DataAccess;

namespace UZBookingProvider
{
    class UZBookingRepository: IBookingRepository, IDisposable
    {
        private bool _disposed = false;
        //TODO: interface
        private UZDataContext _dataContext;

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

        public UZBookingRepository(Trip road, UZAPIConfig apiConfig) {
            //TODO: maybe possible to instanse context whith Trip and forwart it to repository?
            _dataContext = new UZDataContext(road, apiConfig);
        }

        public Dictionary<CoachType, int> GetAvaliablePlacesCount(CoachType coachType) {
            throw new NotImplementedException();
        }

        public Dictionary<CoachType, int[]> GetAvaliablePlaces(CoachType coachType) {
            throw new NotImplementedException();
        }

        public string AddPlaceToCard(int place, CoachType coachType) {
            throw new NotImplementedException();
        }

        public void Dispose() {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
