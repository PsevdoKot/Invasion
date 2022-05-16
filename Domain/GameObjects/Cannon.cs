using Invasion.Domain.Projectiles;
using Invasion.Properties;
using System.Collections.Generic;
using System.Drawing;

namespace Invasion.Domain.GameObjects
{
    public class Cannon : IGameObject
    {
        public Image Image { get; } = Resources.cannon1;
        public Image Image2 { get; } = Resources.cannon2;

        public Vector Position { get; set; }
        public Size Size { get; } = new Size(120, 65);
        public Rectangle Collision { get; }

        private const double dAngle = 5;
        public double Direction { get; private set; } = 0;
        public bool IsFliped => Direction > -90;

        private const int dPower = 5;
        public int ShotPower { get; private set; } = 50;

        public Projectile SelectedProjectile { get; private set; } = 0;
        public Dictionary<Projectile, int> Ammunition;

        public MachineGun MachineGun;

        public Cannon(Vector position, int[] ammunition)
        {
            Position = position.NormalizeForBounds(new Rectangle(0, 0, 1700, 800));
            Collision = new Rectangle(Position.AsPoint().Add(-Size.Width / 2, -Size.Height / 2), Size);
            Ammunition = new Dictionary<Projectile, int>
            {
                [Projectile.CannonBall] = NormalizeProjectileCount(ammunition[0]),
                [Projectile.SpringyBall] = NormalizeProjectileCount(ammunition[1]),
                [Projectile.Laser] = NormalizeProjectileCount(ammunition[2]),
                [Projectile.Missle] = NormalizeProjectileCount(ammunition[3])
            };
            MachineGun = new MachineGun(Position);
        }

        private int NormalizeProjectileCount(int count) => count < 0 ? 0 : count;

        public void RotateDirection(Turn dir)
        {
            if (dir == Turn.Left && Direction < 20)
                Direction -= dAngle * (int)dir;
            else if (dir == Turn.Right && Direction > -200)
                Direction -= dAngle * (int)dir;
        }

        public void ChangeShotPower(Turn dir)
        {
            if (dir == Turn.Left && ShotPower > 10 ||
                dir == Turn.Right && ShotPower < 100)
                ShotPower += dPower * (int)dir;
        }

        public void ChooseProjectile(Projectile proj)
        {
            SelectedProjectile = (Projectile)((int)proj % 4);
        }

        public bool Shoot()
        {
            if (Ammunition[SelectedProjectile] != 0)
            {
                Ammunition[SelectedProjectile]--;
                return true;
            }
            return false;
        }
    }
}
