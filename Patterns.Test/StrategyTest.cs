using Microsoft.VisualStudio.TestTools.UnitTesting;
using Patterns.Infrastructure.Domain.Entities;
using Patterns.Infrastructure.Domain.Implementations.Strategy;
using System.Collections.Generic;

namespace Patterns.Test
{
    [TestClass]
    public class StrategyTest
    {
        [TestMethod]
        public void TestPush_IsNot_Null()
        {
            var log = new Log()
            {
                Action = "Add",
                Changes = new List<ChangeLog>()
                {
                    new ChangeLog("User", "1", "2"), new ChangeLog("Client", "Client1", "Client2")
                },
                TableName = "Table_Y"
            };
            var log1 = new Log()
            {
                Action = "Update",
                Changes = new List<ChangeLog>()
                {
                    new ChangeLog("AttributeID", "1", "3"), new ChangeLog("ClientID", "700", "800")
                },
                TableName = "Table_Y"
            };

            var logs = new List<Log>() { log, log1 };
            Assert.IsFalse(string.IsNullOrWhiteSpace(new Push().Execute(logs).ToString()));
        }

        [TestMethod]
        public void TestPull_Returns_True()
        {
            var log = new Log()
            {
                Changes = new List<ChangeLog>()
                {
                    new ChangeLog("User", "1", "2"), new ChangeLog("Client", "Client1", "Client2")
                },
                TableName = "Table_X"
            };

            Assert.IsTrue(new Pull().Execute(log));
        }

        [TestMethod]
        public void TestPull_Returns_False()
        {
            var log = new Log()
            {
                Changes = new List<ChangeLog>()
                {
                    new ChangeLog("User", "1", "2"), new ChangeLog("Client", "Client1", "Client2")
                },
                TableName = ""
            };

            Assert.IsFalse(new Pull().Execute(log));
        }
    }
}
