using System;
using System.Collections.Concurrent;
using Patterns.Core.Command.Interfaces;
using Patterns.Core.Mediator.Interfaces;

namespace Patterns.Core.Mediator
{
    public class CommandDispatcher : ICommandDispatcher
    {
        ConcurrentDictionary<Type, ICommandHandler> dispatchers;

        public CommandDispatcher(Func<ConcurrentDictionary<Type, ICommandHandler>> getDispatchers)
        {
            if (getDispatchers == null)
                throw new ArgumentNullException(nameof(getDispatchers));

            dispatchers = getDispatchers();
        }

        public TResponse Dispatch<TType, TRequest, TResponse>(TRequest request)
            where TType : ICommand<TRequest, TResponse>, new()
            where TRequest : class
        {
            if (dispatchers == null)
                throw new InvalidOperationException("Invalid state. Cannot dispatch this command.");

            if (dispatchers.TryGetValue(typeof(TType), out ICommandHandler handler))
            return handler.Handle<TType, TRequest, TResponse>(request);

            return default(TResponse);
        }
    }
}
