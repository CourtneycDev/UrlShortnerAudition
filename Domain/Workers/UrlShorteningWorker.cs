using DAL.Repositories;
using DomainTypes.Models.Requests;
using DomainTypes.Contracts.Repositories;
using System;
using DomainTypes.Contracts.Workers;
using System.Text;

namespace Domain.Workers
{
    public class UrlShorteningWorker : IUrlShorteningWorker
    {
        private IShortenUrlRepository shortenedUrlRepo = new ShortenUrlRepository();

        public string SaveLongUrl(ShortenUrlRequest request)
        {
            int id = shortenedUrlRepo.SaveShortenedUrl(request.Url);
            return Base64Encode(id);
        }

        public string GetLongUrl(string encodedId)
        {
            int id = Base64Decode(encodedId);
            return shortenedUrlRepo.GetLongUrl(id);
        }

        private string Base64Encode(int id)
        {
            byte[] plainTextBytes = Encoding.UTF8.GetBytes(id.ToString());
            return Convert.ToBase64String(plainTextBytes);
        }

        private int Base64Decode(string encodedId)
        {
            byte[] encodedBytes = Convert.FromBase64String(encodedId);
            return int.Parse(Encoding.UTF8.GetString(encodedBytes));
        }
    }
}
