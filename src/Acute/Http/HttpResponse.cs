using System.Net.Http;

namespace Acute.Http
{
    public class HttpResponse
    {
        public HttpStatusCode Status { get; set; }

        public HttpResponse(HttpStatusCode status)
        {
            Status = status;
        }
    }
}