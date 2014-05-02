using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using MySql.Data.MySqlClient;
using Hooks;
using Microsoft.DirectX.DirectInput;
using System.Threading;
using System.IO;

namespace enumerator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            KBDHook.KeyDown += new KBDHook.HookKeyPress(KBDHook_KeyDown);
            KBDHook.LocalHook = false;
            KBDHook.InstallHook();
            //System.Windows.Forms.Control.CheckForIllegalCrossThreadCalls = false;
            Data.button_7 = 0;
            Data.button_8 = 0;
        }
        #region Джойстик

        Device joystick;
        // Функция инициализации джойстика
        private void InitDevices()
        {
            joystick = null;
            // Поиск джойстика
            foreach (
                DeviceInstance di in
                Manager.GetDevices(
                    DeviceClass.GameControl,
                    EnumDevicesFlags.AttachedOnly))
            {
                joystick = new Device(di.InstanceGuid);
                break;
            }
            if (joystick != null)
            {
                // Установка диапазона осей на джойстике
                foreach (DeviceObjectInstance doi in joystick.Objects)
                {
                    if ((doi.ObjectId & (int)DeviceObjectTypeFlags.Axis) != 0)
                    {
                        joystick.Properties.SetRange(
                            ParameterHow.ById,
                            doi.ObjectId,
                            new InputRange(-5000, 5000));
                    }
                }
                // Установка абсолютного режима осей на джойстике
                joystick.Properties.AxisModeAbsolute = true;
                joystick.SetCooperativeLevel(
                this,
                CooperativeLevelFlags.NonExclusive |
                CooperativeLevelFlags.Background);
                // Acquire devices for capturing (хз че это)
                joystick.Acquire();
                // Остановка таймера, запускающего инициализацию
                timer2.Stop();
                // Запуск таймера, проверяющего состояние джойстика
                timer1.Start();
                // Надпись "Joystick: online" и зеленая картинка внизу окна программы (в оконном режиме)
                joystick_status.Text = "Joystick: online";
                Image img = Properties.Resources.online.ToBitmap();
                joystick_status.Image = img;
                // Запись изменения в лог
                write_log("Joystick connected");
            }
        }
        // Фукция проверки состояния джойстика и снятие показаний о нажатых кнопках
        private void UpdateJoystick()
        {
            try
            {
                JoystickState state = joystick.CurrentJoystickState;
                byte[] buttons = state.GetButtons();
                for (int i = 0; i < buttons.Length; i++)
                {
                    int b = i + 1;
                    if (buttons[i] != 0)
                    {
                        switch (b)
                        {
                            case 1:
                                if (Data.button_1 == 0)
                                {
                                    if (Data.history != "")
                                    {
                                        cancel();
                                    }
                                    Data.button_1 = 1;
                                }
                                break;
                            case 2:
                                if (Data.button_2 == 0)
                                {
                                    if (Data.status == 1)
                                    {
                                        switch_inning();
                                    }
                                    Data.button_2 = 1;
                                }
                                break;
                            case 3:
                                if (Data.button_3 == 0)
                                {
                                    if ((Data.status == 1)|(Data.status == 0))
                                    {
                                        reverse();
                                        switch_inning();
                                    }
                                    Data.button_3 = 1;
                                }
                                break;
                            case 4:
                                if (Data.button_4 == 0)
                                {
                                    if (Data.status == -1)
                                    {
                                        form_matches fm = new form_matches();
                                        if (!Data.fm_fp)
                                        {
                                            fm.Owner = this;
                                            fm.ShowDialog();
                                        }
                                    }
                                    Data.button_4 = 1;
                                }
                                break;
                            case 5:
                                if (Data.button_5 == 0)
                                {
                                    if (Data.status == -1)
                                    {
                                        form_pick fp = new form_pick();
                                        if (!Data.fm_fp)
                                        {
                                            fp.Owner = this;
                                            fp.ShowDialog();
                                        }
                                    }
                                    Data.button_5 = 1;
                                }
                                break;
                            case 6:
                                if (Data.button_6 == 0)
                                {
                                    if (Data.status == -1)
                                    {
                                        if (info.Text != "Ожидание встречи") write_log("Встреча окончена");
                                        full_reset();
                                        label_timer.Text = "00:00";
                                        info.Text = "Ожидание встречи";
                                        завершитьВстречуToolStripMenuItem.Enabled = false;
                                        выбратьИгроковToolStripMenuItem.Enabled = true;
                                        выбратьВстречуToolStripMenuItem.Enabled = true;
                                    }
                                    else
                                        if (Data.status == 2)
                                        {
                                            Data.query += "INSERT INTO rounds VALUES (null,'" + Data.match + "','" + (Data.x + Data.y).ToString() + "','" + Data.xx + "','" + Data.yy + "');";
                                            Data.status = 3;
                                            info.Text = "";
                                            Data.history = "";
                                            reset_score();
                                        }
                                    Data.button_6 = 1;
                                }
                                break;
                            case 7:
                                if (Data.button_7 == 0)
                                {
                                    if (Data.status == 0) inning(1);
                                    else
                                        if (Data.status == 1)
                                            add_point(Data.reverse, "xx");
                                    Data.button_7 = 1;
                                }
                                break;
                            case 8:
                                if (Data.button_8 == 0)
                                {
                                    if (Data.status == 0) inning(2);
                                    else
                                        if (Data.status == 1)
                                            add_point(Data.reverse, "yy");
                                    Data.button_8 = 1;
                                }
                                break;
                        }
                    }
                    else
                    {
                        switch (b)
                        {
                            case 1:
                                Data.button_1 = 0;
                                break;
                            case 2:
                                Data.button_2 = 0;
                                break;
                            case 3:
                                Data.button_3 = 0;
                                break;
                            case 4:
                                Data.button_4 = 0;
                                break;
                            case 5:
                                Data.button_5 = 0;
                                break;
                            case 6:
                                Data.button_6 = 0;
                                break;
                            case 7:
                                Data.button_7 = 0;
                                break;
                            case 8:
                                Data.button_8 = 0;
                                break;
                        }
                    }
                }
            }
            // Обработка исключения (например, если джойстик внезапно отключили)
            catch (Exception e)
            {
                // Остановка таймера, проверяющего состояние джойстика
                timer1.Stop();
                // Запуск таймера, запускающиего инициализацию джойстика
                timer2.Start();
                // Надпись "Joystick: offline" и красная картинка внизу окна программы (в оконном режиме)
                joystick_status.Text = "Joystick: offline";
                Image img = Properties.Resources.offline;
                joystick_status.Image = img;
                // Запись в лог
                write_log("Joystick disconnected " + e.ToString());
            }
        }
        #endregion

        // Хук клавиатуры
        void KBDHook_KeyDown(LLKHEventArgs e)
        {
            switch (e.Keys)
            {
                case Keys.Left:
                    if (Data.status == 0) inning(1);
                    else
                        if (Data.status == 1)
                        {
                            add_point(Data.reverse, "xx");
                            e.Hooked = true;
                        }
                    break;

                case Keys.Right:
                    if (Data.status == 0) inning(2);
                    else
                        if (Data.status == 1)
                        {
                            add_point(Data.reverse, "yy");
                            e.Hooked = true;
                        }
                    break;

                case Keys.F1:
                    GoFullscreen(true);
                    e.Hooked = true;
                    break;

                case Keys.F2:
                    GoFullscreen(false);
                    e.Hooked = true;
                    break;

                case Keys.F4:
                    if (Data.status == 1)
                    {
                        switch_inning();
                        e.Hooked = true;
                    }
                    break;

                case Keys.Space:
                    if (Data.status == 1)
                    {
                        reverse();
                        switch_inning();
                        e.Hooked = true;
                    }
                    break;

                case Keys.Enter:
                    if (Data.status == -1)
                    {
                        if (info.Text != "Ожидание встречи") write_log("Встреча окончена");
                        full_reset();
                        label_timer.Text = "00:00";
                        info.Text = "Ожидание встречи";
                        завершитьВстречуToolStripMenuItem.Enabled = false;
                        выбратьИгроковToolStripMenuItem.Enabled = true;
                        выбратьВстречуToolStripMenuItem.Enabled = true;
                    }
                    else
                        if (Data.status == 2)
                        {
                            Data.query += "INSERT INTO rounds VALUES (null,'" + Data.match + "','" + (Data.x + Data.y).ToString() + "','" + Data.xx + "','" + Data.yy + "');";
                            Data.status = 3;
                            info.Text = "";
                            Data.history = "";
                            reset_score();
                        }
                    e.Hooked = true;
                    break;

                case Keys.Escape:
                    cancel();
                    e.Hooked = true;
                    break;
            }
        }
        // При закрытии формы какая-то хрень нужна
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            KBDHook.UnInstallHook(); // Обязательно !!!
        }
        // На полный экран
        private void GoFullscreen(bool fullscreen)
        {
            if (fullscreen)
            {
                statusStrip1.Visible = false;
                menuStrip1.Visible = false;
                this.WindowState = FormWindowState.Normal;
                this.FormBorderStyle = FormBorderStyle.None;
                this.WindowState = FormWindowState.Maximized;
                change_font_size();
            }
            else
            {
                statusStrip1.Visible = true;
                menuStrip1.Visible = true;
                this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
                this.WindowState = FormWindowState.Normal;
                change_font_size();
            }
        }
        // Размер шрифта в зависимости от размера формы
        private void change_font_size()
        {
            double font_size = this.Size.Width * 0.45 / Convert.ToDouble(2);
            label_xx.Font = new Font(label_xx.Font.FontFamily, Convert.ToInt32(font_size), label_xx.Font.Unit);
            label_yy.Font = new Font(label_xx.Font.FontFamily, Convert.ToInt32(font_size), label_yy.Font.Unit);
            font_size = this.Size.Width * 0.3 / Convert.ToDouble(8);
            label_player1.Font = new Font(label_player1.Font.FontFamily, Convert.ToInt32(font_size), label_player1.Font.Unit);
            label_player2.Font = new Font(label_player2.Font.FontFamily, Convert.ToInt32(font_size), label_player2.Font.Unit);

            label_x.Font = new Font(label_x.Font.FontFamily, Convert.ToInt32(font_size * 1.5), label_x.Font.Unit);
            label_y.Font = new Font(label_y.Font.FontFamily, Convert.ToInt32(font_size * 1.5), label_y.Font.Unit);

            info.Font = new Font(info.Font.FontFamily, Convert.ToInt32(font_size-5), info.Font.Unit);
            label_timer.Font = new Font(label_timer.Font.FontFamily, Convert.ToInt32(font_size), label_timer.Font.Unit);
            int size = Convert.ToInt32(this.Size.Width * 0.3 / Convert.ToDouble(3));
            inning1.Size = new Size(size, size);
            inning2.Size = new Size(size, size);
        }
        // Выбор игрока
        public void pick()
        {
            if (Data.status == 0)
            {
                Data.x = 0;
                Data.y = 0;
                Data.xx = 0;
                Data.yy = 0;
                Data.status = 0;
                Data.balance = false;
                Data.reverse = false;
                Data.inning_side = 0;
                Data.query = "";
                Data.history = "";
                refresh();
                set_inning();
                //Data.from_bd = true;
                info.Text = "Розыгрыш подачи";
                write_log("Розыгрыш подачи");
                if (!Data.from_bd)
                {
                    string start = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    Data.start = Convert.ToDateTime(start);
                }
                timer4.Start();
                this.Focus();
            }

        }
        // Отмена последнего присвоения очка
        private void cancel()
        {
            // проверить, возможны баги
            if ((Data.history != "") & (Data.history != null))
            {
                string a = "";
                string[] results = Data.history.Split(',');
                Data.xx = 0;
                Data.yy = 0;
                Data.history = "";
                int n;
                if (results[results.Length - 1] == "x")
                {
                    n = 2;
                    Data.x--;
                    Data.status = 1;
                }
                else
                    if (results[results.Length - 1] == "y")
                    {
                        n = 2;
                        Data.y--;
                        Data.status = 1;
                    }
                    else
                    {
                        n = 1;
                    }
                a = results[results.Length - 1];
                for (int i = 0; i < (results.Length - n); i++)
                {
                    if (Data.history != "") Data.history += ",";
                    if (results[i] == "xx")
                    {
                        Data.xx++;
                        Data.history += "xx";
                    }
                    if (results[i] == "yy")
                    {
                        Data.yy++;
                        Data.history += "yy";
                    }
                    if (results[i] == "x")
                    {
                        Data.x++;
                        Data.history += "x";
                    }
                    if (results[i] == "y")
                    {
                        Data.y++;
                        Data.history += "y";
                    }
                }
                if ((Data.balance) & ((Data.xx < 10) | (Data.yy < 10))) Data.balance = false;
                info.Text = Data.history;
                refresh();
                set_inning();
                if (a == "xx")
                {
                    write_log(Data.xx + ":" + Data.yy + " (судья отменил очко игрока " + Data.player1 + ")");
                }
                else
                    if (a == "yy")
                    {
                        write_log(Data.xx + ":" + Data.yy + " (судья отменил очко игрока: " + Data.player2 + ")");
                    }
            }
        }
        // Полный сброс
        private void full_reset()
        {
            Data.status = -1;
            Data.player1 = null;
            Data.player2 = null;
            Data.player1_id = -1;
            Data.player2_id = -1;
            Data.x = 0;
            Data.y = 0;
            Data.xx = 0;
            Data.yy = 0;
            Data.balance = false;
            Data.reverse = false;
            Data.inning_side = 0;
            Data.query = "";
            Data.history = "";

            Data.start = new DateTime();
            timer4.Stop();

            refresh();
            set_inning();
        }
        // Загрузка формы
        private void Form1_Load(object sender, EventArgs e)
        {
            Data.main = false;
            Data.fm_fp = false;
            Data.from_bd = false;
            Data.host = Properties.Settings.Default.host;
            Data.database = Properties.Settings.Default.database;
            Data.user = Properties.Settings.Default.user;
            Data.password = Properties.Settings.Default.password;
            Data.connectionString = "SERVER=" + Data.host + ";" + "DATABASE=" +
                Data.database + ";" + "UID=" + Data.user + ";" + "PASSWORD=" + Data.password + ";CharSet=utf8;";
            write_log("Запуск программы");
            Data.use_console = false;
            timer2.Start();
        }
        // Добавление истории
        private void history_add(string s)
        {
            if (Data.history != "") Data.history += ",";
            Data.history += s;
            //info.Text = Data.history;
        }
        // Добавление очка
        private void add_point(bool reverse, string player)
        {
            if (Data.status == 1)
            {
                if (!Data.reverse)
                {
                    switch (player)
                    {
                        case "xx":
                            Data.xx++;
                            label_xx.Text = Data.xx.ToString();
                            history_add("xx");
                            write_log(Data.xx + ":" + Data.yy + " (игрок " + Data.player1 + " заработал очко)");
                            break;
                        case "yy":
                            Data.yy++;
                            label_yy.Text = Data.yy.ToString();
                            write_log(Data.xx + ":" + Data.yy + " (игрок " + Data.player2 + " заработал очко)");
                            history_add("yy");
                            break;
                    }
                }
                else
                {
                    switch (player)
                    {
                        case "xx":
                            Data.yy++;
                            label_xx.Text = Data.yy.ToString();
                            history_add("yy");
                            write_log(Data.xx + ":" + Data.yy + " (игрок " + Data.player2 + " заработал очко)");
                            break;
                        case "yy":
                            Data.xx++;
                            label_yy.Text = Data.xx.ToString();
                            history_add("xx");
                            write_log(Data.xx + ":" + Data.yy + " (игрок " + Data.player1 + " заработал очко)");
                            break;
                    }
                }
                check_xxyy();
            }
            set_inning();
        }
        // Сброс результата и начало новой партии
        private void reset_score()
        {
            if (Data.status == 3)
            {
                if ((Data.x == Data.min_wins) | (Data.y == Data.min_wins))
                {
                    if (Data.x > Data.y)
                    {
                        info.Text = "Победитель: " + Data.player1;
                        write_log("В этой встрече победил: " + Data.player1);
                    }
                    if (Data.y > Data.x)
                    {
                        info.Text = "Победитель: " + Data.player2;
                        write_log("В этой встрече победил: " + Data.player2);
                    }
                    timer4.Stop();
                    Data.status = -1;
                    Data.query += "UPDATE matches SET x='" + Data.x + "',y='" + Data.y + "',status='2',end='" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "' WHERE id='" + Data.match + "';";
                    // Записать в лог-файл выполняемый запрос
                    //write_log(Data.query);
                    if (Data.match > 0)
                    {
                        MySqlConnection connect = null;
                        try
                        {
                            connect = new MySqlConnection(Data.connectionString);
                            connect.Open();
                            string query = Data.query;
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
                    }
                }
                else
                {
                    write_log("Начало следующей партии");
                    Data.xx = 0;
                    Data.yy = 0;
                    Data.balance = false;
                    Data.status = 1;
                    switch (Data.inning_side)
                    {
                        case 1:
                            Data.inning = false;
                            inning1.Visible = true;
                            inning2.Visible = false;
                            break;
                        case 2:
                            Data.inning = true;
                            inning2.Visible = true;
                            inning1.Visible = false;
                            break;
                    }
                    reverse();
                    set_inning();
                }
            }
        }
        // Обновление полей
        private void refresh()
        {
            if (!Data.reverse)
            {
                label_xx.Text = Data.xx.ToString();
                label_yy.Text = Data.yy.ToString();
                label_x.Text = Data.x.ToString();
                label_y.Text = Data.y.ToString();
                if (Data.player1 == null) label_player1.Text = "Игрок 1";
                else
                    label_player1.Text = Data.player1.ToString();
                if (Data.player2 == null) label_player2.Text = "Игрок 2";
                else
                    label_player2.Text = Data.player2.ToString();
                if (win(Data.xx, Data.yy) != "")
                {
                    if (win(Data.xx, Data.yy) == "xx")
                    {
                        write_log("Эту партию выйграл игрок: " + Data.player1);
                    }
                    else
                        if (win(Data.xx, Data.yy) == "yy")
                        {
                            write_log("Эту партию выйграл игрок: " + Data.player2);
                        }
                    write_log("Результат: " + Data.xx.ToString() + ":" + Data.yy.ToString() + " Счет по партиям: " + Data.x.ToString() + ":" + Data.y.ToString());
                }
            }
            else
            {
                label_xx.Text = Data.yy.ToString();
                label_yy.Text = Data.xx.ToString();
                label_x.Text = Data.y.ToString();
                label_y.Text = Data.x.ToString();
                label_player1.Text = Data.player2.ToString();
                label_player2.Text = Data.player1.ToString();
                if (win(Data.xx, Data.yy) != "")
                {
                    if (win(Data.xx, Data.yy) == "xx")
                    {
                        write_log("Эту партию выйграл игрок: " + Data.player1);
                    }
                    else
                        if (win(Data.xx, Data.yy) == "yy")
                        {
                            write_log("Эту партию выйграл игрок: " + Data.player2);
                        }
                    write_log("Результат: " + Data.xx.ToString() + ":" + Data.yy.ToString() + " Счет по партиям: " + Data.x.ToString() + ":" + Data.y.ToString());
                }
            }
        }
        // Победа
        private void victory(string s)
        {
            switch (s)
            {
                case "x":
                    Data.x++;
                    history_add("x");
                    info.Text = "Эту партию выйграл игрок: " + Data.player1;// + "\r\nНажмите ENTER (или 6 на джойстике) для продолжения";
                    break;
                case "y":
                    Data.y++;
                    history_add("y");
                    info.Text = "Эту партию выйграл игрок: " + Data.player2;// + "\r\nНажмите ENTER (или 6 на джойстике) для продолжения";
                    break;
            }
            Data.status = 2;
            refresh();
            SoundPlayer pl = new SoundPlayer();
            pl.Stream = Properties.Resources.aplause;
            pl.Play();
        }
        // Проверка условий победы (для работы с историей)
        private string win(int xx, int yy)
        {
            string result = "";
            if ((xx > yy) & (xx == 11))
            {
                result = "xx";
            }
            else
                if ((yy > xx) & (yy == 11))
                {
                    result = "yy";
                }
                else
                    if ((xx > 11) & (xx - yy == 2))
                    {
                        result = "xx";
                    }
                    else
                        if ((yy > 11) & (yy - xx == 2))
                        {
                            result = "yy";
                        }
            return result;
        }
        // Проверка условий победы (для основной работы программы)
        private void check_xxyy()
        {
            if ((Data.xx == 10) & (Data.yy == 10))
            {
                Data.balance = true;
            }
            if (!Data.balance)
            {
                if (Data.xx == 11)
                {
                    victory("x");
                }
                else
                    if (Data.yy == 11)
                    {
                        victory("y");
                    }
            }
            else
            {
                if (Data.xx - Data.yy == 2)
                {
                    victory("x");
                }
                else
                    if (Data.yy - Data.xx == 2)
                    {
                        victory("y");
                    }
            }
            set_inning();
        }
        // Поменять игроков местами
        private void reverse()
        {
            if (!Data.reverse)
                Data.reverse = true;
            else Data.reverse = false;
            refresh();
        }
        // Проверка счета и выставление очереди подачи
        private void set_inning()
        {
            int ost;
            if (!Data.balance)
            {
                ost = (Data.xx + Data.yy) % 4;
                if ((ost == 0) | (ost == 1))
                {
                    switch (Data.inning_side)
                    {
                        case 0:
                            inning1.Visible = false;
                            inning2.Visible = false;
                            if (Data.status == 0) info.Text = "Розыгрыш подачи";
                            break;
                        case 1:
                            inning1.Visible = true;
                            inning2.Visible = false;
                            if (Data.status == 1)
                            {
                                if (Data.reverse) info.Text = "Подает: " + Data.player2;
                                else
                                    info.Text = "Подает: " + Data.player1;
                            }
                            break;
                        case 2:
                            inning1.Visible = false;
                            inning2.Visible = true;
                            if (Data.status == 1)
                            {
                                if (Data.reverse) info.Text = "Подает: " + Data.player1;
                                else
                                    info.Text = "Подает: " + Data.player2;
                            }
                            break;
                    }
                }
                else
                    if ((ost == 2) | (ost == 3))
                    {
                        switch (Data.inning_side)
                        {
                            case 0:
                                inning1.Visible = false;
                                inning2.Visible = false;
                                if (Data.status == 0) info.Text = "Розыгрыш подачи";
                                break;
                            case 1:
                                inning1.Visible = false;
                                inning2.Visible = true;
                                if (Data.status == 1)
                                {
                                    if (Data.reverse) info.Text = "Подает: " + Data.player1;
                                    else
                                        info.Text = "Подает: " + Data.player2;
                                }
                                break;
                            case 2:
                                inning1.Visible = true;
                                inning2.Visible = false;
                                if (Data.status == 1)
                                {
                                    if (Data.reverse) info.Text = "Подает: " + Data.player2;
                                    else
                                        info.Text = "Подает: " + Data.player1;
                                }
                                break;
                        }
                    }
            }
            else
            {
                ost = (Data.xx + Data.yy) % 2;
                if (ost == 0)
                {
                    switch (Data.inning_side)
                    {
                        case 0:
                            inning1.Visible = false;
                            inning2.Visible = false;
                            if (Data.status == 0) info.Text = "Розыгрыш подачи";
                            break;
                        case 1:
                            inning1.Visible = true;
                            inning2.Visible = false;
                            if (Data.status == 1)
                            {
                                if (Data.reverse) info.Text = "Подает: " + Data.player2;
                                else
                                    info.Text = "Подает: " + Data.player1;
                            }
                            break;
                        case 2:
                            inning1.Visible = false;
                            inning2.Visible = true;
                            if (Data.status == 1)
                            {
                                if (Data.reverse) info.Text = "Подает: " + Data.player1;
                                else
                                    info.Text = "Подает: " + Data.player2;
                            }
                            break;
                    }
                }
                else
                    if (ost == 1)
                    {
                        switch (Data.inning_side)
                        {
                            case 0:
                                inning1.Visible = false;
                                inning2.Visible = false;
                                if (Data.status == 0) info.Text = "Розыгрыш подачи";
                                break;
                            case 1:
                                inning1.Visible = false;
                                inning2.Visible = true;
                                if (Data.status == 1)
                                {
                                    if (Data.reverse) info.Text = "Подает: " + Data.player1;
                                    else
                                        info.Text = "Подает: " + Data.player2;
                                }
                                break;
                            case 2:
                                inning1.Visible = true;
                                inning2.Visible = false;
                                if (Data.status == 1)
                                {
                                    if (Data.reverse) info.Text = "Подает: " + Data.player2;
                                    else
                                        info.Text = "Подает: " + Data.player1;
                                }
                                break;
                        }
                    }
            }
        }
        // Поменять подачи местами
        private void switch_inning()
        {
            switch (Data.inning_side)
            {
                case 1:
                    Data.inning_side = 2;
                    break;
                case 2:
                    Data.inning_side = 1;
                    break;
            }
            set_inning();
        }
        // Таймер (хз, может пригодится)
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (joystick != null)
                UpdateJoystick();
        }
        private void inning(int side)
        {
            if ((side == 1) | (side == 2))
            {
                Data.status = 1;
                info.Text = "";
                switch (side)
                {
                    case 1:
                        inning1.Visible = true;
                        inning2.Visible = false;
                        Data.inning_side = 1;
                        break;
                    case 2:
                        inning2.Visible = true;
                        inning1.Visible = false;
                        Data.inning_side = 2;
                        break;
                }
                set_inning();
                write_log("Начало игры: " + Data.player1 + " - " + Data.player2);
                write_log("Из " + Data.rounds + "-х партий (до " + Data.min_wins + " побед)");
            }
        }
        // Клик по первому игроку - выставление очереди подачи на него
        private void label_player1_Click(object sender, EventArgs e)
        {
            if (Data.status == 0) inning(1);
        }
        // Клик по второму игроку - выставление очереди подачи на него
        private void label_player2_Click(object sender, EventArgs e)
        {
            if (Data.status == 0) inning(2);
        }
        // Открывает окошко консоли

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult reply = MessageBox.Show("Вы действительно хотите закрыть счетчик?", "Закрыть", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (reply == DialogResult.No)
            {
                e.Cancel = true;
            }
            else
            {
                if ((Data.player1 != null) & (Data.player2 != null))
                    abort_game();
                write_log("Закрытие программы");
                timer1.Stop();
            }
        }
        // Выбрать игроков вручную (из БД берутся только сами игроки)
        private void выбратьИгроковToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Data.status == -1)
            {
                form_pick fp = new form_pick();
                fp.Owner = this;
                fp.ShowDialog();
            }
        }
        // Окошко помощи :)
        // Форма с настройками
        // Периодический вызов функции проверки джойстика
        private void timer2_Tick(object sender, EventArgs e)
        {
            if (!timer1.Enabled) InitDevices();
        }
        // Вместо пробела - переход на новую строку (в имени игрока 1)
        private void label_player1_TextChanged(object sender, EventArgs e)
        {
            label_player1.Text = label_player1.Text.Replace(" ", "\r\n");
        }
        // Вместо пробела - переход на новую строку (в имени игрока 1)
        private void label_player2_TextChanged(object sender, EventArgs e)
        {
            label_player2.Text = label_player2.Text.Replace(" ", "\r\n");
        }
        // Тестирование связи с БД
        private bool test()
        {
            bool result = false;
            MySqlConnection connect = null;
            try
            {
                connect = new MySqlConnection(Data.connectionString);
                connect.Open();
                if (connect != null)
                {
                    result = true;
                }
            }
            catch (MySqlException err)
            {
                write_log("Ошибка: " + err.ToString());
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
        // Получаем количество партий турнира по его id
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
        // Получаем имя игрока по его id
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
        // Функция прерывания текущей игры
        private void abort_game()
        {
            if (Data.from_bd)
            {
                MySqlConnection connect = null;
                try
                {
                    connect = new MySqlConnection(Data.connectionString);
                    connect.Open();
                    string query = "UPDATE matches SET status='0', start=null, end=null, x=null, y=null WHERE id='" + Data.match.ToString() + "'";
                    MySqlCommand cmd = new MySqlCommand(query, connect);
                    cmd.ExecuteNonQuery();
                    connect.Close();
                    Data.from_bd = false;
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
            timer4.Stop();
            full_reset();
            label_timer.Text = "00:00";
            info.Text = "Ожидание встречи";
            завершитьВстречуToolStripMenuItem.Enabled = false;
            выбратьИгроковToolStripMenuItem.Enabled = true;
            выбратьВстречуToolStripMenuItem.Enabled = true;
            write_log("Встреча прервана");
        }
        // Прерывание текущей игры через контекстное меню
        private void завершитьВстречуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            abort_game();
        }
        // Записываем в лог нужную строчку
        private void write_log(string s)
        {
            string log_path = @Properties.Settings.Default.log_path;
            string log_line = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " - " + s + Environment.NewLine;
            if (File.Exists(log_path))
            {
                File.AppendAllText(log_path, log_line);
            }
            else
            {
                //File.Create(log_path);
                File.WriteAllText(log_path, log_line);
            }
            Data.console += log_line;
        }
        // Обновление таймера встречи
        private void timer4_Tick(object sender, EventArgs e)
        {
            DateTime start_datetime = Data.start;
            string now = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            DateTime end_datetime = Convert.ToDateTime(now);
            TimeSpan delta = end_datetime - start_datetime;
            string time = delta.ToString(@"mm\:ss");
            label_timer.Text = time.ToString();
        }
        // Выбрать встречу (из БД)
        private void выбратьВстречуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            form_matches fm = new form_matches();
            if (!fm.Visible)
            {
                fm.Owner = this;
                fm.ShowDialog();
            }
        }

        private void базаДанныхToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Main m = new Main();
            if (!Data.main) m.Show();
        }

        private void настройкиToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (Data.status == -1)
            {
                form_settings fp = new form_settings();
                fp.Owner = this;
                fp.ShowDialog();
            }
        }

        private void помощьToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "(F1) войти в режим полного экрана" + Environment.NewLine +
                "(F2) выйти из режима полного экрана" + Environment.NewLine +
                "(F4) поменять подачи местами" + Environment.NewLine +
                "(<-) присвоить очко игроку 1" + Environment.NewLine +
                "(->) присвоить очко игроку 2" + Environment.NewLine +
                "(Esc) отменить присвоение очка игроку" + Environment.NewLine +
                "(Space) поменять игроков местами" + Environment.NewLine +
                "(Enter) подтвердить победу игрока" + Environment.NewLine
                , "Помощь", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void консольToolStripMenuItem_Click(object sender, EventArgs e)
        {
            form_console f2 = new form_console();
            if (!Data.use_console) f2.Show();
        }
    }
}
