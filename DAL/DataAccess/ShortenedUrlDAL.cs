using System;
using System.Linq;

namespace DAL
{
    public class ShortenedUrlDAL
    {
        /* Improvements: Error handling incase DB communication fails for whatever reason. */
        public int SaveShortenedUrl(string longUrl)
        {
            using (PayrocUrlShortnerEntities dbContext = new PayrocUrlShortnerEntities())
            {
                ShortenedUrl shortenedUrl = new ShortenedUrl()
                {
                    LongUrl = longUrl,
                    DateCreated = DateTime.Now,
                };

                dbContext.ShortenedUrls.Add(shortenedUrl);
                dbContext.SaveChanges();
                return shortenedUrl.ID;
            }
        }

        public string GetLongUrl(int id)
        {
            using (PayrocUrlShortnerEntities dbContext = new PayrocUrlShortnerEntities())
            {
                ShortenedUrl record = (from s in dbContext.ShortenedUrls
                                       select s).Where(t => t.ID == id).FirstOrDefault();

                return record != null ? record.LongUrl : string.Empty;
            }
        }
    }
}
