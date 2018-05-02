using StrategyAndCommand.Core.Command;
using StrategyAndCommand.Core.Command.Interfaces;
using StrategyAndCommand.Core.Strategy;
using StrategyAndCommand.Logic.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace StrategyAndCommand.Logic
{
    public class Publish : Strategy<ICommand<Log, List<string>>, Log, List<string>>
    {
        private Dictionary<string, ICommand<Log, List<string>>> _commands = new Dictionary<string, ICommand<Log, List<string>>>();

        public List<Log> Logs { get; }

        public Publish(List<Log> logs)
            : base()
        {
            this.Logs = logs ?? throw new ArgumentNullException(nameof(logs));

            _commands.Add("Add", new Command<Log, List<string>>((log) =>
            {
                StringBuilder builder = new StringBuilder();
                builder.Append($"INSERT into  {log.TableName} values(");
                log.Changes.ForEach(change => builder.Append(change.To));
                builder.Append(")");
                return new List<string>() { builder.ToString() };
            }));

            _commands.Add("Update", new Command<Log, List<string>>((log) =>
            {
                StringBuilder builder = new StringBuilder();
                builder.Append($"UPDATE {log.TableName} SET ");
                log.Changes.ForEach(change => builder.Append(string.Concat(change.FieldName, " = ", change.To)));
                return new List<string>() { builder.ToString() };
            }));

            _commands.Add("Delete", new Command<Log, List<string>>((log) =>
            {
                StringBuilder builder = new StringBuilder();
                builder.Append($"DELETE from {log.TableName} set ");
                log.Changes.ForEach(change => builder.Append(string.Concat(change.FieldName, " = ", change.To)));
                return new List<string>() { builder.ToString() };
            }));
        }

        public void Execute()
        {
            this.Logs.ForEach(log =>
            {
                GetAndExecute(() => _commands[log.Action], log);
            });
        }
    }
}
