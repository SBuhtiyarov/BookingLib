using System;
using UZBookingProvider.Http;

namespace UZBookingProvider.Gateway
{
    //TODO: access level - public?
    class UZDataGatewaySlim: UZDataGateway, IUZDataGatewaySlim
    {
        public UZDataGatewaySlim(UZAPIConfig config)
            : base(config, new UZSerializer()) {
            var baseURI = string.Format("{0}/{1}", _apiConfig.Host, _apiConfig.Culture);
            _requestExecutor = new BaseHttpRequestExecutor(baseURI);
        }
    }
}
