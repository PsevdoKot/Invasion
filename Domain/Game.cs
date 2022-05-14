using Invasion.Domain;
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
            CurrentLevel = /*LevelMaker.Levels[CurrentLevelNumber] ?? */LevelMaker.LoadLevelFromFolder(Folders.Levels, CurrentLevelNumber);
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

        public void ShootByCannon()
        {
            if (CurrentLevel.Cannon.Shoot())
            {
                switch (CurrentLevel.Cannon.SelectedProj)
                {
                    case Projectile.CannonBall:
                        CurrentLevel.Projectiles.Add(new CannonBall(CalculateShotPosition(),
                            CurrentLevel.Cannon.Direction, CurrentLevel.Cannon.ShotPower));
                        break;
                    case Projectile.SpringyBall:
                        CurrentLevel.Projectiles.Add(new SpringyBall(CalculateShotPosition(),
                            CurrentLevel.Cannon.Direction, CurrentLevel.Cannon.ShotPower));
                        break;
                    case Projectile.Laser:
                        CurrentLevel.Projectiles.Add(new Laser(CalculateShotPosition(),
                            CurrentLevel.Cannon.Direction, CurrentLevel.Cannon.ShotPower));
                        break;
                    case Projectile.Missle:
                        CurrentLevel.Projectiles.Add(new Missle(CalculateShotPosition(), CurrentLevel.RocketTargetPosition,
                            CurrentLevel.Cannon.Direction, CurrentLevel.Cannon.ShotPower));
                        break;
                }
            }
        }

        public void ShootByMachineGun()
        {
            if (CurrentLevel.Cannon.MachineGun.Shoot())
            {
                var angleInRad = CurrentLevel.Cannon.MachineGun.Direction * Math.PI / 180;
                CurrentLevel.Projectiles.Add(new Bullet(new Vector(
                    CurrentLevel.Cannon.MachineGun.Position.X + 20 * Math.Cos(angleInRad) - 5,
                    CurrentLevel.Cannon.MachineGun.Position.Y + 20 * Math.Sin(angleInRad)),
                    CurrentLevel.Cannon.MachineGun.Direction, CurrentLevel.Cannon.ShotPower));
            }
        }

        private Vector CalculateShotPosition()
        {
            var angleInRad = CurrentLevel.Cannon.Direction * Math.PI / 180;
            return new Vector(CurrentLevel.Cannon.Position.X + 100 * Math.Cos(angleInRad),
                              CurrentLevel.Cannon.Position.Y + 100 * Math.Sin(angleInRad) - 10);
        }

        public void SelectTargetPosition(Point mouseLocationOnBattleGround)
        {
            CurrentLevel.RocketTargetPosition = CurrentLevel.RocketTargetPosition == null
                        ? new Vector(mouseLocationOnBattleGround)
                        : null;
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

            bool flag;
            for (var i = 0; i < CurrentLevel.Projectiles.Count; i++)
            {
                flag = false;
                var proj = CurrentLevel.Projectiles[i];

                if (proj.Type == Projectile.Bullet)
                {
                    for (var j = 0; j < CurrentLevel.Drones.Count; j++)
                    {
                        var drone = CurrentLevel.Drones[j];
                        if (proj.Collision.IntersectsWith(drone.Collision))
                        {
                            CurrentLevel.Drones.Remove(drone);
                            j--;

                            CurrentLevel.Projectiles.Remove(proj);
                            i--;
                            flag = true;
                            break;
                        }
                    }
                    if (flag) break;
                    for (var j = 0; j < CurrentLevel.Walls.Count; j++)
                    {
                        if (proj.Collision.IntersectsWith(CurrentLevel.Walls[j].Collision))
                        {
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
                            flag = true;
                            break;
                        }
                    }
                    if (flag) break;
                    for (var j = 0; j < CurrentLevel.Walls.Count; j++)
                    {
                        var wall = CurrentLevel.Walls[j];
                        if (proj.Collision.IntersectsWith(wall.Collision))
                        {
                            if (wall.Type == Wall.FragileWall)
                            {
                                CurrentLevel.Walls.Remove(wall);
                                j--;
                            }
                            CurrentLevel.Projectiles.Remove(proj);
                            i--;
                            break;
                        }
                    }
                }
            }
        }

        private void SpawnDrone()
        {
            var dronePosition = new Vector(random.Next(50, BattleGround.Width - 50), 0);
            CurrentLevel.Drones.Add(new Drone(dronePosition, CurrentLevel.Cannon.Position));
        }
    }
}
