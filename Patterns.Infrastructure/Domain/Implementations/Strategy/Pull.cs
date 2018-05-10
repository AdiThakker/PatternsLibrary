using Patterns.Core.Command;
using Patterns.Core.Command.Interfaces;
using Patterns.Core.Strategy;
using Patterns.Infrastructure.Domain.Entities;

namespace Patterns.Infrastructure.Domain.Implementations.Strategy
{
    public class Pull : Strategy<ICommand<Log, bool>, Log, bool>
    {
        public bool Execute(Log log)
        {
            return GetCommandAndExecute(() => GenerateCommand(log), log);
        }

        private static ICommand<Log, bool> GenerateCommand(Log log)
        {
            switch (log.TableName)
            {
                case "Table_X":
                case "Table_Y":
                    return new Command<Log, bool>(logItem =>
                    {
                        return true;
                    });
                default:
                    return new Command<Log, bool>(logItem =>
                    {
                        return false;
                    });
            }
        }
    }
}
