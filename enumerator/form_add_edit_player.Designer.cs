namespace enumerator
{
    partial class form_add_edit_player
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
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_player = new System.Windows.Forms.TextBox();
            this.dateTimePicker_reg = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox_base_rating = new System.Windows.Forms.TextBox();
            this.dateTimePicker_birthday = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox_note = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox_translit_name = new System.Windows.Forms.TextBox();
            this.button_OK = new System.Windows.Forms.Button();
            this.button_cancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Игрок:";
            // 
            // textBox_player
            // 
            this.textBox_player.Location = new System.Drawing.Point(12, 25);
            this.textBox_player.Name = "textBox_player";
            this.textBox_player.Size = new System.Drawing.Size(200, 20);
            this.textBox_player.TabIndex = 3;
            this.textBox_player.TextChanged += new System.EventHandler(this.textBox_player_TextChanged);
            // 
            // dateTimePicker_reg
            // 
            this.dateTimePicker_reg.Location = new System.Drawing.Point(12, 90);
            this.dateTimePicker_reg.Name = "dateTimePicker_reg";
            this.dateTimePicker_reg.ShowCheckBox = true;
            this.dateTimePicker_reg.Size = new System.Drawing.Size(150, 20);
            this.dateTimePicker_reg.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Дата регистрации:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 113);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Базовый рейтинг:";
            // 
            // textBox_base_rating
            // 
            this.textBox_base_rating.Location = new System.Drawing.Point(12, 129);
            this.textBox_base_rating.Name = "textBox_base_rating";
            this.textBox_base_rating.Size = new System.Drawing.Size(100, 20);
            this.textBox_base_rating.TabIndex = 7;
            // 
            // dateTimePicker_birthday
            // 
            this.dateTimePicker_birthday.Location = new System.Drawing.Point(12, 168);
            this.dateTimePicker_birthday.Name = "dateTimePicker_birthday";
            this.dateTimePicker_birthday.ShowCheckBox = true;
            this.dateTimePicker_birthday.Size = new System.Drawing.Size(150, 20);
            this.dateTimePicker_birthday.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 152);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Дата рождения:";
            // 
            // textBox_note
            // 
            this.textBox_note.Location = new System.Drawing.Point(12, 207);
            this.textBox_note.Multiline = true;
            this.textBox_note.Name = "textBox_note";
            this.textBox_note.Size = new System.Drawing.Size(200, 64);
            this.textBox_note.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 191);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(70, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Примечание";
            // 
            // textBox_translit_name
            // 
            this.textBox_translit_name.Location = new System.Drawing.Point(12, 51);
            this.textBox_translit_name.Name = "textBox_translit_name";
            this.textBox_translit_name.ReadOnly = true;
            this.textBox_translit_name.Size = new System.Drawing.Size(200, 20);
            this.textBox_translit_name.TabIndex = 14;
            // 
            // button_OK
            // 
            this.button_OK.Location = new System.Drawing.Point(12, 278);
            this.button_OK.Name = "button_OK";
            this.button_OK.Size = new System.Drawing.Size(75, 23);
            this.button_OK.TabIndex = 16;
            this.button_OK.Text = "OK";
            this.button_OK.UseVisualStyleBackColor = true;
            this.button_OK.Click += new System.EventHandler(this.button_OK_Click);
            // 
            // button_cancel
            // 
            this.button_cancel.Location = new System.Drawing.Point(137, 278);
            this.button_cancel.Name = "button_cancel";
            this.button_cancel.Size = new System.Drawing.Size(75, 23);
            this.button_cancel.TabIndex = 17;
            this.button_cancel.Text = "Отмена";
            this.button_cancel.UseVisualStyleBackColor = true;
            this.button_cancel.Click += new System.EventHandler(this.button_cancel_Click);
            // 
            // form_edit_player
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(224, 313);
            this.Controls.Add(this.button_cancel);
            this.Controls.Add(this.button_OK);
            this.Controls.Add(this.textBox_translit_name);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBox_note);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dateTimePicker_birthday);
            this.Controls.Add(this.textBox_base_rating);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dateTimePicker_reg);
            this.Controls.Add(this.textBox_player);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "form_edit_player";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Редактировать";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.form_edit_player_FormClosing);
            this.Load += new System.EventHandler(this.form_edit_player_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_player;
        private System.Windows.Forms.DateTimePicker dateTimePicker_reg;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox_base_rating;
        private System.Windows.Forms.DateTimePicker dateTimePicker_birthday;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox_note;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox_translit_name;
        private System.Windows.Forms.Button button_OK;
        private System.Windows.Forms.Button button_cancel;
    }
}