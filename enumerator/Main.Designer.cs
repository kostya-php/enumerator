namespace enumerator
{
    partial class Main
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonDelPlayer = new System.Windows.Forms.Button();
            this.buttonEditPlayer = new System.Windows.Forms.Button();
            this.buttonAddPlayer = new System.Windows.Forms.Button();
            this.dataPlayers = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.player = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.birthday = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.buttonDelTournament = new System.Windows.Forms.Button();
            this.buttonAddTournament = new System.Windows.Forms.Button();
            this.dataTournaments = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.buttonCancelMatch = new System.Windows.Forms.Button();
            this.buttonStartMatch = new System.Windows.Forms.Button();
            this.buttonOpenEnumerator1 = new System.Windows.Forms.Button();
            this.buttonOpenEnumerator2 = new System.Windows.Forms.Button();
            this.dataMatches = new System.Windows.Forms.DataGridView();
            this.dataMatchesColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataMatchesColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataMatchesColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.joystick_status = new System.Windows.Forms.ToolStripStatusLabel();
            this.timer_UpdateJoystick = new System.Windows.Forms.Timer(this.components);
            this.timer_InitDevices = new System.Windows.Forms.Timer(this.components);
            this.timer_Enumerator = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataPlayers)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataTournaments)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataMatches)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupBox2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupBox3, 0, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(784, 537);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buttonDelPlayer);
            this.groupBox1.Controls.Add(this.buttonEditPlayer);
            this.groupBox1.Controls.Add(this.buttonAddPlayer);
            this.groupBox1.Controls.Add(this.dataPlayers);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(386, 262);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Игроки";
            // 
            // buttonDelPlayer
            // 
            this.buttonDelPlayer.Location = new System.Drawing.Point(310, 233);
            this.buttonDelPlayer.Name = "buttonDelPlayer";
            this.buttonDelPlayer.Size = new System.Drawing.Size(75, 23);
            this.buttonDelPlayer.TabIndex = 3;
            this.buttonDelPlayer.Text = "Удалить";
            this.buttonDelPlayer.UseVisualStyleBackColor = true;
            this.buttonDelPlayer.Click += new System.EventHandler(this.buttonDelPlayer_Click);
            // 
            // buttonEditPlayer
            // 
            this.buttonEditPlayer.Location = new System.Drawing.Point(90, 233);
            this.buttonEditPlayer.Name = "buttonEditPlayer";
            this.buttonEditPlayer.Size = new System.Drawing.Size(95, 23);
            this.buttonEditPlayer.TabIndex = 2;
            this.buttonEditPlayer.Text = "Редактировать";
            this.buttonEditPlayer.UseVisualStyleBackColor = true;
            this.buttonEditPlayer.Click += new System.EventHandler(this.buttonEditPlayer_Click);
            // 
            // buttonAddPlayer
            // 
            this.buttonAddPlayer.Location = new System.Drawing.Point(6, 233);
            this.buttonAddPlayer.Name = "buttonAddPlayer";
            this.buttonAddPlayer.Size = new System.Drawing.Size(75, 23);
            this.buttonAddPlayer.TabIndex = 1;
            this.buttonAddPlayer.Text = "Добавить";
            this.buttonAddPlayer.UseVisualStyleBackColor = true;
            this.buttonAddPlayer.Click += new System.EventHandler(this.buttonAddPlayer_Click);
            // 
            // dataPlayers
            // 
            this.dataPlayers.AllowUserToAddRows = false;
            this.dataPlayers.AllowUserToDeleteRows = false;
            this.dataPlayers.AllowUserToResizeColumns = false;
            this.dataPlayers.AllowUserToResizeRows = false;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataPlayers.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.dataPlayers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataPlayers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.player,
            this.birthday});
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataPlayers.DefaultCellStyle = dataGridViewCellStyle9;
            this.dataPlayers.Location = new System.Drawing.Point(6, 19);
            this.dataPlayers.MultiSelect = false;
            this.dataPlayers.Name = "dataPlayers";
            this.dataPlayers.ReadOnly = true;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataPlayers.RowHeadersDefaultCellStyle = dataGridViewCellStyle10;
            this.dataPlayers.RowHeadersVisible = false;
            this.dataPlayers.RowHeadersWidth = 20;
            this.dataPlayers.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataPlayers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataPlayers.Size = new System.Drawing.Size(379, 208);
            this.dataPlayers.TabIndex = 0;
            // 
            // id
            // 
            this.id.HeaderText = "#";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.id.Width = 30;
            // 
            // player
            // 
            this.player.HeaderText = "Игрок";
            this.player.Name = "player";
            this.player.ReadOnly = true;
            this.player.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.player.Width = 200;
            // 
            // birthday
            // 
            this.birthday.HeaderText = "Дата рождения";
            this.birthday.Name = "birthday";
            this.birthday.ReadOnly = true;
            this.birthday.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.birthday.Width = 127;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.buttonDelTournament);
            this.groupBox2.Controls.Add(this.buttonAddTournament);
            this.groupBox2.Controls.Add(this.dataTournaments);
            this.groupBox2.Location = new System.Drawing.Point(395, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(386, 262);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Турниры";
            // 
            // buttonDelTournament
            // 
            this.buttonDelTournament.Enabled = false;
            this.buttonDelTournament.Location = new System.Drawing.Point(304, 233);
            this.buttonDelTournament.Name = "buttonDelTournament";
            this.buttonDelTournament.Size = new System.Drawing.Size(75, 23);
            this.buttonDelTournament.TabIndex = 3;
            this.buttonDelTournament.Text = "Удалить";
            this.buttonDelTournament.UseVisualStyleBackColor = true;
            this.buttonDelTournament.Click += new System.EventHandler(this.buttonDelTournament_Click);
            // 
            // buttonAddTournament
            // 
            this.buttonAddTournament.Enabled = false;
            this.buttonAddTournament.Location = new System.Drawing.Point(6, 233);
            this.buttonAddTournament.Name = "buttonAddTournament";
            this.buttonAddTournament.Size = new System.Drawing.Size(75, 23);
            this.buttonAddTournament.TabIndex = 2;
            this.buttonAddTournament.Text = "Добавить";
            this.buttonAddTournament.UseVisualStyleBackColor = true;
            this.buttonAddTournament.Click += new System.EventHandler(this.buttonAddTournament_Click);
            // 
            // dataTournaments
            // 
            this.dataTournaments.AllowUserToAddRows = false;
            this.dataTournaments.AllowUserToDeleteRows = false;
            this.dataTournaments.AllowUserToResizeColumns = false;
            this.dataTournaments.AllowUserToResizeRows = false;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataTournaments.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle11;
            this.dataTournaments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataTournaments.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3});
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataTournaments.DefaultCellStyle = dataGridViewCellStyle12;
            this.dataTournaments.Location = new System.Drawing.Point(6, 19);
            this.dataTournaments.MultiSelect = false;
            this.dataTournaments.Name = "dataTournaments";
            this.dataTournaments.ReadOnly = true;
            this.dataTournaments.RowHeadersVisible = false;
            this.dataTournaments.RowHeadersWidth = 20;
            this.dataTournaments.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataTournaments.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataTournaments.Size = new System.Drawing.Size(379, 208);
            this.dataTournaments.TabIndex = 1;
            this.dataTournaments.SelectionChanged += new System.EventHandler(this.dataTournaments_SelectionChanged);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "#";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn1.Width = 30;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Название";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn2.Width = 200;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "Дата";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn3.Width = 127;
            // 
            // groupBox3
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.groupBox3, 2);
            this.groupBox3.Controls.Add(this.tableLayoutPanel2);
            this.groupBox3.Controls.Add(this.buttonCancelMatch);
            this.groupBox3.Controls.Add(this.buttonStartMatch);
            this.groupBox3.Controls.Add(this.buttonOpenEnumerator1);
            this.groupBox3.Controls.Add(this.buttonOpenEnumerator2);
            this.groupBox3.Controls.Add(this.dataMatches);
            this.groupBox3.Location = new System.Drawing.Point(3, 271);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(777, 263);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Доступные встречи";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Controls.Add(this.label2, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.pictureBox1, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(467, 19);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(302, 209);
            this.tableLayoutPanel2.TabIndex = 6;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = global::enumerator.Properties.Resources.stol2;
            this.pictureBox1.Location = new System.Drawing.Point(3, 55);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(296, 98);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // buttonCancelMatch
            // 
            this.buttonCancelMatch.Enabled = false;
            this.buttonCancelMatch.Location = new System.Drawing.Point(90, 234);
            this.buttonCancelMatch.Name = "buttonCancelMatch";
            this.buttonCancelMatch.Size = new System.Drawing.Size(175, 23);
            this.buttonCancelMatch.TabIndex = 4;
            this.buttonCancelMatch.Text = "Прервать текущую встречу";
            this.buttonCancelMatch.UseVisualStyleBackColor = true;
            this.buttonCancelMatch.Click += new System.EventHandler(this.buttonCancelMatch_Click);
            // 
            // buttonStartMatch
            // 
            this.buttonStartMatch.Location = new System.Drawing.Point(9, 234);
            this.buttonStartMatch.Name = "buttonStartMatch";
            this.buttonStartMatch.Size = new System.Drawing.Size(75, 23);
            this.buttonStartMatch.TabIndex = 3;
            this.buttonStartMatch.Text = "Вызвать";
            this.buttonStartMatch.UseVisualStyleBackColor = true;
            this.buttonStartMatch.Click += new System.EventHandler(this.buttonStartMatch_Click);
            // 
            // buttonOpenEnumerator1
            // 
            this.buttonOpenEnumerator1.Location = new System.Drawing.Point(280, 234);
            this.buttonOpenEnumerator1.Name = "buttonOpenEnumerator1";
            this.buttonOpenEnumerator1.Size = new System.Drawing.Size(75, 23);
            this.buttonOpenEnumerator1.TabIndex = 0;
            this.buttonOpenEnumerator1.Text = "Счетчик";
            this.buttonOpenEnumerator1.UseVisualStyleBackColor = true;
            this.buttonOpenEnumerator1.Click += new System.EventHandler(this.buttonOpenEnumerator1_Click);
            // 
            // buttonOpenEnumerator2
            // 
            this.buttonOpenEnumerator2.Location = new System.Drawing.Point(361, 234);
            this.buttonOpenEnumerator2.Name = "buttonOpenEnumerator2";
            this.buttonOpenEnumerator2.Size = new System.Drawing.Size(100, 23);
            this.buttonOpenEnumerator2.TabIndex = 1;
            this.buttonOpenEnumerator2.Text = "Счетчик (реверс)";
            this.buttonOpenEnumerator2.UseVisualStyleBackColor = true;
            this.buttonOpenEnumerator2.Click += new System.EventHandler(this.buttonOpenEnumerator2_Click);
            // 
            // dataMatches
            // 
            this.dataMatches.AllowUserToAddRows = false;
            this.dataMatches.AllowUserToDeleteRows = false;
            this.dataMatches.AllowUserToResizeColumns = false;
            this.dataMatches.AllowUserToResizeRows = false;
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle13.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle13.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle13.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle13.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataMatches.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle13;
            this.dataMatches.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataMatches.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataMatchesColumn1,
            this.dataMatchesColumn2,
            this.dataMatchesColumn3});
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle14.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle14.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataMatches.DefaultCellStyle = dataGridViewCellStyle14;
            this.dataMatches.Location = new System.Drawing.Point(9, 19);
            this.dataMatches.MultiSelect = false;
            this.dataMatches.Name = "dataMatches";
            this.dataMatches.ReadOnly = true;
            this.dataMatches.RowHeadersVisible = false;
            this.dataMatches.RowHeadersWidth = 20;
            this.dataMatches.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataMatches.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataMatches.Size = new System.Drawing.Size(452, 209);
            this.dataMatches.TabIndex = 2;
            // 
            // dataMatchesColumn1
            // 
            this.dataMatchesColumn1.HeaderText = "#";
            this.dataMatchesColumn1.Name = "dataMatchesColumn1";
            this.dataMatchesColumn1.ReadOnly = true;
            this.dataMatchesColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataMatchesColumn1.Width = 30;
            // 
            // dataMatchesColumn2
            // 
            this.dataMatchesColumn2.HeaderText = "Игроки";
            this.dataMatchesColumn2.Name = "dataMatchesColumn2";
            this.dataMatchesColumn2.ReadOnly = true;
            this.dataMatchesColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataMatchesColumn2.Width = 400;
            // 
            // dataMatchesColumn3
            // 
            this.dataMatchesColumn3.HeaderText = "id";
            this.dataMatchesColumn3.Name = "dataMatchesColumn3";
            this.dataMatchesColumn3.ReadOnly = true;
            this.dataMatchesColumn3.Visible = false;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.joystick_status});
            this.statusStrip1.Location = new System.Drawing.Point(0, 540);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(784, 22);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // joystick_status
            // 
            this.joystick_status.Name = "joystick_status";
            this.joystick_status.Size = new System.Drawing.Size(88, 17);
            this.joystick_status.Text = "Joystick: offline";
            // 
            // timer_UpdateJoystick
            // 
            this.timer_UpdateJoystick.Interval = 15;
            this.timer_UpdateJoystick.Tick += new System.EventHandler(this.timer_UpdateJoystick_Tick);
            // 
            // timer_InitDevices
            // 
            this.timer_InitDevices.Tick += new System.EventHandler(this.timer_InitDevices_Tick);
            // 
            // timer_Enumerator
            // 
            this.timer_Enumerator.Interval = 1000;
            this.timer_Enumerator.Tick += new System.EventHandler(this.timer_Enumerator_Tick);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(127, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Игрок 1";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(127, 176);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Игрок 2";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(800, 600);
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Enumerator";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Main_FormClosed);
            this.Load += new System.EventHandler(this.Main_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataPlayers)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataTournaments)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataMatches)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dataPlayers;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button buttonDelPlayer;
        private System.Windows.Forms.Button buttonEditPlayer;
        private System.Windows.Forms.Button buttonAddPlayer;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn player;
        private System.Windows.Forms.DataGridViewTextBoxColumn birthday;
        private System.Windows.Forms.Button buttonOpenEnumerator1;
        private System.Windows.Forms.Button buttonOpenEnumerator2;
        private System.Windows.Forms.DataGridView dataTournaments;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.Button buttonAddTournament;
        private System.Windows.Forms.Button buttonDelTournament;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataMatchesColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataMatchesColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataMatchesColumn3;
        public System.Windows.Forms.Button buttonStartMatch;
        public System.Windows.Forms.Button buttonCancelMatch;
        public System.Windows.Forms.StatusStrip statusStrip1;
        public System.Windows.Forms.Timer timer_UpdateJoystick;
        public System.Windows.Forms.Timer timer_InitDevices;
        public System.Windows.Forms.ToolStripStatusLabel joystick_status;
        public System.Windows.Forms.Timer timer_Enumerator;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.DataGridView dataMatches;


    }
}