using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Acute.Services
{
    public interface IHttp
    {
        Task<HttpResponse> RequestAsync(HttpRequest request);
        Task<HttpResponse> GetAsync(string url);
        Task<HttpResponse> PostAsync(string url, object data);
        Task<HttpResponse> PutAsync(string url, object data);
        Task<HttpResponse> HeadAsync(string url);
        Task<HttpResponse> DeleteAsync(string url);
    }

    public class Http : IHttp
    {
        private readonly Angular.Http _angularHttp;

        [Reflectable]
        internal Http(Angular.Http _http)
        {
            _angularHttp = _http;
        }


        public Task<HttpResponse> RequestAsync(HttpRequest request)
        {
            return Task.FromPromise<Angular.HttpResponse, HttpResponse>(_angularHttp
                .Request(request),
                                                               (response) =>
                                                               new HttpResponse((HttpStatusCode) response.Status, response.Data)); 
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

        public Task<HttpResponse> PutAsync(string url, object data)
        {
            return Task.FromPromise<Angular.HttpResponse, HttpResponse>(_angularHttp
                .Put(url, data),
                                                               (response ) =>
                                                               new HttpResponse((HttpStatusCode)response.Status, response.Data)); 
        }

        public Task<HttpResponse> HeadAsync(string url)
        {
            return Task.FromPromise<Angular.HttpResponse, HttpResponse>(_angularHttp
                .Head(url),
                                                               (response) =>
                                                               new HttpResponse((HttpStatusCode) response.Status, response.Data)); 
        }

        public Task<HttpResponse> DeleteAsync(string url)
        {
            return Task.FromPromise<Angular.HttpResponse, HttpResponse>(_angularHttp
                .Delete(url),
                                                               (response) =>
                                                               new HttpResponse((HttpStatusCode) response.Status, response.Data)); 
        }
    }
}