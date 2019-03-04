using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
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

        public TResponse Dispatch<TType, TRequest, TResponse>(TType command, TRequest request)
            where TType : ICommand<TRequest, TResponse>
            where TRequest : class
        {
            if (dispatchers == null)
                throw new InvalidOperationException("Invalid state. Cannot dispatch this command.");

            if (dispatchers.TryGetValue(command.GetType(), out ICommandHandler handler))
            return handler.Handle<TType, TRequest, TResponse>(command, request);

            return default(TResponse);
        }
    }
}
