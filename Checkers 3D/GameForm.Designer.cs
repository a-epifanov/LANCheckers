namespace BoardGame
{
    partial class GameForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GameForm));
            this.gameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.gameToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem0 = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem7 = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem6 = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem9 = new System.Windows.Forms.ToolStripMenuItem();
            this.поискToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.ToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.contentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.gamePanel = new BoardGame.Direct3D.GamePanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.statusStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // gameToolStripMenuItem
            // 
            this.gameToolStripMenuItem.Name = "gameToolStripMenuItem";
            this.gameToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.gameToolStripMenuItem.Text = "&Игра";
            // 
            // newToolStripMenuItem1
            // 
            this.newToolStripMenuItem1.Name = "newToolStripMenuItem1";
            this.newToolStripMenuItem1.Size = new System.Drawing.Size(213, 22);
            this.newToolStripMenuItem1.Text = "&Создать Новую";
            // 
            // newToolStripMenuItem2
            // 
            this.newToolStripMenuItem2.Name = "newToolStripMenuItem2";
            this.newToolStripMenuItem2.Size = new System.Drawing.Size(213, 22);
            this.newToolStripMenuItem2.Text = "&Присоединиться к Игре";
            this.newToolStripMenuItem2.Click += new System.EventHandler(this.ToolStripMenuItem1_Click);
            // 
            // newToolStripMenuItem4
            // 
            this.newToolStripMenuItem4.Enabled = false;
            this.newToolStripMenuItem4.Name = "newToolStripMenuItem4";
            this.newToolStripMenuItem4.Size = new System.Drawing.Size(213, 22);
            this.newToolStripMenuItem4.Text = "&Разъединить";
            // 
            // ToolStripMenuItem5
            // 
            this.ToolStripMenuItem5.Name = "ToolStripMenuItem5";
            this.ToolStripMenuItem5.Size = new System.Drawing.Size(213, 22);
            this.ToolStripMenuItem5.Text = "&Опции";
            this.ToolStripMenuItem5.Click += new System.EventHandler(this.ToolStripMenuItem3_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
            this.exitToolStripMenuItem.Text = "&Выйти";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.ToolStripMenuItem4_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 364);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(570, 22);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(148, 17);
            this.toolStripStatusLabel1.Text = "Установите подключение";
            // 
            // gameToolStripMenuItem1
            // 
            this.gameToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItem0,
            this.ToolStripMenuItem3,
            this.ToolStripMenuItem4});
            this.gameToolStripMenuItem1.Name = "gameToolStripMenuItem1";
            this.gameToolStripMenuItem1.Size = new System.Drawing.Size(46, 20);
            this.gameToolStripMenuItem1.Text = "&Игра";
            // 
            // ToolStripMenuItem0
            // 
            this.ToolStripMenuItem0.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItem7,
            this.ToolStripMenuItem6,
            this.ToolStripMenuItem9,
            this.поискToolStripMenuItem});
            this.ToolStripMenuItem0.Name = "ToolStripMenuItem0";
            this.ToolStripMenuItem0.Size = new System.Drawing.Size(160, 22);
            this.ToolStripMenuItem0.Text = "&Подключение";
            // 
            // ToolStripMenuItem7
            // 
            this.ToolStripMenuItem7.Name = "ToolStripMenuItem7";
            this.ToolStripMenuItem7.Size = new System.Drawing.Size(151, 22);
            this.ToolStripMenuItem7.Text = "&Создать";
            this.ToolStripMenuItem7.Click += new System.EventHandler(this.ToolStripMenuItem7_Click);
            // 
            // ToolStripMenuItem6
            // 
            this.ToolStripMenuItem6.Enabled = false;
            this.ToolStripMenuItem6.Name = "ToolStripMenuItem6";
            this.ToolStripMenuItem6.Size = new System.Drawing.Size(151, 22);
            this.ToolStripMenuItem6.Text = "&Удалить";
            this.ToolStripMenuItem6.Click += new System.EventHandler(this.ToolStripMenuItem6_Click);
            // 
            // ToolStripMenuItem9
            // 
            this.ToolStripMenuItem9.Enabled = false;
            this.ToolStripMenuItem9.Name = "ToolStripMenuItem9";
            this.ToolStripMenuItem9.Size = new System.Drawing.Size(151, 22);
            this.ToolStripMenuItem9.Text = "&Разъединить";
            this.ToolStripMenuItem9.Click += new System.EventHandler(this.ToolStripMenuItem9_Click);
            // 
            // поискToolStripMenuItem
            // 
            this.поискToolStripMenuItem.Name = "поискToolStripMenuItem";
            this.поискToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.поискToolStripMenuItem.Text = " &Поиск";
            this.поискToolStripMenuItem.Click += new System.EventHandler(this.ToolStripMenuItem1_Click);
            // 
            // ToolStripMenuItem3
            // 
            this.ToolStripMenuItem3.Name = "ToolStripMenuItem3";
            this.ToolStripMenuItem3.Size = new System.Drawing.Size(160, 22);
            this.ToolStripMenuItem3.Text = "&Опции";
            this.ToolStripMenuItem3.Click += new System.EventHandler(this.ToolStripMenuItem3_Click);
            // 
            // ToolStripMenuItem4
            // 
            this.ToolStripMenuItem4.Name = "ToolStripMenuItem4";
            this.ToolStripMenuItem4.Size = new System.Drawing.Size(160, 22);
            this.ToolStripMenuItem4.Text = "&Выйти";
            this.ToolStripMenuItem4.Click += new System.EventHandler(this.ToolStripMenuItem4_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gameToolStripMenuItem1,
            this.ToolStripMenuItem2});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(570, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // ToolStripMenuItem2
            // 
            this.ToolStripMenuItem2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.contentsToolStripMenuItem,
            this.ToolStripMenuItem});
            this.ToolStripMenuItem2.Name = "ToolStripMenuItem2";
            this.ToolStripMenuItem2.Size = new System.Drawing.Size(68, 20);
            this.ToolStripMenuItem2.Text = "&Помощь";
            // 
            // contentsToolStripMenuItem
            // 
            this.contentsToolStripMenuItem.Name = "contentsToolStripMenuItem";
            this.contentsToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.contentsToolStripMenuItem.Text = "&Справка";
            this.contentsToolStripMenuItem.Click += new System.EventHandler(this.contentsToolStripMenuItem_Click);
            // 
            // ToolStripMenuItem
            // 
            this.ToolStripMenuItem.Name = "ToolStripMenuItem";
            this.ToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.ToolStripMenuItem.Text = "&О программе";
            this.ToolStripMenuItem.Click += new System.EventHandler(this.helpToolStripMenuItem_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.SystemColors.Control;
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Outset;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 79.11715F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.88285F));
            this.tableLayoutPanel1.Controls.Add(this.gamePanel, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 24);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(570, 362);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // gamePanel
            // 
            this.gamePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gamePanel.Location = new System.Drawing.Point(5, 5);
            this.gamePanel.Name = "gamePanel";
            this.gamePanel.Size = new System.Drawing.Size(440, 352);
            this.gamePanel.TabIndex = 0;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.tableLayoutPanel3.AutoSize = true;
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel2, 0, 2);
            this.tableLayoutPanel3.Controls.Add(this.pictureBox3, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.label3, 0, 0);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(453, 5);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 3;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.11834F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 79.88166F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 152F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(112, 344);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 61.76471F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 38.23529F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.pictureBox2, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.pictureBox1, 1, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 224);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(106, 86);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Игрок";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Соперник";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(68, 46);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(35, 37);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 3;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(68, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(35, 37);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox3.InitialImage = null;
            this.pictureBox3.Location = new System.Drawing.Point(3, 41);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(106, 147);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 2;
            this.pictureBox3.TabStop = false;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Текущий игрок";
            // 
            // GameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(570, 386);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(578, 418);
            this.Name = "GameForm";
            this.Text = "3D Checkers";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStripMenuItem gameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;

        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem2;

        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem5;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripMenuItem gameToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem0;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem7;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem6;
        private System.Windows.Forms.ToolStripMenuItem поискToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem4;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private BoardGame.Direct3D.GamePanel gamePanel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem9;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem contentsToolStripMenuItem;
    }
}

