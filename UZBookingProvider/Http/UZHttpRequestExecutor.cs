using System.Net.Http.Headers;
using System.Threading.Tasks;
using CITR.UZBookingProvider.Http.Security;

namespace CITR.UZBookingProvider.Http
{
    class UZHttpRequestExecutor: BaseHttpRequestExecutor
    {
        private IToken _token;

        public UZHttpRequestExecutor(string serviceBaseAddress, IToken token)
            : base(serviceBaseAddress) {
            _token = token;
        }

        protected override void InitHttpClientHeaders() {
            base.InitHttpClientHeaders();
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

        public override async Task InitConnection() {
            var mainPage = await GetAsync(_serviceBaseAddress);
            _token.DecodeToken(mainPage);
            await base.InitConnection();
        }
    }
}