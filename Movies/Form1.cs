using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Movies
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            insert ins = new insert();
            ins.Show();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            edit edt = new edit();
            edt.Show();
        }
    }
}
