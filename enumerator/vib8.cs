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
    public partial class vib8 : Form
    {
        public vib8()
        {
            InitializeComponent();
        }

        private void vib8_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Visible = false;
        }

        private void vib8_Load(object sender, EventArgs e)
        {

        }
    }
}
