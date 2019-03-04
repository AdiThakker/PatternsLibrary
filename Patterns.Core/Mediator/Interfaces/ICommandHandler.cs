using Patterns.Core.Command.Interfaces;

namespace Patterns.Core.Mediator.Interfaces
{
    interface ICommandHandler
    {
        TResponse Handle<TType, TRequest, TResponse>(TType command, TRequest request) where TType : ICommand<TRequest, TResponse> where TRequest : class;
    }
}
