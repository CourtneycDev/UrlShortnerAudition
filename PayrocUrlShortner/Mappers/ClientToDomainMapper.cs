using Dom = DomainTypes.Models.Requests;
using Client = PayrocUrlShortner.Models.Requests;

namespace PayrocUrlShortner.Mappers
{
    public static class ClientToDomainMapper
    {
        public static Dom.ShortenUrlRequest Map(Client.ShortenUrlRequest request)
        {
            return new Dom.ShortenUrlRequest()
            {
                Url = request.Url
            };
        }
    }
}