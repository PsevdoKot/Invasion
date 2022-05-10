using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Invasion.Domain;
using Invasion.Domain.Enums;
using Invasion.Domain.GameObjects;
using Invasion.Properties;
using Invasion.Domain.Projectiles;

namespace Invasion.Views
{
    public partial class BattleControl : UserControl
    {
        private Game game;
        private Level level;
        private Timer mainTimer;

        private Timer uiTimer;

        private int leftBorder, topBorder, bgWidth, bgHeight;
        private Rectangle battleGround;

        public BattleControl()
        {
            InitializeComponent();

            SetStyle(ControlStyles.DoubleBuffer |ControlStyles.AllPaintingInWmPaint
                | ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.SupportsTransparentBackColor | ControlStyles.Opaque, false);
            typeof(Panel).InvokeMember("DoubleBuffered",
                BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic,
                null, table, new object[] { true });
            BackColor = Color.LightSkyBlue;

            GetBattleGroundBounds();

            mainTimer = new Timer { Interval = 30 };
            mainTimer.Tick += mainTimer_Tick;

            uiTimer = new Timer { Interval = 1000 };
            uiTimer.Tick += uiTimer_Tick;

            menuButton.Click += MenuButton_Click;
        }

        private void GetBattleGroundBounds()
        {
            leftBorder = (int)(ClientSize.Width * 0.2) + 3;
            topBorder = (int)(ClientSize.Height * 0.1) - 3;

            bgWidth = ClientRectangle.Width - leftBorder - 0;
            bgHeight = ClientRectangle.Height - topBorder - 65;

            battleGround = new Rectangle(leftBorder, topBorder, bgWidth, bgHeight);
        }

        public void Configure(Game game)
        {
            if (this.game == null)
                this.game = game;

            game.BattleGround = new Rectangle(0, 0, bgWidth, bgHeight);
            level = game.CurrentLevel;

            mainTimer.Start();
            uiTimer.Start();
            timeInfo.Text = "00:00";
            levelInfo.Text = $"Level {game.CurrentLevelNumber}";

            UpdateProjInfo();
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
                case Keys.X:
                    level.Cannon.RotateDirection(Direction.Up);
                    break;
                case Keys.V:
                    level.Cannon.RotateDirection(Direction.Down);
                    break;
                case Keys.D:
                    level.Cannon.ChangeShotPower(Direction.Up);
                    infoTable.Invalidate();
                    break;
                case Keys.C:
                    level.Cannon.ChangeShotPower(Direction.Down);
                    infoTable.Invalidate();
                    break;
                case Keys.F:
                    level.Cannon.ChooseProjectile(level.Cannon.SelectedProj + 1);
                    UpdateProjInfo();
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
                    level.Cannon.MachineGun.RotateDirectionTo(new Vector(e.Location.Add(-leftBorder, -topBorder)));
                    ShootByMachineGun();
                    break;
                case MouseButtons.Right:
                    ShootByCannon();
                    UpdateProjInfo();
                    break;
                case MouseButtons.Middle:
                    level.RocketTargetPosition = level.RocketTargetPosition == null 
                        ? new Vector(e.Location.Add(-leftBorder, -topBorder))
                        : null;
                    break;
            }
        }

        private void ShootByCannon()
        {
            if (level.Cannon.Shoot())
            {
                switch (level.Cannon.SelectedProj)
                {
                    case Projectile.CannonBall:
                        level.Projectiles.Add(new CannonBall(CalculateShotPosition(), level.Cannon.Direction, level.Cannon.ShotPower));
                        break;
                    case Projectile.SpringyBall:
                        level.Projectiles.Add(new SpringyBall(CalculateShotPosition(), level.Cannon.Direction, level.Cannon.ShotPower));
                        break;
                    case Projectile.Laser:
                        level.Projectiles.Add(new Laser(CalculateShotPosition(), level.Cannon.Direction, level.Cannon.ShotPower));
                        break;
                    case Projectile.Missle:
                        level.Projectiles.Add(new Missle(CalculateShotPosition(), level.RocketTargetPosition,
                            level.Cannon.Direction, level.Cannon.ShotPower));
                        break;
                }
            }
        }

        private void ShootByMachineGun()
        {
            if (level.Cannon.MachineGun.Shoot())
            {
                level.Projectiles.Add(new Bullet(new Vector(
                    level.Cannon.MachineGun.Position.X + 20 * Math.Cos(level.Cannon.MachineGun.Direction * Math.PI / 180) - 5,
                    level.Cannon.MachineGun.Position.Y + 20 * Math.Sin(level.Cannon.MachineGun.Direction * Math.PI / 180)),
                    level.Cannon.MachineGun.Direction, level.Cannon.ShotPower));
            }
        }

