﻿using System;
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
    public partial class krug : Form
    {
        public krug()
        {
            InitializeComponent();
        }

        private void krug_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Visible = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            webBrowser1.Refresh();
        }
    }
}
