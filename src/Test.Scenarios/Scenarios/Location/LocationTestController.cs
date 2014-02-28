namespace Test.Scenarios.Scenarios.Location
{
    public class LocationTestController : Acute.Controller
    {
        private readonly Acute.Services.Location _location;

        public LocationTestController(Acute.Services.Location location)
        {
            _location = location;
        }
    }
}