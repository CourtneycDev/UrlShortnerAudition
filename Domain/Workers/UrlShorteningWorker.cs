using DAL.Repositories;
using DomainTypes.Models.Requests;
using DomainTypes.Contracts.Repositories;
using System;
using DomainTypes.Contracts.Workers;

namespace Domain.Workers
{
    public class UrlShorteningWorker : IUrlShorteningWorker
    {
        /* Improvements: These could be made into configurable values.*/
        private const int NumberOfCharsInShortLink = 7;
        private const string Alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

        private Random _random = new Random();
        private IShortenUrlRepository shortenedUrlDAL = new ShortenUrlRepository();

        public string GenerateUniqueToken(ShortenUrlRequest request)
        {
            /* 
                Improvements: Generate tokens ahead of time
                When someone tries to shorten a URL you already have a unique token ready
                This will remove the need to check against the DB that it is unique
            */

            while (true)
            {               
                string token = BuildToken();

                if (shortenedUrlDAL.IsUniqueToken(token))
                {
                    shortenedUrlDAL.SaveShortenedUrl(request.Url, token);
                    return token;
                }
            }
        }

        public string GetLongUrl(string token)
        {
            return shortenedUrlDAL.GetLongUrl(token);
        }

        private string BuildToken()
        {
            var tokenChars = new char[NumberOfCharsInShortLink];

            for (int index = 0; index < NumberOfCharsInShortLink; index++)
            {
                int randomIndex = _random.Next(Alphabet.Length - 1);
                tokenChars[index] = Alphabet[randomIndex];
            }

            return new string(tokenChars);
        }
    }
}
