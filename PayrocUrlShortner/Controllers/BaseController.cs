using Domain.Workers;
using DomainTypes.Contracts.Workers;
using System;
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

        protected string GetRedirectUrl()
        {
            return $"{HttpContext.Current.Request.Url.AbsoluteUri}?token=";
        }

        protected bool IsValidUrl(string url)
        {
            Uri uriResult;
            return Uri.TryCreate(url, UriKind.Absolute, out uriResult) &&
                (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);
        }
    }
}
