using System;
using System.Text;
using System.Collections.Generic;
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
            Assert.IsNull(response);
        }

        [TestMethod]
        public void Test_Mediator_Command_DecoratorUpdate()
        {
            //var response = CommandMediator.Handle<DecoratedUpdate, Log, StringBuilder>(new DecoratedUpdate(), new Log());
            //Assert.IsTrue(response.ToString().Equals("DecoratedUpdate"));
        }
    }
}
