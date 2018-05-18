using Patterns.Core.ChainOfResponsibility.Interfaces;
using Patterns.Core.Command.Interfaces;
using Patterns.Core.Decorator;
using System;
using System.Collections.Generic;

namespace Patterns.Core.ChainOfResponsibility
{
    public class ChainOfResponsibility<TCommands, TInput, TOutput> : IChainOfResponsibility<TCommands, TInput, TOutput>
                                                                            where TCommands : IEnumerable<DecoratedCommand<TInput, TOutput>>
                                                                            where TInput : class
    {
        public TCommands Commands { get; }

        public ChainOfResponsibility(TCommands commands)
        {
            if (commands == null)
                throw new InvalidOperationException("No Handlers registered.");

            Commands = commands;
        }

        public TOutput Handle(TInput input)
        {
            var commands = Commands.GetEnumerator();
            while (commands.MoveNext())
            {
                if (commands.Current.CanHandle(input))
                    return commands.Current.Execute(input);
            }
            return default(TOutput);
        }
    }
}
