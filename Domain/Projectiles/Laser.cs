using Invasion.Domain.Enums;
using Invasion.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invasion.Domain.Projectiles
{
    public class Laser : IProjectile
    {
        public Image Image { get => new Bitmap(Resources.laser); }
        public Projectile Type { get => Projectile.Laser; }

        public Vector Position { get; set; }
        public Size Size { get; set; }
        public Rectangle Collision
        {
            get => new Rectangle(Position.AsPoint().Add(-Size.Width / 2, -Size.Height / 2), Size);
        }

        public Vector MoveVector { get; set; }
        public double Direction { get; set; }
        public double MoveSpeed { get; set; }
        public int ShotPower { get; set; }

        public Laser(Vector position, double direction, int shotPower)
        {
            Position = position;
            Size = new Size(50, 3);
            Direction = direction;
            ShotPower = shotPower;
            MoveSpeed = 100;
            MoveVector = Vector.Build(MoveSpeed, Direction * Math.PI / 180);
        }

        public void Move()
        {
            Position += MoveVector;
        }
    }
}
