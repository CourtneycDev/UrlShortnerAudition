using DAL.DataAccess;
using DomainTypes.Contracts.Repositories;

namespace DAL.Repositories
{
    public class ShortenUrlRepository : IShortenUrlRepository
    {
        private ShortenedUrlDAL shortenedUrlDAL = new ShortenedUrlDAL();

        public string GetLongUrl(string token)
        {
            return shortenedUrlDAL.GetLongUrl(token);
        }

        public bool IsUniqueToken(string token)
        {
            return shortenedUrlDAL.IsUniqueToken(token);
        }

        public void SaveShortenedUrl(string longUrl, string token)
        {
            shortenedUrlDAL.SaveShortenedUrl(longUrl, token);
        }
    }
}
