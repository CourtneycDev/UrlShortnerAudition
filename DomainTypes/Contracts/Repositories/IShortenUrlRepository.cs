namespace DomainTypes.Contracts.Repositories
{
    public interface IShortenUrlRepository
    {
        void SaveShortenedUrl(string longUrl, string token);
        string GetLongUrl(string token);
        bool IsUniqueToken(string token);
    }
}
