namespace enumerator
{
    partial class Form1
    {
        /// <summary>
        /// Требуется переменная конструктора.
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
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.выбратьВстречуToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.выбратьИгроковToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.завершитьВстречуToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label_xx = new System.Windows.Forms.Label();
            this.label_yy = new System.Windows.Forms.Label();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.label_player2 = new System.Windows.Forms.Label();
            this.label_y = new System.Windows.Forms.Label();
            this.inning2 = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.label_player1 = new System.Windows.Forms.Label();
            this.label_x = new System.Windows.Forms.Label();
            this.inning1 = new System.Windows.Forms.PictureBox();
            this.label_timer = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.info = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.joystick_status = new System.Windows.Forms.ToolStripStatusLabel();
            this.timer4 = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.открытьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.базаДанныхToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.настройкиToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.консольToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.помощьToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutPanel1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.inning2)).BeginInit();
            this.tableLayoutPanel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.inning1)).BeginInit();
            this.panel1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ContextMenuStrip = this.contextMenuStrip1;
            this.tableLayoutPanel1.Controls.Add(this.label_xx, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label_yy, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel4, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel5, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label_timer, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(784, 562);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Enabled = false;
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.выбратьВстречуToolStripMenuItem,
            this.выбратьИгроковToolStripMenuItem,
            this.завершитьВстречуToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(182, 92);
            // 
            // выбратьВстречуToolStripMenuItem
            // 
            this.выбратьВстречуToolStripMenuItem.Enabled = false;
            this.выбратьВстречуToolStripMenuItem.Name = "выбратьВстречуToolStripMenuItem";
            this.выбратьВстречуToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.выбратьВстречуToolStripMenuItem.Text = "Выбрать встречу";
            this.выбратьВстречуToolStripMenuItem.Click += new System.EventHandler(this.выбратьВстречуToolStripMenuItem_Click);
            // 
            // выбратьИгроковToolStripMenuItem
            // 
            this.выбратьИгроковToolStripMenuItem.Enabled = false;
            this.выбратьИгроковToolStripMenuItem.Name = "выбратьИгроковToolStripMenuItem";
            this.выбратьИгроковToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.выбратьИгроковToolStripMenuItem.Text = "Выбрать игроков";
            this.выбратьИгроковToolStripMenuItem.Click += new System.EventHandler(this.выбратьИгроковToolStripMenuItem_Click);
            // 
            // завершитьВстречуToolStripMenuItem
            // 
            this.завершитьВстречуToolStripMenuItem.Enabled = false;
            this.завершитьВстречуToolStripMenuItem.Name = "завершитьВстречуToolStripMenuItem";
            this.завершитьВстречуToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.завершитьВстречуToolStripMenuItem.Text = "Завершить встречу";
            this.завершитьВстречуToolStripMenuItem.Click += new System.EventHandler(this.завершитьВстречуToolStripMenuItem_Click);
            // 
            // label_xx
            // 
            this.label_xx.BackColor = System.Drawing.Color.MediumBlue;
            this.label_xx.Cursor = System.Windows.Forms.Cursors.Default;
            this.label_xx.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_xx.Font = new System.Drawing.Font("Arial Black", 182F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
            this.label_xx.ForeColor = System.Drawing.Color.White;
            this.label_xx.Location = new System.Drawing.Point(0, 196);
            this.label_xx.Margin = new System.Windows.Forms.Padding(0);
            this.label_xx.Name = "label_xx";
            this.label_xx.Size = new System.Drawing.Size(392, 281);
            this.label_xx.TabIndex = 0;
            this.label_xx.Text = "0";
            this.label_xx.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_yy
            // 
            this.label_yy.BackColor = System.Drawing.Color.DarkRed;
            this.label_yy.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_yy.Font = new System.Drawing.Font("Arial Black", 182F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
            this.label_yy.ForeColor = System.Drawing.Color.White;
            this.label_yy.Location = new System.Drawing.Point(392, 196);
            this.label_yy.Margin = new System.Windows.Forms.Padding(0);
            this.label_yy.Name = "label_yy";
            this.label_yy.Size = new System.Drawing.Size(392, 281);
            this.label_yy.TabIndex = 1;
            this.label_yy.Text = "0";
            this.label_yy.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.BackColor = System.Drawing.Color.DarkRed;
            this.tableLayoutPanel4.ColumnCount = 3;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 69F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 21F));
            this.tableLayoutPanel4.Controls.Add(this.label_player2, 1, 0);
            this.tableLayoutPanel4.Controls.Add(this.label_y, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.inning2, 2, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(392, 84);
            this.tableLayoutPanel4.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 112F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(392, 112);
            this.tableLayoutPanel4.TabIndex = 6;
            // 
            // label_player2
            // 
            this.label_player2.AutoSize = true;
            this.label_player2.BackColor = System.Drawing.Color.Transparent;
            this.label_player2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_player2.Font = new System.Drawing.Font("Arial Black", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
            this.label_player2.ForeColor = System.Drawing.Color.White;
            this.label_player2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label_player2.Location = new System.Drawing.Point(39, 0);
            this.label_player2.Margin = new System.Windows.Forms.Padding(0);
            this.label_player2.Name = "label_player2";
            this.label_player2.Size = new System.Drawing.Size(270, 112);
            this.label_player2.TabIndex = 4;
            this.label_player2.Text = "Игрок\r\n2";
            this.label_player2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label_player2.TextChanged += new System.EventHandler(this.label_player2_TextChanged);
            this.label_player2.Click += new System.EventHandler(this.label_player2_Click);
            // 
            // label_y
            // 
            this.label_y.AutoSize = true;
            this.label_y.BackColor = System.Drawing.Color.Transparent;
            this.label_y.Cursor = System.Windows.Forms.Cursors.Default;
            this.label_y.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_y.Font = new System.Drawing.Font("Arial Black", 46F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
            this.label_y.ForeColor = System.Drawing.Color.White;
            this.label_y.Location = new System.Drawing.Point(0, 0);
            this.label_y.Margin = new System.Windows.Forms.Padding(0);
            this.label_y.Name = "label_y";
            this.label_y.Size = new System.Drawing.Size(39, 112);
            this.label_y.TabIndex = 2;
            this.label_y.Text = "0";
            this.label_y.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // inning2
            // 
            this.inning2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.inning2.Image = global::enumerator.Properties.Resources.ball2;
            this.inning2.InitialImage = null;
            this.inning2.Location = new System.Drawing.Point(312, 16);
            this.inning2.Margin = new System.Windows.Forms.Padding(0);
            this.inning2.Name = "inning2";
            this.inning2.Size = new System.Drawing.Size(80, 80);
            this.inning2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.inning2.TabIndex = 5;
            this.inning2.TabStop = false;
            this.inning2.Visible = false;
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.BackColor = System.Drawing.Color.MediumBlue;
            this.tableLayoutPanel5.ColumnCount = 3;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 21F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 69F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel5.Controls.Add(this.label_player1, 1, 0);
            this.tableLayoutPanel5.Controls.Add(this.label_x, 2, 0);
            this.tableLayoutPanel5.Controls.Add(this.inning1, 0, 0);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(0, 84);
            this.tableLayoutPanel5.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 1;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 112F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(392, 112);
            this.tableLayoutPanel5.TabIndex = 7;
            // 
            // label_player1
            // 
            this.label_player1.AutoSize = true;
            this.label_player1.BackColor = System.Drawing.Color.Transparent;
            this.label_player1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_player1.Font = new System.Drawing.Font("Arial Black", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
            this.label_player1.ForeColor = System.Drawing.Color.White;
            this.label_player1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label_player1.Location = new System.Drawing.Point(82, 0);
            this.label_player1.Margin = new System.Windows.Forms.Padding(0);
            this.label_player1.Name = "label_player1";
            this.label_player1.Size = new System.Drawing.Size(270, 112);
            this.label_player1.TabIndex = 3;
            this.label_player1.Text = "Игрок\r\n1";
            this.label_player1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label_player1.TextChanged += new System.EventHandler(this.label_player1_TextChanged);
            this.label_player1.Click += new System.EventHandler(this.label_player1_Click);
            // 
            // label_x
            // 
            this.label_x.AutoSize = true;
            this.label_x.BackColor = System.Drawing.Color.Transparent;
            this.label_x.Cursor = System.Windows.Forms.Cursors.Default;
            this.label_x.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_x.Font = new System.Drawing.Font("Arial Black", 46F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
            this.label_x.ForeColor = System.Drawing.Color.White;
            this.label_x.Location = new System.Drawing.Point(352, 0);
            this.label_x.Margin = new System.Windows.Forms.Padding(0);
            this.label_x.Name = "label_x";
            this.label_x.Size = new System.Drawing.Size(40, 112);
            this.label_x.TabIndex = 1;
            this.label_x.Text = "0";
            this.label_x.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // inning1
            // 
            this.inning1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.inning1.Image = global::enumerator.Properties.Resources.ball2;
            this.inning1.InitialImage = null;
            this.inning1.Location = new System.Drawing.Point(0, 16);
            this.inning1.Margin = new System.Windows.Forms.Padding(0);
            this.inning1.Name = "inning1";
            this.inning1.Size = new System.Drawing.Size(80, 80);
            this.inning1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.inning1.TabIndex = 4;
            this.inning1.TabStop = false;
            this.inning1.Visible = false;
            // 
            // label_timer
            // 
            this.label_timer.AutoSize = true;
            this.label_timer.BackColor = System.Drawing.Color.Black;
            this.tableLayoutPanel1.SetColumnSpan(this.label_timer, 2);
            this.label_timer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_timer.Font = new System.Drawing.Font("Arial Black", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
            this.label_timer.ForeColor = System.Drawing.Color.White;
            this.label_timer.Location = new System.Drawing.Point(0, 0);
            this.label_timer.Margin = new System.Windows.Forms.Padding(0);
            this.label_timer.Name = "label_timer";
            this.label_timer.Size = new System.Drawing.Size(784, 84);
            this.label_timer.TabIndex = 9;
            this.label_timer.Text = "00:00";
            this.label_timer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.tableLayoutPanel1.SetColumnSpan(this.panel1, 2);
            this.panel1.Controls.Add(this.info);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 477);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(784, 85);
            this.panel1.TabIndex = 10;
            // 
            // info
            // 
            this.info.BackColor = System.Drawing.Color.Black;
            this.info.Dock = System.Windows.Forms.DockStyle.Fill;
            this.info.Font = new System.Drawing.Font("Arial Black", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
            this.info.ForeColor = System.Drawing.Color.White;
            this.info.Location = new System.Drawing.Point(0, 0);
            this.info.Margin = new System.Windows.Forms.Padding(0);
            this.info.Name = "info";
            this.info.Size = new System.Drawing.Size(784, 85);
            this.info.TabIndex = 9;
            this.info.Text = "Ожидание встречи";
            this.info.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // timer1
            // 
            this.timer1.Interval = 15;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timer2
            // 
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.joystick_status});
            this.statusStrip1.Location = new System.Drawing.Point(0, 540);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(784, 22);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 4;
            this.statusStrip1.Text = "statusStrip1";
            this.statusStrip1.Visible = false;
            // 
            // joystick_status
            // 
            this.joystick_status.Image = global::enumerator.Properties.Resources.offline;
            this.joystick_status.Name = "joystick_status";
            this.joystick_status.Size = new System.Drawing.Size(104, 17);
            this.joystick_status.Text = "Joystick: offline";
            // 
            // timer4
            // 
            this.timer4.Interval = 1000;
            this.timer4.Tick += new System.EventHandler(this.timer4_Tick);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.открытьToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(784, 24);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.Visible = false;
            // 
            // открытьToolStripMenuItem
            // 
            this.открытьToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.базаДанныхToolStripMenuItem,
            this.настройкиToolStripMenuItem1,
            this.консольToolStripMenuItem,
            this.toolStripSeparator1,
            this.помощьToolStripMenuItem1});
            this.открытьToolStripMenuItem.Name = "открытьToolStripMenuItem";
            this.открытьToolStripMenuItem.Size = new System.Drawing.Size(66, 20);
            this.открытьToolStripMenuItem.Text = "Открыть";
            // 
            // базаДанныхToolStripMenuItem
            // 
            this.базаДанныхToolStripMenuItem.Name = "базаДанныхToolStripMenuItem";
            this.базаДанныхToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.базаДанныхToolStripMenuItem.Text = "База данных";
            this.базаДанныхToolStripMenuItem.Click += new System.EventHandler(this.базаДанныхToolStripMenuItem_Click);
            // 
            // настройкиToolStripMenuItem1
            // 
            this.настройкиToolStripMenuItem1.Name = "настройкиToolStripMenuItem1";
            this.настройкиToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.настройкиToolStripMenuItem1.Text = "Настройки";
            this.настройкиToolStripMenuItem1.Click += new System.EventHandler(this.настройкиToolStripMenuItem1_Click);
            // 
            // консольToolStripMenuItem
            // 
            this.консольToolStripMenuItem.Name = "консольToolStripMenuItem";
            this.консольToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.консольToolStripMenuItem.Text = "Консоль";
            this.консольToolStripMenuItem.Click += new System.EventHandler(this.консольToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(149, 6);
            // 
            // помощьToolStripMenuItem1
            // 
            this.помощьToolStripMenuItem1.Name = "помощьToolStripMenuItem1";
            this.помощьToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.помощьToolStripMenuItem1.Text = "Помощь";
            this.помощьToolStripMenuItem1.Click += new System.EventHandler(this.помощьToolStripMenuItem1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Счетчик";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.inning2)).EndInit();
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.inning1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        public System.Windows.Forms.ToolStripMenuItem выбратьИгроковToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem завершитьВстречуToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem выбратьВстречуToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.Label info;
        public System.Windows.Forms.Timer timer1;
        public System.Windows.Forms.Timer timer2;
        public System.Windows.Forms.ToolStripStatusLabel joystick_status;
        public System.Windows.Forms.Label label_xx;
        public System.Windows.Forms.Label label_yy;
        public System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        public System.Windows.Forms.StatusStrip statusStrip1;
        public System.Windows.Forms.Label label_player2;
        public System.Windows.Forms.Label label_y;
        public System.Windows.Forms.PictureBox inning2;
        public System.Windows.Forms.Label label_player1;
        public System.Windows.Forms.Label label_x;
        public System.Windows.Forms.PictureBox inning1;
        public System.Windows.Forms.Label label_timer;
        public System.Windows.Forms.ToolStripMenuItem открытьToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem базаДанныхToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem настройкиToolStripMenuItem1;
        public System.Windows.Forms.ToolStripMenuItem помощьToolStripMenuItem1;
        public System.Windows.Forms.ToolStripMenuItem консольToolStripMenuItem;
        public System.Windows.Forms.Timer timer4;

    }
}

