using System;
using Acute.Angular;

namespace Acute
{
    public abstract class App
    {
        private Module _module;

        protected App()
        {
           _module = new Module(this.GetType().FullName); 
        }
    }
}