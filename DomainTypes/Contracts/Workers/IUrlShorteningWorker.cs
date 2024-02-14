using DomainTypes.Models.Requests;

namespace DomainTypes.Contracts.Workers
{
    public interface IUrlShorteningWorker
    {
        string GenerateUniqueToken(ShortenUrlRequest request);
        string GetLongUrl(string token);
    }
}
