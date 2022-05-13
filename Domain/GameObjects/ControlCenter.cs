using Invasion.Domain;
using Invasion.Domain.Enums;
using Invasion.Domain.GameObjects;
using Invasion.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invasion.Domain
{
    public class ControlCenter : IGameObject
    {
        public Image Image { get => Resources.controlCenter; }

        public Vector Position { get; set; }
        public Size Size { get; set; }
        public Rectangle Collision
        {
            get => new Rectangle(Position.AsPoint().Add(-Size.Width / 2, -Size.Height / 2), Size);
        }

        public bool IsCrashed { get; set; }
        //public int Health;

        public ControlCenter(Vector controlCenterPos)
        {
            Position = controlCenterPos;
            Size = new Size(100, 100);
            //Health = 100;
        }
    }
}
