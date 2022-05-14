using Invasion.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invasion.Domain.GameObjects
{
    public class SupplyCenter : IGameObject
    {
        public Image Image { get; } = Resources.supplyCenter;

        public Vector Position { get; set; }
        public Size Size { get; }
        public Rectangle Collision => new Rectangle(Position.AsPoint().Add(-Size.Width / 2, -Size.Height / 2), Size);

        public bool IsCrashed { get; set; }

        public SupplyCenter(Vector supplyCenterPos)
        {
            Position = supplyCenterPos;
            Size = new Size(75, 75);
        }
    }
}
