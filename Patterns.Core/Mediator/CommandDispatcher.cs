using System;
using Patterns.Core.Command.Interfaces;
using Patterns.Core.Mediator.Interfaces;

namespace Patterns.Core.Mediator
{
    public class CommandDispatcher : ICommandDispatcher
    {
        public TResponse Dispatch<TType, TRequest, TResponse>(TType command, TRequest request)
            where TType : ICommand<TRequest, TResponse>
            where TRequest : class
        {
            throw new NotImplementedException();
        }
    }
}
