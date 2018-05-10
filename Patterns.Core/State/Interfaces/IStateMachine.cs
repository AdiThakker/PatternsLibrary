using Patterns.Core.Command.Interfaces;
using System.Collections.Generic;

namespace Patterns.Core.State.Interfaces
{
    public interface IStateMachine<TCommand, TInput, TOutput>
                                        where TCommand : IEnumerable<ICommand<TInput, TOutput>>
                                        where TInput : class
    {
        TOutput ExecuteCurrent(TInput input);
    }
}
