﻿using System;
using Patterns.Core.Command.Interfaces;
using Patterns.Core.Mediator.Interfaces;

namespace Patterns.Core.Mediator
{
    public class CommandHandler : ICommandHandler
    {
        public TResponse Handle<TType, TRequest, TResponse>(TType command, TRequest request)
            where TType : ICommand<TRequest, TResponse>
            where TRequest : class
        {
            throw new NotImplementedException();
        }
    }
}