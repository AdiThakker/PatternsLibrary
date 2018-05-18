using Patterns.Core.Decorator;
using Patterns.Infrastructure.Domain.Entities;
using System;
using System.Text;

namespace Patterns.Infrastructure.Domain.Implementations.Decorator
{
    public class DecoratedUpdate : DecoratedCommand<Log, StringBuilder>
    {
        public DecoratedUpdate(Func<Log, StringBuilder> strategy) : base(strategy)
        {
        }

        public override bool CanHandle(Log input)
        {
            return input.Action.Equals("Update", StringComparison.OrdinalIgnoreCase);
        }
    }
}
