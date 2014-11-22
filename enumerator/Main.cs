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

        public void matches_update()
        {
            dataMatches.Rows.Clear();
            MySqlConnection connect = null;
            try
            {
                connect = new MySqlConnection(Data.connectionString);
                connect.Open();
                string query = "SELECT * FROM tournaments WHERE status='1'";
                MySqlCommand cmd = new MySqlCommand(query, connect);
                MySqlDataReader dataReader = cmd.ExecuteReader();
                int t = -1;
                while (dataReader.Read())
                {
                    t = Convert.ToInt32(dataReader["id"]);
                }
                dataReader.Close();
                if (t > 0)
                {

                    query = "SELECT Count(*) FROM matches WHERE tournament='" + t.ToString() + "'";
                    cmd = new MySqlCommand(query, connect);
                    int n = Convert.ToInt32(cmd.ExecuteScalar());
                    if (n > 0)
                    {
                        //query = "SELECT * FROM matches WHERE tournament='" + t.ToString() + "' AND !ISNULL(player1) AND !ISNULL(player2) ORDER BY id ASC";
                        query = "SELECT * FROM matches WHERE status='0' AND !ISNULL(player1) AND !ISNULL(player2) ORDER BY id ASC";
                        cmd = new MySqlCommand(query, connect);
                        dataReader = cmd.ExecuteReader();
                        string players, id, tournament;
                        int number = 1;
                        while (dataReader.Read())
                        {
                            if (dataReader["status"].ToString() == "0")
                            {
                                string p1 = "", p2 = "";
                                if (dataReader["player1"].ToString() != "")
                                {
                                    p1 = Data.player_name(Convert.ToInt32(dataReader["player1"]));
                                }
                                else
                                {
                                    p1 = "?";
                                }
                                if (dataReader["player2"].ToString() != "")
                                {
                                    p2 = Data.player_name(Convert.ToInt32(dataReader["player2"]));
                                }
                                else
                                {
                                    p2 = "?";
                                }
                                //players = Data.player_name(Convert.ToInt32(dataReader["player1"])) + " - " + Data.player_name(Convert.ToInt32(dataReader["player2"]));
                                players = p1 + " - " + p2;
                                id = dataReader["id"].ToString();
                                tournament = Data.tournament_name(Convert.ToInt32(dataReader["tournament"]));
                                number = Convert.ToInt32(dataReader["number"]);
                                dataMatches.Rows.Add(number.ToString(),tournament, p1, p2, id);
                            }
                            number++;
                        }
                        dataReader.Close();
                    }
                }
                groupBox3.Text = "Доступные встречи (" + dataMatches.Rows.Count.ToString() + ")";
                string protocol = Data.get_protocol(Data.get_current_tournament());
                if (protocol == "vib8")
                {
                    Data.update_vib8();
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
            textBox1.Text = "";
        }

        private void Main_Load(object sender, EventArgs e)
        {
            //Data.krug.Show();
            label1.Text = "";
            label2.Text = "Стол свободен";
            Data.use_console = false;
            Data.from_bd = false;
            Data.edited_player = -1;
            matches_update();
            timer_InitDevices.Start();
            Data.update_info();
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            if ((Data.player1 != null) & (Data.player2 != null))
                Data.abort_game();
        }

        private void buttonOpenEnumerator1_Click(object sender, EventArgs e)
        {
            if (!Data.f1.Visible) Data.f1.Show();
            else
            {
                Data.f1.WindowState = FormWindowState.Normal;
                Data.f1.Focus();
            }
            //if (!Data.f1.Visible) Data.f1.Visible = true;
        }

        // При закрытии формы какая-то хрень нужна
        private void Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            KBDHook.UnInstallHook(); // Обязательно !!!
        }

        private void buttonOpenEnumerator2_Click(object sender, EventArgs e)
        {
            if (!Data.f2.Visible) Data.f2.Show();
            else
            {
                Data.f2.WindowState = FormWindowState.Normal;
                Data.f2.Focus();
            }
            //if (!Data.f2.Visible) Data.f2.Visible = true;
        }
        public void start_match()
        {
            if (dataMatches.Rows.Count > 0)
            {
                // получаем id встречи
                int index = dataMatches.CurrentRow.Index;
                Data.match = Convert.ToInt32(dataMatches.Rows[index].Cells[3].Value);
                // получаем текущие дату и время
                string start = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                Data.start = start;
                MySqlConnection connect = null;
                try
                {
                    buttonStartMatch.Enabled = false;
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
                        Data.player1 = Data.player_name(Convert.ToInt32(dataReader["player1"]));
                        Data.player2 = Data.player_name(Convert.ToInt32(dataReader["player2"]));
                        Data.tournament = Convert.ToInt32(dataReader["tournament"]);
                    }
                    dataReader.Close();
                    // получаем количество партий
                    Data.rounds = Data.get_rounds(Data.tournament);
                    // получаем минимальное количество побед
                    double temp = Convert.ToDouble(Data.rounds) / 2.0;
                    Data.min_wins = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(Data.rounds) / 2.0));
                    Data.status = 0;
                    // меняем статус встречи
                    query = "UPDATE matches SET status='1', start='" + start + "' WHERE id='" + Data.match.ToString() + "'";
                    cmd = new MySqlCommand(query, connect);
                    cmd.ExecuteNonQuery();
                    // отображаем данные на форме-счетчике и закрываем исходную форму
                    /*
                    Form1 f1 = this.Owner as Form1;
                    if (f1 != null)
                    {
                        f1.завершитьВстречуToolStripMenuItem.Enabled = true;
                        f1.выбратьИгроковToolStripMenuItem.Enabled = false;
                        f1.выбратьВстречуToolStripMenuItem.Enabled = false;
                        Data.pick();
                    }
                    */
                    Data.pick();
                    Data.from_bd = true;
                    Data.update_info();
                    matches_update();
                    buttonCancelMatch.Enabled = true;
                    Data.f1.label_timer.Text = "00:00";
                    Data.f2.label_timer.Text = "00:00";
                    label1.Text = Data.player1;
                    label2.Text = Data.player2;
                    button_techpor1.Visible = true;
                    button_techpor2.Visible = true;
                    button_noplay.Visible = true;
                }
                catch (MySqlException err)
                {
                    MessageBox.Show("Ошибка: " + err.ToString());
                    buttonCancelMatch.Enabled = false;
                    buttonStartMatch.Enabled = true;
                }
                finally
                {
                    if (connect != null)
                    {
                        connect.Close();
                    }
                }
            }
        }
        private void buttonStartMatch_Click(object sender, EventArgs e)
        {
            start_match();
        }

        private void buttonCancelMatch_Click(object sender, EventArgs e)
        {
            buttonCancelMatch.Enabled = false;
            Data.abort_game();
            matches_update();
            buttonStartMatch.Enabled = true;
            label1.Text = "";
            label2.Text = "Стол свободен";
            button_techpor1.Visible = false;
            button_techpor2.Visible = false;
            button_noplay.Visible = false;
        }

        private void timer_UpdateJoystick_Tick(object sender, EventArgs e)
        {
            if (Data.joystick != null)
                Data.UpdateJoystick();
        }

        private void timer_InitDevices_Tick(object sender, EventArgs e)
        {
            if (!Data.fm.timer_UpdateJoystick.Enabled) Data.InitDevices();
        }

        private void timer_Enumerator_Tick(object sender, EventArgs e)
        {
            DateTime start_datetime = Convert.ToDateTime(Data.start);
            string now = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            DateTime end_datetime = Convert.ToDateTime(now);
            TimeSpan delta = end_datetime - start_datetime;
            string time = delta.ToString(@"mm\:ss");
            Data.f1.label_timer.Text = time.ToString();
            Data.f2.label_timer.Text = time.ToString();
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void SettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            form_settings fs = new form_settings();
            fs.ShowDialog();
        }

        private void ControlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string control =
                "Для начала счета необходимо выбрать одну из доступных встреч и назначить первоначальную подачу стрелками (<-)/(->) или кнопками джойстика (7)/(8)." + Environment.NewLine +
                "Клавиатура:" + Environment.NewLine +
                "(<-)/(->) - присвоить очко игроку" + Environment.NewLine +
                "(Esc) - отменить последнее присвоенное очко" + Environment.NewLine +
                "(F5) - сменить первоначальную подачу" + Environment.NewLine +
                "(Space) - поменять игроков местами" + Environment.NewLine +
                "(Enter) - подтвердить результат партии/вызвать следующих игроков" + Environment.NewLine +
                "(F1)/(F2) - вкл/выкл полноэкранный режим для Счетчика" + Environment.NewLine +
                "(F3)/(F4) - вкл/выкл полноэкранный режим для Счетчика (реверс)" + Environment.NewLine +
                "Джойстик:" + Environment.NewLine +
                "(7)/(8) - присвоить очко игроку" + Environment.NewLine +
                "(1) - отменить последнее присвоенное очко" + Environment.NewLine +
                "(2) - сменить первоначальную подачу" + Environment.NewLine +
                "(3) - поменять игроков местами" + Environment.NewLine +
                "(6) - подтвердить результат партии/вызвать следующих игроков" + Environment.NewLine;
            MessageBox.Show(control, "Управление", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string about =
                "Программа выводит интерактивный счетчик для настольного тенниса, а также автоматизирует добавление данных о турнире, встречах и их результатах.";
            MessageBox.Show(about, "О программе", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://rating.t-t.pp.ua/");
        }

        private void toolStripStatusLabel2_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://rating.t-t.pp.ua/update/");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            matches_update();
            /*
            string protocol = Data.get_protocol(Data.get_current_tournament());
            switch (protocol)
            {
                case "krug":
                    //Data.krug.Show();
                    MessageBox.Show("Таблица результатов в круговую на данный момент в разработке.");
                    break;
                case "vib8":
                    //Data.update_vib8();
                    break;
                default:
                    MessageBox.Show("Сейчас нет активных турниров");
                    break;
            }
            */
            //Data.update_vib8();
        }

        private void techpor(int id, int p)
        {
            MySqlConnection connect = null;
            try
            {
                connect = new MySqlConnection(Data.connectionString);
                connect.Open();
                string query = "";
                if (p == 1)
                {
                    query = "UPDATE matches SET status='3', start=null, end=null, x='0', y='" + Data.min_wins.ToString() + "' WHERE id='" + id.ToString() + "'";
                }
                if (p == 2)
                {
                    query = "UPDATE matches SET status='3', start=null, end=null, x='" + Data.min_wins.ToString() + "', y='0' WHERE id='" + id.ToString() + "'";
                }
                MySqlCommand cmd = new MySqlCommand(query, connect);
                cmd.ExecuteNonQuery();
            }
            catch (MySqlException err)
            {
                MessageBox.Show("Ошибка: " + err.ToString());
            }
            finally
            {
                timer_Enumerator.Stop();
                Data.full_reset();
                Data.f1.label_timer.Text = "00:00";
                Data.f2.label_timer.Text = "00:00";
                buttonCancelMatch.Enabled = false;
                buttonStartMatch.Enabled = true;
                label1.Text = "";
                label2.Text = "Стол свободен";
                button_techpor1.Visible = false;
                button_techpor2.Visible = false;
                button_noplay.Visible = false;
                matches_update();
                if (connect != null)
                {
                    connect.Close();
                }
            }
        }

        private void button_techpor1_Click(object sender, EventArgs e)
        {
            if ((Data.status == 0) || (Data.status == 1))
            {
                DialogResult res = MessageBox.Show("Назначить игроку " + Data.player1.ToString() + " техническое поражение?", "Подтверждение", MessageBoxButtons.OKCancel);
                if (res == DialogResult.OK)
                {
                    int id = Data.match;
                    this.techpor(id, 1);
                }
            }
        }

        private void button_techpor2_Click(object sender, EventArgs e)
        {
            if ((Data.status == 0) || (Data.status == 1))
            {
                DialogResult res = MessageBox.Show("Назначить игроку " + Data.player2.ToString() + " техническое поражение?", "Подтверждение", MessageBoxButtons.OKCancel);
                if (res == DialogResult.OK)
                {
                    int id = Data.match;
                    this.techpor(id, 2);
                }
            }
        }

        private void button_noplay_Click(object sender, EventArgs e)
        {
            if ((Data.status == 0) || (Data.status == 1))
            {
                DialogResult res = MessageBox.Show("Встреча между игроками " + Environment.NewLine + Data.player1.ToString() + " - " + Data.player2.ToString() + Environment.NewLine + " действительно не состоялась?", "Подтверждение", MessageBoxButtons.OKCancel);
                if (res == DialogResult.OK)
                {
                    MySqlConnection connect = null;
                    try
                    {
                        int id = Data.match;
                        connect = new MySqlConnection(Data.connectionString);
                        connect.Open();
                        string query = "UPDATE matches SET status='4', start=null, end=null, x='0', y='0' WHERE id='" + id.ToString() + "'";
                        MySqlCommand cmd = new MySqlCommand(query, connect);
                        cmd.ExecuteNonQuery();
                    }
                    catch (MySqlException err)
                    {
                        MessageBox.Show("Ошибка: " + err.ToString());
                    }
                    finally
                    {
                        timer_Enumerator.Stop();
                        Data.full_reset();
                        Data.f1.label_timer.Text = "00:00";
                        Data.f2.label_timer.Text = "00:00";
                        buttonCancelMatch.Enabled = false;
                        buttonStartMatch.Enabled = true;
                        label1.Text = "";
                        label2.Text = "Стол свободен";
                        button_techpor1.Visible = false;
                        button_techpor2.Visible = false;
                        button_noplay.Visible = false;
                        matches_update();
                        if (connect != null)
                        {
                            connect.Close();
                        }
                    }
                }
            }
        }

        private void таблицаРезультатовToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string protocol = Data.get_protocol(Data.get_current_tournament());
            switch (protocol)
            {
                case "krug":
                    if (!Data.krug.Visible) Data.krug.Show();
                    else
                    {
                        Data.krug.WindowState = FormWindowState.Normal;
                        Data.krug.Focus();
                    }
                    //Data.krug.Show();
                    //MessageBox.Show("Таблица результатов в круговую на данный момент в разработке.");
                    break;
                case "vib8":
                    Data.v8.Show();
                    break;
                default:
                    MessageBox.Show("Сейчас нет активных турниров");
                    break;
            }
        }

        private void игрокиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!Data.fp.Visible) Data.fp.Show();
            else
            {
                Data.fp.WindowState = FormWindowState.Normal;
                Data.fp.Focus();
            }
        }

        private void турнирыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Data.ft
            if (!Data.ft.Visible) Data.ft.Show();
            else
            {
                Data.ft.WindowState = FormWindowState.Normal;
                Data.ft.Focus();
            }
        }

        private void счетчикToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!Data.f1.Visible) Data.f1.Show();
            else
            {
                Data.f1.WindowState = FormWindowState.Normal;
                Data.f1.Focus();
            }
        }

        private void счетчикреверсToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!Data.f2.Visible) Data.f2.Show();
            else
            {
                Data.f2.WindowState = FormWindowState.Normal;
                Data.f2.Focus();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            bool first_find = false;
            foreach (DataGridViewRow row in dataMatches.Rows)
            {
                if ((row.Cells[1].Value.ToString().IndexOf(textBox1.Text, StringComparison.CurrentCultureIgnoreCase) >= 0) | (row.Cells[2].Value.ToString().IndexOf(textBox1.Text, StringComparison.CurrentCultureIgnoreCase) >= 0) | (row.Cells[3].Value.ToString().IndexOf(textBox1.Text, StringComparison.CurrentCultureIgnoreCase) >= 0))
                //if (row.Cells[1].Value.ToString().Contains(textBox1.Text))
                {
                    dataMatches.Rows[row.Index].Visible = true;
                    if (!first_find)
                    {
                        dataMatches.Rows[row.Index].Cells[1].Selected = true;
                        first_find = true;
                    }
                }
                else
                {
                    dataMatches.Rows[row.Index].Visible = false;
                }
            }
        }
    }
}
