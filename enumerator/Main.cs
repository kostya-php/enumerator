using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Hooks;

namespace enumerator
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }
        public void players_update()
        {
            int index = 0;
            if (dataPlayers.RowCount > 0)
            {
                index = dataPlayers.CurrentRow.Index;
            }
            dataPlayers.Rows.Clear();
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
                string id, player, birthday;
                DateTime dt = new DateTime();
                while (dataReader.Read())
                {
                    id = dataReader["id"].ToString();
                    player = dataReader["player"].ToString();
                    if (dataReader["birthday"].ToString() != "")
                    {
                        dt = Convert.ToDateTime(dataReader["birthday"]);
                        birthday = dt.ToString("dd MMMM yyyy");
                    }
                    else
                    {
                        birthday = "?";
                    }
                    dataPlayers.Rows.Add(id, player, birthday);
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
            dataPlayers.Rows[index].Cells[0].Selected = true;
            groupBox1.Text = "Игроки (" + dataPlayers.Rows.Count.ToString() + ")";
        }
        public void tournaments_update()
        {
            dataTournaments.Rows.Clear();
            MySqlConnection connect = null;
            try
            {
                connect = new MySqlConnection(Data.connectionString);
                connect.Open();
                string query = "SELECT Count(*) FROM tournaments";
                MySqlCommand cmd = new MySqlCommand(query, connect);
                int n = Convert.ToInt32(cmd.ExecuteScalar());
                query = "SELECT * FROM tournaments ORDER BY id ASC";
                cmd = new MySqlCommand(query, connect);
                MySqlDataReader dataReader = cmd.ExecuteReader();
                string id, name, date;
                while (dataReader.Read())
                {
                    id = dataReader["id"].ToString();
                    name = dataReader["name"].ToString();
                    date = Convert.ToDateTime(dataReader["date"]).ToString("dd MMMM yyyy");
                    dataTournaments.Rows.Add(id, name, date);
                }
                dataReader.Close();

                query = "SELECT Count(*) FROM tournaments WHERE status='3'";
                cmd = new MySqlCommand(query, connect);
                int n2 = Convert.ToInt32(cmd.ExecuteScalar());
                if (n == n2) buttonAddTournament.Enabled = true;
                else buttonAddTournament.Enabled = false;
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
            groupBox2.Text = "Турниры (" + dataTournaments.Rows.Count.ToString() + ")";
            if (dataTournaments.Rows.Count > 0)
            {
                if ((dataTournaments.CurrentRow.Index + 1) == dataTournaments.Rows.Count)
                {
                    buttonDelTournament.Enabled = true;
                }
                else
                {
                    buttonDelTournament.Enabled = false;
                }
            }
        }

        public void matches_update()
        {
            dataMatches.Rows.Clear();
            MySqlConnection connect = null;
            try
            {
                connect = new MySqlConnection(Data.connectionString);
                connect.Open();
                string query = "SELECT * FROM tournaments WHERE status='1'";
                MySqlCommand cmd = new MySqlCommand(query, connect);
                MySqlDataReader dataReader = cmd.ExecuteReader();
                int t = -1;
                while (dataReader.Read())
                {
                    t = Convert.ToInt32(dataReader["id"]);
                }
                dataReader.Close();
                if (t > 0)
                {

                    query = "SELECT Count(*) FROM matches WHERE tournament='" + t.ToString() + "'";
                    cmd = new MySqlCommand(query, connect);
                    int n = Convert.ToInt32(cmd.ExecuteScalar());
                    if (n > 0)
                    {
                        query = "SELECT * FROM matches WHERE tournament='" + t.ToString() + "' ORDER BY id ASC";
                        cmd = new MySqlCommand(query, connect);
                        dataReader = cmd.ExecuteReader();
                        string players, id;
                        int number = 1;
                        while (dataReader.Read())
                        {
                            if (dataReader["status"].ToString() == "0")
                            {
                                players = Data.player_name(Convert.ToInt32(dataReader["player1"])) + " - " + Data.player_name(Convert.ToInt32(dataReader["player2"]));
                                id = dataReader["id"].ToString();
                                dataMatches.Rows.Add(number.ToString(), players, id);
                            }
                            number++;
                        }
                        dataReader.Close();
                    }
                }
                groupBox3.Text = "Доступные встречи (" + dataMatches.Rows.Count.ToString() + ")";
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

        private void Main_Load(object sender, EventArgs e)
        {
            Data.main = true;
            Data.edited_player = -1;
            players_update();
            tournaments_update();
            if (dataTournaments.Rows.Count > 0)
            {
                if ((dataTournaments.CurrentRow.Index + 1) == dataTournaments.Rows.Count)
                {
                    buttonDelTournament.Enabled = true;
                }
                else
                {
                    buttonDelTournament.Enabled = false;
                }
            }
            matches_update();
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            Data.main = false;
            if ((Data.player1 != null) & (Data.player2 != null))
                Data.abort_game();
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
        }

        private void buttonOpenEnumerator1_Click(object sender, EventArgs e)
        {
            if (!Data.f1.Visible) Data.f1.Visible = true;
        }

        // При закрытии формы какая-то хрень нужна
        private void Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            KBDHook.UnInstallHook(); // Обязательно !!!
        }

        private void buttonOpenEnumerator2_Click(object sender, EventArgs e)
        {
            if (!Data.f2.Visible) Data.f2.Visible = true;
        }

        private void buttonAddTournament_Click(object sender, EventArgs e)
        {
            form_add_tournament form_at = new form_add_tournament();
            form_at.Owner = this;
            form_at.ShowDialog();
        }

        private void buttonDelTournament_Click(object sender, EventArgs e)
        {
            int index = dataTournaments.CurrentRow.Index;
            int id = Convert.ToInt32(dataTournaments[0, index].Value);
            DialogResult dr = MessageBox.Show(dataTournaments[1, index].Value.ToString() + Environment.NewLine + "Вы действительно хотите удалить этот турнир? " + id, "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dr == DialogResult.Yes)
            {
                MySqlConnection connect = null;
                try
                {
                    connect = new MySqlConnection(Data.connectionString);
                    connect.Open();
                    // Удаляем турнир
                    string query = "DELETE FROM tournaments WHERE id='" + id.ToString() + "'";
                    MySqlCommand cmd = new MySqlCommand(query, connect);
                    cmd.ExecuteNonQuery();
                    query = "ALTER TABLE tournaments AUTO_INCREMENT=0";
                    cmd = new MySqlCommand(query, connect);
                    cmd.ExecuteNonQuery();
                    // Удаляем игроков с турнира
                    query = "DELETE FROM in_tournament WHERE tournament='" + id.ToString() + "'";
                    cmd = new MySqlCommand(query, connect);
                    cmd.ExecuteNonQuery();
                    query = "ALTER TABLE in_tournament AUTO_INCREMENT=0";
                    cmd = new MySqlCommand(query, connect);
                    cmd.ExecuteNonQuery();
                    // Делаем выборку игр
                    query = "SELECT * FROM matches WHERE tournament='" + id.ToString() + "'";
                    cmd = new MySqlCommand(query, connect);
                    MySqlDataReader dataReader2 = cmd.ExecuteReader();
                    // И удаляем партии
                    int match;
                    string queries = "";
                    while (dataReader2.Read())
                    {
                        match = Convert.ToInt32(dataReader2["id"]);
                        queries += "DELETE FROM rounds WHERE `match`='" + match.ToString() + "';";
                    }
                    dataReader2.Close();
                    cmd = new MySqlCommand(queries, connect);
                    cmd.ExecuteNonQuery();
                    query = "ALTER TABLE rounds AUTO_INCREMENT=0";
                    cmd = new MySqlCommand(query, connect);
                    cmd.ExecuteNonQuery();
                    // Удаляем игры
                    query = "DELETE FROM matches WHERE tournament='" + id.ToString() + "'";
                    cmd = new MySqlCommand(query, connect);
                    cmd.ExecuteNonQuery();
                    query = "ALTER TABLE matches AUTO_INCREMENT=0";
                    cmd = new MySqlCommand(query, connect);
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
                tournaments_update();
                matches_update();
            }
        }

        private void dataTournaments_SelectionChanged(object sender, EventArgs e)
        {
            //MessageBox.Show(dataTournaments.CurrentRow.Index.ToString() + " " + dataTournaments.Rows.Count.ToString());
            if (dataTournaments.Rows.Count > 0)
            {
                if ((dataTournaments.CurrentRow.Index + 1) == dataTournaments.Rows.Count)
                {
                    buttonDelTournament.Enabled = true;
                }
                else
                {
                    buttonDelTournament.Enabled = false;
                }
            }
        }

        private void buttonStartMatch_Click(object sender, EventArgs e)
        {
            if (dataMatches.Rows.Count > 0)
            {
                // получаем id встречи
                int index = dataMatches.CurrentRow.Index;
                Data.match = Convert.ToInt32(dataMatches.Rows[index].Cells[2].Value);
                // получаем текущие дату и время
                string start = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                Data.start = start;
                MySqlConnection connect = null;
                try
                {
                    buttonStartMatch.Enabled = false;
                    connect = new MySqlConnection(Data.connectionString);
                    connect.Open();
                    // берем информацию о встрече
                    string query = "SELECT * FROM matches WHERE id='" + Data.match.ToString() + "'";
                    MySqlCommand cmd = new MySqlCommand(query, connect);
                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    while (dataReader.Read())
                    {
                        Data.player1_id = Convert.ToInt32(dataReader["player1"]);
                        Data.player2_id = Convert.ToInt32(dataReader["player2"]);
                        Data.player1 = Data.player_name(Convert.ToInt32(dataReader["player1"]));
                        Data.player2 = Data.player_name(Convert.ToInt32(dataReader["player2"]));
                        Data.tournament = Convert.ToInt32(dataReader["tournament"]);
                    }
                    dataReader.Close();
                    // получаем количество партий
                    Data.rounds = Data.get_rounds(Data.tournament);
                    // получаем минимальное количество побед
                    double temp = Convert.ToDouble(Data.rounds) / 2.0;
                    Data.min_wins = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(Data.rounds) / 2.0));
                    Data.status = 0;
                    // меняем статус встречи
                    query = "UPDATE matches SET status='1', start='" + start + "' WHERE id='" + Data.match.ToString() + "'";
                    cmd = new MySqlCommand(query, connect);
                    cmd.ExecuteNonQuery();
                    // отображаем данные на форме-счетчике и закрываем исходную форму
                    /*
                    Form1 f1 = this.Owner as Form1;
                    if (f1 != null)
                    {
                        f1.завершитьВстречуToolStripMenuItem.Enabled = true;
                        f1.выбратьИгроковToolStripMenuItem.Enabled = false;
                        f1.выбратьВстречуToolStripMenuItem.Enabled = false;
                        Data.pick();
                    }
                    */
                    Data.pick();
                    Data.from_bd = true;
                    Data.update_info();
                    matches_update();
                    buttonCancelMatch.Enabled = true;
                }
                catch (MySqlException err)
                {
                    MessageBox.Show("Ошибка: " + err.ToString());
                    buttonCancelMatch.Enabled = false;
                    buttonStartMatch.Enabled = true;
                }
                finally
                {
                    if (connect != null)
                    {
                        connect.Close();
                    }
                }
            }
        }

        private void buttonCancelMatch_Click(object sender, EventArgs e)
        {
            buttonCancelMatch.Enabled = false;
            Data.abort_game();
            matches_update();
            buttonStartMatch.Enabled = true;
        }
    }
}
