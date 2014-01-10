using System;

namespace Acute
{
    public interface RouteProvider
    {
        RouteProvider When(string path);
    }
}