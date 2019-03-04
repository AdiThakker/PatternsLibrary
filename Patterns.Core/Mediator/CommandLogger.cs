using System;
using Patterns.Core.Command.Interfaces;
using Patterns.Core.Mediator.Interfaces;

namespace Patterns.Core.Mediator
{
    public class CommandLogger : ICommandHandler
    {
        public TResponse Handle<TType, TRequest, TResponse>(TType command, TRequest request)
            where TType : ICommand<TRequest, TResponse>
            where TRequest : class
        {
            // TODO: Add Logging behavior
            var commandInstance = (ICommand <TRequest, TResponse>)Activator.CreateInstance(command.GetType());
            return commandInstance.Execute(request);
        }
    }
}
