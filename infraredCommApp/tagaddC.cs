using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace infraredCommApp
{
    public partial class tagaddC : Form
    {
        // public static string IDboxC = "";
        //public static string NameboxC = "";

        public static  string ID = "";
        public static string Name = "";

        public tagaddC()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // set2 SE2 = new set2();
            /*
             Form1 SE2 = new Form1();
             UserControl1 mypanel = new UserControl1();
             */
            // mypanel.Location = new Point(Form1.x, Form1.y);
            // SE2.pictureBox1.Controls.Add(mypanel);
            // SE2.pi
            ID = txtId.Text.Trim();
            Name = txtName.Text.Trim();

       /* SE2.Show();
        * */
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void tagaddC_Load(object sender, EventArgs e)
        {

        }
    }
}
