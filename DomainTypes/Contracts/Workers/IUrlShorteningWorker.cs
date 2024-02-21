using DomainTypes.Models.Requests;

namespace DomainTypes.Contracts.Workers
{
    public interface IUrlShorteningWorker
    {
        string SaveLongUrl(ShortenUrlRequest request);
        string GetLongUrl(string encodedId);
    }
}
