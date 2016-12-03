using System.Net.Http.Headers;
using System.Threading.Tasks;
using CITR.UZBookingProvider.Http.Security;
using System.Net.Http;

namespace CITR.UZBookingProvider.Http
{
    class UZHttpRequestExecutor: BaseHttpRequestExecutor
    {
        private IToken _token;

        public UZHttpRequestExecutor(string serviceBaseAddress, IToken token)
            : base(serviceBaseAddress) {
            _token = token;
        }

        private void InitHttpClientHeaders() {
            //TODO: decrease coupling
            _httpClient.DefaultRequestHeaders.Add("GV-Ajax", "1");
            _httpClient.DefaultRequestHeaders.Add("GV-Token", _token.Value);
            _httpClient.DefaultRequestHeaders.Add("GV-Screen", "1440x900");
            _httpClient.DefaultRequestHeaders.Add("Connection", "keep-alive");
            _httpClient.DefaultRequestHeaders.Add("Host", "booking.uz.gov.ua");
            _httpClient.DefaultRequestHeaders.Add("Origin", "http://booking.uz.gov.ua");
            _httpClient.DefaultRequestHeaders.Add("GV-Referer", "http://booking.uz.gov.ua/ru/");
            _httpClient.DefaultRequestHeaders.AcceptEncoding.Add(StringWithQualityHeaderValue.Parse("gzip"));
            _httpClient.DefaultRequestHeaders.UserAgent.Add(new ProductInfoHeaderValue(new ProductHeaderValue("HttpClient", "1.0")));
        }

        private async Task InitConnection() {
            var mainPage = await GetAsync(_serviceBaseAddress);
            _token.DecodeToken(mainPage);
            InitHttpClientHeaders();
        }

        public async override Task<string> PostAsync(string addressSuffix, FormUrlEncodedContent model) {
            if (!_token.IsInitialized) {
                await InitConnection();
            }
            return await base.PostAsync(addressSuffix, model);
        }

    }
}