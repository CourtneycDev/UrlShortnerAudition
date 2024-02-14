namespace DomainTypes.Models.Requests
{
    public class ShortenUrlRequest : RequestBase
    {
        public string Url { get; set; } = string.Empty;
    }
}
