using StrategyAndCommand.Core.Command.Interfaces;
using System;

namespace StrategyAndCommand.Core.Strategy
{
    public class Strategy<TCommand, TInput, TOutput>
                                        where TCommand : ICommand<TInput, TOutput>
                                        where TInput : class
    {
        public TOutput GetAndExecute(Func<TCommand> get, TInput input)
        {
            try
            {
                return get().Execute(input);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
