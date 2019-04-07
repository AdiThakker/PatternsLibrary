using System;
using Patterns.Core.Command.Interfaces;
using Patterns.Core.Mediator.Interfaces;

namespace Patterns.Core.Mediator
{
    public class CommandHandler : ICommandHandler
    {
        public TResponse Handle<TType, TRequest, TResponse>(TRequest request)
            where TType : ICommand<TRequest, TResponse>, new()
            where TRequest : class
        {
            TType command = new TType();

            //TODO : Move to extension method
            var commandInstance = (ICommand<TRequest, TResponse>)Activator.CreateInstance(command.GetType());
            return commandInstance.Execute(request);
        }
    }
}
