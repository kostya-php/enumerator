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
using System.Threading;

namespace enumerator
{
    public partial class form_tournaments : Form
    {
        public form_tournaments()
        {
            InitializeComponent();
        }

        public void tournaments_update()
        {
            this.Invoke((MethodInvoker)delegate()
            {
                dataTournaments.Rows.Clear();
            });
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
                    this.Invoke((MethodInvoker)delegate()
                    {
                        dataTournaments.Rows.Add(id, name, date);
                        Data.ft.Text = "Турниры (" + dataTournaments.Rows.Count.ToString() + ")";
                    });
                    Thread.Sleep(10);
                }
                dataReader.Close();

                query = "SELECT Count(*) FROM tournaments WHERE status='3'";
                cmd = new MySqlCommand(query, connect);
                int n2 = Convert.ToInt32(cmd.ExecuteScalar());
                this.Invoke((MethodInvoker)delegate()
                {
                    if (n == n2) buttonAddTournament.Enabled = true;
                    else buttonAddTournament.Enabled = false;
                });
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
                button1.Enabled = true;
            });
        }

        private void form_tournaments_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            //this.Visible = false;
            this.WindowState = FormWindowState.Minimized;
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
            DialogResult dr = MessageBox.Show("\"" + dataTournaments[1, index].Value.ToString() + "\"" + Environment.NewLine + "Вы действительно хотите удалить этот турнир?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
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
                //tournaments_update();
                //matches_update();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            Thread myThread = new Thread(tournaments_update);
            myThread.Start();
        }

        private void form_tournaments_Load(object sender, EventArgs e)
        {
            button1.Enabled = false;
            Thread myThread = new Thread(tournaments_update);
            myThread.Start();
        }
    }
}
