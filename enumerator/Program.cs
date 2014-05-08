using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Text;
using Microsoft.DirectX.DirectInput;
using System.Drawing;
using System.IO;
using Hooks;
using System.Media;

namespace enumerator
{
    public class Data
    {
        // Имена игроков
        public static string player1 { get; set; }
        public static string player2 { get; set; }

        // Номера игроков
        public static int player1_id { get; set; }
        public static int player2_id { get; set; }

        // Опции
        public static bool balance { get; set; } // баланс
        public static bool reverse { get; set; } // игроки поменяны местами или нет

        // Статус игры
        // 0 - розыгрыш
        // 1 - идет игра
        // 2 - конец игры
        // 3 - перезапуск игры
        public static int status { get; set; }

        // Счет по очкам
        public static int xx { get; set; }
        public static int yy { get; set; }

        // Счет по партиям
        public static int x { get; set; }
        public static int y { get; set; }

        // Количество партий
        public static int rounds { get; set; }

        // Минимальное количество побед для выйгрыша встречи
        public static int min_wins { get; set; }

        // Подача (какая сторона подает первая)
        public static int inning_side { get; set; }

        // История (необходимо для отмены последнего засчитанного очка)
        public static string history { get; set; }

        // Консоль (текст консоли)
        public static string console { get; set; }

        // Запрос
        public static string query { get; set; }

        // Номер игры (если игра из базы данных)
        public static int match { get; set; }

        // Номер турнира (если игра из базы данных)
        public static int tournament { get; set; }

        // Переменные для того, что-бы определить - зажата ли кнопка
        public static int button_1 { get; set; }
        public static int button_2 { get; set; }
        public static int button_3 { get; set; }
        public static int button_4 { get; set; }
        public static int button_5 { get; set; }
        public static int button_6 { get; set; }
        public static int button_7 { get; set; }
        public static int button_8 { get; set; }

        // Открыта ли консоль
        public static bool use_console { get; set; }

        // Используется встреча из БД или нет
        public static bool from_bd { get; set; }

        // Данные для подключения к БД
        public static string host { get; set; }
        public static string database { get; set; }
        public static string user { get; set; }
        public static string password { get; set; }
        public static string connectionString { get; set; }

        // Время начала встречи
        public static string start { get; set; }

