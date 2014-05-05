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
        public void grid_update()
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
        }
        private void Main_Load(object sender, EventArgs e)
        {
            Data.main = true;
            Data.edited_player = -1;
            grid_update();
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            Data.main = false;
            if ((Data.player1 != null) & (Data.player2 != null))
                Data.abort_game();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            Data.edited_player = -1;
            form_add_edit_player form_aep = new form_add_edit_player();
            form_aep.Owner = this;
            form_aep.ShowDialog();
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            int index = dataPlayers.CurrentRow.Index;
            Data.edited_player = Convert.ToInt32(dataPlayers.Rows[index].Cells[0].Value);
            form_add_edit_player form_aep = new form_add_edit_player();
            form_aep.Owner = this;
            form_aep.ShowDialog();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
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
                grid_update();
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
    }
}
