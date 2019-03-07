using Patterns.Core.Command;
using Patterns.Infrastructure.Domain.Entities;
using System;
using System.Text;

namespace Patterns.Infrastructure.Domain.Implementations.Command
{
    public class Update : Command<Log, StringBuilder>
    {
        public Update() : base((_) => new StringBuilder("Update"))
        {
        }

        public Update(Func<Log, StringBuilder> strategy) : base(strategy)
        {
        }
    }
}
