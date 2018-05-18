using Patterns.Core.Command;
using System;

namespace Patterns.Core.Decorator
{
    public class DecoratedCommand<TInput, TOutput> : Command<TInput, TOutput> where TInput : class
    {
        public DecoratedCommand(Func<TInput, TOutput> strategy) : base(strategy)
        {
        }

        public virtual bool CanHandle(TInput input)
        {
            return true;
        }

        public override TOutput Execute(TInput input)
        {
            return base.Execute(input);
        }
    }
}
