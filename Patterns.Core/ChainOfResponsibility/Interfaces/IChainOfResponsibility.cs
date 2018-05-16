using Patterns.Core.Command.Interfaces;
using System.Collections.Generic;

namespace Patterns.Core.ChainOfResponsibility.Interfaces
{
    public interface IChainOfResponsibility<TCommands, TInput, TOutput>
                                                where TCommands : IEnumerable<ICommand<TInput, TOutput>>
                                                where TInput : class
    {
        TOutput Handle(TInput input);
    }
}
