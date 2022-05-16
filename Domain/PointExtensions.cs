using System.Drawing;

namespace Invasion.Domain
{
    public static class PointExtensions
    {
        public static Point Add(this Point point, int otherX, int otherY)
        {
            return new Point(point.X + otherX, point.Y + otherY);
        }

        public static Point Add(this Point point, Point other)
        {
            return point.Add(other.X, other.Y);
        }
    }
}
