using System.Windows.Forms;

namespace Invasion.Views
{
    partial class MenuControl
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

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MenuControl));
            this.table = new System.Windows.Forms.TableLayoutPanel();
            this.pictureTable2 = new System.Windows.Forms.TableLayoutPanel();
            this.mainTable = new System.Windows.Forms.TableLayoutPanel();
            this.additionalTable = new System.Windows.Forms.TableLayoutPanel();
            this.soundVolumeText = new System.Windows.Forms.Label();
            this.musicVolumeText = new System.Windows.Forms.Label();
            this.soundVolume = new System.Windows.Forms.TrackBar();
            this.exitButton = new System.Windows.Forms.Button();
            this.musicVolume = new System.Windows.Forms.TrackBar();
            this.startButton = new System.Windows.Forms.Button();
            this.logo = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureTable1 = new System.Windows.Forms.TableLayoutPanel();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.table.SuspendLayout();
            this.pictureTable2.SuspendLayout();
            this.mainTable.SuspendLayout();
            this.additionalTable.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.soundVolume)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.musicVolume)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.pictureTable1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // table
            // 
            this.table.BackColor = System.Drawing.Color.LightSkyBlue;
            this.table.ColumnCount = 3;
            this.table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.table.Controls.Add(this.pictureTable1, 0, 0);
            this.table.Controls.Add(this.pictureTable2, 2, 0);
            this.table.Controls.Add(this.mainTable, 1, 0);
            this.table.Dock = System.Windows.Forms.DockStyle.Fill;
            this.table.Location = new System.Drawing.Point(0, 0);
            this.table.Name = "table";
            this.table.RowCount = 1;
            this.table.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 900F));
            this.table.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 900F));
            this.table.Size = new System.Drawing.Size(1600, 900);
            this.table.TabIndex = 0;
            // 
            // pictureTable2
            // 
            this.pictureTable2.ColumnCount = 1;
            this.pictureTable2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.pictureTable2.Controls.Add(this.pictureBox2, 0, 1);
            this.pictureTable2.Controls.Add(this.pictureBox4, 0, 0);
            this.pictureTable2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureTable2.Location = new System.Drawing.Point(1203, 3);
            this.pictureTable2.Name = "pictureTable2";
            this.pictureTable2.RowCount = 2;
            this.pictureTable2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.pictureTable2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.pictureTable2.Size = new System.Drawing.Size(394, 894);
            this.pictureTable2.TabIndex = 12;
            // 
            // mainTable
            // 
            this.mainTable.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.OutsetPartial;
            this.mainTable.ColumnCount = 1;
            this.mainTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.mainTable.Controls.Add(this.additionalTable, 0, 1);
            this.mainTable.Controls.Add(this.logo, 0, 0);
            this.mainTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainTable.Location = new System.Drawing.Point(403, 3);
            this.mainTable.Name = "mainTable";
            this.mainTable.RowCount = 2;
            this.mainTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.mainTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mainTable.Size = new System.Drawing.Size(794, 894);
            this.mainTable.TabIndex = 8;
            // 
            // additionalTable
            // 
            this.additionalTable.ColumnCount = 1;
            this.additionalTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.additionalTable.Controls.Add(this.soundVolumeText, 0, 3);
            this.additionalTable.Controls.Add(this.musicVolumeText, 0, 1);
            this.additionalTable.Controls.Add(this.soundVolume, 0, 2);
            this.additionalTable.Controls.Add(this.exitButton, 0, 5);
            this.additionalTable.Controls.Add(this.musicVolume, 0, 4);
            this.additionalTable.Controls.Add(this.startButton, 0, 0);
            this.additionalTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.additionalTable.Location = new System.Drawing.Point(6, 159);
            this.additionalTable.Name = "additionalTable";
            this.additionalTable.RowCount = 6;
            this.additionalTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.additionalTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.additionalTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.additionalTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.additionalTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.additionalTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.additionalTable.Size = new System.Drawing.Size(782, 729);
            this.additionalTable.TabIndex = 9;
            // 
            // soundVolumeText
            // 
            this.soundVolumeText.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.soundVolumeText.AutoSize = true;
            this.soundVolumeText.Font = new System.Drawing.Font("Cooper Black", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.soundVolumeText.Location = new System.Drawing.Point(285, 401);
            this.soundVolumeText.Name = "soundVolumeText";
            this.soundVolumeText.Size = new System.Drawing.Size(212, 34);
            this.soundVolumeText.TabIndex = 1;
            this.soundVolumeText.Text = "Game volume";
            // 
            // musicVolumeText
            // 
            this.musicVolumeText.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.musicVolumeText.AutoSize = true;
            this.musicVolumeText.Font = new System.Drawing.Font("Cooper Black", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.musicVolumeText.Location = new System.Drawing.Point(283, 257);
            this.musicVolumeText.Name = "musicVolumeText";
            this.musicVolumeText.Size = new System.Drawing.Size(215, 34);
            this.musicVolumeText.TabIndex = 0;
            this.musicVolumeText.Text = "Music volume";
            // 
            // soundVolume
            // 
            this.soundVolume.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.soundVolume.Location = new System.Drawing.Point(266, 304);
            this.soundVolume.Maximum = 100;
            this.soundVolume.Name = "soundVolume";
            this.soundVolume.Size = new System.Drawing.Size(250, 45);
            this.soundVolume.TabIndex = 4;
            this.soundVolume.TickStyle = System.Windows.Forms.TickStyle.None;
            // 
            // exitButton
            // 
            this.exitButton.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.exitButton.Font = new System.Drawing.Font("Cooper Black", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exitButton.Location = new System.Drawing.Point(291, 547);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(200, 60);
            this.exitButton.TabIndex = 6;
            this.exitButton.Text = "Exit";
            this.exitButton.UseVisualStyleBackColor = true;
            // 
            // musicVolume
            // 
            this.musicVolume.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.musicVolume.Location = new System.Drawing.Point(266, 467);
            this.musicVolume.Maximum = 100;
            this.musicVolume.Name = "musicVolume";
            this.musicVolume.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.musicVolume.Size = new System.Drawing.Size(250, 45);
            this.musicVolume.TabIndex = 3;
            this.musicVolume.TickStyle = System.Windows.Forms.TickStyle.None;
            // 
            // startButton
            // 
            this.startButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.startButton.Font = new System.Drawing.Font("Cooper Black", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startButton.Location = new System.Drawing.Point(291, 119);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(200, 60);
            this.startButton.TabIndex = 5;
            this.startButton.Text = "Start";
            this.startButton.UseVisualStyleBackColor = true;
            // 
            // logo
            // 
            this.logo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.logo.AutoSize = true;
            this.logo.Font = new System.Drawing.Font("Cooper Black", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.logo.Location = new System.Drawing.Point(251, 50);
            this.logo.Name = "logo";
            this.logo.Size = new System.Drawing.Size(291, 55);
            this.logo.TabIndex = 7;
            this.logo.Text = "INVASION";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(3, 450);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(388, 441);
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox4.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox4.Image")));
            this.pictureBox4.Location = new System.Drawing.Point(3, 3);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(388, 441);
            this.pictureBox4.TabIndex = 0;
            this.pictureBox4.TabStop = false;
            // 
            // pictureTable1
            // 
            this.pictureTable1.ColumnCount = 1;
            this.pictureTable1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.pictureTable1.Controls.Add(this.pictureBox3, 0, 1);
            this.pictureTable1.Controls.Add(this.pictureBox1, 0, 0);
            this.pictureTable1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureTable1.Location = new System.Drawing.Point(3, 3);
            this.pictureTable1.Name = "pictureTable1";
            this.pictureTable1.RowCount = 2;
            this.pictureTable1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.pictureTable1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.pictureTable1.Size = new System.Drawing.Size(394, 894);
            this.pictureTable1.TabIndex = 15;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(3, 450);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(388, 441);
            this.pictureBox3.TabIndex = 1;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(388, 441);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // MenuControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.table);
            this.Name = "MenuControl";
            this.Size = new System.Drawing.Size(1600, 900);
            this.table.ResumeLayout(false);
            this.pictureTable2.ResumeLayout(false);
            this.mainTable.ResumeLayout(false);
            this.mainTable.PerformLayout();
            this.additionalTable.ResumeLayout(false);
            this.additionalTable.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.soundVolume)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.musicVolume)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.pictureTable1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private TableLayoutPanel table;
        private Label logo;
        private TableLayoutPanel mainTable;
        private TableLayoutPanel additionalTable;
        private Label soundVolumeText;
        private Label musicVolumeText;
        private TrackBar soundVolume;
        private Button exitButton;
        private TrackBar musicVolume;
        private Button startButton;
        private TableLayoutPanel pictureTable2;
        private PictureBox pictureBox2;
        private PictureBox pictureBox4;
        private TableLayoutPanel pictureTable1;
        private PictureBox pictureBox3;
        private PictureBox pictureBox1;
    }
}
