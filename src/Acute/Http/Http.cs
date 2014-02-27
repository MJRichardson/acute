using System;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Acute.Http
{
    public interface IHttp
    {
        Task<HttpResponse> GetAsync(string url);
        Task<HttpResponse> PostAsync(string url, object data);
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
            return Task.FromPromise<Angular.HttpResponse, HttpResponse>(_angularHttp
                .Get(url),
                                                               (response) =>
                                                               new HttpResponse((HttpStatusCode) response.Status, response.Data)); 
        }

        public Task<HttpResponse> PostAsync(string url, object data)
        {
            return Task.FromPromise<Angular.HttpResponse, HttpResponse>(_angularHttp
                .Post(url, data),
                                                               (response ) =>
                                                               new HttpResponse((HttpStatusCode)response.Status, response.Data)); 
        }
    }
}