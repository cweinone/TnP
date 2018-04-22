using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TnP.SubForm
{
    public partial class Add : Form
    {
        public Add()
        {
            InitializeComponent();
        }
        public string s;

        private void OKbutton_Click(object sender, EventArgs e)
        {
            if (textBox1 != null && textBox1.Text != "")
            {
                s = textBox1.Text;
                this.Close();
            }

        }
    }
}
