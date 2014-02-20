using System.Net.Http;

namespace Acute.Http
{
    public class HttpRequest
    {
        public HttpMethod HttpMethod { get; set; }
        public string Url { get; set; }

        public HttpRequest(HttpMethod httpMethod, string url)
        {
            HttpMethod = httpMethod;
            Url = url;
        }
    }
}