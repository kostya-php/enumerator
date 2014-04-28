using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace enumerator
{
    public partial class form_console : Form
    {
        public form_console()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            textbox_console.Text = Data.console;
        }

        private void form_console_Load(object sender, EventArgs e)
        {
            Data.use_console = true;
            this.Top = 0;
            this.Left = 0;
            timer1.Start();
        }

        private void form_console_FormClosing(object sender, FormClosingEventArgs e)
        {
            Data.use_console = false;
            timer1.Stop();
        }

        private void textbox_console_TextChanged(object sender, EventArgs e)
        {
            textbox_console.Focus();
            textbox_console.SelectionStart = textbox_console.Text.Length;
            textbox_console.ScrollToCaret();
        }
    }
}