        // Получаем имя игрока по его id
        public static string player_name(int id)
        {
            string result = "NoName";
            MySqlConnection connect = null;
            try
            {
                connect = new MySqlConnection(connectionString);
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
        // Получаем id игрока по его имени
        public static int player_id(string player)
        {
            int result = -1;
            MySqlConnection connect = null;
            try
            {
                connect = new MySqlConnection(connectionString);
                connect.Open();
                string query = "SELECT * FROM players WHERE player='" + player + "'";
                MySqlCommand cmd = new MySqlCommand(query, connect);
                MySqlDataReader dataReader = cmd.ExecuteReader();
                while (dataReader.Read())
                {
                    result = Convert.ToInt32(dataReader["id"]);
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
        // Получаем список игроков (например, элемента comboBox)
        public static List<string> player_list()
        {
            List<string> list = new List<string>();
            MySqlConnection connect = null;
            try
            {
                connect = new MySqlConnection(Data.connectionString);
                connect.Open();
                string query1 = "SELECT Count(*) FROM players";
                MySqlCommand cmd1 = new MySqlCommand(query1, connect);
                int Count = int.Parse(cmd1.ExecuteScalar() + "");

                string query = "SELECT * FROM players ORDER BY id ASC";
                MySqlCommand cmd = new MySqlCommand(query, connect);
                MySqlDataReader dataReader = cmd.ExecuteReader();
                while (dataReader.Read())
                {
                    list.Add(dataReader["player"].ToString());
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
            return list;
        }
        // Транслит
        private static Dictionary<string, string> transliter = new Dictionary<string, string>();
        public static void prepareTranslit()
        {
            transliter.Add("а", "a");
            transliter.Add("б", "b");
            transliter.Add("в", "v");
            transliter.Add("г", "g");
            transliter.Add("д", "d");
            transliter.Add("е", "e");
            transliter.Add("ё", "e");
            transliter.Add("ж", "zh");
            transliter.Add("з", "z");
            transliter.Add("и", "i");
            transliter.Add("й", "y");
            transliter.Add("к", "k");
            transliter.Add("л", "l");
            transliter.Add("м", "m");
            transliter.Add("н", "n");
            transliter.Add("о", "o");
            transliter.Add("п", "p");
            transliter.Add("р", "r");
            transliter.Add("с", "s");
            transliter.Add("т", "t");
            transliter.Add("у", "u");
            transliter.Add("ф", "f");
            transliter.Add("х", "h");
            transliter.Add("ц", "c");
            transliter.Add("ч", "ch");
            transliter.Add("ш", "sh");
            transliter.Add("щ", "sch");
            transliter.Add("ъ", "");
            transliter.Add("ы", "y");
            transliter.Add("ь", "");
            transliter.Add("э", "e");
            transliter.Add("ю", "yu");
            transliter.Add("я", "ya");
            transliter.Add("А", "A");
            transliter.Add("Б", "B");
            transliter.Add("В", "V");
            transliter.Add("Г", "G");
            transliter.Add("Д", "D");
            transliter.Add("Е", "E");
            transliter.Add("Ё", "E");
            transliter.Add("Ж", "Zh");
            transliter.Add("З", "Z");
            transliter.Add("И", "I");
            transliter.Add("Й", "Y");
            transliter.Add("К", "K");
            transliter.Add("Л", "L");
            transliter.Add("М", "M");
            transliter.Add("Н", "N");
            transliter.Add("О", "O");
            transliter.Add("П", "P");
            transliter.Add("Р", "R");
            transliter.Add("С", "S");
            transliter.Add("Т", "T");
            transliter.Add("У", "U");
            transliter.Add("Ф", "F");
            transliter.Add("Х", "H");
            transliter.Add("Ц", "C");
            transliter.Add("Ч", "Ch");
            transliter.Add("Ш", "Sh");
            transliter.Add("Щ", "Sch");
            transliter.Add("Ъ", "");
            transliter.Add("Ы", "Y");
            transliter.Add("Ь", "");
            transliter.Add("Э", "E");
            transliter.Add("Ю", "Yu");
            transliter.Add("Я", "Ya");
            transliter.Add(" ", "-");
        }
        public static string GetTranslit(string sourceText)
        {
            StringBuilder ans = new StringBuilder();
            for (int i = 0; i < sourceText.Length; i++)
            {
                if (transliter.ContainsKey(sourceText[i].ToString()))
                {
                    ans.Append(transliter[sourceText[i].ToString()]);
                }
                else
                {
                    ans.Append(sourceText[i].ToString());
                }
            }
            return ans.ToString();
        }

        // Редактируемый игрок
        public static int edited_player { get; set; }

        public static Form1 f1 { get; set; }
        public static Form2 f2 { get; set; }
        public static Main fm { get; set; }

        public static void update_info()
        {
            MySqlConnection connect = null;
            try
            {
                string result = "Готовятся: ";
                connect = new MySqlConnection(connectionString);
                connect.Open();
                string query = "SELECT * FROM matches WHERE status='0'";
                MySqlCommand cmd = new MySqlCommand(query, connect);
                MySqlDataReader dataReader = cmd.ExecuteReader();
                if (dataReader.Read())
                {
                    result += player_name(Convert.ToInt32(dataReader["player1"])) + " - " + player_name(Convert.ToInt32(dataReader["player2"]));
                }
                dataReader.Close();
                connect.Close();
                f1.info.Text = result;
                f2.info.Text = result;
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
        // Хук клавиатуры
        public static void KBDHook_KeyDown(LLKHEventArgs e)
        {
            switch (e.Keys)
            {
                case Keys.Left:
                    if (status == 0) inning(1);
                    else
                        if (status == 1)
                        {
                            add_point(reverse, "xx");
                            e.Hooked = true;
                        }
                    break;

                case Keys.Right:
                    if (status == 0) inning(2);
                    else
                        if (status == 1)
                        {
                            add_point(reverse, "yy");
                            e.Hooked = true;
                        }
                    break;

                case Keys.F1:
                    f1.GoFullscreen(true);
                    e.Hooked = true;
                    break;

                case Keys.F2:
                    f1.GoFullscreen(false);
                    e.Hooked = true;
                    break;

                case Keys.F3:
                    f2.GoFullscreen(true);
                    e.Hooked = true;
                    break;

                case Keys.F4:
                    f2.GoFullscreen(false);
                    e.Hooked = true;
                    break;

                case Keys.F5:
                    if (status == 1)
                    {
                        switch_inning();
                        e.Hooked = true;
                    }
                    break;

                case Keys.Space:
                    if (status == 1)
                    {
                        reverse_switch();
                        switch_inning();
                        e.Hooked = true;
                    }
                    break;

                case Keys.Enter:
                    if (status == -1)
                    {
                        if (fm.dataMatches.Rows.Count > 0)
                        {
                            fm.dataMatches.Rows[0].Selected = true;
                            fm.dataMatches.Rows[0].Cells[0].Selected = true;
                            //fm.dataMatches.Refresh();
                            fm.start_match();
                        }
                    }
                    else
                        if (status == 2)
                        {
                            query += "INSERT INTO rounds VALUES (null,'" + match + "','" + (x + y).ToString() + "','" + xx + "','" + yy + "');";
                            status = 3;
                            //f1.info.Text = "";
                            history = "";
                            reset_score();
                        }
                    /*
                    if (status == -1)
                    {
                        //if (f1.info.Text != "Ожидание встречи") write_log("Встреча окончена");
                        full_reset();
                        f1.label_timer.Text = "00:00";
                        f2.label_timer.Text = "00:00";
                        //f1.info.Text = "Ожидание встречи";
                        //f1.завершитьВстречуToolStripMenuItem.Enabled = false;
                        //f1.выбратьИгроковToolStripMenuItem.Enabled = true;
                        //f1.выбратьВстречуToolStripMenuItem.Enabled = true;
                    }
                    else
                        if (status == 2)
                        {
                            query += "INSERT INTO rounds VALUES (null,'" + match + "','" + (x + y).ToString() + "','" + xx + "','" + yy + "');";
                            status = 3;
                            //f1.info.Text = "";
                            history = "";
                            reset_score();
                        }
                    */
                    break;

                case Keys.Escape:
                    cancel();
                    e.Hooked = true;
                    break;
            }
        }
        #region Джойстик

        public static Device joystick;
        // Функция инициализации джойстика
        public static void InitDevices()
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
                f1,
                CooperativeLevelFlags.NonExclusive |
                CooperativeLevelFlags.Background);
                // Acquire devices for capturing (хз че это)
                joystick.Acquire();
                // Остановка таймера, запускающего инициализацию
                //f1.timer2.Stop();
                fm.timer_InitDevices.Stop();
                // Запуск таймера, проверяющего состояние джойстика
                //f1.timer1.Start();
                fm.timer_UpdateJoystick.Start();
                // Надпись "Joystick: online" и зеленая картинка внизу окна программы (в оконном режиме)
                fm.joystick_status.Text = "Joystick: online";
                Image img = Properties.Resources.online.ToBitmap();
                fm.joystick_status.Image = img;
                // Запись изменения в лог
                write_log("Joystick connected");
            }
        }
        // Фукция проверки состояния джойстика и снятие показаний о нажатых кнопках
        public static void UpdateJoystick()
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
                                if (button_1 == 0)
                                {
                                    if (history != "")
                                    {
                                        cancel();
                                    }
                                    button_1 = 1;
                                }
                                break;
                            case 2:
                                if (button_2 == 0)
                                {
                                    if (status == 1)
                                    {
                                        switch_inning();
                                    }
                                    button_2 = 1;
                                }
                                break;
                            case 3:
                                if (button_3 == 0)
                                {
                                    if ((status == 1) | (status == 0))
                                    {
                                        reverse_switch();
                                        switch_inning();
                                    }
                                    button_3 = 1;
                                }
                                break;
                            case 4:
                                if (button_4 == 0)
                                {
                                    /*
                                    if (status == -1)
                                    {
                                        form_matches fm = new form_matches();
                                        if (!fm_fp)
                                        {
                                            fm.Owner = f1;
                                            fm.ShowDialog();
                                        }
                                    }
                                    */
                                    button_4 = 1;
                                }
                                break;
                            case 5:
                                if (button_5 == 0)
                                {
                                    /*
                                    if (status == -1)
                                    {
                                        form_pick fp = new form_pick();
                                        if (!fm_fp)
                                        {
                                            fp.Owner = f1;
                                            fp.ShowDialog();
                                        }
                                    }
                                    */
                                    button_5 = 1;
                                }
                                break;
                            case 6:
                                if (button_6 == 0)
                                {
                                    if (status == -1)
                                    {
                                        if (fm.dataMatches.Rows.Count > 0)
                                        {
                                            fm.dataMatches.Rows[0].Selected = true;
                                            fm.dataMatches.Rows[0].Cells[0].Selected = true;
                                            //fm.dataMatches.Refresh();
                                            fm.start_match();
                                        }
                                    }
                                    else
                                        if (status == 2)
                                        {
                                            query += "INSERT INTO rounds VALUES (null,'" + match + "','" + (x + y).ToString() + "','" + xx + "','" + yy + "');";
                                            status = 3;
                                            //f1.info.Text = "";
                                            history = "";
                                            reset_score();
                                        }
                                    button_6 = 1;
                                }
                                break;
                            case 7:
                                if (button_7 == 0)
                                {
                                    if (status == 0) inning(1);
                                    else
                                        if (status == 1)
                                            add_point(reverse, "xx");
                                    button_7 = 1;
                                }
                                break;
                            case 8:
                                if (button_8 == 0)
                                {
                                    if (status == 0) inning(2);
                                    else
                                        if (status == 1)
                                            add_point(reverse, "yy");
                                    button_8 = 1;
                                }
                                break;
                        }
                    }
                    else
                    {
                        switch (b)
                        {
                            case 1:
                                button_1 = 0;
                                break;
                            case 2:
                                button_2 = 0;
                                break;
                            case 3:
                                button_3 = 0;
                                break;
                            case 4:
                                button_4 = 0;
                                break;
                            case 5:
                                button_5 = 0;
                                break;
                            case 6:
                                button_6 = 0;
                                break;
                            case 7:
                                button_7 = 0;
                                break;
                            case 8:
                                button_8 = 0;
                                break;
                        }
                    }
                }
            }
            // Обработка исключения (например, если джойстик внезапно отключили)
            catch (Exception e)
            {
                // Остановка таймера, проверяющего состояние джойстика
                //f1.timer1.Stop();
                fm.timer_UpdateJoystick.Stop();
                // Запуск таймера, запускающиего инициализацию джойстика
                //f1.timer2.Start();
                fm.timer_InitDevices.Start();
                // Надпись "Joystick: offline" и красная картинка внизу окна программы (в оконном режиме)
                fm.joystick_status.Text = "Joystick: offline";
                Image img = Properties.Resources.offline;
                fm.joystick_status.Image = img;
                // Запись в лог
                write_log("Joystick disconnected " + e.ToString());
            }
        }
        #endregion

        // Записываем в лог нужную строчку
        public static void write_log(string s)
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
            console += log_line;
        }

