using Invasion.Domain;
using Invasion.Domain.GameObjects;
using Invasion.Domain.Projectiles;
using NUnit.Framework;
using System;
using System.Linq;

namespace Invasion.Tests
{
    [TestFixture]
    public class CannonTest
    {
        private Random random = new Random();

        private const int rightBattleGroundBound = 1700;
        private const int bottomBattleGroundBound = 800;

        [TestCase(100, 100, 100, 100)]
        [TestCase(-50, 100, 0, 100)]
        [TestCase(100, -50, 100, 0)]
        [TestCase(rightBattleGroundBound + 100, 100, rightBattleGroundBound, 100)]
        [TestCase(100, bottomBattleGroundBound + 100, 100, bottomBattleGroundBound)]
        public void CannonInitTest1(int x, int y, int expectedX, int expectedY)
        {
            var cannon = new Cannon(new Vector(x, y), new int[] { 0, 0, 0, 0 });
            Assert.AreEqual(expectedX, cannon.Position.X);
            Assert.AreEqual(expectedY, cannon.Position.Y);
        }

        [Test]
        public void CannonInitTest2()
        {
            var cannon1 = new Cannon(new Vector(100, 100), new int[] { 1, 11, 22, 33 });
            var cannon2 = new Cannon(new Vector(100, 100), new int[] { -1, -11, -22, -33 });
            Assert.AreEqual(new int[] { 1, 11, 22, 33 }, cannon1.Ammunition.Select(pair => pair.Value).ToArray());
            Assert.AreEqual(new int[] { 0, 0, 0, 0 }, cannon2.Ammunition.Select(pair => pair.Value).ToArray());
        }

        [Test]
        public void CannonChooseProjectileTest()
        {
            var cannon = new Cannon(new Vector(100, 100), new int[] { 5, 5, 5, 5 });
            Assert.AreEqual(Projectile.CannonBall, cannon.SelectedProjectile);
            cannon.ChooseProjectile(Projectile.Laser);
            Assert.AreEqual(Projectile.Laser, cannon.SelectedProjectile);
            cannon.ChooseProjectile(cannon.SelectedProjectile + 1);
            Assert.AreEqual(Projectile.Missle, cannon.SelectedProjectile);
            cannon.ChooseProjectile(cannon.SelectedProjectile + 1);
            Assert.AreEqual(Projectile.CannonBall, cannon.SelectedProjectile);
        }

        [Test]
        public void CannonRotateDirectionTest()
        {
            var cannon = new Cannon(new Vector(100, 100), new int[] { 5, 5, 5, 5 });
            Assert.AreEqual(0, -cannon.Direction);
            cannon.RotateDirection(Turn.Left);
            Assert.AreEqual(-5, -cannon.Direction);
            Repeat(cannon.RotateDirection, Turn.Left, 10);
            Assert.AreEqual(-20, -cannon.Direction);
            Repeat(cannon.RotateDirection, Turn.Right, 22);
            Assert.AreEqual(90, -cannon.Direction);
            Repeat(cannon.RotateDirection, Turn.Right, 30);
            Assert.AreEqual(200, -cannon.Direction);
        }

        [Test]
        public void CannonChangeShotPowerTest()
        {
            var cannon = new Cannon(new Vector(100, 100), new int[] { 5, 5, 5, 5 });
            Assert.AreEqual(50, cannon.ShotPower);
            cannon.ChangeShotPower(Turn.Right);
            Assert.AreEqual(55, cannon.ShotPower);
            Repeat(cannon.ChangeShotPower, Turn.Right, 20);
            Assert.AreEqual(100, cannon.ShotPower);
            Repeat(cannon.ChangeShotPower, Turn.Left, 20);
            Assert.AreEqual(10, cannon.ShotPower);
        }

        private void Repeat(Action<Turn> action, Turn dir, int timeCount)
        {
            for (var i = 0; i < timeCount; i++)
                action(dir);
        }

        [Test]
        public void CannonShootTest()
        {
            var cannon = new Cannon(new Vector(100, 100), new int[] { 5, 0, 0, 0 });
            cannon.ChooseProjectile(0);
            Assert.AreEqual(true, cannon.Shoot());
            Assert.AreEqual(4, cannon.Ammunition[0]);
            cannon.ChooseProjectile((Projectile)1);
            Assert.AreEqual(false, cannon.Shoot());
            Assert.AreEqual(0, cannon.Ammunition[(Projectile)1]);
        }
    }
}
