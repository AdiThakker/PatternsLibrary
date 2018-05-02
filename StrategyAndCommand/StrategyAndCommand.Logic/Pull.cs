using StrategyAndCommand.Core.Command;
using StrategyAndCommand.Core.Command.Interfaces;
using StrategyAndCommand.Core.Strategy;
using StrategyAndCommand.Logic.Domain;

namespace StrategyAndCommand.Logic
{
    public class Pull : Strategy<ICommand<Log, bool>, Log, bool>
    {
        public bool Execute(Log log)
        {
            return GetAndExecute(() => GenerateCommand(log), log);
        }

        private static ICommand<Log, bool> GenerateCommand(Log log)
        {
            switch (log.TableName)
            {
                case "Attribute":
                case "Payor":
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
