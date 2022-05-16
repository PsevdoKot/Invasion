using Invasion.Domain;
using System;
using System.Windows.Forms;

namespace Invasion.Views
{
    public partial class DefeatControl : UserControl
    {
        private Game game;

        public DefeatControl()
        {
            InitializeComponent();
        }

        public void Configure(Game game)
        {
            if (this.game != null)
                return;

            this.game = game;

            restartButton.Click += RestartButton_Click;
        }

        private void RestartButton_Click(object sender, EventArgs e)
        {
            game.RestartLevel();
        }
    }
}
