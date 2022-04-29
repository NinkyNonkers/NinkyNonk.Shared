using System;
using System.Threading.Tasks;

namespace NinkyNonk.Shared.Framework.Events
{
    public interface INinkyEvent<out TParam> : IDisposable where TParam : IEventArguments
    {
         Task Setup();
         void AddEventListener<T>() where T : IEventSubscriber<TParam>, new();
         void AddEventListener(IEventSubscriber<TParam> obj);
         Task RemoveEventListener(string identifier);
         Task RemoveEventListener(IEventSubscriber<TParam> subscriber);
    }

    public interface INinkyEvent : IDisposable
    {
         Task Setup();
         void AddEventListener<T>() where T : IEventSubscriber, new();
         void AddEventListener(IEventSubscriber obj);
         Task RemoveEventListener(string identifier);
         Task RemoveEventListener(IEventSubscriber subscriber);
    }
}