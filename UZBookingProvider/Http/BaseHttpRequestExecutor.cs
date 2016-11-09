using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace UZBookingProvider
{
    class BaseHttpRequestExecutor : IHttpRequestExecutor<FormUrlEncodedContent>
    {
        #region Fields: Protected

        protected bool _disposed = false;
        protected HttpClient _httpClient;
        protected CookieContainer _cookieContainer;
        protected HttpClientHandler _httpClientHandler;
        protected readonly string _serviceBaseAddress;
        protected readonly string _mediaType;

        public string Cookies {
            get {
                var cookies = string.Empty;
                var baseURI = new Uri(_serviceBaseAddress);
                var cookieCollection = _cookieContainer.GetCookies(baseURI);
                foreach (var cookie in cookieCollection) {
                    cookies += string.Format("{0};", cookie.ToString());
                }
                return cookies;
            }
        }

        #endregion

        #region Constructors: Public

        public BaseHttpRequestExecutor(string serviceBaseAddress) {
            _serviceBaseAddress = serviceBaseAddress;
            _mediaType = "application/x-www-form-urlencoded";
            _httpClient = MakeHttpClient(serviceBaseAddress);
        }

        #endregion

        #region Methods: Protected

        protected virtual void InitHttpClientHeaders() {
            _httpClient.DefaultRequestHeaders.Accept.Add(MediaTypeWithQualityHeaderValue.Parse(_mediaType));
        }

        protected virtual HttpClient MakeHttpClient(string serviceBaseAddress) {
            _cookieContainer = new CookieContainer();
            _httpClientHandler = new HttpClientHandler() { CookieContainer = _cookieContainer };
            _httpClient = new HttpClient(_httpClientHandler);
            _httpClient.BaseAddress = new Uri(serviceBaseAddress);
            return _httpClient;
        }

        protected void Dispose(bool disposing) {
            if (!_disposed && disposing) {
                if (_httpClient != null) {
                    var hc = _httpClient;
                    _httpClient = null;
                    hc.Dispose();
                }
                if (_httpClientHandler != null) {
                    var hch = _httpClientHandler;
                    _httpClientHandler = null;
                    hch.Dispose();
                }
                _disposed = true;
            }
        }

        #endregion

        #region Methods: Public

        public virtual Task InitConnection() {
            InitHttpClientHeaders();
            return Task.FromResult(0);
        }

        public async Task<string> GetAsync(string addressSuffix) {
            var responseMessage = await _httpClient.GetAsync(addressSuffix);
            responseMessage.EnsureSuccessStatusCode();
            return await responseMessage.Content.ReadAsStringAsync();
        }

        public async Task<string> PostAsync(string addressSuffix, FormUrlEncodedContent model) {
            var responseMessage = await _httpClient.PostAsync(addressSuffix, model);
            return await responseMessage.Content.ReadAsStringAsync();
        }

        public void Dispose() {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}
