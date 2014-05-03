﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace enumerator
{
    public partial class form_add_edit_player : Form
    {
        public form_add_edit_player()
        {
            InitializeComponent();
        }

        private const int CP_NOCLOSE_BUTTON = 0x200;
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams myCp = base.CreateParams;
                myCp.ClassStyle = myCp.ClassStyle | CP_NOCLOSE_BUTTON;
                return myCp;
            }
        }

        private void textBox_player_TextChanged(object sender, EventArgs e)
        {
            textBox_translit_name.Text = Data.GetTranslit(textBox_player.Text);
        }

        private void form_edit_player_Load(object sender, EventArgs e)
        {
            if (Data.edited_player > 0)
            {
                this.Icon = Properties.Resources.edit_user_7629;
                MySqlConnection connect = null;
                try
                {
                    connect = new MySqlConnection(Data.connectionString);
                    connect.Open();
                    string query = "SELECT * FROM players WHERE id='" + Data.edited_player.ToString() + "'";
                    MySqlCommand cmd = new MySqlCommand(query, connect);
                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    string player, reg, base_rating, birthday, note;
                    dataReader.Read();
                    player = dataReader["player"].ToString();
                    reg = dataReader["reg"].ToString();
                    base_rating = dataReader["base_rating"].ToString();
                    birthday = dataReader["birthday"].ToString();
                    note = dataReader["note"].ToString();
                    dataReader.Close();
                    this.Text = player;
                    textBox_player.Text = player;
                    if (reg != "")
                    {
                        dateTimePicker_reg.Value = Convert.ToDateTime(reg);
                    }
                    else
                    {
                        reg = DateTime.Now.ToString("yyyy-MM-dd");
                        dateTimePicker_reg.Value = Convert.ToDateTime(reg);
                        dateTimePicker_reg.Checked = false;
                    }
                    textBox_base_rating.Text = base_rating;
                    if (birthday != "")
                    {
                        dateTimePicker_birthday.Value = Convert.ToDateTime(birthday);
                    }
                    else
                    {
                        birthday = DateTime.Now.ToString("yyyy-MM-dd");
                        dateTimePicker_birthday.Value = Convert.ToDateTime(birthday);
                        dateTimePicker_birthday.Checked = false;
                    }
                    textBox_note.Text = note;
                }
                catch (MySqlException err)
                {
                    MessageBox.Show("Ошибка: " + err.ToString());
                }
                finally
                {
                    if (connect != null)
                    {
                        connect.Close();
                    }
                }
            }
            else
                if (Data.edited_player == -1)
                {
                    this.Icon = Properties.Resources.add_group_8863;
                    this.Text = "Добавить игрока";
                    dateTimePicker_reg.Value = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"));
                    dateTimePicker_reg.Checked = false;
                    dateTimePicker_birthday.Value = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"));
                    dateTimePicker_birthday.Checked = false;
                }
        }

        private void form_edit_player_FormClosing(object sender, FormClosingEventArgs e)
        {
            Data.edited_player = -1;
        }

        private void button_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button_OK_Click(object sender, EventArgs e)
        {
            if (Data.edited_player > 0)
            {
                MySqlConnection connect = null;
                try
                {
                    connect = new MySqlConnection(Data.connectionString);
                    connect.Open();
                    string player, reg, base_rating, birthday, note, translit_name;
                    player = textBox_player.Text;
                    if (dateTimePicker_reg.Checked)
                    {
                        reg = "'" + dateTimePicker_reg.Value.ToString("yyyy-MM-dd") + "'";
                    }
                    else
                    {
                        reg = "NULL";
                    }
                    base_rating = textBox_base_rating.Text;
                    if (dateTimePicker_birthday.Checked)
                    {
                        birthday = "'" + dateTimePicker_birthday.Value.ToString("yyyy-MM-dd") + "'";
                    }
                    else
                    {
                        birthday = "NULL";
                    }
                    note = textBox_note.Text;
                    translit_name = textBox_translit_name.Text;
                    string query = "UPDATE players SET player='" + player + "',reg=" + reg + ",base_rating='" + base_rating + "',birthday=" + birthday + ",note='" + note + "',translit_name='" + translit_name + "' WHERE id='" + Data.edited_player.ToString() + "'";
                    MySqlCommand cmd = new MySqlCommand(query, connect);
                    cmd.ExecuteNonQuery();
                }
                catch (MySqlException err)
                {
                    MessageBox.Show("Ошибка: " + err.ToString());
                }
                finally
                {
                    if (connect != null)
                    {
                        connect.Close();
                    }
                }
            }
            else
                if (Data.edited_player == -1)
                {
                    MySqlConnection connect = null;
                    try
                    {
                        connect = new MySqlConnection(Data.connectionString);
                        connect.Open();
                        string player, reg, base_rating, birthday, note, translit_name;
                        player = textBox_player.Text;
                        if (dateTimePicker_reg.Checked)
                        {
                            reg = "'" + dateTimePicker_reg.Value.ToString("yyyy-MM-dd") + "'";
                        }
                        else
                        {
                            reg = "NULL";
                        }
                        base_rating = textBox_base_rating.Text;
                        if (dateTimePicker_birthday.Checked)
                        {
                            birthday = "'" + dateTimePicker_birthday.Value.ToString("yyyy-MM-dd") + "'";
                        }
                        else
                        {
                            birthday = "NULL";
                        }
                        note = textBox_note.Text;
                        translit_name = textBox_translit_name.Text;
                        string query = "INSERT INTO players VALUES(null,'"+player+"',"+reg+",'"+base_rating+"',"+birthday+",'"+note+"',null,'"+translit_name+"',null)";
                        MySqlCommand cmd = new MySqlCommand(query, connect);
                        cmd.ExecuteNonQuery();
                    }
                    catch (MySqlException err)
                    {
                        MessageBox.Show("Ошибка: " + err.ToString());
                    }
                    finally
                    {
                        if (connect != null)
                        {
                            connect.Close();
                        }
                    }
                }
            Main form_aep = this.Owner as Main;
            if (form_aep != null)
            {
                form_aep.grid_update();
            }
            this.Close();
        }
    }
}