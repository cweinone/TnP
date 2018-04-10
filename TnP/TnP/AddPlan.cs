using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TnP
{
    public partial class AddPlan : Form
    {
        public string plan;
        public AddPlan()
        {
            InitializeComponent();
        }

        private void AddPlan_Load(object sender, EventArgs e)
        {

        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            if(textBox1 != null && textBox1.Text != "")
            {
                plan = textBox1.Text;
            }
            this.Close();
        }
    }
}
