using System;
using System.Text;
using Patterns.Core.Command.Interfaces;
using Patterns.Core.Mediator.Interfaces;

namespace Patterns.Core.Mediator
{
    public class CommandHandlerAndLogger : ICommandHandler
    {
        public StringBuilder LogStatus { get; private set; }

        public CommandHandlerAndLogger() => LogStatus = new StringBuilder();

        public TResponse Handle<TType, TRequest, TResponse>(TRequest request)
            where TType : ICommand<TRequest, TResponse>, new()
            where TRequest : class
        {
            TType command = new TType();

            LogStatus.AppendLine($"Instantiating command {command.GetType()}");

            //TODO : Move to extension method
            var commandInstance = (ICommand<TRequest, TResponse>)Activator.CreateInstance(command.GetType());
            var result = commandInstance.Execute(request);

            LogStatus.AppendLine($"Executed command {command.GetType()} and got the result {result.ToString()}");

            return result;
        }
    }
}
