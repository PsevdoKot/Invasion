using Invasion.Properties;
using System.Drawing;

namespace Invasion.Domain.Walls
{
    public class ReflectiveWall : IWall
    {
        public Image Image { get; } = Resources.reflectiveWall;
        public Wall Type { get; } = Wall.ReflectiveWall;

        public Vector Position { get; set; }
        public Size Size { get; }
        public double InclinationAngle { get; }

        public Rectangle Collision { get; }

        public ReflectiveWall((Vector, Size, double) wallData)
        {
            Position = wallData.Item1.NormalizeForBounds(new Rectangle(0, 0, 1700, 800));
            Size = wallData.Item2;
            InclinationAngle = wallData.Item3;
            Collision = InclinationAngle == 90
                ? new Rectangle((int)Position.X - Size.Height / 2, (int)Position.Y - Size.Width / 2, Size.Height, Size.Width)
                : new Rectangle(Position.AsPoint().Add(-Size.Width / 2, -Size.Height / 2), Size);
        }
    }
}
