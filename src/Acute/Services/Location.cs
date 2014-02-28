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

        public string Path
        {
            get { return _angularLocation.Path; }
            set { _angularLocation.Path = value; }
        }
    }
}