using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Acute.Services
{
    public interface ILocation
    {
        string Path { get; set; } 
    }

    public class Location
    {
        private readonly Angular.Location _angularLocation;

        [Reflectable]
        internal Location(Angular.Location angularLocation)
        {
            _angularLocation = angularLocation;
        }

        public string AbsoluteUrl
        {
            get { return _angularLocation.AbsUrl; }
        }

        public string Host
        {
            get { return _angularLocation.Host; }
        }

        public int Port
        {
            get { return _angularLocation.Port; }
        } 

        public string Protocol
        {
            get { return _angularLocation.Protocol; }
        } 

        public string Path
        {
            get { return _angularLocation.Path; }
            set { _angularLocation.Path = value; }
        }

        public string Hash
        {
            get { return _angularLocation.Hash; }
            set { _angularLocation.Hash = value; }
        }

        public JsDictionary<string, string> Search
        {
            get { return _angularLocation.Search; }
            set { _angularLocation.Search = value; }
        } 

    }
}