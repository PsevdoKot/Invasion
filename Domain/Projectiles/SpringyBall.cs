using Invasion.Properties;
using System;
using System.Drawing;

namespace Invasion.Domain.Projectiles
{
    public class SpringyBall : IProjectile
    {
        public Image Image { get; } = Resources.springyBall;
        public Projectile Type { get; } = Projectile.SpringyBall;

        public Vector Position { get; set; }
        public Size Size { get; } = new Size(20, 20);
        public Rectangle Collision => new Rectangle(Position.AsPoint().Add(-Size.Width / 2, -Size.Height / 2), Size);

        public Vector MoveVector { get; set; }
        public double Direction { get; set; }
        public double MoveSpeed { get; set; } = 50;
        public int ShotPower { get; set; }

        private Vector gravityVector { get; set; }

        public SpringyBall(Vector position, double direction, int shotPower)
        {
            Position = position.NormalizeForBounds(new Rectangle(0, 0, 1700, 800));
            Direction = direction;
            ShotPower = shotPower < 20 ? 20 : shotPower > 100 ? 100 : shotPower;
            MoveVector = Vector.Build(MoveSpeed, Direction * Math.PI / 180);
        }

        public void Move()
        {
            MoveVector += new Vector(0, 3);
            Position += MoveVector * ShotPower / 50;
            if (ShotPower > 50)
                ShotPower = ShotPower - 1;
        }
    }
}
