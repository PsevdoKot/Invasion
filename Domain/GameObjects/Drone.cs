using Invasion.Domain;
using Invasion.Domain.GameObjects;
using Invasion.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invasion.Domain.GameObjects
{
    public class Drone : IGameObject
    {
        public Image Image { get; } = Resources.drone;

        public Vector Position { get; set; }
        public Size Size { get; }
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
        public double MoveSpeed { get; set; }

        public bool IsCrashed { get; set; }
        //public int Health;

        public Drone(Vector dronePos, Vector cannonPos)
        {
            Position = dronePos;
            Size = new Size(40, 40);
            Direction = (cannonPos - Position).Angle * 180 / Math.PI;
            MoveSpeed = 20;
            MoveVector = Vector.Build(MoveSpeed, Direction * Math.PI / 180);
            //Health = 100;
        }

        public void Move()
        {
            Position += MoveVector;
        }
    }
}
