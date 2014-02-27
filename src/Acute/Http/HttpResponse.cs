using System.Net.Http;

namespace Acute.Http
{
    public class HttpResponse
    {
        public HttpStatusCode Status { get; private set; }

        public string Body { get; private set; }

        public HttpResponse(HttpStatusCode status) :this(status, null)
        {
        }

        public HttpResponse(HttpStatusCode status, string body)
        {
            Status = status;
            Body = body;
        }
    }
}