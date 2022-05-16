using Invasion.Properties;
using System.Drawing;

namespace Invasion.Domain.GameObjects
{
    public class SupplyCenter : IGameObject
    {
        public Image Image { get; } = Resources.supplyCenter;

        public Vector Position { get; set; }
        public Size Size { get; } = new Size(75, 75);
        public Rectangle Collision { get; }

        public bool IsCrashed { get; set; }

        public SupplyCenter(Vector position)
        {
            Position = position.NormalizeForBounds(new Rectangle(0, 0, 1700, 800));
            Collision = new Rectangle(Position.AsPoint().Add(-Size.Width / 2, -Size.Height / 2), Size);
        }
    }
}
