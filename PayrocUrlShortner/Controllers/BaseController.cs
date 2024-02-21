using Domain.Workers;
using DomainTypes.Contracts.Workers;
using System;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.Http;

namespace PayrocUrlShortner.Controllers
{
    public abstract class BaseController : ApiController
    {
        private IUrlShorteningWorker _urlShorteningWorker;

        protected IUrlShorteningWorker UrlShorteningWorker
        {
            get
            {
                if (_urlShorteningWorker == null)
                {
                    _urlShorteningWorker = new UrlShorteningWorker();
                }
                return _urlShorteningWorker;
            }
        }

        protected string GetLocationUrl()
        {
            return $"{HttpContext.Current.Request.Url.AbsoluteUri}/";
        }

        protected bool IsValidUrl(string url)
        {
            Uri uriResult;
            return Uri.TryCreate(url, UriKind.Absolute, out uriResult) &&
                (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);
        }

        protected bool IsValidDomain(string url)
        {
            var requestDommain = new Uri(url).GetLeftPart(UriPartial.Authority);
            string clientDomain = HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority);
            return requestDommain != clientDomain ? true : false;
        }
    }
}
