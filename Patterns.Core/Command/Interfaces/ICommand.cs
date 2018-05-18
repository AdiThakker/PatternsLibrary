namespace Patterns.Core.Command.Interfaces
{
    public interface ICommand<TInput, TOutput> where TInput : class
    {
        TOutput Execute(TInput input);
    }
}
