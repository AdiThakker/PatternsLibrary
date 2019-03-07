using Patterns.Core.Command;
using Patterns.Infrastructure.Domain.Entities;
using System;
using System.Text;

namespace Patterns.Infrastructure.Domain.Implementations.Command
{
    public class Add : Command<Log, StringBuilder>
    {
        public Add() : base((_) => new StringBuilder("Add"))
        {
        }

        public Add(Func<Log, StringBuilder> strategy) : base(strategy)
        {
        }
    }
}
