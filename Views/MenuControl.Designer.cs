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
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.additionalTable = new System.Windows.Forms.TableLayoutPanel();
            this.mainTable = new System.Windows.Forms.TableLayoutPanel();
            this.soundVolumeText = new System.Windows.Forms.Label();
            this.musicVolumeText = new System.Windows.Forms.Label();
            this.soundVolume = new System.Windows.Forms.TrackBar();
            this.exitButton = new System.Windows.Forms.Button();
            this.musicVolume = new System.Windows.Forms.TrackBar();
            this.startButton = new System.Windows.Forms.Button();
            this.logo = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.table.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.additionalTable.SuspendLayout();
            this.mainTable.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.soundVolume)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.musicVolume)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
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
            this.table.Controls.Add(this.tableLayoutPanel2, 2, 0);
            this.table.Controls.Add(this.additionalTable, 1, 0);
            this.table.Controls.Add(this.tableLayoutPanel1, 0, 0);
            this.table.Dock = System.Windows.Forms.DockStyle.Fill;
            this.table.Location = new System.Drawing.Point(0, 0);
            this.table.Name = "table";
            this.table.RowCount = 1;
            this.table.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.table.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.table.Size = new System.Drawing.Size(1600, 900);
            this.table.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.pictureBox2, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.pictureBox4, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(1203, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(394, 894);
            this.tableLayoutPanel2.TabIndex = 12;
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
            // additionalTable
            // 
            this.additionalTable.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.OutsetPartial;
            this.additionalTable.ColumnCount = 1;
            this.additionalTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.additionalTable.Controls.Add(this.mainTable, 0, 1);
            this.additionalTable.Controls.Add(this.logo, 0, 0);
            this.additionalTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.additionalTable.Location = new System.Drawing.Point(403, 3);
            this.additionalTable.Name = "additionalTable";
            this.additionalTable.RowCount = 2;
            this.additionalTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.additionalTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 83.33334F));
            this.additionalTable.Size = new System.Drawing.Size(794, 894);
            this.additionalTable.TabIndex = 8;
            // 
            // mainTable
            // 
            this.mainTable.ColumnCount = 1;
            this.mainTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.mainTable.Controls.Add(this.soundVolumeText, 0, 3);
            this.mainTable.Controls.Add(this.musicVolumeText, 0, 1);
            this.mainTable.Controls.Add(this.soundVolume, 0, 2);
            this.mainTable.Controls.Add(this.exitButton, 0, 5);
            this.mainTable.Controls.Add(this.musicVolume, 0, 4);
            this.mainTable.Controls.Add(this.startButton, 0, 0);
            this.mainTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainTable.Location = new System.Drawing.Point(6, 156);
            this.mainTable.Name = "mainTable";
            this.mainTable.RowCount = 6;
            this.mainTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.mainTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.mainTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.mainTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.mainTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.mainTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.mainTable.Size = new System.Drawing.Size(782, 732);
            this.mainTable.TabIndex = 9;
            // 
            // soundVolumeText
            // 
            this.soundVolumeText.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.soundVolumeText.AutoSize = true;
            this.soundVolumeText.Font = new System.Drawing.Font("Cooper Black", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.soundVolumeText.Location = new System.Drawing.Point(285, 404);
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
            this.musicVolumeText.Location = new System.Drawing.Point(283, 258);
            this.musicVolumeText.Name = "musicVolumeText";
            this.musicVolumeText.Size = new System.Drawing.Size(215, 34);
            this.musicVolumeText.TabIndex = 0;
            this.musicVolumeText.Text = "Music volume";
            // 
            // soundVolume
            // 
            this.soundVolume.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.soundVolume.Location = new System.Drawing.Point(266, 306);
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
            this.exitButton.Location = new System.Drawing.Point(291, 550);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(200, 60);
            this.exitButton.TabIndex = 6;
            this.exitButton.Text = "Exit";
            this.exitButton.UseVisualStyleBackColor = true;
            // 
            // musicVolume
            // 
            this.musicVolume.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.musicVolume.Location = new System.Drawing.Point(266, 470);
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
            this.startButton.Location = new System.Drawing.Point(291, 120);
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
            this.logo.Location = new System.Drawing.Point(251, 49);
            this.logo.Name = "logo";
            this.logo.Size = new System.Drawing.Size(291, 55);
            this.logo.TabIndex = 7;
            this.logo.Text = "INVASION";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.pictureBox3, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.pictureBox1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(394, 894);
            this.tableLayoutPanel1.TabIndex = 11;
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
            this.tableLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.additionalTable.ResumeLayout(false);
            this.additionalTable.PerformLayout();
            this.mainTable.ResumeLayout(false);
            this.mainTable.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.soundVolume)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.musicVolume)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private TableLayoutPanel table;
        private Label logo;
        private TableLayoutPanel additionalTable;
        private TableLayoutPanel mainTable;
        private Label soundVolumeText;
        private Label musicVolumeText;
        private TrackBar soundVolume;
        private Button exitButton;
        private TrackBar musicVolume;
        private Button startButton;
        private TableLayoutPanel tableLayoutPanel2;
        private PictureBox pictureBox2;
        private PictureBox pictureBox4;
        private TableLayoutPanel tableLayoutPanel1;
        private PictureBox pictureBox3;
        private PictureBox pictureBox1;
    }
}
