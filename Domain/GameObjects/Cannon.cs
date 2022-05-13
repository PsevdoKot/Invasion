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
    public class Cannon : IGameObject
    {
        public Image Image { get => Resources.turret1; }
        public Image Image2 { get => Resources.turret2; }

        public Vector Position { get; set; }
        public Size Size { get; set; }
        public Rectangle Collision
        {
            get => new Rectangle(Position.AsPoint().Add(-Size.Width / 2, -Size.Height / 2), Size);
        }

        private const double dAngle = 5;
        public double Direction { get; private set; }
        public bool IsFliped { get => Direction > -90; }

        private const int dPower = 5;
        public int ShotPower { get; private set; }

        public Projectile SelectedProj { get; private set; }
        public Dictionary<Projectile, int> projInfo;

        private const int mgOffsetX = 0;
        private const int mgOffsetY = 0;
        public MachineGun MachineGun;

        public Cannon(Vector position, int[] ammunition)
        {
            Position = position;
            Size = new Size(120, 65);
            Direction = 0;
            ShotPower = 50;
            SelectedProj = 0;
            projInfo = new Dictionary<Projectile, int>();
            projInfo[Projectile.CannonBall] = ammunition[0];
            projInfo[Projectile.SpringyBall] = ammunition[1];
            projInfo[Projectile.Laser] = ammunition[2];
            projInfo[Projectile.Missle] = ammunition[3];
            MachineGun = new MachineGun(Position);
        }

        public void RotateDirection(Direction dir)
        {
            if (dir == Enums.Direction.Down && Direction < 20)
                Direction -= dAngle * (int)dir; 
            else if (dir == Enums.Direction.Up && Direction > -200)
                Direction -= dAngle * (int)dir;
        }

        public void ChangeShotPower(Direction dir)
        {
            if (dir == Enums.Direction.Down && ShotPower > 10 ||
                dir == Enums.Direction.Up && ShotPower < 100)
                ShotPower += dPower * (int)dir;
        }

        public void ChooseProjectile(Projectile proj)
        {
            SelectedProj = (Projectile)((int)proj % 4);
        }

        public bool Shoot()
        {
            if (projInfo[SelectedProj] != 0)
            {
                projInfo[SelectedProj]--;
                return true;
            }
            return false;
        }
    }
}
