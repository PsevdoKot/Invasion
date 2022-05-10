using Invasion.Domain;
using Invasion.Domain.Enums;
using Invasion.Domain.GameObjects;
using Invasion.Domain.Projectiles;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invasion.Domain
{
    public class Game
    {
        private Random random = new Random(1277);

        public GameStage Stage { get; set; }
        public event Action<GameStage> StageChanged;

        public Rectangle BattleGround { get; set; }

        public Level[] Levels = new[] 
            { 
                new Level(
                    new Cannon(new Vector(200, 680), (5, 4, 3, 2)),
                    new Vector(1200, 100),
                    new List<Vector> 
                    {
                        new Vector(150, 200),
                        new Vector(700, 350)
                    },
                    new List<IGameObject>
                    { 
                        
                    }
                ),
                new Level(
                    new Cannon(new Vector(200, 680), (5, 4, 3, 0)),
                    new Vector(1200, 100),
                    new List<Vector>
                    {
                        new Vector(150, 200),
                        new Vector(700, 350)
                    },
                    new List<IGameObject>
                    {

                    }
                )
            };
        public Level CurrentLevel { get; private set; }
        public int CurrentLevelNumber { get; private set; }        
        public int PlayerScore { get; private set; }

        public int LevelTime { get; private set; }
        private int minutes;
        private int seconds;

        public Game()
        {
            Stage = GameStage.Menu;
            PlayerScore = 0;
            LevelTime = 0;
        }

        private void ChangeStage(GameStage stage)
        {
            Stage = stage;
            StageChanged?.Invoke(stage);
        }

        public void ToSelectLevel()
        {
            ChangeStage(GameStage.LevelSelecting);
        }

        public void ToMenu()
        {
            LevelTime = 0;
            ChangeStage(GameStage.Menu);
        }

        public void LoadLevel(int levelNumber)
        {
            LevelTime = 0;
            CurrentLevelNumber = levelNumber;
            CurrentLevel = Levels[CurrentLevelNumber - 1];
            ChangeStage(GameStage.Battle);
        }

        public void RestartLevel()
        {
            LoadLevel(CurrentLevelNumber);
        }

        /////
        /////
        /////

        public void UpdateTime()
        {
            LevelTime += 1;
            if (LevelTime % 10 == 0)
                SpawnDrone();
        }

        public string GetTime()
        {
            minutes = LevelTime / 60 % 60;
            seconds = LevelTime % 60;
            return minutes >= 10
                ? seconds >= 10
                    ? $"{minutes}:{seconds}"
                    : $"{minutes}:0{seconds}"
                : seconds >= 10
                    ? $"0{minutes}:{seconds}"
                    : $"0{minutes}:0{seconds}";
        }

        public string GetProjInfo(Projectile projType)
        {
            return CurrentLevel.Cannon.projInfo[projType].ToString();
        }

        /////
        /////
        /////

        public void Update()
        {
            CurrentLevel.Cannon.MachineGun.UpdateReloadTime();
            MoveObjects();
            CheckCollisions();

            if (CurrentLevel.IsCompleted)
            {
                if (CurrentLevelNumber != 6)
                    ChangeStage(GameStage.Finished);
                else
                    ChangeStage(GameStage.Menu);
            }
        }

        private void MoveObjects()
        {
            foreach (var drone in CurrentLevel.Drones)
            {
                drone.Move();
            }

            for (var i = 0; i < CurrentLevel.Projectiles.Count; i++)
            {
                var proj = CurrentLevel.Projectiles[i];
                if (proj.Collision.IntersectsWith(BattleGround))
                    proj.Move();
                else
                {
                    CurrentLevel.Projectiles.Remove(proj);
                    i--;
                }
            }
        }

        private void CheckCollisions()
        {
            foreach (var drone in CurrentLevel.Drones)
            {
                if (drone.Collision.IntersectsWith(CurrentLevel.Cannon.Collision))
                {
                    RestartLevel();
                }
            }

            for (var i = 0; i < CurrentLevel.Projectiles.Count; i++)
            {
                var proj = CurrentLevel.Projectiles[i];

                if (proj.Type == Projectile.Bullet)
                {
                    for (var j = 0; j < CurrentLevel.Drones.Count; j++)
                    {
                        var dr = CurrentLevel.Drones[j];
                        if (proj.Collision.IntersectsWith(dr.Collision))
                        {
                            CurrentLevel.Drones.Remove(dr);
                            j--;

                            CurrentLevel.Projectiles.Remove(proj);
                            i--;
                            break;
                        }
                    }
                }

                else
                {
                    if (proj.Collision.IntersectsWith(CurrentLevel.ControlCenter.Collision))
                    {
                        CurrentLevel.ControlCenter.IsCrashed = true;
                        PlayerScore += 3;
                        return;
                    }
                    for (var j = 0; j < CurrentLevel.SupplyCenters.Count; j++)
                    {
                        var sc = CurrentLevel.SupplyCenters[j];
                        if (proj.Collision.IntersectsWith(sc.Collision))
                        {
                            CurrentLevel.SupplyCenters.Remove(sc);
                            j--;
                            PlayerScore++;

                            CurrentLevel.Projectiles.Remove(proj);
                            i--;
                            break;
                        }
                    }
                }
                // ++projs with walls,
            }
        }

        private void SpawnDrone()
        {
            var dronePosition = new Vector(random.Next(50, BattleGround.Width - 50), 0);
            CurrentLevel.Drones.Add(new Drone(dronePosition, CurrentLevel.Cannon.Position));
        }
    }
}
