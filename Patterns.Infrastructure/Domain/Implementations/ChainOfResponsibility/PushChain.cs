using Patterns.Core.ChainOfResponsibility;
using Patterns.Core.Command.Interfaces;
using Patterns.Infrastructure.Domain.Entities;
using System.Collections.Generic;
using System.Text;

namespace Patterns.Infrastructure.Domain.Implementations.ChainOfResponsibility
{
    public class PushChain : ChainOfResponsibility<List<ICommand<Log, StringBuilder>>, Log, StringBuilder>
    {
        public PushChain(List<ICommand<Log, StringBuilder>> commands) : base(commands)
        {
        }
    }
}
