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
            //System.Windows.Forms.Control.CheckForIllegalCrossThreadCalls = false;
        }
        // На полный экран
        public void GoFullscreen(bool fullscreen)
        {
            if (fullscreen)
            {
                //statusStrip1.Visible = false;
                //menuStrip1.Visible = false;
                this.WindowState = FormWindowState.Normal;
                this.FormBorderStyle = FormBorderStyle.None;
                this.WindowState = FormWindowState.Maximized;
                change_font_size();
            }
            else
            {
                //statusStrip1.Visible = true;
                //menuStrip1.Visible = true;
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
            font_size = this.Size.Width * 0.25 / Convert.ToDouble(8);
            label_player1.Font = new Font(label_player1.Font.FontFamily, Convert.ToInt32(font_size), label_player1.Font.Unit);
            label_player2.Font = new Font(label_player2.Font.FontFamily, Convert.ToInt32(font_size), label_player2.Font.Unit);

            label_x.Font = new Font(label_x.Font.FontFamily, Convert.ToInt32(font_size * 1.5), label_x.Font.Unit);
            label_y.Font = new Font(label_y.Font.FontFamily, Convert.ToInt32(font_size * 1.5), label_y.Font.Unit);

            info.Font = new Font(info.Font.FontFamily, Convert.ToInt32(font_size-5), info.Font.Unit);
            label_timer.Font = new Font(label_timer.Font.FontFamily, Convert.ToInt32(font_size), label_timer.Font.Unit);
            label1.Font = new Font(label1.Font.FontFamily, Convert.ToInt32(font_size), label1.Font.Unit);
            int size = Convert.ToInt32(this.Size.Width * 0.3 / Convert.ToDouble(3));
            inning1.Size = new Size(size, size);
            inning2.Size = new Size(size, size);
        }
        // Загрузка формы
        private void Form1_Load(object sender, EventArgs e)
        {
            Data.update_info();
            Data.write_log("Запуск программы");
            //timer2.Start();
        }
        // Таймер (хз, может пригодится)
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (Data.joystick != null)
                Data.UpdateJoystick();
        }
        // Клик по первому игроку - выставление очереди подачи на него
        private void label_player1_Click(object sender, EventArgs e)
        {
            if (Data.status == 0) Data.inning(1);
        }
        // Клик по второму игроку - выставление очереди подачи на него
        private void label_player2_Click(object sender, EventArgs e)
        {
            if (Data.status == 0) Data.inning(2);
        }
        // Открывает окошко консоли

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            /*
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
            */
            e.Cancel = true;
            this.Visible = false;
        }
        // Выбрать игроков вручную (из БД берутся только сами игроки)
        private void выбратьИгроковToolStripMenuItem_Click(object sender, EventArgs e)
        {

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
        // Прерывание текущей игры через контекстное меню
        private void завершитьВстречуToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        // Обновление таймера встречи
        private void timer4_Tick(object sender, EventArgs e)
        {

        }
    }
}
