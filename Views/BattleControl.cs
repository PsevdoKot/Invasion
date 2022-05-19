using Invasion.Domain;
using Invasion.Domain.Projectiles;
using Invasion.Properties;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Reflection;
using System.Windows.Forms;

namespace Invasion.Views
{
    public partial class BattleControl : UserControl
    {
        private Game game;
        private Level level;
        private Timer mainTimer;

        private Timer uiTimer;

        private int leftBattleGroundBorder, topBattleGroundBorder, battleGroundWidth, battleGroundHeight;

        private Matrix initialMatrix;

        public BattleControl()
        {
            InitializeComponent();

            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint
                | ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.SupportsTransparentBackColor | ControlStyles.Opaque, false);
            typeof(Panel).InvokeMember("DoubleBuffered",
                BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic,
                null, table, new object[] { true });

            table.BackgroundImage = Resources.battleBackground;

            GetBattleGroundBounds();

            mainTimer = new Timer { Interval = 30 };
            mainTimer.Tick += mainTimer_Tick;

            uiTimer = new Timer { Interval = 1000 };
            uiTimer.Tick += uiTimer_Tick;

            menuButton.Click += MenuButton_Click;
        }

        private void GetBattleGroundBounds()
        {
            leftBattleGroundBorder = (int)(ClientSize.Width * 0.2) + 3;
            topBattleGroundBorder = (int)(ClientSize.Height * 0.1) - 3;

            battleGroundWidth = ClientRectangle.Width - leftBattleGroundBorder - 0;
            battleGroundHeight = ClientRectangle.Height - topBattleGroundBorder - 65;
        }

        public void Configure(Game game)
        {
            if (this.game == null)
                this.game = game;

            game.BattleGround = new Rectangle(0, 0, battleGroundWidth, battleGroundHeight);
            level = game.CurrentLevel;

            mainTimer.Start();
            uiTimer.Start();
            timeInfo.Text = "00:00";
            levelInfo.Text = $"Level {game.CurrentLevelNumber}";

            UpdateProjectileInfo();
        }

        public void StopUpdating()
        {
            mainTimer.Stop();
            uiTimer.Stop();
        }

        private void mainTimer_Tick(object sender, EventArgs e)
        {
            game.Update();
            table.Refresh();
        }

        private void MenuButton_Click(object sender, EventArgs e)
        {
            StopUpdating();
            game.ToMenu();
        }

        public void HandleKey(Keys e)
        {
            switch (e)
            {
                case Keys.A:
                    level.Cannon.RotateDirection(Turn.Right);
                    break;
                case Keys.D:
                    level.Cannon.RotateDirection(Turn.Left);
                    break;
                case Keys.W:
                    level.Cannon.ChangeShotPower(Turn.Right);
                    infoTable.Invalidate();
                    break;
                case Keys.S:
                    level.Cannon.ChangeShotPower(Turn.Left);
                    infoTable.Invalidate();
                    break;
                case Keys.F:
                    level.Cannon.ChooseProjectile(level.Cannon.SelectedProjectile + 1);
                    UpdateProjectileInfo();
                    break;
                case Keys.R:
                    game.RestartLevel();
                    break;
            }
        }

        private void OnMouseDowm(object sender, MouseEventArgs e)
        {
            switch (e.Button)
            {
                case MouseButtons.Left:
                    level.Cannon.MachineGun.RotateDirectionTo(new Vector(e.Location.Add(-leftBattleGroundBorder, -topBattleGroundBorder)));
                    game.ShootByMachineGun();
                    break;
                case MouseButtons.Right:
                    game.ShootByCannon();
                    UpdateProjectileInfo();
                    break;
                case MouseButtons.Middle:
                    game.SelectTargetPosition(e.Location.Add(-leftBattleGroundBorder, -topBattleGroundBorder));
                    break;
            }
        }

        /////
        /////  
        /////

        private void uiTimer_Tick(object sender, EventArgs e)
        {
            game.UpdateTimer();
            scoreInfo.Text = $"Score: {game.PlayerScore}";
            timeInfo.Text = game.GetTime();
        }

        public void UpdateProjectileInfo()
        {
            cannonBallInfo.Text = game.GetProjectileCount(Projectile.CannonBall);
            springyBallInfo.Text = game.GetProjectileCount(Projectile.SpringyBall);
            laserInfo.Text = game.GetProjectileCount(Projectile.Laser);
            missleInfo.Text = game.GetProjectileCount(Projectile.Missle);

            RepaintInfo(level.Cannon.SelectedProjectile);
        }

        private void RepaintInfo(Projectile projType)
        {
            springyBallInfo.ForeColor = Color.Black;
            laserInfo.ForeColor = Color.Black;
            missleInfo.ForeColor = Color.Black;
            cannonBallInfo.ForeColor = Color.Black;

            switch (level.Cannon.SelectedProjectile)
            {
                case Projectile.CannonBall:
                    cannonBallInfo.ForeColor = Color.Crimson;
                    break;
                case Projectile.SpringyBall:
                    springyBallInfo.ForeColor = Color.Crimson;
                    break;
                case Projectile.Laser:
                    laserInfo.ForeColor = Color.Crimson;
                    break;
                case Projectile.Missle:
                    missleInfo.ForeColor = Color.Crimson;
                    break;
            }
        }

