using Microsoft.VisualStudio.TestTools.UnitTesting;
using StrategyAndCommand.Logic;
using StrategyAndCommand.Logic.Domain;
using System.Collections.Generic;

namespace StrategyAndCommand.Test
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
                TableName = "User"
            };
            var log1 = new Log()
            {
                Action = "Update",
                Changes = new List<ChangeLog>()
                {
                    new ChangeLog("AttributeID", "1", "3"), new ChangeLog("ClientID", "700", "800")
                },
                TableName = "ClientAttribute"
            };

            var logs = new List<Log>() { log, log1 };
            Assert.IsFalse(string.IsNullOrWhiteSpace(new Push(logs).Execute().ToString()));
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
                TableName = "Payor"
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
