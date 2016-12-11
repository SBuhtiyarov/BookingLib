using System;
using CITR.UZBookingProvider.Http;

namespace CITR.UZBookingProvider.Gateway
{
    //TODO: access level - public? move accessible to dataContext?
    class UZDataGatewaySlim: UZDataGateway, IUZDataGatewaySlim
    {
        public UZDataGatewaySlim(UZAPIConfig config)
            : base(config, new UZSerializer()) {
            //var baseURI = string.Format("{0}/{1}", _apiConfig.Host, _apiConfig.Culture);
            _requestExecutor = new BaseHttpRequestExecutor(_apiConfig.Host);
        }
    }
}
