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

        private void Main_Load(object sender, EventArgs e)
        {
            Data.main = true;
            TableLayoutPanel tlp = new TableLayoutPanel();
            tlp.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            tlp.ColumnCount = 3;
            //ColumnStyle cs = new ColumnStyle(SizeType.Absolute, 50);
            //tlp.ColumnStyles.Add(cs);
            //tlp.ColumnStyles[0].Width = 100;
            //tlp.ColumnStyles[1].Width = 200;
            //tlp.ColumnStyles[5].Width = 100;
            tlp.Dock = DockStyle.Fill;
            tlp.AutoScroll = true;
            tabPlayers.Controls.Add(tlp);
            tlp.Margin = new Padding(50, 50, 50, 50);

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
                Label[] lbl_id = new Label[n+1];
                Label[] lbl_name = new Label[n + 1];
                Label[] lbl_birthday = new Label[n + 1];
                // заголовок
                lbl_id[0] = new Label()
                {
                    Text = "id"
                };
                tlp.Controls.Add(lbl_id[0]);
                lbl_name[0] = new Label()
                {
                    Text = "Игрок"
                };
                tlp.Controls.Add(lbl_name[0]);
                lbl_birthday[0] = new Label()
                {
                    Text = "Дата рождения"
                };
                tlp.Controls.Add(lbl_birthday[0]);
                for (int i = 1; i <= n; i++)
                {
                    dataReader.Read();
                    // id
                    lbl_id[i] = new Label()
                    {
                        Text = dataReader["id"].ToString()
                    };
                    tlp.Controls.Add(lbl_id[i]);
                    // player
                    lbl_name[i] = new Label()
                    {
                        Text = dataReader["player"].ToString()
                    };
                    tlp.Controls.Add(lbl_name[i]);
                    // birthday
                    string birthday = "-";
                    DateTime dt = new DateTime();
                    if (dataReader["birthday"].ToString() != "")
                    {
                        dt = Convert.ToDateTime(dataReader["birthday"]);
                        birthday = dt.ToString("dd MMMM yyyy");
                    }
                    //string birthday = String.Format("{0:MM.dd.yyyy}", dt);
                    //string birthday = dt.ToString("MM.dd.yyyy");
                    lbl_birthday[i] = new Label()
                    {
                        Text = birthday
                    };
                    tlp.Controls.Add(lbl_birthday[i]);
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
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            Data.main = false;
        }
    }
}
