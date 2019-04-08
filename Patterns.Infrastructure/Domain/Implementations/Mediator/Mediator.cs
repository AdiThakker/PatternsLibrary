using System;
using System.Collections.Concurrent;
using Patterns.Core.Command.Interfaces;
using Patterns.Core.Mediator;
using Patterns.Core.Mediator.Interfaces;
using Patterns.Infrastructure.Domain.Implementations.Command;
using Patterns.Infrastructure.Domain.Implementations.Decorator;

namespace Patterns.Infrastructure.Domain.Implementations.Mediator
{
    public class Mediator
    {
        // Setup dispatcher with DI
        private static CommandDispatcher dispatcher  = new CommandDispatcher(() =>
            {
                var handlerLookup = new ConcurrentDictionary<Type, ICommandHandler>();

                handlerLookup.AddOrUpdate(typeof(Add), new CommandHandler(),  (_,logger) => logger);
                handlerLookup.AddOrUpdate(typeof(DecoratedAdd), new CommandHandlerAndLogger(), (_, logger) => logger);
                handlerLookup.AddOrUpdate(typeof(DecoratedUpdate), new CommandHandlerAndLogger(), (_, logger) => logger);

                return handlerLookup;
        });

        public TResponse Handle<TType, TRequest, TResponse>(TRequest request)
        where TType : ICommand<TRequest, TResponse>, new()
        where TRequest : class
        {
            return dispatcher.Dispatch<TType, TRequest, TResponse>(request);
        }
    }
}
