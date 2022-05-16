using Invasion.Properties;
using System;
using System.Drawing;

namespace Invasion.Domain.GameObjects
{
    public class MachineGun
    {
        public Image Image { get; } = Resources.machineGun;

        public Vector Position { get; set; }

        public double Direction;
        public bool IsFliped => Direction < -90 || Direction > 90;

        private const int shotSpeed = 50;
        private int timeBetweenShots;

        public MachineGun(Vector position)
        {
            Position = position;
            timeBetweenShots = shotSpeed;
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
            if (timeBetweenShots >= shotSpeed)
            {
                timeBetweenShots = 0;
                return true;
            }
            return false;
        }
    }
}
