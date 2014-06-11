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

namespace enumerator
{
    public partial class table : Form
    {
        public table()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int players = Convert.ToInt32(textBox1.Text);
                Pen pen1 = new Pen(Color.Black, 3);
                Graphics g = this.CreateGraphics();
                g.Clear(Color.FromArgb(0xFF, 0xF0, 0xF0, 0xF0));
                // Горизонтальные линии
                for (int i = 1; i <= players; i++)
                {
                    g.DrawLine(pen1, 50, 50 * i, 50 * players, 50 * i);
                }
                // Вертикальные линии
                for (int i = 1; i <= players; i++)
                {
                    g.DrawLine(pen1, 50 * i, 50, 50 * i, 50 * players);
                }
                pen1.Dispose();
                g.Dispose();
            }
            catch
            {

            }
        }
    }
}
