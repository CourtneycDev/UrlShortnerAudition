using DomainTypes.Contracts.Repositories;

namespace DAL.Repositories
{
    public class ShortenUrlRepository : IShortenUrlRepository
    {
        private ShortenedUrlDAL shortenedUrlDAL = new ShortenedUrlDAL();

        public string GetLongUrl(int id)
        {
            return shortenedUrlDAL.GetLongUrl(id);
        }

        public int SaveShortenedUrl(string longUrl)
        {
            return shortenedUrlDAL.SaveShortenedUrl(longUrl);
        }
    }
}
