using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Patterns.Core.Command.Interfaces;
using Patterns.Core.Mediator.Interfaces;

namespace Patterns.Core.Composite
{
    public class CompositeHandler : ICommandHandler 
    {
        private IEnumerable<ICommandHandler> commandHandlers;

        public CompositeHandler(IEnumerable<ICommandHandler> handlers)
        {
            commandHandlers = handlers ?? throw new ArgumentNullException(nameof(handlers));
        }

        public TResponse Handle<TType, TRequest, TResponse>(TRequest request)
            where TType : ICommand<TRequest, TResponse>, new()
            where TRequest : class
        {
            if (commandHandlers == null)
                throw new InvalidOperationException("No Command Handlers found.");

            return commandHandlers.Aggregate(new List<TResponse>(), (result, handler) =>
            {
                try
                {
                    result.Add(handler.Handle<TType, TRequest, TResponse>(request));
                }
                catch (Exception)
                {
                    // TODO Handle exceptions                    
                }
                return result;
            }).Last();
        }
    }
}
