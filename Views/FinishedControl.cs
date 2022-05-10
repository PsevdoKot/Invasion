using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Invasion.Domain;

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
            scoreText.Text += game.PlayerScore.ToString();

        }

        private void NextLevelButton_Click(object sender, EventArgs e)
        {
            game.LoadLevel(game.CurrentLevelNumber + 1);
        }
    }
}
