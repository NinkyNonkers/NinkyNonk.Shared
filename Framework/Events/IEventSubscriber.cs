using System.Threading.Tasks;

namespace NinkyNonk.Shared.Framework.Events
{
    public interface IEventSubscriber<in T> where T : IEventArguments
    {
         Task Fire(T t);
         string Identifier { get; }
    }
    
    public interface IEventSubscriber
    {
         Task Fire();
         string Identifier { get; }
    }
}