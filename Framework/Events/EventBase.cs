using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NinkyNonk.Shared.Framework.Events
{

    public abstract class EventBase : INinkyEvent
    {
        protected EventBase()
        {
            Subscribers = new List<IEventSubscriber>();
        }

        protected List<IEventSubscriber> Subscribers { get; }

        public abstract Task Setup();

        public virtual void AddEventListener<T1>() where T1 : IEventSubscriber, new()
        {
            Subscribers.Add(new T1());
        }

        public virtual void AddEventListener(IEventSubscriber obj)
        {
            Subscribers.Add(obj);
        }

        public async virtual Task RemoveEventListener(string identifier)
        {
            IEventSubscriber t = Subscribers.FirstOrDefault(c => c.Identifier == identifier);
            if (t == null)
                return;
            Subscribers.Remove(t);
        }

        public async virtual Task RemoveEventListener(IEventSubscriber subscriber)
        {
            if (!Subscribers.Contains(subscriber))
                return;
            Subscribers.Remove(subscriber);
        }

        public abstract void Dispose();
    }

    public abstract class EventBase<T> : INinkyEvent<T> where T : IEventArguments
    {
        

        protected EventBase()
        {
            Subscribers = new List<IEventSubscriber<T>>();
        }

        protected List<IEventSubscriber<T>> Subscribers { get; }

        public abstract Task Setup();

        public virtual void AddEventListener<T1>() where T1 : IEventSubscriber<T>, new()
        {
            Subscribers.Add(new T1());
        }

        public virtual void AddEventListener(IEventSubscriber<T> obj)
        {
            Subscribers.Add(obj);
        }

        public async virtual Task RemoveEventListener(string identifier)
        {
            IEventSubscriber<T> t = Subscribers.FirstOrDefault(c => c.Identifier == identifier);
            if (t == null)
                return;
            Subscribers.Remove(t);
        }
        
        public async virtual Task RemoveEventListener(IEventSubscriber<T> subscriber)
        {
            if (!Subscribers.Contains(subscriber))
                return;
            Subscribers.Remove(subscriber);
        }

        public abstract void Dispose();
    }
}