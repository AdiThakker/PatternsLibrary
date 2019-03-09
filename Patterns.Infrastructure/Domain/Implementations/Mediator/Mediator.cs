using System;
using System.Collections.Concurrent;
using Patterns.Core.Command.Interfaces;
using Patterns.Core.Mediator;
using Patterns.Core.Mediator.Interfaces;

namespace Patterns.Infrastructure.Domain.Implementations.Mediator
{
    public class Mediator<TType, TRequest, TResponse>
        where TType : ICommand<TRequest, TResponse>
        where TRequest : class
    {
        TType command = default(TType);

        private static CommandDispatcher dispatcher  = new CommandDispatcher(() =>
            {
            var handlerLookup = new ConcurrentDictionary<Type, ICommandHandler>();
            // handlerLookup.AddOrUpdate(typeof(Add), )
            return handlerLookup;
        });

        public TResponse Handle(TRequest request)
        {
            return dispatcher.Dispatch<TType, TRequest, TResponse>(request);
        }
    }
}
