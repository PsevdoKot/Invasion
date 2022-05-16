using Invasion.Domain.GameObjects;

namespace Invasion.Domain.Walls
{
    public interface IWall : IGameObject
    {
        Wall Type { get; }

        double InclinationAngle { get; }
    }
}
