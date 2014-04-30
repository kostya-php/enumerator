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
        private void form_matches_Load(object sender, EventArgs e)
        {
            MySqlConnection connect = null;
            try
            {
                connect = new MySqlConnection(Data.connectionString);
                connect.Open();
                string query = "SELECT Count(*) FROM matches WHERE status='0'";
                MySqlCommand cmd = new MySqlCommand(query, connect);
                int n = Convert.ToInt32(cmd.ExecuteScalar());
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
                        Name = "start_match_"+dataReader["id"].ToString(),
                        Text = "Вызвать игроков", Location = new Point(12, (i*29) + 12),
                        Size = new Size (75,23)
                    };
                    labels[i] = new Label() 
                    {
                        Name = "match_ " + dataReader["id"].ToString(),
                        AutoSize = true,
                        Location = new Point(12 + 75, (i*29) + 15),
                        Text = player_name(Convert.ToInt32(dataReader["player1"])) + " - " + player_name(Convert.ToInt32(dataReader["player2"]))
                    };
                }
                /*
                while (dataReader.Read())
                {
                    Label lbl = new Label();
                    lbl.Name = "match_" + dataReader["id"].ToString();
                    lbl.Text = dataReader["player1"].ToString() + " - " + dataReader["player2"].ToString();
                    lbl.Top = 9 * i;
                    lbl.Left = 10;
                    this.Controls.Add(lbl);
                    MessageBox.Show(i.ToString());
                    i++;
                }
                 * */

                this.Controls.AddRange(buttons);
                this.Controls.AddRange(labels);
                for (int i = 0; i < n; i++)
                {
                    if (labels[i].Width > width) width = labels[i].Width;
                }
                this.Size = new Size(75 + width + 24, (n+2) * 29 + 12);
                this.Location = new Point((Screen.PrimaryScreen.Bounds.Width - this.Width) / 2,
                    (Screen.PrimaryScreen.Bounds.Height - this.Height) / 2);
                dataReader.Close();

                Button btn = new Button()
                {
                    Name = "close",
                    Text = "Закрыть",
                    Location = new Point((this.Width / 2) - (75 / 2), (n * 29) + 12),
                    Size = new Size(75, 23)
                };
                this.Controls.Add(btn);
                this.Text += " ("+(n).ToString()+")";
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
    }

}
