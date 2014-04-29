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
namespace enumerator
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }
        /*
        private static string host = Properties.Settings.Default.host;
        private static string database = Properties.Settings.Default.database;
        private static string user = Properties.Settings.Default.user;
        private static string password = Properties.Settings.Default.password;
        private static string connectionString = "SERVER=" + host + ";" + "DATABASE=" +
        database + ";" + "UID=" + user + ";" + "PASSWORD=" + password + ";CharSet=utf8;";
        */
        private void button1_Click(object sender, EventArgs e)
        {

        }
        private string player_name(int id)
        {
            string result = "NoName";
            MySqlConnection connect = null;
            try
            {
                connect = new MySqlConnection(Data.connectionString);
                connect.Open();
                string query = "SELECT * FROM players WHERE id='"+id.ToString()+"'";
                MySqlCommand cmd = new MySqlCommand(query, connect);
                MySqlDataReader dataReader = cmd.ExecuteReader();
                while (dataReader.Read())
                {
                    result = dataReader["player"].ToString();
                }
                dataReader.Close();
                connect.Close();
            }
            catch (MySqlException err)
            {
                MessageBox.Show("Ошибка: " + err.ToString());
            }
            finally
            {
                if (connect != null)
                {
                    connect.Close(); //safely close the connection
                }
            }
            return result;
        }
        private string rez_part(int id)
        {
            string result = "";
            MySqlConnection connect = null;
            try
            {
                connect = new MySqlConnection(Data.connectionString);
                connect.Open();
                string query = "SELECT * FROM rounds WHERE `match`='" + id.ToString() + "'";
                MySqlCommand cmd = new MySqlCommand(query, connect);
                MySqlDataReader dataReader = cmd.ExecuteReader();
                while (dataReader.Read())
                {
                    if (result != "") result += ",";
                    result += dataReader["xx"].ToString() + ":" + dataReader["yy"].ToString();
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
                    connect.Close(); //safely close the connection
                }
            }
            return result;
        }

        private int active_row = 0;
        private DateTime active_start;

        private void update_datagrid()
        {
            button_update.Enabled = false;
            timer1.Stop();
            dataGridView1.Rows.Clear();
            MySqlConnection connect = null;
            try
            {
                connect = new MySqlConnection(Data.connectionString);
                connect.Open();
                int t = 0;
                string query = "SELECT * FROM tournaments WHERE status='1'";
                MySqlCommand cmd = new MySqlCommand(query, connect);
                MySqlDataReader dataReader = cmd.ExecuteReader();
                while (dataReader.Read())
                {
                    t = Convert.ToInt32(dataReader["id"]);
                }
                dataReader.Close();

                if (t > 0)
                {
                    query = "SELECT * FROM matches WHERE tournament='" + t.ToString() + "'";
                    cmd = new MySqlCommand(query, connect);
                    dataReader = cmd.ExecuteReader();
                    int i = 0;
                    while (dataReader.Read())
                    {
                        // Игрок 1
                        string player1 = this.player_name(Convert.ToInt32(dataReader["player1"]));
                        // Результат
                        string x, y;
                        if (dataReader["x"].ToString() == "") x = "-"; else x = dataReader["x"].ToString();
                        if (dataReader["y"].ToString() == "") y = "-"; else y = dataReader["y"].ToString();
                        string rez = x + ":" + y;
                        // Игрок 2
                        string player2 = this.player_name(Convert.ToInt32(dataReader["player2"]));
                        // Результат по партиям
                        string rez_part = this.rez_part(Convert.ToInt32(dataReader["id"]));
                        // Статус
                        string status = "";
                        // Время
                        //DateTime start = this.in_string("2014-04-17 12:00:00");
                        //DateTime end = this.in_string("2014-04-17 12:05:00");
                        string time = "00:00:00";
                        string start = dataReader["start"].ToString();
                        string end = dataReader["end"].ToString();
                        string now;
                        if (start != "")
                        {
                            DateTime start_datetime = Convert.ToDateTime(start);
                            DateTime end_datetime = new DateTime();
                            if (end == "")
                            {
                                now = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                                end_datetime = Convert.ToDateTime(now);
                                this.active_row = i;
                                this.active_start = start_datetime;
                                timer1.Start();
                            }
                            else
                            {
                                end_datetime = Convert.ToDateTime(end);
                            }
                            TimeSpan delta = end_datetime - start_datetime;
                            time = delta.ToString();
                        }
                        switch (Convert.ToInt32(dataReader["status"]))
                        {
                            case 0:
                                status = "не играли";
                                break;
                            case 1:
                                status = "идет игра";
                                break;
                            case 2:
                                status = "сыграли";
                                break;
                            case 3:
                                status = "тех.поражение";
                                break;
                            case 4:
                                status = "неявка игроков";
                                break;
                        }
                        dataGridView1.Rows.Add(player1, rez, player2, rez_part, status, time);
                        //dataGridView1.Rows[i].Cells[0].Value = i.ToString();
                        //dataGridView1.Rows[i].Cells[1].Value = dataReader2["player1"].ToString();
                        //dataGridView1.Rows[i].Cells[2].Value = dataReader2["x"].ToString() + ":" + dataReader2["y"].ToString();
                        //dataGridView1.Rows[i].Cells[3].Value = dataReader2["player2"].ToString();
                        i++;
                    }
                    dataGridView1.Height = 22 * (i + 1) + 1;
                    dataReader.Close();
                }
                connect.Close();
            }
            catch (MySqlException err)
            {
                MessageBox.Show("Ошибка: " + err.ToString());
            }
            finally
            {
                if (connect != null)
                {
                    connect.Close(); //safely close the connection
                }
            }
            button_update.Enabled = true;
        }

        private void players_list()
        {
            MySqlConnection connect = null;
            try
            {
                connect = new MySqlConnection(Data.connectionString);
                connect.Open();
                string query = "SELECT * FROM players ORDER BY id ASC";
                MySqlCommand cmd = new MySqlCommand(query, connect);
                MySqlDataReader dataReader = cmd.ExecuteReader();
                while (dataReader.Read())
                {
                    comboBox1.Items.Add(dataReader["player"]);
                    comboBox2.Items.Add(dataReader["player"]);
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
                    connect.Close(); //safely close the connection
                }
            }
        }

        private void Main_Load(object sender, EventArgs e)
        {
            //this.update_datagrid();
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
            this.players_list();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime start_datetime = this.active_start;
            string now = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            DateTime end_datetime = Convert.ToDateTime(now);
            TimeSpan delta = end_datetime - start_datetime;
            string time = delta.ToString();
            dataGridView1.Rows[this.active_row].Cells[5].Value = time.ToString();
        }

        private void button_update_Click(object sender, EventArgs e)
        {
            this.update_datagrid();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            bool valid = true;
            for (int j = 0; j < dataGridView1.Rows.Count; j++)
            {
                string s = dataGridView1.Rows[j].Cells[4].Value.ToString();
                if (s == "идет игра") valid = false;
            }
            if (valid)
            {
                int i = e.RowIndex;
                string status = dataGridView1.Rows[i].Cells[4].Value.ToString();
                string player1 = dataGridView1.Rows[i].Cells[0].Value.ToString();
                string player2 = dataGridView1.Rows[i].Cells[2].Value.ToString();
                if (status == "не играли")
                {
                    DialogResult res = MessageBox.Show("Вызввать игроков?\n" + player1 + " - " + player2, "Вызов игроков", MessageBoxButtons.YesNo);
                }
            }
            else
            {
                MessageBox.Show("Невозможно вызвать игроков, стол занят :)","Предупреждение",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            int player1_id = comboBox1.SelectedIndex;
            int player2_id = comboBox2.SelectedIndex;
            if ((player1_id > 0) & (player2_id > 0))
            {
                Data.player1_id = player1_id;
                Data.player2_id = player2_id;
                Data.player1 = comboBox1.Text;
                Data.player2 = comboBox2.Text;
                Main m = new Main();
                Main.ActiveForm.Hide();
                Form1 f1 = new Form1();
                f1.ShowDialog();
                Close();
            }
            else
            {
                MessageBox.Show("Необходимо выбрать обоих игроков","Предупреждение",MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
