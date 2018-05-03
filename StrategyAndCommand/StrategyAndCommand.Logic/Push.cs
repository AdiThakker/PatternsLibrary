using StrategyAndCommand.Core.Command;
using StrategyAndCommand.Core.Command.Interfaces;
using StrategyAndCommand.Core.Strategy;
using StrategyAndCommand.Logic.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StrategyAndCommand.Logic
{
    public class Push : Strategy<ICommand<Log, List<string>>, Log, List<string>>
    {
        private Dictionary<string, ICommand<Log, List<string>>> _commands = new Dictionary<string, ICommand<Log, List<string>>>();

        public Push()            
        {
            _commands.Add("Add", new Command<Log, List<string>>((log) =>
            {
                StringBuilder builder = new StringBuilder();
                builder.Append($"Publish Add Strategy executed.");
                return new List<string>() { builder.ToString() };
            }));

            _commands.Add("Update", new Command<Log, List<string>>((log) =>
            {
                StringBuilder builder = new StringBuilder();
                builder.Append($"Publish Update Strategy executed.");
                return new List<string>() { builder.ToString() };
            }));

            _commands.Add("Delete", new Command<Log, List<string>>((log) =>
            {
                StringBuilder builder = new StringBuilder();
                builder.Append($"Publish Delete Strategy executed.");
                return new List<string>() { builder.ToString() };
            }));
        }

        public StringBuilder Execute(List<Log> logs)
        {
            if (logs == null)
                throw new ArgumentNullException(nameof(logs));

            return logs.Aggregate(new StringBuilder(), (results, log) =>
            {
                results.Append(GetCommandAndExecute(() => _commands[log.Action], log)); // Not safe for Key access
                return results;
            });
        }
    }
}
