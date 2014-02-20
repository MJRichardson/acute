using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Acute.Angular
{
    [Imported]
    internal class Http
    {
      [InlineCode("{this}.get({Url})")] 
      public HttpPromise Get(string Url) { return null; }
    }

   [Imported]
   internal sealed class HttpPromise : IPromise
   {
      [ScriptName("success")]
      public HttpPromise Success(Action<object, object> handler) { return this; }
      //[ScriptName("success")] public HttpPromise Success(Action<object, object, object> handler) { return this; }
      //[ScriptName("success")] public HttpPromise Success(Action<object, object, object, object>) { return this; }

      //[ScriptName("error")] public HttpPromise Error(HttpDelegate2 function) { return this; }
      //[ScriptName("error")] public HttpPromise Error(HttpDelegate3 function) { return this; }
      //[ScriptName("error")] public HttpPromise Error(HttpDelegate4 function) { return this; }

      [ScriptName("then")]
      public HttpPromise Then(object success, object error)
      {
          return this.Then(success, error, null);
      }

      [ScriptName("then")]
      public HttpPromise Then(object success, object error, object notify)
      {
         return this;
      }

      [ScriptName("then")]
       void IPromise.Then(Delegate fulfilledHandler)
      {
          this.Then(fulfilledHandler, null);
      }

      [ScriptName("then")]
       void IPromise.Then(Delegate fulfilledHandler, Delegate errorHandler)
      {
          this.Then(fulfilledHandler, errorHandler);
      }

      [ScriptName("then")]
       void IPromise.Then(Delegate fulfilledHandler, Delegate errorHandler, Delegate progressHandler)
      {
          this.Then(fulfilledHandler, errorHandler, progressHandler);
      }
   }

   [Imported]
   internal class HttpResponse
   {
      [ScriptName("data")]     public object Data;
      [ScriptName("status")]   public int Status;
      [ScriptName("headers")]  public HttpResponseHeaders Headers;

      [InlineCode("{this}.data")]
      public T DataAs<T>()
      {
         return default(T);
      }
   }

   [Imported]
   internal class HttpResponseHeaders
   {
      //[IntrinsicProperty]
      public string this[string key] 
      { 
         [InlineCode("{this}({key})")]
         get {return null;}           
      } 

      public JsDictionary<string, string> Items
      {
         [InlineCode("{this}()")]
         get {return null;}           
      }
   }
}