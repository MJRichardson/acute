using System.Net.Http;
using System.Runtime.CompilerServices;

namespace Acute.Services
{
    public class HttpResponse
    {
        public HttpStatusCode Status { get; private set; }

        public string Data { get; private set; }

        [InlineCode("{this}.get_data()")]
        public T DataAs<T>()
        {
            return default(T);
        }

        //todo: headers

        public HttpResponse(HttpStatusCode status) :this(status, null)
        {
        }

        public HttpResponse(HttpStatusCode status, string body)
        {
            Status = status;
            Data = body;
        }
    }
}