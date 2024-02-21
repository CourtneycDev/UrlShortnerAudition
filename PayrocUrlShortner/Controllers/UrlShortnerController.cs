using PayrocUrlShortner.Mappers;
using PayrocUrlShortner.Models.Requests;
using System;
using System.Web.Http;

namespace PayrocUrlShortner.Controllers
{
    public class UrlShortnerController : BaseController
    {

        public IHttpActionResult Get(string id)
        {
            /* 
                Improvements: Add caching
                When a URL is retrieved add it to the cache.
                Subsequent requests to the same URL can be fetched from the cache.
                Faster + less calls to DB.
             */

            if (id == null ||
               id == string.Empty)
            {
                return NotFound();
            }

            string longUrl = UrlShorteningWorker.GetLongUrl(id);

            if (longUrl == string.Empty)
            {
                return NotFound();
            }

            return Redirect(new Uri(longUrl));
        }

        public IHttpActionResult Post([FromBody] ShortenUrlRequest request)
        {
            if (!IsValidUrl(request.Url))
            {
                return BadRequest("The specified URL is invalid.");
            }

            if (!IsValidDomain(request.Url))
            {
                return BadRequest("The specified URL must be from an external domain.");
            }

            string id = UrlShorteningWorker.SaveLongUrl(ClientToDomainMapper.Map(request));
            return Created(GetLocationUrl(), id);
        }
    }
}
