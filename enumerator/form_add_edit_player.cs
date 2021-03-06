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
using System.Threading;

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
            if (textBox_player.Text.Length > 5)
            {
                button_OK.Enabled = true;
            }
            else
            {
                button_OK.Enabled = false;
            }
        }

        private void load_player_data()
        {
            this.Invoke((MethodInvoker)delegate()
            {
                MySqlConnection connect = null;
                try
                {
                    connect = new MySqlConnection(Data.connectionString);
                    connect.Open();
                    string query = "SELECT * FROM players WHERE id='" + Data.edited_player.ToString() + "'";
                    MySqlCommand cmd = new MySqlCommand(query, connect);
                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    string player, reg, base_rating, birthday, note, photo, gender, is_rated;
                    dataReader.Read();
                    player = dataReader["player"].ToString();
                    reg = dataReader["reg"].ToString();
                    base_rating = dataReader["base_rating"].ToString();
                    birthday = dataReader["birthday"].ToString();
                    note = dataReader["note"].ToString();
                    photo = dataReader["photo"].ToString();
                    label4.Text = "Для отображения фото - двойной клик.";
                    gender = dataReader["gender"].ToString();
                    is_rated = dataReader["is_rated"].ToString();

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
                    if (photo != "")
                    {
                        textBox_photo.Text = photo;
                        checkBox_photo.Checked = true;
                    }
                    else
                    {
                        checkBox_photo.Checked = false;
                        //update_photo();
                    }
                    if (is_rated == "1")
                    {
                        checkBox_is_rated.Checked = true;
                    }
                    else
                    {
                        checkBox_is_rated.Checked = false;
                    }
                    switch (gender)
                    {
                        case "male":
                            comboBox_gender.SelectedIndex = 0;
                            break;
                        case "female":
                            comboBox_gender.SelectedIndex = 1;
                            break;
                        default:
                            comboBox_gender.SelectedIndex = -1;
                            break;
                    }
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
            });
        }

        private void form_edit_player_Load(object sender, EventArgs e)
        {
            if (Data.edited_player >= 0)
            {
                this.Icon = Properties.Resources.edit_user_7629;
                Thread myThread = new Thread(load_player_data);
                myThread.Start();
            }
            else
                if (Data.edited_player == -1)
                {
                    this.Icon = Properties.Resources.add_group_8863;
                    this.Text = "Добавить игрока";
                    dateTimePicker_reg.Value = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"));
                    dateTimePicker_reg.Checked = true;
                    dateTimePicker_birthday.Value = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"));
                    dateTimePicker_birthday.Checked = false;
                    //update_photo();
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
            if (Data.edited_player >= 0)
            {
                MySqlConnection connect = null;
                try
                {
                    connect = new MySqlConnection(Data.connectionString);
                    connect.Open();
                    string player, reg, base_rating, birthday, note, translit_name, photo, gender, is_rated;
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

                    if (checkBox_photo.Checked)
                    {
                        photo = "'" + textBox_photo.Text + "'";
                    }
                    else
                    {
                        photo = "NULL";
                    }
                    if (checkBox_is_rated.Checked)
                    {
                        is_rated = "1";
                    }
                    else
                    {
                        is_rated = "0";
                    }
                    //gender = "''";
                    switch (comboBox_gender.SelectedIndex)
                    {
                        case 0:
                            gender = "'male'";
                            break;
                        case 1:
                            gender = "'female'";
                            break;
                        default:
                            gender = "NULL";
                            break;
                    }
                    string query = "UPDATE players SET player='" + player + "',reg=" + reg + ",base_rating='" + base_rating + "',birthday=" + birthday + ",note='" + note + "',translit_name='" + translit_name + "',photo=" + photo + ",gender=" + gender + ",is_rated='" + is_rated.ToString() + "' WHERE id='" + Data.edited_player.ToString() + "'";
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
                        string player, reg, base_rating, birthday, note, translit_name, photo, gender, is_rated;
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
                        if (checkBox_photo.Checked)
                        {
                            photo = "'" + textBox_photo.Text + "'";
                        }
                        else
                        {
                            photo = "null";
                        }
                        if (checkBox_is_rated.Checked)
                        {
                            is_rated = "1";
                        }
                        else
                        {
                            is_rated = "0";
                        }
                        //gender = "''";
                        switch (comboBox_gender.SelectedIndex)
                        {
                            case 0:
                                {
                                    gender = "'male'";
                                    break;
                                }
                            case 1:
                                {
                                    gender = "'female'";
                                    break;
                                }
                            default:
                                gender = "NULL";
                                break;
                        }
                        string query = "INSERT INTO players VALUES(null,'" + player + "'," + reg + ",'" + base_rating + "'," + birthday + ",'" + note + "',null,'" + translit_name + "'," + photo + "," + gender + ",'" + is_rated + "')";
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
            Data.fp.button1.Enabled = false;
            Thread myThread = new Thread(Data.fp.players_update);
            myThread.Start();
            this.Close();
        }

        private void checkBox_photo_CheckedChanged(object sender, EventArgs e)
        {
            textBox_photo.Enabled = checkBox_photo.Checked;
            //update_photo();
        }

        private void textBox_photo_TextChanged(object sender, EventArgs e)
        {
            //update_photo();
        }
        private void update_photo()
        {
            try
            {
                if (checkBox_photo.Checked)
                {
                    pictureBox1.Load("http://rating.t-t.pp.ua" + textBox_photo.Text);
                }
                else
                {
                    pictureBox1.Load("http://rating.t-t.pp.ua/photos/nophoto.jpg");
                }
            }
            catch
            {
                pictureBox1.Load("http://rating.t-t.pp.ua/photos/nophoto.jpg");
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox_base_rating_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox_note_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_DoubleClick(object sender, EventArgs e)
        {
            update_photo();
            label4.Text = "";
        }
    }
}
