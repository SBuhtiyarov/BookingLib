using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using UZBookingProvider;
using UZBookingProvider.Domain;

namespace UZBookingProvider
{
    class UZDataContext: IDisposable
    {
        #region Fields: private

        private bool _disposed = false;
        private IHttpRequestExecutor<FormUrlEncodedContent> _requestExecutor;
        private UZAPIConfig apiConfig;

        #endregion

        #region Methods: Private

        private FormUrlEncodedContent SerializeRequest(object request) {
            var json = JsonConvert.SerializeObject(request);
            var jsonDict = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);
            return new FormUrlEncodedContent(jsonDict.ToArray());
        }

        private void Dispose(bool disposing) {
            if (!_disposed && disposing) {
                if (_requestExecutor != null) {
                    var re = _requestExecutor;
                    _requestExecutor = null;
                    re.Dispose();
                }
                _disposed = true;
            }
        }

        #endregion

        #region Constructors: Public

        public UZDataContext(UZAPIConfig config) {
            apiConfig = config;
            var baseURI = string.Format("{0}/{1}", config.Host, config.Culture);
            _requestExecutor = new UZHttpRequestExecutor(baseURI, new UZToken());
            _requestExecutor.InitConnection();
       } 

        #endregion

        #region Methods: Public

        public async Task<UZTrainSet> GetTrains(UZTrainsRequest request) {
            var response = await _requestExecutor.PostAsync(apiConfig.TrainsURI, SerializeRequest(request));
            //TODO: process deserialize error when no trains
            var trainSet = JsonConvert.DeserializeObject<UZTrainSet>(response);
            return trainSet;
        }

        public async Task<UZCoachSet> GetCoaches(UZCoachesRequest request) {
            var response = await _requestExecutor.PostAsync(apiConfig.CoachesURI, SerializeRequest(request));
            var coachSet = JsonConvert.DeserializeObject<UZCoachSet>(response);
            return coachSet;
        }

        public async Task<UZPlacesSet> GetPlaces(UZPlacesRequest request) {
            var response = await _requestExecutor.PostAsync(apiConfig.PlacesURI, SerializeRequest(request));
            var placesSet = JsonConvert.DeserializeObject<UZPlacesSet>(response);
            return placesSet;
        }

        public async Task<UZCardSet> AddPlaceToCard(UZAddPlaceRequestConfig request) {
            var response =  await _requestExecutor.PostAsync(apiConfig.CardURI, SerializeRequest(request));
            var cardSet = JsonConvert.DeserializeObject<UZCardSet>(response);
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