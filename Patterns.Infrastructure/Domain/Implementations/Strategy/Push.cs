using Patterns.Core.Command.Interfaces;
using Patterns.Core.Strategy;
using Patterns.Infrastructure.Domain.Entities;
using Patterns.Infrastructure.Domain.Implementations.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Patterns.Infrastructure.Domain.Implementations.Strategy
{
    public class Push : Strategy<ICommand<Log, StringBuilder>, Log, StringBuilder>
    {
        private Dictionary<string, ICommand<Log, StringBuilder>> _commands = new Dictionary<string, ICommand<Log, StringBuilder>>();

        public Push()
        {
            _commands.Add("Add", GetPushAddLogic());
            _commands.Add("Update", GetPushUpdateLogic());
            _commands.Add("Delete", GetPushDeleteLogic());
        }

        public StringBuilder Execute(List<Log> logs)
        {
            if (logs == null)
                throw new ArgumentNullException(nameof(logs));

            return logs.Aggregate(new StringBuilder(), (results, log) =>
            {
                if (_commands.ContainsKey(log.Action))
                    results.Append(GetCommandAndExecute(() => _commands[log.Action], log));

                return results;
            });
        }

        private static Delete GetPushDeleteLogic()
        {
            return new Delete((log) =>
            {
                return new StringBuilder("Push Delete: Executed");
            });
        }

        private static Update GetPushUpdateLogic()
        {
            return new Update((log) =>
            {
                return new StringBuilder("Push Update: Executed");
            });
        }

        private static Add GetPushAddLogic()
        {
            return new Add((log) =>
            {
                return new StringBuilder("Push Add: Executed");
            });
        }
    }
}
