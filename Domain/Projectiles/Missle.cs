using Invasion.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invasion.Domain.Projectiles
{
    public class Missle : IProjectile
    {
        public Image Image { get; } = Resources.missle;
        public Projectile Type { get; } = Projectile.Missle;

        public Vector Position { get; set; }
        public Size Size { get; }
        public Rectangle Collision => new Rectangle(Position.AsPoint().Add(-Size.Width / 2, -Size.Height / 2), Size);

        public Vector MoveVector { get; set; }
        public double Direction { get; set; }
        public double MoveSpeed { get; set; }
        public int ShotPower { get; set; }

        private Vector targetPosition;

        public Missle(Vector position, Vector targetPosition, double direction, int shotPower)
        {
            Position = position;
            this.targetPosition = targetPosition;
            Size = new Size(30, 10);
            ShotPower = shotPower;
            Direction = direction;
            MoveSpeed = 50;
            MoveVector = Vector.Build(MoveSpeed, Direction * Math.PI / 180);
        }

        public void Move()
        {
            if (targetPosition != null)
            {
                Direction += (targetPosition - Position).Angle - Direction * Math.PI / 180 > 0
                    ? 3
                    : -3;
                MoveVector = Vector.Build(MoveSpeed, Direction * Math.PI / 180);
            }
            Position += MoveVector * ShotPower / 50;
            if (ShotPower > 50)
                ShotPower--;
        }
    }
}
