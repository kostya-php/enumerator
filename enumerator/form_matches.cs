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
    public partial class form_matches : Form
    {
        public form_matches()
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
        // получаем имя игрока по его id
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
                    connect.Close();
                }
            }
            return result;
        }
        // получаем количество партий в турнире по его id
        private int get_rounds(int id)
        {
            int rounds = 0;
            MySqlConnection connect = null;
            try
            {
                connect = new MySqlConnection(Data.connectionString);
                connect.Open();

                string query = "SELECT * FROM tournaments WHERE id='" + id + "'";
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
                    connect.Close();
                }
            }
            return rounds;
        }
        // отображаем несыгранные встречи на форме
        private void form_matches_Load(object sender, EventArgs e)
        {
            Data.fm_fp = true;
            //this.ControlBox = false;
            MySqlConnection connect = null;
            try
            {
                connect = new MySqlConnection(Data.connectionString);
                connect.Open();
                string query = "SELECT Count(*) FROM matches WHERE status='0'";
                MySqlCommand cmd = new MySqlCommand(query, connect);
                int n = Convert.ToInt32(cmd.ExecuteScalar());
                if (n > 0)
                {
                    label1.Visible = false;
                    query = "SELECT * FROM matches WHERE status='0'";
                    cmd = new MySqlCommand(query, connect);
                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    Label[] labels = new Label[n];
                    Button[] buttons = new Button[n];
                    int width = 0;
                    for (int i = 0; i < n; i++)
                    {
                        dataReader.Read();
                        buttons[i] = new Button()
                        {
                            Name = "start_match_" + dataReader["id"].ToString(),
                            Text = "Вызвать игроков",
                            Location = new Point(12, (i * 29) + 12),
                            Size = new Size(75, 23)
                        };
                        buttons[i].Click += this.match_click;
                        labels[i] = new Label()
                        {
                            Name = "match_ " + dataReader["id"].ToString(),
                            AutoSize = true,
                            Location = new Point(12 + 75, (i * 29) + 15),
                            Text = player_name(Convert.ToInt32(dataReader["player1"])) + " - " + player_name(Convert.ToInt32(dataReader["player2"]))
                        };
                    }

                    this.Controls.AddRange(buttons);
                    this.Controls.AddRange(labels);
                    for (int i = 0; i < n; i++)
                    {
                        if (labels[i].Width > width) width = labels[i].Width;
                    }
                    this.Size = new Size(75 + width + 36, (n + 2) * 29 + 24);
                    this.Location = new Point((Screen.PrimaryScreen.Bounds.Width - this.Width) / 2,
                        (Screen.PrimaryScreen.Bounds.Height - this.Height) / 2);
                    dataReader.Close();
                    button_close.Location = new Point((this.Width / 2) - (75 / 2), (n * 29) + 12);
                    this.Text += " (" + (n).ToString() + ")";
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
        }
        public void match_click(object sender, EventArgs e)
        {
            // получаем id встречи
            string[] s = (sender as Button).Name.Split('_');
            Data.match = Convert.ToInt32(s[2]);
            // получаем текущие дату и время
            string start = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            Data.start = Convert.ToDateTime(start);
            MySqlConnection connect = null;
            try
            {
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
                    Data.player1 = player_name(Convert.ToInt32(dataReader["player1"]));
                    Data.player2 = player_name(Convert.ToInt32(dataReader["player2"]));
                    Data.tournament = Convert.ToInt32(dataReader["tournament"]);
                }
                dataReader.Close();
                // получаем количество партий
                Data.rounds = get_rounds(Data.tournament);
                // получаем минимальное количество побед
                double temp = Convert.ToDouble(Data.rounds) / 2.0;
                Data.min_wins = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(Data.rounds) / 2.0));
                Data.status = 0;
                // меняем статус встречи
                query = "UPDATE matches SET status='1', start='" + start + "' WHERE id='" + Data.match.ToString() + "'";
                cmd = new MySqlCommand(query, connect);
                cmd.ExecuteNonQuery();
                // отображаем данные на форме-счетчике и закрываем исходную форму
                Form1 f1 = this.Owner as Form1;
                if (f1 != null)
                {
                    f1.завершитьВстречуToolStripMenuItem.Enabled = true;
                    f1.выбратьИгроковToolStripMenuItem.Enabled = false;
                    f1.выбратьВстречуToolStripMenuItem.Enabled = false;
                    f1.pick();
                }
                Data.from_bd = true;
                Data.update_info();
                this.Close();
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

        private void button_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void form_matches_FormClosed(object sender, FormClosedEventArgs e)
        {
            Data.fm_fp = false;
        }
    }

}
