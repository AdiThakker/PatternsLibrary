using Microsoft.VisualStudio.TestTools.UnitTesting;
using StrategyAndCommand.Logic;
using StrategyAndCommand.Logic.Domain;
using System.Collections.Generic;
using System.Text;

namespace StrategyAndCommand.Test
{
    [TestClass]
    public class ActionsTest
    {
        [TestMethod]
        public void TestPublish()
        {
            var log = new Log() { Action = "Add", Changes = new List<ChangeLog>() { new ChangeLog("User", "1", "2"), new ChangeLog("Client", "Client1", "Client2") }, TableName = "User" };
            var log1 = new Log() { Action = "Update", Changes = new List<ChangeLog>() { new ChangeLog("AttributeID", "1", "3"), new ChangeLog("ClientID", "700", "800") }, TableName = "ClientAttribute" };

            var logs = new List<Log>() { log, log1 };
            new Publish(logs).Execute();
        }
    }
}
