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

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void form_add_tournament_Load(object sender, EventArgs e)
        {
            comboBox1.DataSource = Data.player_list();
        }

        private void button_OK_Click(object sender, EventArgs e)
        {
            MySqlConnection connect = null;
            try
            {
                connect = new MySqlConnection(Data.connectionString);
                connect.Open();
                string name, date, K, rounds, note, translit_name;

                name = textBox_name.Text;
                date = dateTimePicker_date.Value.ToString("yyyy-MM-dd");
                K = textBox_K.Text;
                note = textBox_note.Text;
                translit_name = textBox_translit_name.Text;
                rounds = comboBox_rounds.Text;

                string query = "INSERT INTO tournaments VALUES (null,'" + name + "','" + date + "','" + K + "','" + note + "','1','" + translit_name + "','" + rounds + "')";
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
            Main form_at = this.Owner as Main;
            if (form_at != null)
            {
                form_at.tournaments_update();
            }
            this.Close();
        }

        private void textBox_name_TextChanged(object sender, EventArgs e)
        {
            textBox_translit_name.Text = Data.GetTranslit(textBox_name.Text);
        }

        private void buttonAddPlayerInTournament_Click(object sender, EventArgs e)
        {
            string id, player;
            bool error = false;
            id = Data.player_id(comboBox1.Text).ToString();
            player = comboBox1.Text;

            for (int i = 0; i < dataPlayersInTournament.Rows.Count; i++)
            {
                if (dataPlayersInTournament.Rows[i].Cells[0].Value.ToString() == id) error = true;
            }
            if (comboBox1.SelectedIndex == -1) error = true;
            if (!error)
            {
                dataPlayersInTournament.Rows.Add(id, player);
            }
            if ((dataPlayersInTournament.Rows.Count > 3) & (dataPlayersInTournament.Rows.Count < 13))
            {
                button_OK.Enabled = true;
            }
            else
            {
                button_OK.Enabled = false;
            }
            label6.Text = "Игроки ("+dataPlayersInTournament.Rows.Count.ToString()+"):";
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

            if ((dataPlayersInTournament.Rows.Count > 3) & (dataPlayersInTournament.Rows.Count < 13))
            {
                button_OK.Enabled = true;
            }
            else
            {
                button_OK.Enabled = false;
            }
            label6.Text = "Игроки (" + dataPlayersInTournament.Rows.Count.ToString() + "):";
        }
    }
}
