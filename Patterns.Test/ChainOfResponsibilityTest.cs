using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Patterns.Core.Command;
using Patterns.Core.Command.Interfaces;
using Patterns.Infrastructure.Domain.Entities;
using Patterns.Infrastructure.Domain.Implementations.ChainOfResponsibility;
using Patterns.Infrastructure.Domain.Implementations.Command;

namespace Patterns.Test
{
    [TestClass]
    public class ChainOfResponsibilityTest
    {
        [TestMethod]
        public void Test_Add_Handled()
        {
            var commands = new List<ICommand<Log, StringBuilder>>();

            commands.Add(new Add((_) => new StringBuilder("Add")));
            commands.Add(new Update((_) => new StringBuilder("Update")));
            commands.Add(new Delete((_) => new StringBuilder("Delete")));

            var pushAction = new PushChain(commands);

            Log log = new Log() { Action = "Add" };

            Assert.IsTrue(pushAction.Handle(log).ToString().Equals("Add"));
        }

        [TestMethod]
        public void Test_Update_Handled()
        {
            var commands = new List<ICommand<Log, StringBuilder>>();

            commands.Add(new Add((_) => new StringBuilder("Add")));
            commands.Add(new Update((_) => new StringBuilder("Update")));
            commands.Add(new Delete((_) => new StringBuilder("Delete")));

            var pushAction = new PushChain(commands);

            Log log = new Log() { Action = "Update" };

            Assert.IsTrue(pushAction.Handle(log).ToString().Equals("Update"));
        }

        [TestMethod]
        public void Test_Delete_Handled()
        {
            var commands = new List<ICommand<Log, StringBuilder>>();

            commands.Add(new Add((_) => new StringBuilder("Add")));
            commands.Add(new Update((_) => new StringBuilder("Update")));
            commands.Add(new Delete((_) => new StringBuilder("Delete")));

            var pushAction = new PushChain(commands);

            Log log = new Log() { Action = "Delete" };

            Assert.IsTrue(pushAction.Handle(log).ToString().Equals("Delete"));
        }

        [TestMethod]
        public void Test_No_Handler()
        {
            var commands = new List<ICommand<Log, StringBuilder>>();

            commands.Add(new Add((_) => new StringBuilder("Add")));
            commands.Add(new Update((_) => new StringBuilder("Update")));
            commands.Add(new Delete((_) => new StringBuilder("Delete")));

            var pushAction = new PushChain(commands);

            Log log = new Log() { Action = "Upsert" };

            Assert.IsNull(pushAction.Handle(log));
        }
    }
}
