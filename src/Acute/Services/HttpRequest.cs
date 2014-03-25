using System.Collections.Generic;
using System.Net.Http;

namespace Acute.Services
{
    public class HttpRequest
    {
        /// <summary>
        /// HTTP method (e.g. 'GET', 'POST', etc)
        /// </summary>
        public HttpMethod HttpMethod { get; set; }

        /// <summary>
        /// Absolute or relative URL of the resource that is being requested.
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// Data to be sent as the request message data.
        /// </summary>
        public object Data { get; set; }

        /// <summary>
        ///  Map of strings which will be turned to ?key1=value1&key2=value2 after the url.
        /// </summary>
        public JsDictionary<string, string> Parameters { get; private set; } 

        public HttpRequest(HttpMethod httpMethod, string url)
        {
            HttpMethod = httpMethod;
            Url = url;
            Parameters = new JsDictionary<string, string>();
        }
    }
}