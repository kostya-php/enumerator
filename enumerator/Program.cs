using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace enumerator
{
    public class Data
    {
        /*
        // Вызов консоли. хз, будет ли использоваться
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool AllocConsole();

        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool FreeConsole();

        public static void Console()
        {
            AllocConsole();
        }
        */
        // Имена игроков
        public static string player1 { get; set; }
        public static string player2 { get; set; }
        // Номера игроков
        public static int player1_id { get; set; }
        public static int player2_id { get; set; }
        // Опции
        public static bool balance { get; set; }
        public static bool reverse { get; set; }
        public static bool game { get; set; }
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
        public static int min_wins { get; set; }
        // Подача
        public static bool inning { get; set; }
        public static int inning_side { get; set; }
        // История
        public static string history { get; set; }
        // Сонсоль
        public static string console { get; set; }
        // Запрос
        public static string query { get; set; }
        // Номер игры
        public static int match { get; set; }
        // Номер турнира
        public static int tournament { get; set; }
        // Используется джойстик или нет
        public static bool use_joystick { get; set; }
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
        // Искать в бд или нет
        public static bool find_bd { get; set; }
        // Используется встреча из БД или нет
        public static bool from_bd { get; set; }
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
            Application.Run(new Form1());
        }
    }
}
