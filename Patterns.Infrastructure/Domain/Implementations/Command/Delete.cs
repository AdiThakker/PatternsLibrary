using Patterns.Core.Command;
using Patterns.Infrastructure.Domain.Entities;
using System;
using System.Text;

namespace Patterns.Infrastructure.Domain.Implementations.Command
{
    public class Delete : Command<Log, StringBuilder>
    {
        public Delete() : base((_) => new StringBuilder("Delete"))
        {
        }

        public Delete(Func<Log, StringBuilder> strategy) : base(strategy)
        {
        }
    }
}
