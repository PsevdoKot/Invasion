
namespace Invasion.Views
{
    partial class BattleControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BattleControl));
            this.table = new System.Windows.Forms.TableLayoutPanel();
            this.infoTable = new System.Windows.Forms.TableLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.projectilesTable = new System.Windows.Forms.TableLayoutPanel();
            this.cannonBallInfo = new System.Windows.Forms.Label();
            this.springyBallInfo = new System.Windows.Forms.Label();
            this.laserInfo = new System.Windows.Forms.Label();
            this.missleInfo = new System.Windows.Forms.Label();
            this.cannonBallImage = new System.Windows.Forms.PictureBox();
            this.springyBallImage = new System.Windows.Forms.PictureBox();
            this.laserImage = new System.Windows.Forms.PictureBox();
            this.missleImage = new System.Windows.Forms.PictureBox();
            this.levelInfo = new System.Windows.Forms.Label();
            this.timeInfo = new System.Windows.Forms.Label();
            this.scoreInfo = new System.Windows.Forms.Label();
            this.menuButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.table.SuspendLayout();
            this.infoTable.SuspendLayout();
            this.projectilesTable.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cannonBallImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.springyBallImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.laserImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.missleImage)).BeginInit();
            this.SuspendLayout();
            // 
            // table
            // 
            this.table.BackColor = System.Drawing.Color.LightSkyBlue;
            this.table.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.table.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.OutsetPartial;
            this.table.ColumnCount = 2;
            this.table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.table.Controls.Add(this.infoTable, 0, 1);
            this.table.Controls.Add(this.menuButton, 0, 0);
            this.table.Controls.Add(this.label1, 1, 0);
            this.table.Dock = System.Windows.Forms.DockStyle.Fill;
            this.table.Location = new System.Drawing.Point(0, 0);
            this.table.Name = "table";
            this.table.RowCount = 2;
            this.table.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.table.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 90F));
            this.table.Size = new System.Drawing.Size(1600, 900);
            this.table.TabIndex = 0;
            this.table.CellPaint += new System.Windows.Forms.TableLayoutCellPaintEventHandler(this.Table_OnPaint);
            this.table.MouseDown += new System.Windows.Forms.MouseEventHandler(this.OnMouseDowm);
            // 
            // infoTable
            // 
            this.infoTable.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.OutsetPartial;
            this.infoTable.ColumnCount = 1;
            this.infoTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.infoTable.Controls.Add(this.label2, 0, 4);
            this.infoTable.Controls.Add(this.projectilesTable, 0, 3);
            this.infoTable.Controls.Add(this.levelInfo, 0, 0);
            this.infoTable.Controls.Add(this.timeInfo, 0, 1);
            this.infoTable.Controls.Add(this.scoreInfo, 0, 2);
            this.infoTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.infoTable.Location = new System.Drawing.Point(6, 98);
            this.infoTable.Name = "infoTable";
            this.infoTable.RowCount = 5;
            this.infoTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.infoTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.infoTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.infoTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 58F));
            this.infoTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12F));
            this.infoTable.Size = new System.Drawing.Size(312, 796);
            this.infoTable.TabIndex = 0;
            this.infoTable.CellPaint += new System.Windows.Forms.TableLayoutCellPaintEventHandler(this.LevelInfo_OnPaint);
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Font = new System.Drawing.Font("Cooper Black", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 697);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(300, 48);
            this.label2.TabIndex = 4;
            this.label2.Text = "Shot power";
            this.label2.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // projectilesTable
            // 
            this.projectilesTable.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.OutsetPartial;
            this.projectilesTable.ColumnCount = 2;
            this.projectilesTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 75F));
            this.projectilesTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.projectilesTable.Controls.Add(this.cannonBallInfo, 1, 0);
            this.projectilesTable.Controls.Add(this.springyBallInfo, 1, 1);
            this.projectilesTable.Controls.Add(this.laserInfo, 1, 2);
            this.projectilesTable.Controls.Add(this.missleInfo, 1, 3);
            this.projectilesTable.Controls.Add(this.cannonBallImage, 0, 0);
            this.projectilesTable.Controls.Add(this.springyBallImage, 0, 1);
            this.projectilesTable.Controls.Add(this.laserImage, 0, 2);
            this.projectilesTable.Controls.Add(this.missleImage, 0, 3);
            this.projectilesTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.projectilesTable.Location = new System.Drawing.Point(6, 246);
            this.projectilesTable.Name = "projectilesTable";
            this.projectilesTable.RowCount = 4;
            this.projectilesTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.projectilesTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.projectilesTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.projectilesTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.projectilesTable.Size = new System.Drawing.Size(300, 445);
            this.projectilesTable.TabIndex = 0;
            // 
            // cannonBallInfo
            // 
            this.cannonBallInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cannonBallInfo.Font = new System.Drawing.Font("Cooper Black", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cannonBallInfo.ForeColor = System.Drawing.Color.Black;
            this.cannonBallInfo.Location = new System.Drawing.Point(227, 3);
            this.cannonBallInfo.Name = "cannonBallInfo";
            this.cannonBallInfo.Size = new System.Drawing.Size(67, 107);
            this.cannonBallInfo.TabIndex = 0;
            this.cannonBallInfo.Text = "0";
            this.cannonBallInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // springyBallInfo
            // 
            this.springyBallInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.springyBallInfo.Font = new System.Drawing.Font("Cooper Black", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.springyBallInfo.Location = new System.Drawing.Point(227, 113);
            this.springyBallInfo.Name = "springyBallInfo";
            this.springyBallInfo.Size = new System.Drawing.Size(67, 107);
            this.springyBallInfo.TabIndex = 1;
            this.springyBallInfo.Text = "0";
            this.springyBallInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // laserInfo
            // 
            this.laserInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.laserInfo.Font = new System.Drawing.Font("Cooper Black", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.laserInfo.Location = new System.Drawing.Point(227, 223);
            this.laserInfo.Name = "laserInfo";
            this.laserInfo.Size = new System.Drawing.Size(67, 107);
            this.laserInfo.TabIndex = 2;
            this.laserInfo.Text = "0";
            this.laserInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // missleInfo
            // 
            this.missleInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.missleInfo.Font = new System.Drawing.Font("Cooper Black", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.missleInfo.Location = new System.Drawing.Point(227, 333);
            this.missleInfo.Name = "missleInfo";
            this.missleInfo.Size = new System.Drawing.Size(67, 109);
            this.missleInfo.TabIndex = 3;
            this.missleInfo.Text = "0";
            this.missleInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cannonBallImage
            // 
            this.cannonBallImage.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cannonBallImage.Image = global::Invasion.Properties.Resources.cannonBall;
            this.cannonBallImage.Location = new System.Drawing.Point(77, 21);
            this.cannonBallImage.Name = "cannonBallImage";
            this.cannonBallImage.Size = new System.Drawing.Size(70, 70);
            this.cannonBallImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.cannonBallImage.TabIndex = 4;
            this.cannonBallImage.TabStop = false;
            // 
            // springyBallImage
            // 
            this.springyBallImage.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.springyBallImage.Image = ((System.Drawing.Image)(resources.GetObject("springyBallImage.Image")));
            this.springyBallImage.Location = new System.Drawing.Point(77, 131);
            this.springyBallImage.Name = "springyBallImage";
            this.springyBallImage.Size = new System.Drawing.Size(70, 70);
            this.springyBallImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.springyBallImage.TabIndex = 5;
            this.springyBallImage.TabStop = false;
            // 
            // laserImage
            // 
            this.laserImage.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.laserImage.Image = ((System.Drawing.Image)(resources.GetObject("laserImage.Image")));
            this.laserImage.Location = new System.Drawing.Point(52, 271);
            this.laserImage.Name = "laserImage";
            this.laserImage.Size = new System.Drawing.Size(120, 10);
            this.laserImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.laserImage.TabIndex = 6;
            this.laserImage.TabStop = false;
            // 
            // missleImage
            // 
            this.missleImage.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.missleImage.Image = ((System.Drawing.Image)(resources.GetObject("missleImage.Image")));
            this.missleImage.Location = new System.Drawing.Point(37, 371);
            this.missleImage.Name = "missleImage";
            this.missleImage.Size = new System.Drawing.Size(150, 32);
            this.missleImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.missleImage.TabIndex = 7;
            this.missleImage.TabStop = false;
            // 
            // levelInfo
            // 
            this.levelInfo.AutoSize = true;
            this.levelInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.levelInfo.Font = new System.Drawing.Font("Cooper Black", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.levelInfo.Location = new System.Drawing.Point(6, 3);
            this.levelInfo.Name = "levelInfo";
            this.levelInfo.Size = new System.Drawing.Size(300, 77);
            this.levelInfo.TabIndex = 1;
            this.levelInfo.Text = "Level ";
            this.levelInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // timeInfo
            // 
            this.timeInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.timeInfo.Font = new System.Drawing.Font("Cooper Black", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timeInfo.Location = new System.Drawing.Point(6, 83);
            this.timeInfo.Name = "timeInfo";
            this.timeInfo.Size = new System.Drawing.Size(300, 77);
            this.timeInfo.TabIndex = 2;
            this.timeInfo.Text = "00:00";
            this.timeInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // scoreInfo
            // 
            this.scoreInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scoreInfo.Font = new System.Drawing.Font("Cooper Black", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.scoreInfo.Location = new System.Drawing.Point(6, 163);
            this.scoreInfo.Name = "scoreInfo";
            this.scoreInfo.Size = new System.Drawing.Size(300, 77);
            this.scoreInfo.TabIndex = 3;
            this.scoreInfo.Text = "Score: ";
            this.scoreInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // menuButton
            // 
            this.menuButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.menuButton.Font = new System.Drawing.Font("Cooper Black", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuButton.Location = new System.Drawing.Point(62, 17);
            this.menuButton.Name = "menuButton";
            this.menuButton.Size = new System.Drawing.Size(200, 60);
            this.menuButton.TabIndex = 1;
            this.menuButton.Text = "Menu";
            this.menuButton.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Cooper Black", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(327, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1267, 89);
            this.label1.TabIndex = 2;
            this.label1.Text = resources.GetString("label1.Text");
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BattleControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.table);
            this.Name = "BattleControl";
            this.Size = new System.Drawing.Size(1600, 900);
            this.table.ResumeLayout(false);
            this.infoTable.ResumeLayout(false);
            this.infoTable.PerformLayout();
            this.projectilesTable.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cannonBallImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.springyBallImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.laserImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.missleImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel table;
        private System.Windows.Forms.TableLayoutPanel infoTable;
        private System.Windows.Forms.TableLayoutPanel projectilesTable;
        private System.Windows.Forms.Label cannonBallInfo;
        private System.Windows.Forms.Label springyBallInfo;
        private System.Windows.Forms.Label laserInfo;
        private System.Windows.Forms.Label missleInfo;
        private System.Windows.Forms.PictureBox cannonBallImage;
        private System.Windows.Forms.PictureBox springyBallImage;
        private System.Windows.Forms.PictureBox laserImage;
        private System.Windows.Forms.PictureBox missleImage;
        private System.Windows.Forms.Label levelInfo;
        private System.Windows.Forms.Label timeInfo;
        private System.Windows.Forms.Label scoreInfo;
        private System.Windows.Forms.Button menuButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}