        private void LevelInfo_OnPaint(object sender, TableLayoutCellPaintEventArgs e)
        {
            var shotPowerBar = new Rectangle(25, (int)(ClientSize.Height * 0.8) + 30, 250, 20);
            e.Graphics.DrawRectangle(Pens.Black, shotPowerBar.X - 1, shotPowerBar.Y - 1, shotPowerBar.Width + 1, shotPowerBar.Height + 1);
            e.Graphics.FillRectangle(Brushes.DarkRed, shotPowerBar);
            e.Graphics.FillRectangle(Brushes.Red, shotPowerBar.X, shotPowerBar.Y, 2.5f * level.Cannon.ShotPower, shotPowerBar.Height);
        }

        private void Table_OnPaint(object sender, TableLayoutCellPaintEventArgs e)
        {
            var image = new Bitmap(battleGroundWidth, battleGroundHeight);
            var graph = Graphics.FromImage(image);
            DrawTo(graph);
            e.Graphics.DrawImageUnscaled(image, leftBattleGroundBorder, topBattleGroundBorder);
        }

        private void DrawTo(Graphics g)
        {
            g.SmoothingMode = SmoothingMode.AntiAlias;

            initialMatrix = g.Transform;

            DrawCannon(g);
            DrawMachineGun(g);
            DrawControlCenter(g);
            DrawSupplyCenters(g);
            DrawWalls(g);
            DrawDrones(g);
            DrawProjectiles(g);
            DrawRocketTarget(g);
        }

        private void DrawCannon(Graphics g)
        {
            g.TranslateTransform((float)level.Cannon.Position.X, (float)level.Cannon.Position.Y);
            g.DrawImage(level.Cannon.Image2, -15, 0, 30, 70);
            g.RotateTransform((level.Cannon.IsFliped ? 0 : 180) + (float)level.Cannon.Direction);
            g.DrawImage(level.Cannon.Image, level.Cannon.IsFliped ? 100 : -100, -15, level.Cannon.IsFliped ? -150 : 150, 30);
            g.Transform = initialMatrix;
        }

        private void DrawMachineGun(Graphics g)
        {
            g.TranslateTransform((float)level.Cannon.Position.X, (float)level.Cannon.Position.Y + 5);
            g.RotateTransform((level.Cannon.MachineGun.IsFliped ? 180 : 0) + (float)level.Cannon.MachineGun.Direction);
            g.DrawImage(level.Cannon.MachineGun.Image, level.Cannon.MachineGun.IsFliped ? 20 : -20, -20,
                level.Cannon.MachineGun.IsFliped ? -50 : 50, 30);
            g.Transform = initialMatrix;
        }

        private void DrawControlCenter(Graphics g)
        {
            g.DrawImage(level.ControlCenter.Image, level.ControlCenter.Collision);
        }

        private void DrawSupplyCenters(Graphics g)
        {
            foreach (var supplyCenter in level.SupplyCenters)
            {
                g.DrawImage(supplyCenter.Image, supplyCenter.Collision);
            }
        }

        private void DrawWalls(Graphics g)
        {
            foreach (var wall in level.Walls)
            {
                g.TranslateTransform((float)wall.Position.X, (float)wall.Position.Y);
                g.RotateTransform((float)wall.InclinationAngle);
                g.DrawImage(wall.Image, -wall.Size.Width / 2, -wall.Size.Height / 2, wall.Size.Width, wall.Size.Height);
                g.Transform = initialMatrix;
            }
        }

        private void DrawDrones(Graphics g)
        {
            foreach (var drone in level.Drones)
            {
                g.TranslateTransform((float)drone.Position.X, (float)drone.Position.Y);
                g.RotateTransform((float)drone.Direction);
                g.DrawImage(drone.Image, -drone.Size.Width / 2, -drone.Size.Height / 2, drone.Size.Width, drone.Size.Height);
                g.Transform = initialMatrix;
            }
        }

        private void DrawProjectiles(Graphics g)
        {
            foreach (var projectile in level.Projectiles)
            {
                g.TranslateTransform((float)projectile.Position.X, (float)projectile.Position.Y);
                g.RotateTransform((float)projectile.Direction);
                g.DrawImage(projectile.Image, -projectile.Size.Width / 2, -projectile.Size.Height / 2, projectile.Size.Width, projectile.Size.Height);
                g.Transform = initialMatrix;
            }
        }

        private void DrawRocketTarget(Graphics g)
        {
            if (level.RocketTargetPosition != null)
            {
                g.TranslateTransform((float)level.RocketTargetPosition.X, (float)level.RocketTargetPosition.Y);
                g.DrawEllipse(widthRedPen, -10, -10, 20, 20);
                for (var i = 0; i < 4; i++)
                {
                    g.DrawLine(widthRedPen, 10, 0, 17, 0);
                    g.RotateTransform(90f);
                }
            }
        }

        private Pen widthRedPen = new Pen(Color.Red, 4);
    }
}