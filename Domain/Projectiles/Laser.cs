using Invasion.Properties;
using System;
using System.Drawing;

namespace Invasion.Domain.Projectiles
{
    public class Laser : IProjectile
    {
        public Image Image { get; } = Resources.laser;
        public Projectile Type { get; } = Projectile.Laser;

        public Vector Position { get; set; }
        public Size Size { get; } = new Size(30, 3);
        public Rectangle Collision => new Rectangle(Position.AsPoint().Add(-Size.Width / 2, -Size.Height / 2), Size);

        public Vector MoveVector { get; set; }
        public double Direction { get; set; }
        public double MoveSpeed { get; set; } = 70;
        public int ShotPower { get; set; }

        public Laser(Vector position, double direction, int shotPower)
        {
            Position = position.NormalizeForBounds(new Rectangle(0, 0, 1700, 800));
            Direction = direction;
            ShotPower = shotPower < 20 ? 20 : shotPower > 100 ? 100 : shotPower;
            MoveVector = Vector.Build(MoveSpeed, Direction * Math.PI / 180);
        }

        public void Move()
        {
            MoveVector = Vector.Build(MoveSpeed, Direction * Math.PI / 180);
            Position += MoveVector;
        }
    }
}
