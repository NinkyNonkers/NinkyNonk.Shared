namespace NinkyNonker.Events
{
    public class EventArgument<TArgType> : IEventArguments
    {
        public TArgType Argument { get; }
        
        public EventArgument(TArgType arg)
        {
            Argument = arg;
        }
    }
}