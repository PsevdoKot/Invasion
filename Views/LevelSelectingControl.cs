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
    public partial class LevelSelectingControl : UserControl
    {
        private Game game;

        public LevelSelectingControl()
        {
            InitializeComponent();
        }

        public void Configure(Game game)
        {
            if (this.game != null)
                return;

            this.game = game;

            level1Button.Click += LevelButton_Click;
            level2Button.Click += LevelButton_Click;
            level3Button.Click += LevelButton_Click;
            level4Button.Click += LevelButton_Click;
            level5Button.Click += LevelButton_Click;
            level6Button.Click += LevelButton_Click;

            menuButton.Click += MenuButton_Click;
        }

        private void LevelButton_Click(object sender, EventArgs e) 
            => game.LoadLevel(((Button)sender).Text.ElementAt(6) - 48);

        private void MenuButton_Click(object sender, EventArgs e)
        {
            game.ToMenu();
        }
    }
}
