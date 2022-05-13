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
    public class SpringyBall : IProjectile
    {
        public Image Image { get => Resources.springyBall; }
        public Projectile Type { get => Projectile.SpringyBall; }

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

        public SpringyBall(Vector position, double direction, int shotPower)
        {
            Position = position;
            Size = new Size(20, 20);
            Direction = direction;
            ShotPower = shotPower;
            MoveSpeed = 50;
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
