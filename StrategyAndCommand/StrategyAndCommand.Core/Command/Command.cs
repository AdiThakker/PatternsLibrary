using StrategyAndCommand.Core.Command.Interfaces;
using System;

namespace StrategyAndCommand.Core.Command
{
    public class Command<TInput, TOutput> : ICommand<TInput, TOutput> where TInput : class
    {
        public Func<TInput, TOutput> _strategy { get; private set; }

        public Command(Func<TInput, TOutput> strategy)
        {
            this._strategy = strategy;
        }

        public virtual TOutput Execute(TInput input)
        {
            if (this._strategy == null)
                throw new InvalidOperationException($"Command cannot be executed. Please provide a Strategy!!!");

            // delegate
            return this._strategy(input);
        }
    }
}
