using Invasion.Domain.GameObjects;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invasion.Domain.Walls
{
    public interface IWall : IGameObject
    {
        Wall Type { get; } 

        double InclinationAngle { get; }
    }
}
