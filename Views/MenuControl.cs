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
    public partial class MenuControl : UserControl
    {
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

            startButton.Click += SelectButton_Click;
            exitButton.Click += ExitButton_Click;
            musicVolume.Scroll += MusicVolume_Scroll;
            soundVolume.Scroll += SoundVolume_Scroll;
        }
        
        private void SelectButton_Click(object sender, EventArgs e)
        {
            game.ToSelectLevel();
        }
        
        private void ExitButton_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show(
                "Вы уверенны, что хотите закрыть приложение?",
                "Сообщение",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Information,
                MessageBoxDefaultButton.Button1,
                MessageBoxOptions.DefaultDesktopOnly);
            if (result == DialogResult.Yes)
                Application.Exit();
        }
        
        private void MusicVolume_Scroll(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void SoundVolume_Scroll(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
