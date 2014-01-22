namespace Test.Scenarios.Controllers
{
    public class Controller : Acute.Controller
    {
        public Controller()
        {
            SimpleString = "Yabba dabba doo!";
        }

        public string SimpleString { get; set; }
    }
}