        // Выбор игрока
        public static void pick()
        {
            if (status == 0)
            {
                x = 0;
                y = 0;
                xx = 0;
                yy = 0;
                status = 0;
                balance = false;
                reverse = false;
                inning_side = 0;
                query = "";
                history = "";
                refresh();
                set_inning();
                //f1.info.Text = "Розыгрыш подачи";
                write_log("Розыгрыш подачи");
                if (!from_bd)
                {
                    start = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    //start = Convert.ToDateTime(start);
                }
                fm.timer_Enumerator.Start();
                //f1.timer4.Start();
                //this.Focus();
            }

        }

        // Отмена последнего присвоения очка
        public static void cancel()
        {
            // проверить, возможны баги
            if ((history != "") & (history != null))
            {
                string a = "";
                string[] results = history.Split(',');
                xx = 0;
                yy = 0;
                history = "";
                int n;
                if (results[results.Length - 1] == "x")
                {
                    n = 2;
                    x--;
                    status = 1;
                }
                else
                    if (results[results.Length - 1] == "y")
                    {
                        n = 2;
                        y--;
                        status = 1;
                    }
                    else
                    {
                        n = 1;
                    }
                a = results[results.Length - 1];
                for (int i = 0; i < (results.Length - n); i++)
                {
                    if (history != "") history += ",";
                    if (results[i] == "xx")
                    {
                        xx++;
                        history += "xx";
                    }
                    if (results[i] == "yy")
                    {
                        yy++;
                        history += "yy";
                    }
                    if (results[i] == "x")
                    {
                        x++;
                        history += "x";
                    }
                    if (results[i] == "y")
                    {
                        y++;
                        history += "y";
                    }
                }
                if ((balance) & ((xx < 10) | (yy < 10))) balance = false;
                //f1.info.Text = history;
                refresh();
                set_inning();
                if (a == "xx")
                {
                    write_log(xx + ":" + yy + " (судья отменил очко игрока " + player1 + ")");
                }
                else
                    if (a == "yy")
                    {
                        write_log(xx + ":" + yy + " (судья отменил очко игрока: " + player2 + ")");
                    }
            }
        }
        // Полный сброс
        public static void full_reset()
        {
            status = -1;
            player1 = null;
            player2 = null;
            player1_id = -1;
            player2_id = -1;
            x = 0;
            y = 0;
            xx = 0;
            yy = 0;
            balance = false;
            reverse = false;
            inning_side = 0;
            query = "";
            history = "";

            start = "";
            fm.timer_Enumerator.Stop();
            //f1.timer4.Stop();

            refresh();
            set_inning();
        }

