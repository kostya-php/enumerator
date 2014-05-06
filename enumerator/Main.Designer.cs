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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle38 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle39 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle40 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle41 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle42 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle36 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle37 = new System.Windows.Forms.DataGridViewCellStyle();
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
            this.buttonOpenEnumerator2 = new System.Windows.Forms.Button();
            this.buttonOpenEnumerator1 = new System.Windows.Forms.Button();
            this.dataMatches = new System.Windows.Forms.DataGridView();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dataMatchesColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataMatchesColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataMatchesColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buttonStartMatch = new System.Windows.Forms.Button();
            this.buttonCancelMatch = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataPlayers)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataTournaments)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataMatches)).BeginInit();
            this.groupBox3.SuspendLayout();
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
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(784, 562);
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
            this.groupBox1.Size = new System.Drawing.Size(386, 275);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Игроки";
            // 
            // buttonDelPlayer
            // 
            this.buttonDelPlayer.Location = new System.Drawing.Point(310, 246);
            this.buttonDelPlayer.Name = "buttonDelPlayer";
            this.buttonDelPlayer.Size = new System.Drawing.Size(75, 23);
            this.buttonDelPlayer.TabIndex = 3;
            this.buttonDelPlayer.Text = "Удалить";
            this.buttonDelPlayer.UseVisualStyleBackColor = true;
            this.buttonDelPlayer.Click += new System.EventHandler(this.buttonDelPlayer_Click);
            // 
            // buttonEditPlayer
            // 
            this.buttonEditPlayer.Location = new System.Drawing.Point(146, 246);
            this.buttonEditPlayer.Name = "buttonEditPlayer";
            this.buttonEditPlayer.Size = new System.Drawing.Size(95, 23);
            this.buttonEditPlayer.TabIndex = 2;
            this.buttonEditPlayer.Text = "Редактировать";
            this.buttonEditPlayer.UseVisualStyleBackColor = true;
            this.buttonEditPlayer.Click += new System.EventHandler(this.buttonEditPlayer_Click);
            // 
            // buttonAddPlayer
            // 
            this.buttonAddPlayer.Location = new System.Drawing.Point(6, 246);
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
            dataGridViewCellStyle38.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle38.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle38.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle38.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle38.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle38.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle38.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataPlayers.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle38;
            this.dataPlayers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataPlayers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.player,
            this.birthday});
            dataGridViewCellStyle39.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle39.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle39.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle39.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle39.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle39.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle39.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataPlayers.DefaultCellStyle = dataGridViewCellStyle39;
            this.dataPlayers.Location = new System.Drawing.Point(6, 19);
            this.dataPlayers.MultiSelect = false;
            this.dataPlayers.Name = "dataPlayers";
            this.dataPlayers.ReadOnly = true;
            dataGridViewCellStyle40.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle40.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle40.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle40.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle40.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle40.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle40.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataPlayers.RowHeadersDefaultCellStyle = dataGridViewCellStyle40;
            this.dataPlayers.RowHeadersVisible = false;
            this.dataPlayers.RowHeadersWidth = 20;
            this.dataPlayers.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataPlayers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataPlayers.Size = new System.Drawing.Size(379, 221);
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
            this.groupBox2.Size = new System.Drawing.Size(386, 275);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Турниры";
            // 
            // buttonDelTournament
            // 
            this.buttonDelTournament.Enabled = false;
            this.buttonDelTournament.Location = new System.Drawing.Point(310, 246);
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
            this.buttonAddTournament.Location = new System.Drawing.Point(6, 246);
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
            dataGridViewCellStyle41.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle41.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle41.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle41.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle41.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle41.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle41.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataTournaments.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle41;
            this.dataTournaments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataTournaments.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3});
            dataGridViewCellStyle42.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle42.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle42.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle42.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle42.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle42.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle42.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataTournaments.DefaultCellStyle = dataGridViewCellStyle42;
            this.dataTournaments.Location = new System.Drawing.Point(6, 19);
            this.dataTournaments.MultiSelect = false;
            this.dataTournaments.Name = "dataTournaments";
            this.dataTournaments.ReadOnly = true;
            this.dataTournaments.RowHeadersVisible = false;
            this.dataTournaments.RowHeadersWidth = 20;
            this.dataTournaments.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataTournaments.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataTournaments.Size = new System.Drawing.Size(379, 221);
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
            // buttonOpenEnumerator2
            // 
            this.buttonOpenEnumerator2.Location = new System.Drawing.Point(669, 243);
            this.buttonOpenEnumerator2.Name = "buttonOpenEnumerator2";
            this.buttonOpenEnumerator2.Size = new System.Drawing.Size(100, 23);
            this.buttonOpenEnumerator2.TabIndex = 1;
            this.buttonOpenEnumerator2.Text = "Счетчик (реверс)";
            this.buttonOpenEnumerator2.UseVisualStyleBackColor = true;
            this.buttonOpenEnumerator2.Click += new System.EventHandler(this.buttonOpenEnumerator2_Click);
            // 
            // buttonOpenEnumerator1
            // 
            this.buttonOpenEnumerator1.Location = new System.Drawing.Point(694, 214);
            this.buttonOpenEnumerator1.Name = "buttonOpenEnumerator1";
            this.buttonOpenEnumerator1.Size = new System.Drawing.Size(75, 23);
            this.buttonOpenEnumerator1.TabIndex = 0;
            this.buttonOpenEnumerator1.Text = "Счетчик";
            this.buttonOpenEnumerator1.UseVisualStyleBackColor = true;
            this.buttonOpenEnumerator1.Click += new System.EventHandler(this.buttonOpenEnumerator1_Click);
            // 
            // dataMatches
            // 
            this.dataMatches.AllowUserToAddRows = false;
            this.dataMatches.AllowUserToDeleteRows = false;
            this.dataMatches.AllowUserToResizeColumns = false;
            this.dataMatches.AllowUserToResizeRows = false;
            dataGridViewCellStyle36.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle36.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle36.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle36.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle36.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle36.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle36.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataMatches.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle36;
            this.dataMatches.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataMatches.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataMatchesColumn1,
            this.dataMatchesColumn2,
            this.dataMatchesColumn3});
            dataGridViewCellStyle37.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle37.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle37.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle37.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle37.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle37.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle37.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataMatches.DefaultCellStyle = dataGridViewCellStyle37;
            this.dataMatches.Location = new System.Drawing.Point(9, 19);
            this.dataMatches.MultiSelect = false;
            this.dataMatches.Name = "dataMatches";
            this.dataMatches.ReadOnly = true;
            this.dataMatches.RowHeadersVisible = false;
            this.dataMatches.RowHeadersWidth = 20;
            this.dataMatches.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataMatches.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataMatches.Size = new System.Drawing.Size(452, 218);
            this.dataMatches.TabIndex = 2;
            // 
            // groupBox3
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.groupBox3, 2);
            this.groupBox3.Controls.Add(this.buttonCancelMatch);
            this.groupBox3.Controls.Add(this.buttonStartMatch);
            this.groupBox3.Controls.Add(this.buttonOpenEnumerator1);
            this.groupBox3.Controls.Add(this.buttonOpenEnumerator2);
            this.groupBox3.Controls.Add(this.dataMatches);
            this.groupBox3.Location = new System.Drawing.Point(3, 284);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(777, 275);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Доступные встречи";
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
            // buttonStartMatch
            // 
            this.buttonStartMatch.Location = new System.Drawing.Point(9, 243);
            this.buttonStartMatch.Name = "buttonStartMatch";
            this.buttonStartMatch.Size = new System.Drawing.Size(75, 23);
            this.buttonStartMatch.TabIndex = 3;
            this.buttonStartMatch.Text = "Вызвать";
            this.buttonStartMatch.UseVisualStyleBackColor = true;
            this.buttonStartMatch.Click += new System.EventHandler(this.buttonStartMatch_Click);
            // 
            // buttonCancelMatch
            // 
            this.buttonCancelMatch.Enabled = false;
            this.buttonCancelMatch.Location = new System.Drawing.Point(90, 243);
            this.buttonCancelMatch.Name = "buttonCancelMatch";
            this.buttonCancelMatch.Size = new System.Drawing.Size(175, 23);
            this.buttonCancelMatch.TabIndex = 4;
            this.buttonCancelMatch.Text = "Прервать текущую встречу";
            this.buttonCancelMatch.UseVisualStyleBackColor = true;
            this.buttonCancelMatch.Click += new System.EventHandler(this.buttonCancelMatch_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(784, 562);
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
            ((System.ComponentModel.ISupportInitialize)(this.dataMatches)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

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
        private System.Windows.Forms.DataGridView dataMatches;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataMatchesColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataMatchesColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataMatchesColumn3;
        public System.Windows.Forms.Button buttonStartMatch;
        public System.Windows.Forms.Button buttonCancelMatch;


    }
}