using Invasion.Domain.GameObjects;
using Invasion.Domain.Projectiles;
using Invasion.Domain.Walls;
using System;
using System.Drawing;

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

        public void ToLevelSelecting()
        {
            ChangeStage(GameStage.LevelSelecting);
        }

        public void ToMenu()
        {
            PlayerScore = playerScoreAtLevelBeginning;
            ChangeStage(GameStage.Menu);
        }

        public void ToTutorial()
        {
            ChangeStage(GameStage.Tutorial);
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
            CurrentLevel = LevelMaker.LoadLevelFromFolder(Folders.Levels, levelNumber);
            ChangeStage(GameStage.Battle);
        }

        public void RestartLevel()
        {
            LoadLevel(CurrentLevelNumber);
        }

        /////
        /////
        /////

        public void UpdateTimer()
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

        public string GetProjectileCount(Projectile projType)
        {
            return CurrentLevel.Cannon.Ammunition[projType].ToString();
        }

        /////
        /////
        /////

        public void ShootByCannon()
        {
            if (CurrentLevel.Cannon.Shoot())
            {
                switch (CurrentLevel.Cannon.SelectedProjectile)
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
                var projectile = CurrentLevel.Projectiles[i];
                var projectileCollision = projectile.Collision;
                if (projectileCollision.IntersectsWith(BattleGround) || projectileCollision.Y < -200)
                    projectile.Move();
                else
                {
                    CurrentLevel.Projectiles.Remove(projectile);
                    i--;
                }
            }
        }

        private void CheckCollisions()
        {
            CheckDronesCollision();
            CheckProjectileCollision();
        }

        private void CheckDronesCollision()
        {
            foreach (var drone in CurrentLevel.Drones)
                if (drone.Collision.IntersectsWith(CurrentLevel.Cannon.Collision))
                    ToDefeat();
        }

        private void CheckProjectileCollision()
        {
            for (var i = 0; i < CurrentLevel.Projectiles.Count && !CurrentLevel.IsCompleted; i++)
            {
                var projectile = CurrentLevel.Projectiles[i];
                if (projectile.Type == Projectile.Bullet)
                {
                    if (CheckMachineGunProjectile(projectile))
                        i--;
                }
                else if (CheckCannonProjectile(projectile))
                    i--;
            }
        }

        private bool CheckMachineGunProjectile(IProjectile projectile)
        {
            for (var j = 0; j < CurrentLevel.Drones.Count; j++)
            {
                var drone = CurrentLevel.Drones[j];
                if (projectile.Collision.IntersectsWith(drone.Collision))
                {
                    CurrentLevel.Drones.Remove(drone);
                    j--;

                    CurrentLevel.Projectiles.Remove(projectile);
                    return true;
                }
            }
            //for (var j = 0; j < CurrentLevel.Walls.Count; j++)
            //{
            //    var wall = CurrentLevel.Walls[j];
            //    if (projectile.Collision.IntersectsWith(wall.Collision))
            //    {
            //        CurrentLevel.Projectiles.Remove(projectile);
            //        return true;
            //    }
            //}
            return false;
        }

        private bool CheckCannonProjectile(IProjectile projectile)
        {
            if (projectile.Collision.IntersectsWith(CurrentLevel.ControlCenter.Collision))
            {
                CurrentLevel.ControlCenter.IsCrashed = true;
                PlayerScore += 3;
                return true;
            }
            for (var j = 0; j < CurrentLevel.SupplyCenters.Count; j++)
            {
                var supplyCenter = CurrentLevel.SupplyCenters[j];
                if (projectile.Collision.IntersectsWith(supplyCenter.Collision))
                {
                    CurrentLevel.SupplyCenters.Remove(supplyCenter);
                    j--;
                    PlayerScore++;

                    CurrentLevel.Projectiles.Remove(projectile);
                    return true;
                }
            }
            for (var j = 0; j < CurrentLevel.Walls.Count; j++)
            {
                var wall = CurrentLevel.Walls[j];
                if (projectile.Collision.IntersectsWith(wall.Collision))
                {
                    if (projectile.Type == Projectile.SpringyBall && (wall.Type == Wall.SolidWall || wall.Type == Wall.FragileWall)
                        || projectile.Type == Projectile.Laser && wall.Type == Wall.ReflectiveWall)
                    {
                        projectile.Direction = 2 * (180 - wall.InclinationAngle) - projectile.Direction;
                        projectile.MoveVector = Vector.Build(projectile.MoveSpeed, projectile.Direction * Math.PI / 180);
                    }
                    else
                    {
                        if ((projectile.Type == Projectile.CannonBall || projectile.Type == Projectile.Missle) && wall.Type == Wall.FragileWall)
                        {
                            CurrentLevel.Walls.Remove(wall);
                            j--;
                        }
                        CurrentLevel.Projectiles.Remove(projectile);
                        return true;
                    }
                    break;
                }
            }
            return false;
        }

        private void SpawnDrone()
        {
            var dronePosition = new Vector(random.Next(50, BattleGround.Width - 50), 0);
            CurrentLevel.Drones.Add(new Drone(dronePosition, CurrentLevel.Cannon.Position));
        }
    }
}
