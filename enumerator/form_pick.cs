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
    public partial class form_pick : Form
    {
        public form_pick()
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
        private string player_name(int id)
        {
            string result = "NoName";
            MySqlConnection connect = null;
            try
            {
                connect = new MySqlConnection(Data.connectionString);
                connect.Open();
                string query = "SELECT * FROM players WHERE id='" + id.ToString() + "'";
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
        private int get_rounds(int id)
        {
            int rounds = 0;
            MySqlConnection connect = null;
            try
            {
                connect = new MySqlConnection(Data.connectionString);
                connect.Open();

                string query = "SELECT * FROM tournaments WHERE id='"+id+"'";
                MySqlCommand cmd = new MySqlCommand(query, connect);
                MySqlDataReader dataReader = cmd.ExecuteReader();
                while (dataReader.Read())
                {
                    rounds = Convert.ToInt32(dataReader["rounds"]);
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
            return rounds;
        }
        private void players_list()
        {
            MySqlConnection connect = null;
            try
            {
                connect = new MySqlConnection(Data.connectionString);
                connect.Open();
                string query1 = "SELECT Count(*) FROM players";
                MySqlCommand cmd1 = new MySqlCommand(query1, connect);
                int Count = int.Parse(cmd1.ExecuteScalar() + "");
                //progressBar1.Maximum = Count;

                string query = "SELECT * FROM players ORDER BY id ASC";
                MySqlCommand cmd = new MySqlCommand(query, connect);
                MySqlDataReader dataReader = cmd.ExecuteReader();
                while (dataReader.Read())
                {
                    comboBox1.Items.Add(dataReader["player"]);
                    comboBox2.Items.Add(dataReader["player"]);
                    //progressBar1.PerformStep();
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
            comboBox1.Enabled = true;
            comboBox2.Enabled = true;
            comboBox3.Enabled = true;
            button1.Enabled = true;
            progressBar1.Style = ProgressBarStyle.Blocks;
            progressBar1.Value = 100;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (((comboBox1.SelectedIndex > 0) & (comboBox2.SelectedIndex > 0)) & (comboBox1.SelectedIndex != comboBox2.SelectedIndex))
            {
                Data.from_bd = false;
                Data.player1 = comboBox1.Text;
                Data.player2 = comboBox2.Text;
                Data.status = 0;
                Data.rounds = Convert.ToInt32(comboBox3.Text);
                double temp = Convert.ToDouble(Data.rounds) / 2.0;
                Data.min_wins = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(Data.rounds) / 2.0));
                Form1 f1 = this.Owner as Form1;
                if (f1 != null)
                {
                    //f1.tableLayoutPanel1.Visible = true;
                    //f1.Focus();
                    f1.завершитьВстречуToolStripMenuItem.Enabled = true;
                    f1.выбратьИгроковToolStripMenuItem.Enabled = false;
                    f1.настройкиToolStripMenuItem.Enabled = false;
                    f1.pick();
                }
                this.Hide();
            }
            else
            {
                MessageBox.Show("Необходимо выбрать обоих игроков", "Выбор игроков", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            /*
            int player1_id = comboBox1.SelectedIndex;
            int player2_id = comboBox2.SelectedIndex;
            if ((player1_id > 0) & (player2_id > 0))
            {
                Data.player1 = comboBox1.Text;
                Data.player2 = comboBox2.Text;
                Data.status = 0;
                Data.rounds = Convert.ToInt32(comboBox3.Text);
                double temp = Convert.ToDouble(Data.rounds) / 2.0;
                Data.min_wins = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(Data.rounds) / 2.0));
                MessageBox.Show(Data.min_wins.ToString());
                Form1 f1 = this.Owner as Form1;
                if (f1 != null)
                {
                    f1.tableLayoutPanel1.Visible = true;
                }
                //f1.tableLayoutPanel1.Visible = true;
                this.Hide();
            }
            else
            {
                MessageBox.Show("Необходимо выбрать обоих игроков", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            */
        }

        private void form_pick_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
            comboBox3.SelectedIndex = 0;
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.players_list();
            //this.check_bd();
            timer1.Stop();
            //timer2.Start();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            check_bd();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.check_bd();
        }
        private void check_bd()
        {
            MySqlConnection connect = null;
            try
            {
                connect = new MySqlConnection(Data.connectionString);
                connect.Open();
                string query = "SELECT * FROM matches WHERE status='1'";
                MySqlCommand cmd = new MySqlCommand(query, connect);
                MySqlDataReader dataReader = cmd.ExecuteReader();
                int match = -1;
                int tournament = -1;
                int player1 = 0;
                int player2 = 0;
                while (dataReader.Read())
                {
                    match = Convert.ToInt32(dataReader["id"]);
                    tournament = Convert.ToInt32(dataReader["tournament"]);
                    player1 = Convert.ToInt32(dataReader["player1"]);
                    player2 = Convert.ToInt32(dataReader["player2"]);
                }
                if (match > 0)
                {
                    Data.match = match;
                    Data.tournament = tournament;
                    switch (get_rounds(tournament))
                    {
                        case 3:
                            comboBox3.SelectedIndex = 0;
                            break;
                        case 5:
                            comboBox3.SelectedIndex = 1;
                            break;
                        case 7:
                            comboBox3.SelectedIndex = 2;
                            break;
                        case 9:
                            comboBox3.SelectedIndex = 3;
                            break;
                    }
                    comboBox1.SelectedIndex = player1;
                    comboBox2.SelectedIndex = player2;
                    comboBox1.Enabled = false;
                    comboBox2.Enabled = false;
                    comboBox3.Enabled = false;
                    progressBar1.Style = ProgressBarStyle.Blocks;
                    progressBar1.Value = 100;
                    //MessageBox.Show("Игра найдена!","Поиск",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    //MessageBox.Show("Игра найдена!");
                }
                //else
                //{
                //   this.reset();
                    //MessageBox.Show("Игра не найдена!", "Поиск", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //MessageBox.Show("Игра не найдена!");
                //}
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
        private void reset()
        {
            comboBox1.Enabled = true;
            comboBox2.Enabled = true;
            comboBox3.Enabled = true;
            Data.match = -1;
            Data.tournament = -1;
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
            progressBar1.Style = ProgressBarStyle.Marquee;
            progressBar1.Value = 0;
        }
        private void button3_Click(object sender, EventArgs e)
        {
            this.reset();
        }
    }
}
