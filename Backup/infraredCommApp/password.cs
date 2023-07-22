using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace infraredCommApp
{
    public partial class password : Form
    {
        public password()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == Form1.strSETUPpassword)
            {
                this.DialogResult = DialogResult.OK;

            }

            this.Close();
        }
    }
}
