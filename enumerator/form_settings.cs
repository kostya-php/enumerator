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
using System.IO;

namespace enumerator
{
    public partial class form_settings : Form
    {
        public form_settings()
        {
            InitializeComponent();
        }

        private void form_settings_Load(object sender, EventArgs e)
        {
            textBox_host.Text = Properties.Settings.Default.host;
            textBox_database.Text = Properties.Settings.Default.database;
            textBox_user.Text = Properties.Settings.Default.user;
            textBox_password.Text = Properties.Settings.Default.password;
            textBox_log_path.Text = Properties.Settings.Default.log_path;
            saveFileDialog1.FileName = Path.GetFileName(Properties.Settings.Default.log_path);
            string dir = Path.GetDirectoryName(Properties.Settings.Default.log_path);
            saveFileDialog1.InitialDirectory = @dir;
        }

        private void button_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button_OK_Click(object sender, EventArgs e)
        {
            if (test())
            {
                Properties.Settings.Default.host = textBox_host.Text;
                Properties.Settings.Default.database = textBox_database.Text;
                Properties.Settings.Default.user = textBox_user.Text;
                Properties.Settings.Default.password = textBox_password.Text;

                Data.host = Properties.Settings.Default.host;
                Data.database = Properties.Settings.Default.database;
                Data.user = Properties.Settings.Default.user;
                Data.password = Properties.Settings.Default.password;
                Data.connectionString = "SERVER=" + Data.host + ";" + "DATABASE=" +
                    Data.database + ";" + "UID=" + Data.user + ";" + "PASSWORD=" + Data.password + ";CharSet=utf8;";

                this.Close();
            }
            else
            {
                MessageBox.Show("Ошибка соединения с Базой Данных! Подробности в консоли.", "Тестирование связи");
                form_console f2 = new form_console();
                if (!Data.use_console) f2.Show();
            }
            Properties.Settings.Default.log_path = textBox_log_path.Text;
            Properties.Settings.Default.Save();
        }

        private void button_test_Click(object sender, EventArgs e)
        {
            if (test())
            {
                MessageBox.Show("Соединение с Базой Данных успешно!", "Тестирование связи");
            }
            else
            {
                MessageBox.Show("Ошибка соединения с Базой Данных! Подробности в консоли.", "Тестирование связи");
                form_console f2 = new form_console();
                if (!Data.use_console) f2.Show();
            }
        }
        private bool test()
        {
            bool result = false;
            string host = textBox_host.Text;
            string database = textBox_database.Text;
            string user = textBox_user.Text;
            string password = textBox_password.Text;
            string connectionString = "SERVER=" + host + ";" + "DATABASE=" +
            database + ";" + "UID=" + user + ";" + "PASSWORD=" + password + ";CharSet=utf8;";
            MySqlConnection connect = null;
            try
            {
                connect = new MySqlConnection(connectionString);
                connect.Open();
                if (connect != null)
                {
                    result = true;
                }
            }
            catch (MySqlException err)
            {
                Data.console += DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " - " + "Ошибка: " + err.ToString() + Environment.NewLine;
                result = false;
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

        private void button_log_path_Click(object sender, EventArgs e)
        {
            saveFileDialog1.ShowDialog();
        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            //MessageBox.Show(saveFileDialog1.InitialDirectory);
            textBox_log_path.Text = saveFileDialog1.FileName;
            string[] s = saveFileDialog1.FileName.Split('\\');
            string dir = Path.GetDirectoryName(saveFileDialog1.FileName);
            saveFileDialog1.InitialDirectory = @dir;
        }
    }
}
