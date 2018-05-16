namespace Patterns.Core.Command.Interfaces
{
    public interface ICommand<TInput, TOutput> where TInput : class
    {
        bool CanHandle(TInput input);

        TOutput Execute(TInput input);
    }
}
