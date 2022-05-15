using Invasion.Domain;
using Invasion.Domain.GameObjects;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invasion.Tests
{
    [TestFixture]
    public class CentersTest
    {
        private const int rightBattleGroundBound = 1700;
        private const int bottomBattleGroundBound = 800;

        [TestCase(100, 100, 100, 100)]
        [TestCase(-50, 100, 0, 100)]
        [TestCase(100, -50, 100, 0)]
        [TestCase(rightBattleGroundBound + 100, 100, rightBattleGroundBound, 100)]
        [TestCase(100, bottomBattleGroundBound + 100, 100, bottomBattleGroundBound)]
        public void ControlCenterInitTest(int x, int y, int expectedX, int expectedY)
        {
            var controlCenter = new ControlCenter(new Vector(x, y));
            Assert.AreEqual(expectedX, controlCenter.Position.X);
            Assert.AreEqual(expectedY, controlCenter.Position.Y);

            var supplyCenter = new SupplyCenter(new Vector(x, y));
            Assert.AreEqual(expectedX, controlCenter.Position.X);
            Assert.AreEqual(expectedY, controlCenter.Position.Y);
        }
    }
}
