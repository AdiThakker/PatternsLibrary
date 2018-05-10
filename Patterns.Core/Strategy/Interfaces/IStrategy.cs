using Patterns.Core.Command.Interfaces;
using System;

namespace Patterns.Core.Strategy.Interfaces
{
    public interface IStrategy<TCommand, TInput, TOutput>
                                        where TCommand : ICommand<TInput, TOutput>
                                        where TInput : class
    {
        TOutput GetCommandAndExecute(Func<TCommand> getCommand, TInput input);
    }
}
