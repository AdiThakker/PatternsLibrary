using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Patterns.Core.Command.Interfaces;
using Patterns.Core.Mediator;
using Patterns.Core.Mediator.Interfaces;
using Patterns.Infrastructure.Domain.Implementations.Command;

namespace Patterns.Infrastructure.Domain.Implementations.Mediator
{
    public class CommandMediator
    {
        public CommandMediator()
        {
            new CommandDispatcher(() =>
            {
                var handlerLookup = new ConcurrentDictionary<Type, ICommandHandler>();
                // handlerLookup.AddOrUpdate(typeof(Add), )
                return handlerLookup;
            });
        }
    }
}
