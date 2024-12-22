
namespace Minesweeper2
{
    partial class Game
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.gameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gameSizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.firstLevelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.secondLevelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thirdLevelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.infoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rulesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblPlayerName = new System.Windows.Forms.Label();
            this.lblTime = new System.Windows.Forms.Label();
            this.lblNumberOfBombs = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.btnSaveResult = new System.Windows.Forms.Button();
            this.saveResult = new System.Windows.Forms.SaveFileDialog();
            this.lblResult = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gameToolStripMenuItem,
            this.infoToolStripMenuItem,
            this.rulesToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(679, 30);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // gameToolStripMenuItem
            // 
            this.gameToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gameSizeToolStripMenuItem});
            this.gameToolStripMenuItem.Image = global::Minesweeper2.Properties.Resources.iconfinder_icon_game_controller_b_211668;
            this.gameToolStripMenuItem.Name = "gameToolStripMenuItem";
            this.gameToolStripMenuItem.Size = new System.Drawing.Size(115, 26);
            this.gameToolStripMenuItem.Text = "Нова игра";
            // 
            // gameSizeToolStripMenuItem
            // 
            this.gameSizeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.firstLevelToolStripMenuItem,
            this.secondLevelToolStripMenuItem,
            this.thirdLevelToolStripMenuItem});
            this.gameSizeToolStripMenuItem.Name = "gameSizeToolStripMenuItem";
            this.gameSizeToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.gameSizeToolStripMenuItem.Text = "Размер на полето";
            // 
            // firstLevelToolStripMenuItem
            // 
            this.firstLevelToolStripMenuItem.Name = "firstLevelToolStripMenuItem";
            this.firstLevelToolStripMenuItem.Size = new System.Drawing.Size(139, 26);
            this.firstLevelToolStripMenuItem.Text = "5 x 5";
            this.firstLevelToolStripMenuItem.Click += new System.EventHandler(this.firstLevelToolStripMenuItem_Click);
            // 
            // secondLevelToolStripMenuItem
            // 
            this.secondLevelToolStripMenuItem.Name = "secondLevelToolStripMenuItem";
            this.secondLevelToolStripMenuItem.Size = new System.Drawing.Size(139, 26);
            this.secondLevelToolStripMenuItem.Text = "10 x 10";
            this.secondLevelToolStripMenuItem.Click += new System.EventHandler(this.secondLevelToolStripMenuItem_Click);
            // 
            // thirdLevelToolStripMenuItem
            // 
            this.thirdLevelToolStripMenuItem.Name = "thirdLevelToolStripMenuItem";
            this.thirdLevelToolStripMenuItem.Size = new System.Drawing.Size(139, 26);
            this.thirdLevelToolStripMenuItem.Text = "15 x 15";
            this.thirdLevelToolStripMenuItem.Click += new System.EventHandler(this.thirdLevelToolStripMenuItem_Click);
            // 
            // infoToolStripMenuItem
            // 
            this.infoToolStripMenuItem.Image = global::Minesweeper2.Properties.Resources.iconfinder_ic_info_48px_3669162;
            this.infoToolStripMenuItem.Name = "infoToolStripMenuItem";
            this.infoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.I)));
            this.infoToolStripMenuItem.Size = new System.Drawing.Size(136, 26);
            this.infoToolStripMenuItem.Text = "Информация";
            this.infoToolStripMenuItem.Click += new System.EventHandler(this.infoToolStripMenuItem_Click);
            // 
            // rulesToolStripMenuItem
            // 
            this.rulesToolStripMenuItem.Image = global::Minesweeper2.Properties.Resources.iconfinder_rules_3018564;
            this.rulesToolStripMenuItem.Name = "rulesToolStripMenuItem";
            this.rulesToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R)));
            this.rulesToolStripMenuItem.Size = new System.Drawing.Size(104, 26);
            this.rulesToolStripMenuItem.Text = "Правила";
            this.rulesToolStripMenuItem.Click += new System.EventHandler(this.rulesToolStripMenuItem_Click);
            // 
            // lblPlayerName
            // 
            this.lblPlayerName.AutoSize = true;
            this.lblPlayerName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblPlayerName.Location = new System.Drawing.Point(374, 49);
            this.lblPlayerName.Name = "lblPlayerName";
            this.lblPlayerName.Size = new System.Drawing.Size(72, 25);
            this.lblPlayerName.TabIndex = 2;
            this.lblPlayerName.Text = "Играч:";
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblTime.Location = new System.Drawing.Point(168, 82);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(80, 25);
            this.lblTime.TabIndex = 3;
            this.lblTime.Text = "Време:";
            // 
            // lblNumberOfBombs
            // 
            this.lblNumberOfBombs.AutoSize = true;
            this.lblNumberOfBombs.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblNumberOfBombs.Location = new System.Drawing.Point(12, 52);
            this.lblNumberOfBombs.Name = "lblNumberOfBombs";
            this.lblNumberOfBombs.Size = new System.Drawing.Size(181, 25);
            this.lblNumberOfBombs.TabIndex = 4;
            this.lblNumberOfBombs.Text = "Общ брой бомби: ";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(12, 89);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(139, 18);
            this.label1.TabIndex = 6;
            this.label1.Text = "продължителност:";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblName.Location = new System.Drawing.Point(13, 192);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(75, 22);
            this.lblName.TabIndex = 7;
            this.lblName.Text = "lblName";
            // 
            // btnSaveResult
            // 
            this.btnSaveResult.Enabled = false;
            this.btnSaveResult.Location = new System.Drawing.Point(221, 49);
            this.btnSaveResult.Name = "btnSaveResult";
            this.btnSaveResult.Size = new System.Drawing.Size(138, 25);
            this.btnSaveResult.TabIndex = 8;
            this.btnSaveResult.Text = "Запази резултат";
            this.btnSaveResult.UseVisualStyleBackColor = true;
            this.btnSaveResult.Click += new System.EventHandler(this.btnSaveResult_Click);
            // 
            // lblResult
            // 
            this.lblResult.AutoSize = true;
            this.lblResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblResult.Location = new System.Drawing.Point(344, 89);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(89, 22);
            this.lblResult.TabIndex = 9;
            this.lblResult.Text = "резултат:";
            // 
            // Game
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(679, 269);
            this.Controls.Add(this.lblResult);
            this.Controls.Add(this.btnSaveResult);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblNumberOfBombs);
            this.Controls.Add(this.lblTime);
            this.Controls.Add(this.lblPlayerName);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "Game";
            this.Text = "Minesweeper";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Game_FormClosing);
            this.Load += new System.EventHandler(this.Game_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem gameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gameSizeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem firstLevelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem secondLevelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thirdLevelToolStripMenuItem;
        private System.Windows.Forms.Label lblPlayerName;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Label lblNumberOfBombs;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripMenuItem infoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rulesToolStripMenuItem;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Button btnSaveResult;
        private System.Windows.Forms.SaveFileDialog saveResult;
        private System.Windows.Forms.Label lblResult;
    }
}

