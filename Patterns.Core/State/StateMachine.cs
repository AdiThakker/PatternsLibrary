﻿using Patterns.Core.ChainOfResponsibility.Interfaces;
using Patterns.Core.Command.Interfaces;
using System;
using System.Collections.Generic;

namespace Patterns.Core.State
{
    public class StateMachine<TCommands, TInput, TOutput> : IChainOfResponsibility<TCommands, TInput, TOutput>
                                                                            where TCommands : IEnumerable<ICommand<TInput, TOutput>>
                                                                            where TInput : class
    {
        public TCommands Commands { get; }

        private readonly IEnumerator<ICommand<TInput, TOutput>> CurrentState;

        public StateMachine(TCommands commands)
        {
            if (commands == null)
                throw new InvalidOperationException("No Handlers registered.");

            Commands = commands;
            CurrentState = Commands.GetEnumerator();
        }

        public TOutput Handle(TInput input)
        {
            if (CurrentState.MoveNext())
                return CurrentState.Current.Execute(input);

            return default(TOutput);
        }
    }
}
