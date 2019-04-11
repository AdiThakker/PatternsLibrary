using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using Patterns.Core.Command.Interfaces;
using Patterns.Core.Composite;
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

                handlerLookup.AddOrUpdate(typeof(Add), new CommandHandler(),  (_,handler) => handler);
                handlerLookup.AddOrUpdate(typeof(DecoratedAdd), new CommandHandlerAndLogger(), (_, logger) => logger);

                // Composite setup
                List<ICommandHandler> handlers = new List<ICommandHandler>() { new CommandHandler(), new CommandHandlerAndLogger() };
                CompositeHandler compositeHandler = new CompositeHandler(handlers);

                handlerLookup.AddOrUpdate(typeof(DecoratedUpdate), new CompositeHandler(handlers), (_, loggers) => loggers);

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
