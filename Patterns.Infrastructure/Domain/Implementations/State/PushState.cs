using Patterns.Core.Command.Interfaces;
using Patterns.Core.State;
using Patterns.Infrastructure.Domain.Entities;
using System.Collections.Generic;
using System.Text;

namespace Patterns.Infrastructure.Domain.Implementations.State
{
    public class PushState : StateMachine<List<ICommand<Log, StringBuilder>>, Log, StringBuilder>
    {
        public PushState(List<ICommand<Log, StringBuilder>> commands) : base(commands)
        {
        }
    }
}
