using Invasion.Domain;
using Invasion.Domain.GameObjects;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

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