        // Добавление истории
        public static void history_add(string s)
        {
            if (history != "") history += ",";
            history += s;
            //info.Text = history;
        }
        // Добавление очка
        public static void add_point(bool reverse, string player)
        {
            if (status == 1)
            {
                if (!reverse)
                {
                    switch (player)
                    {
                        case "xx":
                            xx++;
                            //f1.label_xx.Text = xx.ToString();
                            //f2.label_xx.Text = xx.ToString();
                            history_add("xx");
                            write_log(xx + ":" + yy + " (игрок " + player1 + " заработал очко)");
                            break;
                        case "yy":
                            yy++;
                            //f1.label_yy.Text = yy.ToString();
                            //f2.label_yy.Text = yy.ToString();
                            write_log(xx + ":" + yy + " (игрок " + player2 + " заработал очко)");
                            history_add("yy");
                            break;
                    }
                }
                else
                {
                    switch (player)
                    {
                        case "xx":
                            yy++;
                            //f1.label_xx.Text = yy.ToString();
                            //f2.label_xx.Text = yy.ToString();
                            history_add("yy");
                            write_log(xx + ":" + yy + " (игрок " + player2 + " заработал очко)");
                            break;
                        case "yy":
                            xx++;
                            //f1.label_yy.Text = xx.ToString();
                            //f2.label_yy.Text = xx.ToString();
                            history_add("xx");
                            write_log(xx + ":" + yy + " (игрок " + player1 + " заработал очко)");
                            break;
                    }
                }
                check_xxyy();
            }
            refresh();
            set_inning();
        }
        // Сброс результата и начало новой партии
        public static void reset_score()
        {
            if (status == 3)
            {
                // Окончательная победа
                if ((x == min_wins) | (y == min_wins))
                {
                    Data.fm.buttonStartMatch.Enabled = false;
                    Data.fm.buttonCancelMatch.Enabled = false;
                    if (x > y)
                    {
                        //f1.info.Text = "Победитель: " + player1;
                        write_log("В этой встрече победил: " + player1);
                    }
                    if (y > x)
                    {
                        //f1.info.Text = "Победитель: " + player2;
                        write_log("В этой встрече победил: " + player2);
                    }
                    //fm.timer_Enumerator.Stop();
                    //f1.timer4.Stop();
                    status = -1;
                    query += "UPDATE matches SET x='" + x + "',y='" + y + "',status='2',end='" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "' WHERE id='" + match + "';";
                    // Записать в лог-файл выполняемый запрос
                    //write_log(query);
                    if (match > 0)
                    {
                        MySqlConnection connect = null;
                        try
                        {
                            connect = new MySqlConnection(connectionString);
                            connect.Open();
                            string q = query;
                            MySqlCommand cmd = new MySqlCommand(q, connect);
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
                    full_reset();
                    //f1.label_timer.Text = "00:00";
                    //f2.label_timer.Text = "00:00";
                    Data.fm.buttonStartMatch.Enabled = true;
                    Data.fm.buttonCancelMatch.Enabled = false;
                }
                else
                {
                    write_log("Начало следующей партии");
                    xx = 0;
                    yy = 0;
                    balance = false;
                    status = 1;
                    switch (inning_side)
                    {
                        case 1:
                            f1.inning1.Visible = true;
                            f1.inning2.Visible = false;
                            break;
                        case 2:
                            f1.inning2.Visible = true;
                            f1.inning1.Visible = false;
                            break;
                    }
                    reverse_switch();
                    set_inning();
                }
            }
        }
        // Обновление полей
        public static void refresh()
        {
            if (!reverse)
            {
                f1.label_xx.Text = xx.ToString();
                f1.label_yy.Text = yy.ToString();
                f1.label_x.Text = x.ToString();
                f1.label_y.Text = y.ToString();


                f2.label_xx.Text = xx.ToString();
                f2.label_yy.Text = yy.ToString();
                f2.label_x.Text = x.ToString();
                f2.label_y.Text = y.ToString();

                if (player1 == null) f1.label_player1.Text = "Игрок 1";
                else
                    f1.label_player1.Text = player1.ToString();
                if (player2 == null) f1.label_player2.Text = "Игрок 2";
                else
                    f1.label_player2.Text = player2.ToString();

                if (player1 == null) f2.label_player1.Text = "Игрок 1";
                else
                    f2.label_player1.Text = player1.ToString();
                if (player2 == null) f2.label_player2.Text = "Игрок 2";
                else
                    f2.label_player2.Text = player2.ToString();

                if (win(xx, yy) != "")
                {
                    if (win(xx, yy) == "xx")
                    {
                        write_log("Эту партию выйграл игрок: " + player1);
                    }
                    else
                        if (win(xx, yy) == "yy")
                        {
                            write_log("Эту партию выйграл игрок: " + player2);
                        }
                    write_log("Результат: " + xx.ToString() + ":" + yy.ToString() + " Счет по партиям: " + x.ToString() + ":" + y.ToString());
                }
            }
            else
            {
                f1.label_xx.Text = yy.ToString();
                f1.label_yy.Text = xx.ToString();
                f1.label_x.Text = y.ToString();
                f1.label_y.Text = x.ToString();


                f2.label_xx.Text = yy.ToString();
                f2.label_yy.Text = xx.ToString();
                f2.label_x.Text = y.ToString();
                f2.label_y.Text = x.ToString();

                if (player1 == null) f1.label_player1.Text = "Игрок 2";
                else
                    f1.label_player1.Text = player2.ToString();
                if (player2 == null) f1.label_player2.Text = "Игрок 1";
                else
                    f1.label_player2.Text = player1.ToString();

                if (player1 == null) f2.label_player1.Text = "Игрок 2";
                else
                    f2.label_player1.Text = player2.ToString();
                if (player2 == null) f2.label_player2.Text = "Игрок 1";
                else
                    f2.label_player2.Text = player1.ToString();

                if (win(xx, yy) != "")
                {
                    if (win(xx, yy) == "xx")
                    {
                        write_log("Эту партию выйграл игрок: " + player1);
                    }
                    else
                        if (win(xx, yy) == "yy")
                        {
                            write_log("Эту партию выйграл игрок: " + player2);
                        }
                    write_log("Результат: " + xx.ToString() + ":" + yy.ToString() + " Счет по партиям: " + x.ToString() + ":" + y.ToString());
                }
            }
        }
        // Победа
        public static void victory(string s)
        {
            switch (s)
            {
                case "x":
                    x++;
                    history_add("x");
                    //f1.info.Text = "Эту партию выйграл игрок: " + player1;// + "\r\nНажмите ENTER (или 6 на джойстике) для продолжения";
                    break;
                case "y":
                    y++;
                    history_add("y");
                    //f1.info.Text = "Эту партию выйграл игрок: " + player2;// + "\r\nНажмите ENTER (или 6 на джойстике) для продолжения";
                    break;
            }
            status = 2;
            refresh();
            SoundPlayer pl = new SoundPlayer();
            pl.Stream = Properties.Resources.aplause;
            pl.Play();
        }
        // Проверка условий победы (для работы с историей)
        public static string win(int xx, int yy)
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
        public static void check_xxyy()
        {
            if ((xx == 10) & (yy == 10))
            {
                balance = true;
            }
            if (!balance)
            {
                if (xx == 11)
                {
                    victory("x");
                }
                else
                    if (yy == 11)
                    {
                        victory("y");
                    }
            }
            else
            {
                if (xx - yy == 2)
                {
                    victory("x");
                }
                else
                    if (yy - xx == 2)
                    {
                        victory("y");
                    }
            }
            set_inning();
        }
        // Поменять игроков местами
        public static void reverse_switch()
        {
            if (!reverse)
                reverse = true;
            else reverse = false;
            refresh();
        }
        // Проверка счета и выставление очереди подачи
        public static void set_inning()
        {
            int ost;
            if (!balance)
            {
                ost = (xx + yy) % 4;
                if ((ost == 0) | (ost == 1))
                {
                    switch (inning_side)
                    {
                        case 0:
                            f1.inning1.Visible = false;
                            f1.inning2.Visible = false;
                            f2.inning1.Visible = false;
                            f2.inning2.Visible = false;
                            //if (status == 0) f1.info.Text = "Розыгрыш подачи";
                            break;
                        case 1:
                            f1.inning1.Visible = true;
                            f1.inning2.Visible = false;
                            f2.inning1.Visible = true;
                            f2.inning2.Visible = false;
                            /*
                            if (status == 1)
                            {
                                if (reverse) f1.info.Text = "Подает: " + player2;
                                else
                                    f1.info.Text = "Подает: " + player1;
                            }
                            */
                            break;
                        case 2:
                            f1.inning1.Visible = false;
                            f1.inning2.Visible = true;
                            f2.inning1.Visible = false;
                            f2.inning2.Visible = true;
                            /*
                            if (status == 1)
                            {
                                if (reverse) f1.info.Text = "Подает: " + player1;
                                else
                                    f1.info.Text = "Подает: " + player2;
                            }
                            */
                            break;
                    }
                }
                else
                    if ((ost == 2) | (ost == 3))
                    {
                        switch (inning_side)
                        {
                            case 0:
                                f1.inning1.Visible = false;
                                f1.inning2.Visible = false;
                                f2.inning1.Visible = false;
                                f2.inning2.Visible = false;
                                //if (status == 0) f1.info.Text = "Розыгрыш подачи";
                                break;
                            case 1:
                                f1.inning1.Visible = false;
                                f1.inning2.Visible = true;
                                f2.inning1.Visible = false;
                                f2.inning2.Visible = true;
                                /*
                                if (status == 1)
                                {
                                    if (reverse) f1.info.Text = "Подает: " + player1;
                                    else
                                        f1.info.Text = "Подает: " + player2;
                                }
                                */
                                break;
                            case 2:
                                f1.inning1.Visible = true;
                                f1.inning2.Visible = false;
                                f2.inning1.Visible = true;
                                f2.inning2.Visible = false;
                                /*
                                if (status == 1)
                                {
                                    if (reverse) f1.info.Text = "Подает: " + player2;
                                    else
                                        f1.info.Text = "Подает: " + player1;
                                }
                                */
                                break;
                        }
                    }
            }
            else
            {
                ost = (xx + yy) % 2;
                if (ost == 0)
                {
                    switch (inning_side)
                    {
                        case 0:
                            f1.inning1.Visible = false;
                            f1.inning2.Visible = false;
                            f2.inning1.Visible = false;
                            f2.inning2.Visible = false;
                            //if (status == 0) f1.info.Text = "Розыгрыш подачи";
                            break;
                        case 1:
                            f1.inning1.Visible = true;
                            f1.inning2.Visible = false;
                            f2.inning1.Visible = true;
                            f2.inning2.Visible = false;
                            /*
                            if (status == 1)
                            {
                                if (reverse) f1.info.Text = "Подает: " + player2;
                                else
                                    f1.info.Text = "Подает: " + player1;
                            }
                            */
                            break;
                        case 2:
                            f1.inning1.Visible = false;
                            f1.inning2.Visible = true;
                            f2.inning1.Visible = false;
                            f2.inning2.Visible = true;
                            /*
                            if (status == 1)
                            {
                                if (reverse) f1.info.Text = "Подает: " + player1;
                                else
                                    f1.info.Text = "Подает: " + player2;
                            }
                            */
                            break;
                    }
                }
                else
                    if (ost == 1)
                    {
                        switch (inning_side)
                        {
                            case 0:
                                f1.inning1.Visible = false;
                                f1.inning2.Visible = false;
                                f2.inning1.Visible = false;
                                f2.inning2.Visible = false;
                                //if (status == 0) f1.info.Text = "Розыгрыш подачи";
                                break;
                            case 1:
                                f1.inning1.Visible = false;
                                f1.inning2.Visible = true;
                                f2.inning1.Visible = false;
                                f2.inning2.Visible = true;
                                /*
                                if (status == 1)
                                {
                                    if (reverse) f1.info.Text = "Подает: " + player1;
                                    else
                                        f1.info.Text = "Подает: " + player2;
                                }
                                */
                                break;
                            case 2:
                                f1.inning1.Visible = true;
                                f1.inning2.Visible = false;
                                f2.inning1.Visible = true;
                                f2.inning2.Visible = false;
                                /*
                                if (status == 1)
                                {
                                    if (reverse) f1.info.Text = "Подает: " + player2;
                                    else
                                        f1.info.Text = "Подает: " + player1;
                                }
                                */
                                break;
                        }
                    }
            }
        }
        // Поменять подачи местами
        public static void switch_inning()
        {
            switch (inning_side)
            {
                case 1:
                    inning_side = 2;
                    break;
                case 2:
                    inning_side = 1;
                    break;
            }
            set_inning();
        }

        // Тестирование связи с БД
        public static bool test()
        {
            bool result = false;
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
        public static int get_rounds(int id)
        {
            int rounds = 0;
            MySqlConnection connect = null;
            try
            {
                connect = new MySqlConnection(connectionString);
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
        // Функция прерывания текущей игры
        public static void abort_game()
        {
            if (from_bd)
            {
                MySqlConnection connect = null;
                try
                {
                    connect = new MySqlConnection(connectionString);
                    connect.Open();
                    string query = "UPDATE matches SET status='0', start=null, end=null, x=null, y=null WHERE id='" + match.ToString() + "'";
                    MySqlCommand cmd = new MySqlCommand(query, connect);
                    cmd.ExecuteNonQuery();
                    connect.Close();
                    from_bd = false;
                    update_info();
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
            else
            {
                MessageBox.Show("atata");
            }
            fm.timer_Enumerator.Stop();
            //f1.timer4.Stop();
            full_reset();
            f1.label_timer.Text = "00:00";
            f2.label_timer.Text = "00:00";
            //f1.info.Text = "Ожидание встречи";
            //f1.завершитьВстречуToolStripMenuItem.Enabled = false;
            //f1.выбратьИгроковToolStripMenuItem.Enabled = true;
            //f1.выбратьВстречуToolStripMenuItem.Enabled = true;
            write_log("Встреча прервана");
        }
        // Выставляем стартовую подачу
        public static void inning(int side)
        {
            if ((side == 1) | (side == 2))
            {
                status = 1;
                //f1.info.Text = "";
                switch (side)
                {
                    case 1:
                        f1.inning1.Visible = true;
                        f1.inning2.Visible = false;
                        inning_side = 1;
                        break;
                    case 2:
                        f1.inning2.Visible = true;
                        f1.inning1.Visible = false;
                        inning_side = 2;
                        break;
                }
                set_inning();
                write_log("Начало игры: " + player1 + " - " + player2);
                write_log("Из " + rounds + "-х партий (до " + min_wins + " побед)");
            }
        }
    }
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Data.status = -1;
            Data.match = -1;
            Data.tournament = -1;
            Data.button_1 = 0;
            Data.button_2 = 0;
            Data.button_3 = 0;
            Data.button_4 = 0;
            Data.button_5 = 0;
            Data.button_6 = 0;
            Data.button_7 = 0;
            Data.button_8 = 0;
            Data.prepareTranslit();
            Data.host = Properties.Settings.Default.host;
            Data.database = Properties.Settings.Default.database;
            Data.user = Properties.Settings.Default.user;
            Data.password = Properties.Settings.Default.password;
            Data.connectionString = "SERVER=" + Data.host + ";" + "DATABASE=" +
                Data.database + ";" + "UID=" + Data.user + ";" + "PASSWORD=" + Data.password + ";CharSet=utf8;";
            Data.f1 = new Form1();
            Data.f2 = new Form2();
            Data.fm = new Main();
            KBDHook.KeyDown += new KBDHook.HookKeyPress(Data.KBDHook_KeyDown);
            KBDHook.LocalHook = false;
            KBDHook.InstallHook();
            //Application.Run(new Main());
            Application.Run(Data.fm);
        }
    }
}
