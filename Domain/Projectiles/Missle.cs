using Invasion.Properties;
using System;
using System.Drawing;

namespace Invasion.Domain.Projectiles
{
    public class Missle : IProjectile
    {
        public Image Image { get; } = Resources.missle;
        public Projectile Type { get; } = Projectile.Missle;

        public Vector Position { get; set; }
        public Size Size { get; } = new Size(30, 10);
        public Rectangle Collision => new Rectangle(Position.AsPoint().Add(-Size.Width / 2, -Size.Height / 2), Size);

        public Vector MoveVector { get; set; }
        public double Direction { get; set; }
        public double MoveSpeed { get; set; } = 50;
        public int ShotPower { get; set; }

        private Vector targetPosition;

        public Missle(Vector position, Vector targetPosition, double direction, int shotPower)
        {
            Position = position.NormalizeForBounds(new Rectangle(0, 0, 1700, 800));
            this.targetPosition = targetPosition;
            ShotPower = shotPower < 20 ? 20 : shotPower > 100 ? 100 : shotPower;
            Direction = direction;
            MoveVector = Vector.Build(MoveSpeed, Direction * Math.PI / 180);
        }

        public void Move()
        {
            if (targetPosition != null)
            {
                Direction += (targetPosition - Position).Angle - Direction * Math.PI / 180 > 0
                    ? 7
                    : -7;
                MoveVector = Vector.Build(MoveSpeed, Direction * Math.PI / 180);
            }
            Position += MoveVector * ShotPower / 50;
            if (ShotPower > 50)
                ShotPower--;
        }
    }
}
