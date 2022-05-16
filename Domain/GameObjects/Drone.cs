using Invasion.Properties;
using System;
using System.Drawing;

namespace Invasion.Domain.GameObjects
{
    public class Drone : IGameObject
    {
        public Image Image { get; } = Resources.drone;

        public Vector Position { get; set; }
        public Size Size { get; } = new Size(40, 40);
        public Rectangle Collision
        {
            get
            {
                var colSize = new Size(Size.Width + 15, Size.Height + 15);
                return new Rectangle(Position.AsPoint().Add(-colSize.Width / 2, -colSize.Height / 2), colSize);
            }
        }

        public Vector MoveVector { get; set; }
        public double Direction { get; set; }
        public double MoveSpeed { get; set; } = 20;

        public bool IsCrashed { get; set; }

        public Drone(Vector dronePos, Vector cannonPos)
        {
            Position = dronePos.NormalizeForBounds(new Rectangle(0, 0, 1700, 800));
            Direction = (cannonPos - Position).Angle * 180 / Math.PI;
            MoveVector = Vector.Build(MoveSpeed, Direction * Math.PI / 180);
        }

        public void Move()
        {
            Position += MoveVector;
        }
    }
}
