using Invasion.Domain;
using Invasion.Domain.Enums;
using Invasion.Domain.GameObjects;
using Invasion.Domain.Projectiles;
using System;
using System.IO;
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

        public Level CurrentLevel { get; private set; }
        public int CurrentLevelNumber { get; private set; }        
        public int PlayerScore { get; private set; }
        private int playerScoreAtLevelBeginning;

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
            PlayerScore = playerScoreAtLevelBeginning;
            ChangeStage(GameStage.Menu);
        }

        public void ToDefeat()
        {
            PlayerScore = playerScoreAtLevelBeginning;
            ChangeStage(GameStage.Defeat);
        }

        public void LoadLevel(int levelNumber)
        {
            playerScoreAtLevelBeginning = PlayerScore;
            LevelTime = 0;
            CurrentLevelNumber = levelNumber;
            CurrentLevel = LevelMaker.Levels[CurrentLevelNumber] ?? LevelMaker.LoadLevelFromFolder(Folders.Levels, CurrentLevelNumber);
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
            if (LevelTime % CurrentLevel.DroneAppearanceTime == 0)
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
                    ToDefeat();
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
