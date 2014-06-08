namespace enumerator
{
    partial class form_add_tournament
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
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_name = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dateTimePicker_date = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_K = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBox_rounds = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox_note = new System.Windows.Forms.TextBox();
            this.button_OK = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.textBox_translit_name = new System.Windows.Forms.TextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.dataPlayersInTournament = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.player = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buttonAddPlayerInTournament = new System.Windows.Forms.Button();
            this.buttonDelPlayerInTournament = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataPlayersInTournament)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Название турнира:";
            // 
            // textBox_name
            // 
            this.textBox_name.Location = new System.Drawing.Point(12, 25);
            this.textBox_name.Name = "textBox_name";
            this.textBox_name.Size = new System.Drawing.Size(312, 20);
            this.textBox_name.TabIndex = 1;
            this.textBox_name.TextChanged += new System.EventHandler(this.textBox_name_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Дата:";
            // 
            // dateTimePicker_date
            // 
            this.dateTimePicker_date.Location = new System.Drawing.Point(12, 90);
            this.dateTimePicker_date.Name = "dateTimePicker_date";
            this.dateTimePicker_date.Size = new System.Drawing.Size(130, 20);
            this.dateTimePicker_date.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(233, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Коэффициент:";
            // 
            // textBox_K
            // 
            this.textBox_K.Location = new System.Drawing.Point(236, 90);
            this.textBox_K.Name = "textBox_K";
            this.textBox_K.Size = new System.Drawing.Size(50, 20);
            this.textBox_K.TabIndex = 5;
            this.textBox_K.Text = "0.1";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(145, 75);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Кол-во партий:";
            // 
            // comboBox_rounds
            // 
            this.comboBox_rounds.FormattingEnabled = true;
            this.comboBox_rounds.Items.AddRange(new object[] {
            "3",
            "5",
            "7",
            "9"});
            this.comboBox_rounds.Location = new System.Drawing.Point(148, 90);
            this.comboBox_rounds.Name = "comboBox_rounds";
            this.comboBox_rounds.Size = new System.Drawing.Size(50, 21);
            this.comboBox_rounds.TabIndex = 7;
            this.comboBox_rounds.Text = "3";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 113);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Примечание:";
            // 
            // textBox_note
            // 
            this.textBox_note.Location = new System.Drawing.Point(12, 129);
            this.textBox_note.Multiline = true;
            this.textBox_note.Name = "textBox_note";
            this.textBox_note.Size = new System.Drawing.Size(312, 155);
            this.textBox_note.TabIndex = 9;
            // 
            // button_OK
            // 
            this.button_OK.Enabled = false;
            this.button_OK.Location = new System.Drawing.Point(12, 290);
            this.button_OK.Name = "button_OK";
            this.button_OK.Size = new System.Drawing.Size(75, 23);
            this.button_OK.TabIndex = 10;
            this.button_OK.Text = "OK";
            this.button_OK.UseVisualStyleBackColor = true;
            this.button_OK.Click += new System.EventHandler(this.button_OK_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(507, 290);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 11;
            this.buttonCancel.Text = "Отмена";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // textBox_translit_name
            // 
            this.textBox_translit_name.Location = new System.Drawing.Point(12, 51);
            this.textBox_translit_name.Name = "textBox_translit_name";
            this.textBox_translit_name.ReadOnly = true;
            this.textBox_translit_name.Size = new System.Drawing.Size(312, 20);
            this.textBox_translit_name.TabIndex = 12;
            // 
            // comboBox1
            // 
            this.comboBox1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.comboBox1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(330, 263);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(170, 21);
            this.comboBox1.TabIndex = 13;
            // 
            // dataPlayersInTournament
            // 
            this.dataPlayersInTournament.AllowUserToAddRows = false;
            this.dataPlayersInTournament.AllowUserToDeleteRows = false;
            this.dataPlayersInTournament.AllowUserToResizeColumns = false;
            this.dataPlayersInTournament.AllowUserToResizeRows = false;
            this.dataPlayersInTournament.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataPlayersInTournament.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.player});
            this.dataPlayersInTournament.Location = new System.Drawing.Point(330, 25);
            this.dataPlayersInTournament.MultiSelect = false;
            this.dataPlayersInTournament.Name = "dataPlayersInTournament";
            this.dataPlayersInTournament.ReadOnly = true;
            this.dataPlayersInTournament.RowHeadersVisible = false;
            this.dataPlayersInTournament.RowHeadersWidth = 20;
            this.dataPlayersInTournament.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataPlayersInTournament.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataPlayersInTournament.Size = new System.Drawing.Size(252, 232);
            this.dataPlayersInTournament.TabIndex = 14;
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
            // buttonAddPlayerInTournament
            // 
            this.buttonAddPlayerInTournament.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonAddPlayerInTournament.Location = new System.Drawing.Point(506, 263);
            this.buttonAddPlayerInTournament.Name = "buttonAddPlayerInTournament";
            this.buttonAddPlayerInTournament.Size = new System.Drawing.Size(35, 23);
            this.buttonAddPlayerInTournament.TabIndex = 15;
            this.buttonAddPlayerInTournament.Text = "+";
            this.buttonAddPlayerInTournament.UseVisualStyleBackColor = true;
            this.buttonAddPlayerInTournament.Click += new System.EventHandler(this.buttonAddPlayerInTournament_Click);
            // 
            // buttonDelPlayerInTournament
            // 
            this.buttonDelPlayerInTournament.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonDelPlayerInTournament.Location = new System.Drawing.Point(547, 263);
            this.buttonDelPlayerInTournament.Name = "buttonDelPlayerInTournament";
            this.buttonDelPlayerInTournament.Size = new System.Drawing.Size(35, 23);
            this.buttonDelPlayerInTournament.TabIndex = 16;
            this.buttonDelPlayerInTournament.Text = "-";
            this.buttonDelPlayerInTournament.UseVisualStyleBackColor = true;
            this.buttonDelPlayerInTournament.Click += new System.EventHandler(this.buttonDelPlayerInTournament_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(327, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(62, 13);
            this.label6.TabIndex = 17;
            this.label6.Text = "Игроки (0):";
            // 
            // form_add_tournament
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(594, 325);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.buttonDelPlayerInTournament);
            this.Controls.Add(this.buttonAddPlayerInTournament);
            this.Controls.Add(this.dataPlayersInTournament);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.textBox_translit_name);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.button_OK);
            this.Controls.Add(this.textBox_note);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.comboBox_rounds);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox_K);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dateTimePicker_date);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox_name);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "form_add_tournament";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Добавить турнир";
            this.Load += new System.EventHandler(this.form_add_tournament_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataPlayersInTournament)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_name;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateTimePicker_date;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_K;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBox_rounds;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox_note;
        private System.Windows.Forms.Button button_OK;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.TextBox textBox_translit_name;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.DataGridView dataPlayersInTournament;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn player;
        private System.Windows.Forms.Button buttonAddPlayerInTournament;
        private System.Windows.Forms.Button buttonDelPlayerInTournament;
        private System.Windows.Forms.Label label6;
    }
}