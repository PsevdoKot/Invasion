using Invasion.Domain.GameObjects;

namespace Invasion.Domain.Projectiles
{
    public interface IProjectile : IGameObject
    {
        Projectile Type { get; }

        Vector MoveVector { get; set; }
        double Direction { get; set; }
        double MoveSpeed { get; set; }
        int ShotPower { get; set; }

        void Move();
    }
}
