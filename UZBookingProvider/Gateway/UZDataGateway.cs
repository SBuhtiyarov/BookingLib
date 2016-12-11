using System;
using System.Net.Http;
using System.Threading.Tasks;
using CITR.UZBookingProvider.Domain;
using CITR.UZBookingProvider.Http;
using CITR.UZBookingProvider.Http.Security;

namespace CITR.UZBookingProvider.Gateway
{
    class UZDataGateway: IUZDataGateway, IDisposable
    {
        #region Fields: Protected

        protected bool _disposed = false;
        protected IHttpRequestExecutor<FormUrlEncodedContent> _requestExecutor;
        protected UZAPIConfig _apiConfig;
        protected IUZSerializer _serializer;

        #endregion

        #region Methods: Protected

        protected void Dispose(bool disposing) {
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

        public UZDataGateway(UZAPIConfig config)
            : this(config, new UZSerializer()) {
            var token = new UZToken(config.TokenPattern);
            _requestExecutor = new UZHttpRequestExecutor(_apiConfig.Host, token);
       }

        public UZDataGateway(UZAPIConfig config, IUZSerializer serializer) {
            _apiConfig = config;
            _serializer = serializer;
        }

        #endregion

        #region Methods: Public

        public async Task<UZStationSet> GetStations(string request) {
            var requestURI = string.Format("{0}{1}{2}", _apiConfig.Culture, _apiConfig.StationsURI, request);
            var response = await _requestExecutor.GetAsync(requestURI);
            var stationSet = _serializer.DeserializeResponse<UZStationSet>(response);
            return stationSet;
        }

        public async Task<UZTrainSet> GetTrains(UZTrainsRequest request) {
            var serializedRequest = _serializer.SerializeRequest(request);
            var requestedUri = string.Format("{0}{1}", _apiConfig.Culture, _apiConfig.TrainsURI);
            var response = await _requestExecutor.PostAsync(requestedUri, serializedRequest);
            var trainSet = _serializer.DeserializeResponse<UZTrainSet>(response);
            trainSet.OwnerRequest = request;
            return trainSet;
        }

        public async Task<UZCoachSet> GetCoaches(UZCoachesRequest request) {
            var serializedRequest = _serializer.SerializeRequest(request);
            var requestedUri = string.Format("{0}{1}", _apiConfig.Culture, _apiConfig.CoachesURI);
            var response = await _requestExecutor.PostAsync(requestedUri, serializedRequest);
            var coachSet = _serializer.DeserializeResponse<UZCoachSet>(response);
            coachSet.OwnerRequest = request;
            return coachSet;
        }

        public async Task<UZPlacesSet> GetPlaces(UZPlacesRequest request) {
            var serializedRequest = _serializer.SerializeRequest(request);
            var requestedUri = string.Format("{0}{1}", _apiConfig.Culture, _apiConfig.PlacesURI);
            var response = await _requestExecutor.PostAsync(requestedUri, serializedRequest);
            var placesSet = _serializer.DeserializeResponse<UZPlacesSet>(response);
            placesSet.OwnerRequest = request;
            return placesSet;
        }

        public async Task<UZCardSet> AddPlaceToCard(UZCardRequest request) {
            var serializedRequest = _serializer.SerializeRequest(request);
            var requestedUri = string.Format("{0}{1}", _apiConfig.Culture, _apiConfig.CardURI);
            var response =  await _requestExecutor.PostAsync(requestedUri, serializedRequest);
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