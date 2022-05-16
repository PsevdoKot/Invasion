using Invasion.Domain;
using Invasion.Domain.GameObjects;
using NUnit.Framework;

namespace Invasion.Tests
{
    [TestFixture]
    public class MachineGunTest
    {
        [Test]
        public void MachineGunShootTest()
        {
            var machineGun = new MachineGun(new Vector(100, 100));
            Assert.AreEqual(true, machineGun.Shoot());
            Assert.AreEqual(false, machineGun.Shoot());
        }
    }
}
