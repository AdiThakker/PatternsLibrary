using Microsoft.VisualStudio.TestTools.UnitTesting;
using Patterns.Core.Factory;
using Patterns.Infrastructure.Domain.Entities;

namespace Patterns.Test
{
    [TestClass]
    public class FactoryTest
    {
        [TestMethod]
        public void TestDependencyRegistered_IsNotNull()
        {
            DependencyFactory.Set(typeof(Log), () => new Log());
            Assert.IsNotNull(DependencyFactory.Get<Log>());
        }

        [TestMethod]
        public void TestDependencyRegistered_IsUpdated()
        {
            DependencyFactory.Set(typeof(Log), () => new Log());

            // Simulate Update
            DependencyFactory.Set(typeof(Log), () => new Log());

            Assert.IsNotNull(DependencyFactory.Get<Log>());
        }
    }
}
