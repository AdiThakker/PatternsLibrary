using Patterns.Core.Command.Interfaces;

namespace Patterns.Core.Mediator.Interfaces
{
    public interface ICommandDispatcher
    {
        TResponse Dispatch<TType, TRequest, TResponse>(TRequest request) where TType : ICommand<TRequest, TResponse> where TRequest : class;
    }
}
