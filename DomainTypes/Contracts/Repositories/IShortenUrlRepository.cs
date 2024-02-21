namespace DomainTypes.Contracts.Repositories
{
    public interface IShortenUrlRepository
    {
        int SaveShortenedUrl(string longUrl);
        string GetLongUrl(int id);
    }
}
