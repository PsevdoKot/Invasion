using Invasion.Domain;
using Invasion.Domain.Projectiles;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invasion.Tests
{
    [TestFixture]
    public class ProjectileTest
    {
        private Random random = new Random();

        private const int rightBattleGroundBound = 1700;
        private const int bottomBattleGroundBound = 800;

        [TestCase(-10, 20)]
        [TestCase(60, 60)]
        [TestCase(666, 100)]
        public void ProjectileInitTest1(int shotPower, int expected)
        {
            var position = new Vector(100, 100);
            var direction = random.NextDouble() * Math.PI;
            var projectiles = new List<IProjectile>();
            projectiles.Add(new CannonBall(position, direction, shotPower));
            projectiles.Add(new SpringyBall(position, direction, shotPower));
            projectiles.Add(new Laser(position, direction, shotPower));
            projectiles.Add(new Missle(position, new Vector(200, 200), direction, shotPower));
            foreach (var projectile in projectiles)
            {
                Assert.AreEqual(position, projectile.Position);
                Assert.AreEqual(direction, projectile.Direction);
                Assert.AreEqual(expected, projectile.ShotPower);
            }
        }

        [TestCase(100, 100, 100, 100)]
        [TestCase(-50, 100, 0, 100)]
        [TestCase(100, -50, 100, 0)]
        [TestCase(rightBattleGroundBound + 100, 100, rightBattleGroundBound, 100)]
        [TestCase(100, bottomBattleGroundBound + 100, 100, bottomBattleGroundBound)]
        public void ProjectileInitTest2(int x, int y, int expectedX, int expectedY)
        {
            var projectile = new CannonBall(new Vector(x, y), 0, 50);
            Assert.AreEqual(expectedX, projectile.Position.X);
            Assert.AreEqual(expectedY, projectile.Position.Y);
        }
    }
}
