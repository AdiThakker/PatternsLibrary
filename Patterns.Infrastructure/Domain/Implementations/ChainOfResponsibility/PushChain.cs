using Patterns.Core.ChainOfResponsibility;
using Patterns.Core.Decorator;
using Patterns.Infrastructure.Domain.Entities;
using System.Collections.Generic;
using System.Text;

namespace Patterns.Infrastructure.Domain.Implementations.ChainOfResponsibility
{
    public class PushChain : ChainOfResponsibility<List<DecoratedCommand<Log, StringBuilder>>, Log, StringBuilder>
    {
        public PushChain(List<DecoratedCommand<Log, StringBuilder>> commands) : base(commands)
        {
        }
    }
}
