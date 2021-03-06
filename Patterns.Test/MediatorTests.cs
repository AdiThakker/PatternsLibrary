﻿using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Patterns.Infrastructure.Domain.Implementations.Mediator;
using Patterns.Infrastructure.Domain.Implementations.Command;
using Patterns.Infrastructure.Domain.Entities;
using Patterns.Infrastructure.Domain.Implementations.Decorator;

namespace Patterns.Test
{
    /// <summary>
    /// Summary description for MediatorTests
    /// </summary>
    [TestClass]
    public class MediatorTests
    {
        [TestMethod]
        public void Test_Mediator_Command_Add()
        {
            var response = new Mediator().Handle<Add, Log, StringBuilder>(new Log());
            Assert.IsTrue(response.ToString().Equals("Add"));
        }

        [TestMethod]
        public void Test_Mediator_Command_DecoratorAdd()
        {
            var response = new Mediator().Handle<DecoratedAdd, Log, StringBuilder>(new Log());
            Assert.IsTrue(response.ToString().Equals("DecoratedAdd"));
        }

        [TestMethod]
        public void Test_Mediator_Command_DecoratorUpdate()
        {
            var response = new Mediator().Handle<DecoratedUpdate, Log, StringBuilder>(new Log());
            Assert.IsTrue(response.ToString().Equals("DecoratedUpdate"));
        }
    }
}
