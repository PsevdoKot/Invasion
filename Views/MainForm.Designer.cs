
namespace Invasion
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuControl = new Invasion.Views.MenuControl();
            this.levelSelectingControl = new Invasion.Views.LevelSelectingControl();
            this.tutorialControl = new Views.TutorialControl();
            this.battleControl = new Invasion.Views.BattleControl();
            this.finishedControl = new Invasion.Views.FinishedControl();
            this.defeatControl = new Invasion.Views.DefeatControl();
            this.SuspendLayout();
            // 
            // menuControl
            // 
            this.menuControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.menuControl.Location = new System.Drawing.Point(0, 0);
            this.menuControl.Name = "menuControl";
            this.menuControl.Size = new System.Drawing.Size(1600, 881);
            this.menuControl.TabIndex = 0;
            // 
            // levelSelectingControl
            // 
            this.levelSelectingControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.levelSelectingControl.Location = new System.Drawing.Point(0, 0);
            this.levelSelectingControl.Name = "levelSelectingControl";
            this.levelSelectingControl.Size = new System.Drawing.Size(1600, 881);
            this.levelSelectingControl.TabIndex = 1;
            // 
            // tutorialControl
            // 
            this.tutorialControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tutorialControl.Location = new System.Drawing.Point(0, 0);
            this.tutorialControl.Name = "tutorialControl";
            this.tutorialControl.Size = new System.Drawing.Size(1600, 881);
            this.tutorialControl.TabIndex = 2;
            // 
            // battleControl
            // 
            this.battleControl.BackColor = System.Drawing.Color.LightSkyBlue;
            this.battleControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.battleControl.Location = new System.Drawing.Point(0, 0);
            this.battleControl.Name = "battleControl";
            this.battleControl.Size = new System.Drawing.Size(1600, 881);
            this.battleControl.TabIndex = 3;
            // 
            // finishedControl
            // 
            this.finishedControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.finishedControl.Location = new System.Drawing.Point(0, 0);
            this.finishedControl.Name = "finishedControl";
            this.finishedControl.Size = new System.Drawing.Size(1600, 881);
            this.finishedControl.TabIndex = 4;
            // 
            // defeatControl
            // 
            this.defeatControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.defeatControl.Location = new System.Drawing.Point(0, 0);
            this.defeatControl.Name = "defeatControl";
            this.defeatControl.Size = new System.Drawing.Size(1600, 881);
            this.defeatControl.TabIndex = 5;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1600, 881);
            this.Controls.Add(this.menuControl);
            this.Controls.Add(this.levelSelectingControl);
            this.Controls.Add(this.tutorialControl);
            this.Controls.Add(this.battleControl);
            this.Controls.Add(this.finishedControl);
            this.Controls.Add(this.defeatControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "MainForm";
            this.Text = "Invasion";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);

        }

        #endregion

        private Invasion.Views.MenuControl menuControl;
        private Invasion.Views.LevelSelectingControl levelSelectingControl;
        private Invasion.Views.TutorialControl tutorialControl;
        private Invasion.Views.BattleControl battleControl;
        private Invasion.Views.FinishedControl finishedControl;
        private Invasion.Views.DefeatControl defeatControl;
    }
}

