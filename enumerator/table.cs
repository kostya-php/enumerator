using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Imaging;
using MySql.Data.MySqlClient;

namespace enumerator
{
    public partial class table : Form
    {
        public table()
        {
            InitializeComponent();
        }
        private void draw_table(int t)
        {
            MySqlConnection connect = null;
            try
            {
                connect = new MySqlConnection(Data.connectionString);
                connect.Open();
                string query = "SELECT Count(*) FROM in_tournament WHERE tournament='" + t.ToString() + "'";
                MySqlCommand cmd = new MySqlCommand(query, connect);
                int players = Convert.ToInt32(cmd.ExecuteScalar());
                //int players = Convert.ToInt32(textBox1.Text);
                int p_width = 200;
                int res_size = 50;
                Pen pen1 = new Pen(Color.Black, 3);
                Graphics g = this.CreateGraphics();
                g.Clear(Color.FromArgb(0xFF, 0xF0, 0xF0, 0xF0));
                // Горизонтальные линии
                g.DrawLine(pen1, 50, 50, 50 + p_width + (res_size * 2) + (res_size * players), 50);
                g.DrawLine(pen1, 50, 50 + res_size, 50 + p_width + (res_size * 2) + (res_size * players), 50 + res_size);
                for (int i = 1; i <= players; i++)
                {
                    g.DrawLine(pen1, 50, 50 + res_size + (res_size * i), 50 + p_width + (res_size * 2) + (res_size * players), 50 + res_size + (res_size * i));
                }
                // Вертикальные линии
                g.DrawLine(pen1, 50, 50, 50, 50 + res_size + (res_size * players));
                g.DrawLine(pen1, 50 + p_width, 50, 50 + p_width, 50 + res_size + (res_size * players));
                for (int i = 1; i <= players; i++)
                {
                    g.DrawLine(pen1, 50 + p_width + (res_size * i), 50, 50 + p_width + (res_size * i), 50 + res_size + (res_size * players));
                }
                g.DrawLine(pen1, 50 + p_width + res_size + (res_size * players), 50, 50 + p_width + res_size + (res_size * players), 50 + res_size + (res_size * players));
                g.DrawLine(pen1, 50 + p_width + (res_size * 2) + (res_size * players), 50, 50 + p_width + (res_size * 2) + (res_size * players), 50 + res_size + (res_size * players));

                // Create font and brush.
                Font drawFont = new Font("Arial", 16);
                SolidBrush drawBrush = new SolidBrush(Color.Black);

                // Create point for upper-left corner of drawing.
                //PointF drawPoint = new PointF(150.0F, 50.0F);
                Point drawPoint = new Point(105, 65);

                // Set format of string.
                StringFormat drawFormat = new StringFormat();
                drawFormat.FormatFlags = StringFormatFlags.NoWrap;

                // Draw string to screen.
                g.DrawString("Игроки", drawFont, drawBrush, drawPoint, drawFormat);

                for (int i = 1; i <= players; i++)
                {
                    g.DrawString(i.ToString(), drawFont, drawBrush, new Point(p_width + 15 + (50 * i), 65), drawFormat);
                }
                g.DrawString("О", drawFont, drawBrush, new Point(p_width + 15 + (50 * (players + 1)), 65), drawFormat);
                g.DrawString("М", drawFont, drawBrush, new Point(p_width + 15 + (50 * (players + 2)), 65), drawFormat);

                string[] pl = new string[players];
                query = "SELECT * FROM in_tournament WHERE tournament='"+t.ToString()+"' ORDER BY number ASC";
                cmd = new MySqlCommand(query, connect);
                MySqlDataReader dataReader = cmd.ExecuteReader();
                int k = 0;
                while (dataReader.Read())
                {
                    pl[k] = Data.player_name(Convert.ToInt32(dataReader["player"]));
                    k++;
                }
                /*
                pl[0] = "Салынский Иван";
                pl[1] = "Охмак Николай";
                pl[2] = "Шипка Роман";
                pl[3] = "Янина Надежда";
                pl[4] = "Пришвин Константин";
                pl[5] = "Ткаченко Александр";
                */
                for (int i = 1; i <= players; i++)
                {
                    g.DrawString(pl[i - 1], new Font("Arial", 14), drawBrush, new Point(50, 65 + (res_size * i)), drawFormat);
                }

                for (int i = 1; i <= players; i++)
                {
                    for (int j = 1; j <= players; j++)
                    {
                        // Диагональ
                        if (i == j)
                        {
                            g.DrawString("-", new Font("Arial", 14), drawBrush, new Point(15 + p_width + (50 * i), 65 + (50 * j)), drawFormat);
                        }
                        if (i > j)
                        {
                            g.DrawString(j.ToString()+":"+i.ToString(), new Font("Arial", 14), drawBrush, new Point(15 + p_width + (50 * i), 65 + (50 * j)), drawFormat);
                        }

                    }
                }
                pen1.Dispose();
                g.Dispose();
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

        private void table_Load(object sender, EventArgs e)
        {
            MySqlConnection connect = null;
            try
            {
                connect = new MySqlConnection(Data.connectionString);
                connect.Open();
                string query = "SELECT * FROM tournaments ORDER BY id ASC";
                MySqlCommand cmd = new MySqlCommand(query, connect);
                MySqlDataReader dataReader = cmd.ExecuteReader();
                while (dataReader.Read())
                {
                    comboBox1.Items.Add(dataReader["name"]);
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            draw_table(comboBox1.SelectedIndex + 1);
        }
    }
}
