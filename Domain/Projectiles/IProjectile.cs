using Invasion.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invasion.Domain.Projectiles
{
    public interface IProjectile
    {
        Image Image { get; }
        Projectile Type { get; }

        Vector Position { get; set; }
        Size Size { get; set; }
        Rectangle Collision { get; }

        Vector MoveVector { get; set; }
        double Direction { get; set; }
        double MoveSpeed { get; set; }
        int ShotPower { get; set; }

        void Move();
    }
}
