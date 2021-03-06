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
    public partial class form_add_tournament : Form
    {
        public form_add_tournament()
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

        public void players_update()
        {
            int index = 0;
            if (dataPlayers.RowCount > 0)
            {
                index = dataPlayers.CurrentRow.Index;
            }
            this.Invoke((MethodInvoker)delegate()
            {
                dataPlayers.Rows.Clear();
            });
            MySqlConnection connect = null;
            try
            {
                connect = new MySqlConnection(Data.connectionString);
                connect.Open();
                string query = "SELECT Count(*) FROM players";
                MySqlCommand cmd = new MySqlCommand(query, connect);
                int n = Convert.ToInt32(cmd.ExecuteScalar());
                query = "SELECT * FROM players ORDER BY id ASC";
                cmd = new MySqlCommand(query, connect);
                MySqlDataReader dataReader = cmd.ExecuteReader();
                string id, player;
                while (dataReader.Read())
                {
                    id = dataReader["id"].ToString();
                    player = dataReader["player"].ToString();
                    this.Invoke((MethodInvoker)delegate()
                    {
                        dataPlayers.Rows.Add(id, player);
                    });
                    Thread.Sleep(10);
                }
                dataReader.Close();

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
            this.Invoke((MethodInvoker)delegate()
            {
                dataPlayers.Rows[index].Cells[0].Selected = true;
                groupBox1.Text = "Игроки (" + dataPlayers.Rows.Count.ToString() + ")";
                //dataPlayers.Sort(dataPlayers.Columns[1], ListSortDirection.Ascending);
                dataPlayers.Rows[0].Cells[1].Selected = true;
            });
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void form_add_tournament_Load(object sender, EventArgs e)
        {
            //comboBox1.DataSource = Data.player_list();
            Thread myThread = new Thread(players_update);
            myThread.Start();
            //players_update();
            comboBox_protocol.SelectedIndex = 0;
        }

        private void button_OK_Click(object sender, EventArgs e)
        {
            MySqlConnection connect = null;
            try
            {
                connect = new MySqlConnection(Data.connectionString);
                connect.Open();

                string query = "SELECT Count(*) FROM tournaments";
                MySqlCommand cmd = new MySqlCommand(query, connect);
                int n = Convert.ToInt32(cmd.ExecuteScalar());

                string name, date, K, rounds, note, translit_name, protocol;

                name = textBox_name.Text;
                date = dateTimePicker_date.Value.ToString("yyyy-MM-dd");
                K = textBox_K.Text;
                note = textBox_note.Text;
                translit_name = textBox_translit_name.Text;
                rounds = comboBox_rounds.Text;
                protocol = "";

                for (int i = 0; i < dataPlayersInTournament.Rows.Count; i++)
                {
                    query = "INSERT INTO in_tournament VALUES (null,'" + (n + 1).ToString() + "','" + (i + 1).ToString() + "','" + dataPlayersInTournament.Rows[i].Cells[0].Value.ToString() + "')";
                    cmd = new MySqlCommand(query, connect);
                    cmd.ExecuteNonQuery();
                }
                switch (comboBox_protocol.SelectedIndex)
                {
                    case 0:
                        {
                            protocol = "krug";
                            query = "INSERT INTO tournaments VALUES (null,'" + name + "','" + date + "','" + K + "','" + note + "','1','" + translit_name + "','" + rounds + "','" + protocol + "')";
                            cmd = new MySqlCommand(query, connect);
                            cmd.ExecuteNonQuery();
                            int membership = dataPlayersInTournament.Rows.Count;
                            string matches = "";
                            switch (membership)
                            {
                                case 4:
                                    {
                                        matches = "1-4,2-3,3-1,4-2,1-2,3-4";
                                        break;
                                    }
                                case 5:
                                    {
                                        matches = "2-5,3-4,5-1,2-3,1-4,5-3,3-1,4-2,1-2,4-5";
                                        break;
                                    }
                                case 6:
                                    {
                                        matches = "1-6,2-5,3-4,5-1,6-4,2-3,1-4,5-3,6-2,3-1,4-2,5-6,1-2,3-6,4-5";
                                        break;
                                    }
                                case 7:
                                    {
                                        matches = "2-7,3-6,4-5,7-1,2-5,3-4,1-6,7-5,2-3,5-1,6-4,7-3,1-4,5-3,6-2,3-1,4-2,6-7,1-2,4-7,5-6";
                                        break;
                                    }
                                case 8:
                                    {
                                        matches = "1-8,2-7,3-6,4-5,7-1,8-6,2-5,3-4,1-6,7-5,8-4,2-3,5-1,6-4,7-3,8-2,1-4,5-3,6-2,7-8,3-1,4-2,5-8,6-7,1-2,3-8,4-7,5-6";
                                        break;
                                    }
                                case 9:
                                    {
                                        matches = "2-9,3-8,4-7,5-6,9-1,2-7,3-6,4-5,1-8,9-7,2-5,3-4,7-1,8-6,9-5,2-3,1-6,7-5,8-4,9-3,5-1,6-4,7-3,8-2,1-4,5-3,6-2,8-9,3-1,4-2,6-9,7-8,1-2,4-9,5-8,6-7";
                                        break;
                                    }
                                case 10:
                                    {
                                        matches = "1-10,2-9,3-8,4-7,5-6,9-1,10-8,2-7,3-6,4-5,1-8,9-7,10-6,2-5,3-4,7-1,8-6,9-5,10-4,2-3,1-6,7-5,8-4,9-3,10-2,5-1,6-4,7-3,8-2,9-10,1-4,5-3,6-2,7-10,8-9,3-1,4-2,5-10,6-9,7-8,1-2,3-10,4-9,5-8,6-7";
                                        break;
                                    }
                                case 11:
                                    {
                                        matches = "2-11,3-10,4-9,5-8,6-7,11-1,2-9,3-8,4-7,5-6,1-10,11-9,2-7,3-6,4-5,9-1,10-8,11-7,2-5,3-4,1-8,9-7,10-6,11-5,2-3,7-1,8-6,9-5,10-4,11-3,1-6,7-5,8-4,9-3,10-2,5-1,6-4,7-3,8-2,10-11,1-4,5-3,6-2,8-11,9-10,3-1,4-2,6-11,7-10,8-9,1-2,4-11,5-10,6-9,7-8";
                                        break;
                                    }
                                case 12:
                                    {
                                        matches = "1-12,2-11,3-10,4-9,5-8,6-7,11-1,12-10,2-9,3-8,4-7,5-6,1-10,11-9,12-8,2-7,3-6,4-5,9-1,10-8,11-7,12-6,2-5,3-4,1-8,9-7,10-6,11-5,12-4,2-3,7-1,8-6,9-5,10-4,11-3,12-2,1-6,7-5,8-4,9-3,10-2,11-12,5-1,6-4,7-3,8-2,9-12,10-11,1-4,5-3,6-2,7-12,8-11,9-10,3-1,4-2,5-12,6-11,7-10,8-9,1-2,3-12,4-11,5-10,6-9,7-8";
                                        break;
                                    }
                            }
                            query = "SELECT * FROM in_tournament WHERE tournament='" + (n + 1).ToString() + "'";
                            cmd = new MySqlCommand(query, connect);
                            int[] player = new int[membership];
                            int j = 0;
                            MySqlDataReader dataReader = cmd.ExecuteReader();
                            while (dataReader.Read())
                            {
                                player[j] = Convert.ToInt32(dataReader["player"]);
                                j++;
                            }
                            dataReader.Close();
                            string[] match = matches.Split(',');
                            string[] players;
                            for (int k = 0; k < match.Length; k++)
                            {
                                players = match[k].Split('-');
                                query = "INSERT INTO matches VALUES (null,'" + (n + 1).ToString() + "','" + (k + 1).ToString() + "','" + (player[Convert.ToInt32(players[0]) - 1]).ToString() + "','" + (player[Convert.ToInt32(players[1]) - 1]).ToString() + "',null,null,0,null,null)";
                                cmd = new MySqlCommand(query, connect);
                                cmd.ExecuteNonQuery();
                            }
                            break;
                        }
                    case 1:
                        {
                            /*
                                1 1-2
                                2 3-4
                                3 5-6
                                4 7-8
                                5 win1-win2
                                6 win3-win4
                                7 win5-win6 (1-2 place)
                                8 los1-los2
                                9 los3-los4
                                10 los6-win8
                                11 los5-win9
                                12 win10-win11 (3-4 place)
                                13 los8-los9 (7-8 place)
                                14 los10-los11 (5-6 place)
                                
                             * победитель в первой игре попадает в пятую
                             * победитель во второй игре попадает в пятую
                             * победитель в третей игре попадает в шестую
                             * победитель в четвертой игре попадает в шестую
                             * победитель в пятой игре попадает в седьмую
                             * победитель в шестой игре попадает в седьмую
                             * победитель в седьмой игре занимает первое место
                            
                            */
                            protocol = "vib8";
                            query = "INSERT INTO tournaments VALUES (null,'" + name + "','" + date + "','" + K + "','" + note + "','1','" + translit_name + "','" + rounds + "','" + protocol + "')";
                            cmd = new MySqlCommand(query, connect);
                            cmd.ExecuteNonQuery();
                            int membership = dataPlayersInTournament.Rows.Count;
                            query = "SELECT * FROM in_tournament WHERE tournament='" + (n + 1).ToString() + "'";
                            cmd = new MySqlCommand(query, connect);
                            int[] player = new int[membership];
                            int j = 0;
                            MySqlDataReader dataReader = cmd.ExecuteReader();
                            while (dataReader.Read())
                            {
                                player[j] = Convert.ToInt32(dataReader["player"]);
                                j++;
                            }
                            dataReader.Close();
                            int k = 1;
                            int p1 = 1, p2 = 2;
                            for (int i = 0; i < membership / 2; i++)
                            {
                                query = "INSERT INTO matches VALUES (null,'" + (n + 1).ToString() + "','" + k.ToString() + "','" + (player[p1 - 1]).ToString() + "','" + (player[p2 - 1]).ToString() + "',null,null,0,null,null)";
                                cmd = new MySqlCommand(query, connect);
                                cmd.ExecuteNonQuery();
                                k++;
                                p1 += 2;
                                p2 += 2;
                            }
                            for (int i = 0; i < 10; i++)
                            {
                                query = "INSERT INTO matches VALUES (null,'" + (n + 1).ToString() + "','" + k.ToString() + "',null,null,null,null,0,null,null)";
                                cmd = new MySqlCommand(query, connect);
                                cmd.ExecuteNonQuery();
                                k++;
                            }
                            /*
                            Data.v8.game1_player1.Text = Data.player_name(player[0]);
                            Data.v8.game1_player2.Text = Data.player_name(player[1]);
                            Data.v8.game2_player1.Text = Data.player_name(player[2]);
                            Data.v8.game2_player2.Text = Data.player_name(player[3]);
                            Data.v8.game3_player1.Text = Data.player_name(player[4]);
                            Data.v8.game3_player2.Text = Data.player_name(player[5]);
                            Data.v8.game4_player1.Text = Data.player_name(player[6]);
                            Data.v8.game4_player2.Text = Data.player_name(player[7]);
                            */
                            break;
                        }
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
            Main form_at = this.Owner as Main;
            if (form_at != null)
            {
                //form_at.tournaments_update();
                form_at.matches_update();
            }
            this.Close();
            Data.ft.Close();
            //Thread myThread = new Thread(Data.ft.tournaments_update);
            //myThread.Start();
            Data.fm.Focus();
            Data.fm.matches_update();
        }

        private void textBox_name_TextChanged(object sender, EventArgs e)
        {
            textBox_translit_name.Text = Data.GetTranslit(textBox_name.Text);
            check();
        }

        private void buttonAddPlayerInTournament_Click(object sender, EventArgs e)
        {
            if (dataPlayers.CurrentRow != null)
            {
                string player;
                int id;
                bool error = false;
                //id = Data.player_id(comboBox1.Text).ToString();
                //id = dataPlayers.CurrentRow.Index;
                id = Convert.ToInt32(dataPlayers.Rows[Convert.ToInt32(dataPlayers.CurrentRow.Index)].Cells[0].Value);
                //player = comboBox1.Text;
                player = dataPlayers.Rows[Convert.ToInt32(Convert.ToInt32(dataPlayers.CurrentRow.Index))].Cells[1].Value.ToString();

                for (int i = 0; i < dataPlayersInTournament.Rows.Count; i++)
                {
                    if (Convert.ToInt32(dataPlayersInTournament.Rows[i].Cells[0].Value) == id) error = true;
                    //MessageBox.Show(dataPlayersInTournament.Rows[i].Cells[0].Value.ToString() + " - " + id.ToString());
                }
                //if (comboBox1.SelectedIndex == -1) error = true;
                if (!error)
                {
                    dataPlayersInTournament.Rows.Add(id, player);
                }
                label6.Text = "Игроки на турнире (" + dataPlayersInTournament.Rows.Count.ToString() + "):";
                check();
            }
        }

        private void buttonDelPlayerInTournament_Click(object sender, EventArgs e)
        {
            if (dataPlayersInTournament.Rows.Count > 0)
            {
                int index = dataPlayersInTournament.CurrentRow.Index;
                if (index >= 0)
                {
                    dataPlayersInTournament.Rows.RemoveAt(index);
                }
            }
            label6.Text = "Игроки на турнире (" + dataPlayersInTournament.Rows.Count.ToString() + "):";
            check();
        }

        private void buttonAddPlayer_Click(object sender, EventArgs e)
        {
            Data.edited_player = -1;
            form_add_edit_player form_aep = new form_add_edit_player();
            form_aep.Owner = this;
            form_aep.ShowDialog();
        }

        private void buttonEditPlayer_Click(object sender, EventArgs e)
        {
            int index = dataPlayers.CurrentRow.Index;
            Data.edited_player = Convert.ToInt32(dataPlayers.Rows[index].Cells[0].Value);
            form_add_edit_player form_aep = new form_add_edit_player();
            form_aep.Owner = this;
            form_aep.ShowDialog();
        }

        private void buttonDelPlayer_Click(object sender, EventArgs e)
        {
            buttonDelPlayer.Enabled = false;
            MessageBox.Show("Удаление игроков отключено в целях безопасности", "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Information);
            /*
            int index = dataPlayers.CurrentRow.Index;
            int id = Convert.ToInt32(dataPlayers.Rows[index].Cells[0].Value);
            DialogResult dr = MessageBox.Show(Data.player_name(id) + Environment.NewLine + "Вы действительно хотите удалить этого игрока?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dr == DialogResult.Yes)
            {
                MySqlConnection connect = null;
                try
                {
                    connect = new MySqlConnection(Data.connectionString);
                    connect.Open();
                    string query = "DELETE FROM players WHERE id='" + id + "'";
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
                players_update();
            }
            */
        }

        private void check()
        {
            bool error = false;
            int membership = dataPlayersInTournament.Rows.Count;
            if (textBox_name.Text.Length < 4) error = true;
            switch (comboBox_protocol.SelectedIndex)
            {
                case 0:
                    if (!((membership >= 4) & (membership <= 12))) error = true;
                    toolStripStatusLabel1.Text = "Подсказка: во встречах по круговому способу может участвовать от 4 до 12 игроков.";
                    toolStripStatusLabel1.ForeColor = Color.Black;
                    break;
                case 1:
                    // пока не работает
                    //error = true;
                    if (membership != 8) error = true;
                    toolStripStatusLabel1.Text = "Подсказка: во встречах на выбывание может участвовать 8 игроков. P.S. В разработке.";
                    toolStripStatusLabel1.ForeColor = Color.Red;
                    break;
                default:
                    error = true;
                    break;
            }
            if (!error) button_OK.Enabled = true;
            else button_OK.Enabled = false;
        }

        private void comboBox_protocol_SelectedIndexChanged(object sender, EventArgs e)
        {
            check();
        }

        private void dataPlayers_SortCompare(object sender, DataGridViewSortCompareEventArgs e)
        {
            if (e.Column.Index == 0)
            {
                e.SortResult = int.Parse(e.CellValue1.ToString()).CompareTo(int.Parse(e.CellValue2.ToString()));
                e.Handled = true;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            bool first_find = false;
            foreach (DataGridViewRow row in dataPlayers.Rows)
            {
                if (row.Cells[1].Value.ToString().IndexOf(textBox1.Text, StringComparison.CurrentCultureIgnoreCase) >= 0)
                //if (row.Cells[1].Value.ToString().Contains(textBox1.Text))
                {
                    dataPlayers.Rows[row.Index].Visible = true;
                    if (!first_find)
                    {
                        dataPlayers.Rows[row.Index].Cells[1].Selected = true;
                        first_find = true;
                    }
                }
                else
                {
                    dataPlayers.Rows[row.Index].Visible = false;
                }
            }
        }
    }
}