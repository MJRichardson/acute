using System.Runtime.CompilerServices;
using Acute.Angular;

namespace Acute.Services
{
    public interface ICookies
    {
        string this[string key] { get; set; }
        T Get<T>(string key);
        void Put<T>(string key, T item);
        void Remove(string key);
    }

    public class Cookies : ICookies
    {
        private readonly CookieStore _angularCookieStore;
        private readonly Angular.Cookies _angularCookies;

        [Reflectable]
        internal Cookies(Angular.CookieStore cookieStore, Angular.Cookies cookies)
        {
            _angularCookieStore = cookieStore;
            _angularCookies = cookies;
        }

        public string this[string key]
        {
            get { return _angularCookies.Get(key); }
            set { _angularCookies.Set(key, value); }
        }


        public T Get<T>(string key)
        {
            return (T) _angularCookieStore.Get(key);
        }

        public void Put<T>(string key, T item)
        {
            _angularCookieStore.Put(key, item);
        }

        public void Remove(string key)
        {
            _angularCookieStore.Remove(key);
        }
    }
}