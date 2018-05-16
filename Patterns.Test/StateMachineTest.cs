using Microsoft.VisualStudio.TestTools.UnitTesting;
using Patterns.Core.Command.Interfaces;
using Patterns.Infrastructure.Domain.Entities;
using Patterns.Infrastructure.Domain.Implementations.Command;
using Patterns.Infrastructure.Domain.Implementations.State;
using System.Collections.Generic;
using System.Text;

namespace Patterns.Test
{
    [TestClass]
    public class StateMachineTest
    {
        [TestMethod]
        public void Test_Push_States()
        {
            var commands = new List<ICommand<Log, StringBuilder>>();

            commands.Add(new Add((_) => new StringBuilder("Add")));
            commands.Add(new Update((_) => new StringBuilder("Update")));
            commands.Add(new Delete((_) => new StringBuilder("Delete")));

            var pushAction = new PushState(commands);

            Log log = new Log();

            Assert.IsTrue(pushAction.Handle(log).ToString().Equals("Add"));
            Assert.IsTrue(pushAction.Handle(log).ToString().Equals("Update"));
            Assert.IsTrue(pushAction.Handle(log).ToString().Equals("Delete"));
        }
    }
}
