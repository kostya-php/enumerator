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
using System.Net;
using System.IO;
using System.Threading;

namespace enumerator
{
    public partial class form_players : Form
    {
        public form_players()
        {
            InitializeComponent();
        }

        private void form_players_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Visible = false;
            //this.WindowState = FormWindowState.Minimized;
        }
        public void players_update()
        {
            this.Invoke((MethodInvoker)delegate()
            {
                dataPlayers.Rows.Clear();
                textBox1.Text = "";
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
                    string path = dataReader["photo"].ToString();

                    this.Invoke((MethodInvoker)delegate()
                    {
                        dataPlayers.Rows.Add(id, player, path);
                        Data.fp.Text = "Игроки (" + dataPlayers.Rows.Count.ToString() + ")";
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
                //dataPlayers.Rows[index].Cells[0].Selected = true;
                button1.Enabled = true;
                textBox1.Enabled = true;
                toolStripStatusLabel1.Text = "Показаны все игроки: " + dataPlayers.Rows.Count.ToString();
            });

            //dataPlayers.Sort(dataPlayers.Columns[1], ListSortDirection.Ascending);
        }

        private void form_players_Load(object sender, EventArgs e)
        {
            //players_update();
            Thread myThread = new Thread(players_update);
            myThread.Start();
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
            if (!(dataPlayers.SelectedRows.Count < 1))
            {
                int index = dataPlayers.CurrentRow.Index;
                Data.edited_player = Convert.ToInt32(dataPlayers.Rows[index].Cells[0].Value);
                form_add_edit_player form_aep = new form_add_edit_player();
                form_aep.Owner = this;
                form_aep.ShowDialog();
            }
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

        private void dataPlayers_SortCompare(object sender, DataGridViewSortCompareEventArgs e)
        {
            if (e.Column.Index == 0)
            {
                e.SortResult = int.Parse(e.CellValue1.ToString()).CompareTo(int.Parse(e.CellValue2.ToString()));
                e.Handled = true;
            }
        }

        private void dataPlayers_SelectionChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            textBox1.Enabled = false;
            Thread myThread = new Thread(players_update);
            myThread.Start();
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
            if (textBox1.Text != "") toolStripStatusLabel1.Text = "Найдено игроков: " + dataPlayers.DisplayedRowCount(true).ToString();
            else toolStripStatusLabel1.Text = "Показаны все игроки: " + dataPlayers.Rows.Count.ToString();
        }
    }
}
