using StrategyAndCommand.Core.Command.Interfaces;
using System;

namespace StrategyAndCommand.Core.Strategy.Interfaces
{
    public interface IStrategy<TCommand, TInput, TOutput>
                                        where TCommand : ICommand<TInput, TOutput>
                                        where TInput : class
    {
        TOutput GetCommandAndExecute(Func<TCommand> getCommand, TInput input);
    }
}
