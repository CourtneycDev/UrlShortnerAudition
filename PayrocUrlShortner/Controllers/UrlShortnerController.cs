using PayrocUrlShortner.Mappers;
using PayrocUrlShortner.Models.Requests;
using System;
using System.Web.Http;

namespace PayrocUrlShortner.Controllers
{
    public class UrlShortnerController : BaseController
    {
        public IHttpActionResult Get(string token)
        {
            /* 
                Improvements: Add caching
                When a URL is retrieved add it to the cache.
                Subsequent requests to the same URL can be fetched from the cache.
                Faster + less calls to DB.
             */

            if(token == null)
            {
                return NotFound();
            }

            string longUrl = UrlShorteningWorker.GetLongUrl(token);

            if(longUrl == string.Empty)
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

            string token = GetRedirectUrl() + UrlShorteningWorker.GenerateUniqueToken(ClientToDomainMapper.Map(request));
            return Ok(token);
        }
    }
}
