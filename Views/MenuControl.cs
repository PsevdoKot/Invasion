using Invasion.Domain;
using System;
using System.Windows.Forms;

namespace Invasion.Views
{
    public partial class MenuControl : UserControl
    {
        private WMPLib.WindowsMediaPlayer WMP = new WMPLib.WindowsMediaPlayer();

        private Game game;

        public MenuControl()
        {
            InitializeComponent();
        }

        public void Configure(Game game)
        {
            if (this.game != null)
                return;

            this.game = game;

            tutorialButton.Click += TutorialButton_Click;

            startButton.Click += StartButton_Click;
            exitButton.Click += ExitButton_Click;

            //musicVolume.ValueChanged += GameVolume_ValueChanged;
            //musicVolume.Value = 50
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            game.ToLevelSelecting();
        }

        private void TutorialButton_Click(object sender, EventArgs e)
        {
            game.ToTutorial();
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show(
                "Are you sure you want to close the app?",
                "Massage",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Information,
                MessageBoxDefaultButton.Button1,
                MessageBoxOptions.DefaultDesktopOnly);
            if (result == DialogResult.Yes)
                Application.Exit();
        }

        //private void MusicVolume_ValueChanged(object sender, EventArgs e)
        //{
        //    WMP.settings.volume = musicVolume.Value;
        //}
    }
}
