using Invasion.Domain;
using Invasion.Properties;
using System;
using System.Drawing;

namespace Invasion.Views
{
    public partial class TutorialControl : System.Windows.Forms.UserControl
    {
        private Game game;

        public TutorialControl()
        {
            InitializeComponent();
        }

        public void Configure(Game game)
        {
            if (this.game != null)
                return;

            this.game = game;

            Size = ClientSize;

            mainTable.Size = ClientSize;

            backButton.Click += BackButton_Click;
            gameProcessButton.Click += GameProcessButton_Click;
            controlButton.Click += ControlButton_Click;
            AmmunitionButton.Click += AmmunitionButton_Click;
            wallsButton.Click += WallsButton_Click;

            GameProcessButton_Click(null, null);
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            game.ToLevelSelecting();
        }

        private void GameProcessButton_Click(object sender, EventArgs e)
        {
            HideInfoBlock();
            ShowGameProcessInfo();
        }

        private void ControlButton_Click(object sender, EventArgs e)
        {
            HideInfoBlock();
            ShowControlInfo();
        }

        private void AmmunitionButton_Click(object sender, EventArgs e)
        {
            HideInfoBlock();
            ShowAmmunitionInfo();
        }

        private void WallsButton_Click(object sender, EventArgs e)
        {
            HideInfoBlock();
            ShowWallsInfo();
        }

        private void ShowGameProcessInfo()
        {
            pictureBox1.Image = Resources.controlCenter;
            pictureBox1.Size = new Size(110, 110);
            pictureBox1.Visible = true;
            label1.Text = "Your task is to destroy the enemy control center. Destroy the control center to get 3 points";
            label1.Visible = true;

            pictureBox2.Image = Resources.cannonUnit;
            pictureBox2.Size = new Size(190, 75);
            pictureBox2.Visible = true;
            label2.Text = "You control the cannon. You have a choice of 4 types of projectiles: heavy cannonball, springy cannonball, laser and guided missile. Your ammunition is limited. " + Environment.NewLine +
                "Choose the necessary type of projectile, depending on the situation, and adjust the necessary shot power to damage the enemy base and pass the level";
            label2.Visible = true;

            pictureBox3.Image = Resources.drone;
            pictureBox3.Size = new Size(110, 110);
            pictureBox3.Visible = true;
            label3.Text = "With some frequency, enemy drones will appear on the level. When they approaching you, they will blow up your cannon, and you will lose. Fight them off with a turret mounted on a cannon";
            label3.Visible = true;

            pictureBox4.Image = Resources.supplyCenter;
            pictureBox4.Size = new Size(110, 110);
            pictureBox4.Visible = true;
            label4.Text = "Your additional task is to destroy enemy supply centers. Destroy supply centers to get 1 point each";
            label4.Visible = true;
        }

        private void ShowControlInfo()
        {
            pictureBox2.Image = Resources.cannonUnit;
            pictureBox2.Size = new Size(190, 75);
            pictureBox2.Visible = true;
            label2.Text = "Use A,D to change the direction of the cannon" + Environment.NewLine +
                "Use W,S to raise or lower shot power" + Environment.NewLine +
                "The F key will change the type of projectile loaded into the cannon" + Environment.NewLine +
                "Click RMB to shoot by cannon" + Environment.NewLine +
                "Use E to lock target for missle";
            label2.Visible = true;

            pictureBox3.Image = Resources.machineGun;
            pictureBox3.Size = new Size(140, 80);
            pictureBox3.Visible = true;
            label3.Text = "Use LMB to shoot by machine gun." + Environment.NewLine +
                "The direction of firing is determined by the position of the mouse on the screen";
            label3.Visible = true;

            label4.Text = "You can restart the level by pressing the R key";
            label4.Visible = true;
        }

        private void ShowAmmunitionInfo()
        {
            pictureBox1.Image = Resources.cannonBall;
            pictureBox1.Size = new Size(100, 100);
            pictureBox1.Visible = true;
            label1.Text = "An ordinary cannonball, subject to gravity. Capable of breaking walls";
            label1.Visible = true;

            pictureBox2.Image = Resources.springyBall;
            pictureBox2.Size = new Size(100, 100);
            pictureBox2.Visible = true;
            label2.Text = "A cannonball that can bounce off walls";
            label2.Visible = true;

            pictureBox3.Image = Resources.laser;
            pictureBox3.Size = new Size(180, 15);
            pictureBox3.Visible = true;
            label3.Text = "A beam that reflects off some types of walls";
            label3.Visible = true;

            pictureBox4.Image = Resources.missle;
            pictureBox4.Size = new Size(160, 35);
            pictureBox4.Visible = true;
            label4.Text = "A missile that changes its flight path by focusing on the target for guidance";
            label4.Visible = true;
        }

        private void ShowWallsInfo()
        {
            pictureBox1.Image = Resources.solidWall;
            pictureBox1.Size = new Size(200, 40);
            pictureBox1.Visible = true;
            label1.Text = "Springy balls will bounce off this wall";
            label1.Visible = true;

            pictureBox2.Image = Resources.fragileWall;
            pictureBox2.Size = new Size(200, 40);
            pictureBox2.Visible = true;
            label2.Text = "Heavy cannonballs and rockets can destroy this type of walls";
            label2.Visible = true;

            pictureBox3.Image = Resources.reflectiveWall;
            pictureBox3.Size = new Size(200, 40);
            pictureBox3.Visible = true;
            label3.Text = "Lasers reflected from these walls";
            label3.Visible = true;
        }

        private void HideInfoBlock()
        {
            pictureBox1.Visible = false;
            pictureBox2.Visible = false;
            pictureBox3.Visible = false;
            pictureBox4.Visible = false;
            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
        }
    }
}