        private Vector CalculateShotPosition()
        {
            return new Vector(level.Cannon.Position.X + 100 * Math.Cos(level.Cannon.Direction * Math.PI / 180),
                level.Cannon.Position.Y + 100 * Math.Sin(level.Cannon.Direction * Math.PI / 180) - 10);
        }

        /////
        /////  Views
        /////

        private void uiTimer_Tick(object sender, EventArgs e)
        {
            game.UpdateTime();
            scoreInfo.Text = $"Score: {game.PlayerScore}";
            timeInfo.Text = game.GetTime();
        }

        public void UpdateProjInfo()
        {
            cannonBallInfo.Text = game.GetProjInfo(Projectile.CannonBall);
            springyBallInfo.Text = game.GetProjInfo(Projectile.SpringyBall);
            laserInfo.Text = game.GetProjInfo(Projectile.Laser);
            missleInfo.Text = game.GetProjInfo(Projectile.Missle);

            RepaintInfo(level.Cannon.SelectedProj);
        }

        private void RepaintInfo(Projectile projType)
        {
            springyBallInfo.ForeColor = Color.Black;
            laserInfo.ForeColor = Color.Black;
            missleInfo.ForeColor = Color.Black;
            cannonBallInfo.ForeColor = Color.Black;

            switch (level.Cannon.SelectedProj)
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
            var shotPowerBar = new Rectangle(25, (int)(ClientSize.Height * 0.8) + 15, 250, 30);
            e.Graphics.DrawRectangle(Pens.Black, shotPowerBar.X - 1, shotPowerBar.Y - 1, shotPowerBar.Width + 1, shotPowerBar.Height + 1);
            e.Graphics.FillRectangle(Brushes.DarkRed, shotPowerBar);
            e.Graphics.FillRectangle(Brushes.Red, shotPowerBar.X, shotPowerBar.Y, 2.5f * level.Cannon.ShotPower, shotPowerBar.Height);
        }

        private void Table_OnPaint(object sender, TableLayoutCellPaintEventArgs e)
        {
            var image = new Bitmap(bgWidth, bgHeight);
            var graph = Graphics.FromImage(image);
            DrawTo(graph);
            e.Graphics.DrawImageUnscaled(image, leftBorder, topBorder);
        }

        private void DrawTo(Graphics g)
        {
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.FillRectangle(/*Brushes.Gainsboro*/Brushes.Gray, 0, 0, bgWidth, bgHeight);

            var matrix = g.Transform;

            // cannon
            g.TranslateTransform((float)level.Cannon.Position.X, (float)level.Cannon.Position.Y);
            g.DrawImage(level.Cannon.Image2, -15, 0, 30, 70);
            g.RotateTransform((level.Cannon.IsFliped ? 0 : 180) + (float)level.Cannon.Direction);
            g.DrawImage(level.Cannon.Image, level.Cannon.IsFliped ? 100 : -100, -15, level.Cannon.IsFliped ? -150 : 150, 30);
            
            // machine gun
            g.Transform = matrix;
            g.TranslateTransform((float)level.Cannon.Position.X, (float)level.Cannon.Position.Y + 5);
            g.RotateTransform((level.Cannon.MachineGun.IsFliped ? 180 : 0) + (float)level.Cannon.MachineGun.Direction);
            g.DrawImage(level.Cannon.MachineGun.Image, level.Cannon.MachineGun.IsFliped ? 20 : -20, -20,
                level.Cannon.MachineGun.IsFliped ? -50 : 50, 30);

            // controlCenter
            g.Transform = matrix;
            g.DrawImage(level.ControlCenter.Image, level.ControlCenter.Collision);

            // supplyCenters
            foreach (var supplyCenter in level.SupplyCenters)
            {
                g.DrawImage(supplyCenter.Image, supplyCenter.Collision);
            }

            // drones
            foreach (var drone in level.Drones)
            {
                g.DrawRectangle(Pens.Red, drone.Collision);
                g.TranslateTransform((float)drone.Position.X, (float)drone.Position.Y);
                g.RotateTransform((float)drone.Direction);
                g.DrawImage(drone.Image, -drone.Size.Width / 2, -drone.Size.Height / 2, drone.Size.Width, drone.Size.Height);
                g.Transform = matrix;
            }

            // projectiles
            foreach (var projectile in level.Projectiles)
            {
                g.TranslateTransform((float)projectile.Position.X, (float)projectile.Position.Y);
                g.RotateTransform((float)projectile.Direction);
                g.DrawImage(projectile.Image, 0, 0, projectile.Size.Width, projectile.Size.Height);
                g.Transform = matrix;
            }

            // rocket target
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