
namespace System.Net.Http
{
    public class HttpMethod : IEquatable<HttpMethod>
    {

        private static readonly HttpMethod GetMethod = new HttpMethod("GET");
        private static readonly HttpMethod PutMethod = new HttpMethod("PUT");
        private static readonly HttpMethod PostMethod = new HttpMethod("POST");
        private static readonly HttpMethod DeleteMethod = new HttpMethod("DELETE");
        private static readonly HttpMethod HeadMethod = new HttpMethod("HEAD");
        private static readonly HttpMethod OptionsMethod = new HttpMethod("OPTIONS");
        private static readonly HttpMethod TraceMethod = new HttpMethod("TRACE");
        private readonly string _method;

        public static HttpMethod Get
        {
            get { return HttpMethod.GetMethod; }
        }

        public static HttpMethod Put
        {
            get { return HttpMethod.PutMethod; }
        }

        public static HttpMethod Post
        {
            get { return HttpMethod.PostMethod; }
        }

        public static HttpMethod Delete
        {
            get { return HttpMethod.DeleteMethod; }
        }

        public static HttpMethod Head
        {
            get { return HttpMethod.HeadMethod; }
        }

        public static HttpMethod Options
        {
            get { return HttpMethod.OptionsMethod; }
        }

        public static HttpMethod Trace
        {
            get { return HttpMethod.TraceMethod; }
        }

        public string Method
        {
            get { return this._method; }
        }

        public HttpMethod(string method)
        {
            if (string.IsNullOrEmpty(method))
                throw new ArgumentNullException("method");

            _method = method;
        }

 public static bool operator ==(HttpMethod left, HttpMethod right)
    {
      if (left == null)
        return right == null;
      if (right == null)
        return left == null;
      else
        return left.Equals(right);
    }

    public static bool operator !=(HttpMethod left, HttpMethod right)
    {
      return !(left == right);
    }

    public bool Equals(HttpMethod other)
    {
      if (other == null)
        return false;
      if (object.ReferenceEquals((object) _method, (object) other._method))
        return true;

        return this._method == other._method;
    }

    public override bool Equals(object obj)
    {
      return this.Equals(obj as HttpMethod);
    }

    public override int GetHashCode()
    {
      return this._method.ToLower().GetHashCode();
    }

    public override string ToString()
    {
      return this._method;
    }
    }
}