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
    public class MachineGun
    {
        public Image Image { get => new Bitmap(Resources.machineGun); }

        public Vector Position { get; set; }

        public double Direction;
        public bool IsFliped { get => Direction < -90 || Direction > 90; }

        private const int shotSpeed = 50;
        private int timeBetweenShots;

        public MachineGun(Vector position)
        {
            timeBetweenShots = shotSpeed;
            Position = position;
        }

        public void UpdateReloadTime()
        {
            timeBetweenShots += 20;
        }

        public void RotateDirectionTo(Vector targetPos)
        {            
            Direction = 180 * (targetPos - Position).Angle / Math.PI;
        }

        public bool Shoot()
        {
            if (timeBetweenShots > shotSpeed)
            {
                timeBetweenShots = 0;
                return true;
            }
            return false;
        }
    }
}
