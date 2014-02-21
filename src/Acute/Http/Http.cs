using System;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Acute.Http
{
    public interface IHttp
    {
        Task<HttpResponse> GetAsync(string url);
    }

    public class HttpDefault : IHttp
    {
        private readonly Angular.Http _angularHttp;

        [Reflectable]
        internal HttpDefault(Angular.Http _http)
        {
            _angularHttp = _http;
        }


        public Task<HttpResponse> GetAsync(string url)
        {
            return Task.FromPromise<string, int, HttpResponse>(_angularHttp
                .Get(url),
                                                               (data, status) =>
                                                               new HttpResponse((HttpStatusCode) status)); 
        }
    }
}