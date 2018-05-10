using Patterns.Core.Command.Interfaces;
using Patterns.Core.Strategy.Interfaces;
using System;

namespace Patterns.Core.Strategy
{
    public class Strategy<TCommand, TInput, TOutput> : IStrategy<TCommand, TInput, TOutput>
                                                        where TCommand : ICommand<TInput, TOutput>
                                                        where TInput : class
    {
        public TOutput GetCommandAndExecute(Func<TCommand> getCommand, TInput input)
        {
            if (getCommand == null)
                throw new ArgumentNullException(nameof(getCommand));

            if (input == null)
                throw new ArgumentNullException(nameof(input));

            try
            {
                return getCommand()
                        .Execute(input);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
