using Patterns.Core.Decorator;
using Patterns.Infrastructure.Domain.Entities;
using System;
using System.Text;

namespace Patterns.Infrastructure.Domain.Implementations.Decorator
{
    public class DecoratedAdd : DecoratedCommand<Log, StringBuilder>
    {
        public DecoratedAdd(Func<Log, StringBuilder> strategy) : base(strategy)
        {
        }

        public override bool CanHandle(Log input)
        {
            return input.Action.Equals("Add", StringComparison.OrdinalIgnoreCase);
        }
    }
}
