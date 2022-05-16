using Invasion.Domain;
using System;
using System.Windows.Forms;

namespace Invasion.Views
{
    public partial class FinishedControl : UserControl
    {
        private Game game;

        public FinishedControl()
        {
            InitializeComponent();
        }

        public void Configure(Game game)
        {
            if (this.game != null)
                return;

            this.game = game;

            nextLevelButton.Click += NextLevelButton_Click;
        }

        public void UpdateScoreInfo()
        {
            scoreText.Text = $"Your score is: {game.PlayerScore}";
        }

        private void NextLevelButton_Click(object sender, EventArgs e)
        {
            game.LoadLevel(game.CurrentLevelNumber + 1);
        }
    }
}
