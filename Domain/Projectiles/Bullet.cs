using Invasion.Properties;
using System;
using System.Drawing;

namespace Invasion.Domain.Projectiles
{
    public class Bullet : IProjectile
    {
        public Image Image { get; } = Resources.bullet;
        public Projectile Type { get; } = Projectile.Bullet;

        public Vector Position { get; set; }
        public Size Size { get; } = new Size(20, 4);
        public Rectangle Collision => new Rectangle(Position.AsPoint().Add(-Size.Width / 2, -Size.Height / 2), Size);

        public Vector MoveVector { get; set; }
        public double Direction { get; set; }
        public double MoveSpeed { get; set; } = 50;
        public int ShotPower { get; set; }

        public Bullet(Vector position, double direction, int shotPower)
        {
            Position = position.NormalizeForBounds(new Rectangle(0, 0, 1700, 800));
            Direction = direction;
            ShotPower = shotPower < 20 ? 20 : shotPower > 100 ? 100 : shotPower;
            MoveVector = Vector.Build(MoveSpeed, Direction * Math.PI / 180);
        }

        public void Move()
        {
            MoveVector += new Vector(0, 1);
            Direction = MoveVector.Angle * 180 / Math.PI;
            Position += MoveVector;
        }
    }
}
