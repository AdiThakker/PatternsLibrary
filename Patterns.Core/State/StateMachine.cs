using Patterns.Core.Command.Interfaces;
using Patterns.Core.State.Interfaces;
using System;
using System.Collections.Generic;

namespace Patterns.Core.State
{
    public class StateMachine<TCommand, TInput, TOutput> : IStateMachine<TCommand, TInput, TOutput>
                                                            where TCommand : IEnumerable<ICommand<TInput, TOutput>>
                                                            where TInput : class
    {
        public List<ICommand<TInput, TOutput>> Commands { get; }
        private List<ICommand<TInput, TOutput>>.Enumerator CurrentState;

        public StateMachine(List<ICommand<TInput, TOutput>> commands)
        {
            Commands = commands ?? throw new ArgumentNullException(nameof(commands));
            CurrentState = Commands.GetEnumerator();
        }

        public TOutput ExecuteCurrent(TInput input)
        {
            if (!CurrentState.MoveNext())
                return CurrentState.Current.Execute(input);

            return default(TOutput);
        }
    }
}
