using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Text;

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
        public static DateTime start { get; set; }
                
        // Открыта ли форма с выбором встречи или выбором игроков
        public static bool fm_fp { get; set; }
        
        // Открыта ли форма с базой данных
        public static bool main { get; set; }

        // Получаем имя игрока по его id
        public static string player_name(int id)
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

        public static void update_info()
        {
            MySqlConnection connect = null;
            try
            {
                string result = "Готовятся: ";
                connect = new MySqlConnection(Data.connectionString);
                connect.Open();
                string query = "SELECT * FROM matches WHERE status='0'";
                MySqlCommand cmd = new MySqlCommand(query, connect);
                MySqlDataReader dataReader = cmd.ExecuteReader();
                if (dataReader.Read())
                {
                    result += Data.player_name(Convert.ToInt32(dataReader["player1"])) + " - " + Data.player_name(Convert.ToInt32(dataReader["player2"]));
                }
                dataReader.Close();
                connect.Close();
                Data.f1.info.Text = result;
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
            Data.prepareTranslit();
            Data.host = Properties.Settings.Default.host;
            Data.database = Properties.Settings.Default.database;
            Data.user = Properties.Settings.Default.user;
            Data.password = Properties.Settings.Default.password;
            Data.connectionString = "SERVER=" + Data.host + ";" + "DATABASE=" +
                Data.database + ";" + "UID=" + Data.user + ";" + "PASSWORD=" + Data.password + ";CharSet=utf8;";
            Data.f1 = new Form1();
            //Application.Run(new Form1());
            Application.Run(new Main());
        }
    }
}
