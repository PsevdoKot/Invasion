using System.Drawing;

namespace Invasion.Domain.GameObjects
{
    public interface IGameObject
    {
        Image Image { get; }

        Vector Position { get; set; }
        Size Size { get; }
        Rectangle Collision { get; }
    }
}
