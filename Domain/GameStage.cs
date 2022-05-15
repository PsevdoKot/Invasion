using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invasion.Domain
{
    public enum GameStage
    {
        Menu = 0,
        LevelSelecting = 1,
        Tutorial = 2,
        Battle = 3,
        Finished = 4,
        Defeat = 5
    }
}
