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
    public class GameTest
    {
        [Test]
        public void GameShootByCannonTest()
        {
            var game = new Game();
            game.LoadLevel(1);
            Assert.IsEmpty(game.CurrentLevel.Projectiles);
            game.CurrentLevel.Cannon.ChooseProjectile(Projectile.CannonBall);
            game.ShootByCannon();
            Assert.True(game.CurrentLevel.Projectiles[0] is CannonBall);
            game.CurrentLevel.Cannon.ChooseProjectile(Projectile.Laser);
            game.ShootByCannon();
            Assert.True(game.CurrentLevel.Projectiles[0] is Laser);
        }

        [Test]
        public void GameShootByMachineGunTest()
        {
            var game = new Game();
            game.LoadLevel(1);
            Assert.IsEmpty(game.CurrentLevel.Projectiles);
            game.ShootByMachineGun();
            Assert.True(game.CurrentLevel.Projectiles[0] is Bullet);
            game.ShootByMachineGun();
            Assert.AreEqual(1, game.CurrentLevel.Projectiles.Count);
        }

        [Test]
        public void GameScoreTest()
        {
            var game = new Game();
            game.LoadLevel(1);
            Assert.AreEqual(0, game.PlayerScore);
            game.CurrentLevel.ControlCenter.IsCrashed = true;
            game.Update();
            Assert.AreEqual(3, game.PlayerScore);
        }
    }
}
