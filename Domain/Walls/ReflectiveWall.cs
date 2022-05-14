using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invasion.Domain.Walls
{
    public class ReflectiveWall : IWall
    {
        public Image Image { get; }
        public Wall Type { get; } = Wall.ReflectiveWall;

        public Vector Position { get; set; }
        public Size Size { get; }
        public double InclinationAngle { get; }

        public Rectangle Collision => new Rectangle(Position.AsPoint().Add(-Size.Width / 2, -Size.Height / 2), Size);

        public ReflectiveWall((Vector, Size, double) wallData)
        {
            Position = wallData.Item1;
            Size = wallData.Item2;
            InclinationAngle = wallData.Item3;
        }
    }
}
