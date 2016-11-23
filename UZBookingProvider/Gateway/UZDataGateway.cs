using System;
using System.Net.Http;
using System.Threading.Tasks;
using UZBookingProvider.Domain;
using UZBookingProvider.Http;
using UZBookingProvider.Http.Security;

namespace UZBookingProvider.Gateway
{
    class UZDataGateway: IUZDataGateway, IDisposable
    {
        #region Fields: Private

        private bool _disposed = false;
        private IHttpRequestExecutor<FormUrlEncodedContent> _requestExecutor;
        private UZAPIConfig _apiConfig;
        private IUZSerializer _serializer;

        #endregion

        #region Methods: Private

        private void Dispose(bool disposing) {
            if (!_disposed && disposing) {
                if (_requestExecutor != null) {
                    var re = (IDisposable)_requestExecutor;
                    _requestExecutor = null;
                    re.Dispose();
                }
                _disposed = true;
            }
        }

        #endregion

        #region Constructors: Public

        public UZDataGateway(UZAPIConfig config) {
            _apiConfig = config;
            _serializer = new UZSerializer();
            var baseURI = string.Format("{0}/{1}", config.Host, config.Culture);
            _requestExecutor = new UZHttpRequestExecutor(baseURI, new UZToken());
            _requestExecutor.InitConnection();
       } 

        #endregion

        #region Methods: Public

        public async Task<UZTrainSet> GetTrains(UZTrainsRequest request) {
            var serializedRequest = _serializer.SerializeRequest(request);
            var response = await _requestExecutor.PostAsync(_apiConfig.TrainsURI, serializedRequest);
            var trainSet = _serializer.DeserializeResponse<UZTrainSet>(response);
            trainSet.OwnerRequest = request;
            return trainSet;
        }

        public async Task<UZCoachSet> GetCoaches(UZCoachesRequest request) {
            var serializedRequest = _serializer.SerializeRequest(request);
            var response = await _requestExecutor.PostAsync(_apiConfig.CoachesURI, serializedRequest);
            var coachSet = _serializer.DeserializeResponse<UZCoachSet>(response);
            coachSet.OwnerRequest = request;
            return coachSet;
        }

        public async Task<UZPlacesSet> GetPlaces(UZPlacesRequest request) {
            var serializedRequest = _serializer.SerializeRequest(request);
            var response = await _requestExecutor.PostAsync(_apiConfig.PlacesURI, serializedRequest);
            var placesSet = _serializer.DeserializeResponse<UZPlacesSet>(response);
            placesSet.OwnerRequest = request;
            return placesSet;
        }

        public async Task<UZCardSet> AddPlaceToCard(UZCardRequest request) {
            var serializedRequest = _serializer.SerializeRequest(request);
            var response =  await _requestExecutor.PostAsync(_apiConfig.CardURI, serializedRequest);
            var cardSet = _serializer.DeserializeResponse<UZCardSet>(response);
            cardSet.OwnerRequest = request;
            cardSet.Cookies = _requestExecutor.Cookies;
            return cardSet;
        }

        public void Dispose() {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}