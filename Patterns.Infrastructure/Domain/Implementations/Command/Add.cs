using Patterns.Core.Command;
using Patterns.Infrastructure.Domain.Entities;
using System;
using System.Text;

namespace Patterns.Infrastructure.Domain.Implementations.Command
{
    class Add : Command<Log, StringBuilder>
    {
        public Add(Func<Log, StringBuilder> strategy) : base(strategy)
        {
        }
    }
}
