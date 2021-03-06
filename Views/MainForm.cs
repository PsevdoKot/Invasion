using Invasion.Domain;
using System.Windows.Forms;

namespace Invasion
{
    public partial class MainForm : Form
    {
        private Game game;

        public MainForm()
        {
            InitializeComponent();

            game = new Game();
            game.StageChanged += GameStageChanged;

            ShowStartScreen();
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams handleParam = base.CreateParams;
                handleParam.ExStyle |= 0x02000000;
                return handleParam;
            }
        }

        private void GameStageChanged(GameStage stage)
        {
            switch (stage)
            {
                case GameStage.LevelSelecting:
                    ShowLevelSelectingScreen();
                    break;
                case GameStage.Tutorial:
                    ShowTutorialScreen();
                    break;
                case GameStage.Battle:
                    ShowBattleScreen();
                    break;
                case GameStage.Finished:
                    ShowFinishedScreen();
                    break;
                case GameStage.Defeat:
                    ShowDefeatScreen();
                    break;
                case GameStage.Menu:
                default:
                    ShowStartScreen();
                    break;
            }
        }

        private void ShowStartScreen()
        {
            HideScreens();
            menuControl.Configure(game);
            menuControl.Show();
        }

        private void ShowLevelSelectingScreen()
        {
            HideScreens();
            levelSelectingControl.Configure(game);
            levelSelectingControl.Show();
        }

        private void ShowTutorialScreen()
        {
            HideScreens();
            tutorialControl.Configure(game);
            tutorialControl.Show();
        }

        private void ShowBattleScreen()
        {
            HideScreens();
            battleControl.Configure(game);
            battleControl.Show();
            KeyPreview = true;
        }

        private void ShowFinishedScreen()
        {
            battleControl.StopUpdating();
            HideScreens();
            finishedControl.Configure(game);
            finishedControl.UpdateScoreInfo();
            finishedControl.Show();
        }

        private void ShowDefeatScreen()
        {
            battleControl.StopUpdating();
            HideScreens();
            defeatControl.Configure(game);
            defeatControl.Show();
        }

        private void HideScreens()
        {
            KeyPreview = false;
            menuControl.Hide();
            levelSelectingControl.Hide();
            tutorialControl.Hide();
            battleControl.Hide();
            finishedControl.Hide();
            defeatControl.Hide();
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
            battleControl.HandleKey(e.KeyCode);
        }
    }
}
