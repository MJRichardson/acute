using System;

namespace Acute.Angular
{
    internal class AngularServiceAttribute : Attribute
    {
        public string ServiceName { get; private set; }

        public AngularServiceAttribute(string serviceName)
        {
            ServiceName = serviceName;
        }
    }
}