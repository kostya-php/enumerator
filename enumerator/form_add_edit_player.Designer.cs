﻿namespace enumerator
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
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_base_rating = new System.Windows.Forms.TextBox();
            this.dateTimePicker_birthday = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox_note = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox_translit_name = new System.Windows.Forms.TextBox();
            this.button_OK = new System.Windows.Forms.Button();
            this.button_cancel = new System.Windows.Forms.Button();
            this.dateTimePicker_reg = new System.Windows.Forms.DateTimePicker();
            this.checkBox_photo = new System.Windows.Forms.CheckBox();
            this.textBox_photo = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.comboBox_gender = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.checkBox_is_rated = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(218, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Игрок:";
            // 
            // textBox_player
            // 
            this.textBox_player.Location = new System.Drawing.Point(221, 28);
            this.textBox_player.Name = "textBox_player";
            this.textBox_player.Size = new System.Drawing.Size(150, 20);
            this.textBox_player.TabIndex = 3;
            this.textBox_player.TextChanged += new System.EventHandler(this.textBox_player_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(218, 143);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Дата регистрации:";
            // 
            // textBox_base_rating
            // 
            this.textBox_base_rating.Location = new System.Drawing.Point(321, 185);
            this.textBox_base_rating.Name = "textBox_base_rating";
            this.textBox_base_rating.Size = new System.Drawing.Size(50, 20);
            this.textBox_base_rating.TabIndex = 7;
            this.textBox_base_rating.Text = "100";
            // 
            // dateTimePicker_birthday
            // 
            this.dateTimePicker_birthday.Location = new System.Drawing.Point(221, 120);
            this.dateTimePicker_birthday.Name = "dateTimePicker_birthday";
            this.dateTimePicker_birthday.ShowCheckBox = true;
            this.dateTimePicker_birthday.Size = new System.Drawing.Size(150, 20);
            this.dateTimePicker_birthday.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(218, 104);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Дата рождения:";
            // 
            // textBox_note
            // 
            this.textBox_note.Location = new System.Drawing.Point(9, 311);
            this.textBox_note.Multiline = true;
            this.textBox_note.Name = "textBox_note";
            this.textBox_note.Size = new System.Drawing.Size(362, 36);
            this.textBox_note.TabIndex = 10;
            this.textBox_note.TextChanged += new System.EventHandler(this.textBox_note_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 295);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(73, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Примечание:";
            // 
            // textBox_translit_name
            // 
            this.textBox_translit_name.Location = new System.Drawing.Point(221, 54);
            this.textBox_translit_name.Name = "textBox_translit_name";
            this.textBox_translit_name.ReadOnly = true;
            this.textBox_translit_name.Size = new System.Drawing.Size(150, 20);
            this.textBox_translit_name.TabIndex = 14;
            // 
            // button_OK
            // 
            this.button_OK.Enabled = false;
            this.button_OK.Location = new System.Drawing.Point(9, 353);
            this.button_OK.Name = "button_OK";
            this.button_OK.Size = new System.Drawing.Size(75, 23);
            this.button_OK.TabIndex = 16;
            this.button_OK.Text = "OK";
            this.button_OK.UseVisualStyleBackColor = true;
            this.button_OK.Click += new System.EventHandler(this.button_OK_Click);
            // 
            // button_cancel
            // 
            this.button_cancel.Location = new System.Drawing.Point(296, 353);
            this.button_cancel.Name = "button_cancel";
            this.button_cancel.Size = new System.Drawing.Size(75, 23);
            this.button_cancel.TabIndex = 17;
            this.button_cancel.Text = "Отмена";
            this.button_cancel.UseVisualStyleBackColor = true;
            this.button_cancel.Click += new System.EventHandler(this.button_cancel_Click);
            // 
            // dateTimePicker_reg
            // 
            this.dateTimePicker_reg.Location = new System.Drawing.Point(221, 159);
            this.dateTimePicker_reg.Name = "dateTimePicker_reg";
            this.dateTimePicker_reg.ShowCheckBox = true;
            this.dateTimePicker_reg.Size = new System.Drawing.Size(150, 20);
            this.dateTimePicker_reg.TabIndex = 4;
            // 
            // checkBox_photo
            // 
            this.checkBox_photo.AutoSize = true;
            this.checkBox_photo.Location = new System.Drawing.Point(224, 208);
            this.checkBox_photo.Name = "checkBox_photo";
            this.checkBox_photo.Size = new System.Drawing.Size(57, 17);
            this.checkBox_photo.TabIndex = 19;
            this.checkBox_photo.Text = "Фото:";
            this.checkBox_photo.UseVisualStyleBackColor = true;
            this.checkBox_photo.CheckedChanged += new System.EventHandler(this.checkBox_photo_CheckedChanged);
            // 
            // textBox_photo
            // 
            this.textBox_photo.Enabled = false;
            this.textBox_photo.Location = new System.Drawing.Point(221, 231);
            this.textBox_photo.Name = "textBox_photo";
            this.textBox_photo.Size = new System.Drawing.Size(150, 20);
            this.textBox_photo.TabIndex = 20;
            this.textBox_photo.TextChanged += new System.EventHandler(this.textBox_photo_TextChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(204, 242);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 21;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.DoubleClick += new System.EventHandler(this.pictureBox1_DoubleClick);
            // 
            // comboBox_gender
            // 
            this.comboBox_gender.FormattingEnabled = true;
            this.comboBox_gender.Items.AddRange(new object[] {
            "м",
            "ж"});
            this.comboBox_gender.Location = new System.Drawing.Point(248, 80);
            this.comboBox_gender.Name = "comboBox_gender";
            this.comboBox_gender.Size = new System.Drawing.Size(50, 21);
            this.comboBox_gender.TabIndex = 22;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(218, 83);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 23;
            this.label1.Text = "Пол:";
            // 
            // checkBox_is_rated
            // 
            this.checkBox_is_rated.AutoSize = true;
            this.checkBox_is_rated.Location = new System.Drawing.Point(224, 185);
            this.checkBox_is_rated.Name = "checkBox_is_rated";
            this.checkBox_is_rated.Size = new System.Drawing.Size(91, 17);
            this.checkBox_is_rated.TabIndex = 24;
            this.checkBox_is_rated.Text = "Рейтингован";
            this.checkBox_is_rated.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 257);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(207, 13);
            this.label4.TabIndex = 25;
            this.label4.Text = "Для отображения фото - двойной клик.";
            // 
            // form_add_edit_player
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(383, 388);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.checkBox_is_rated);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox_gender);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.textBox_photo);
            this.Controls.Add(this.checkBox_photo);
            this.Controls.Add(this.button_cancel);
            this.Controls.Add(this.button_OK);
            this.Controls.Add(this.textBox_translit_name);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBox_note);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dateTimePicker_birthday);
            this.Controls.Add(this.textBox_base_rating);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dateTimePicker_reg);
            this.Controls.Add(this.textBox_player);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "form_add_edit_player";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Редактировать";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.form_edit_player_FormClosing);
            this.Load += new System.EventHandler(this.form_edit_player_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_player;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_base_rating;
        private System.Windows.Forms.DateTimePicker dateTimePicker_birthday;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox_note;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox_translit_name;
        private System.Windows.Forms.Button button_OK;
        private System.Windows.Forms.Button button_cancel;
        private System.Windows.Forms.DateTimePicker dateTimePicker_reg;
        private System.Windows.Forms.CheckBox checkBox_photo;
        private System.Windows.Forms.TextBox textBox_photo;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ComboBox comboBox_gender;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox checkBox_is_rated;
        private System.Windows.Forms.Label label4;
    }
}