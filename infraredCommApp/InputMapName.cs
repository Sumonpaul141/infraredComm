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
    public partial class InputMapName : Form
    {
        public static string fileName = string.Empty;
        public InputMapName()
        {
            InitializeComponent();
        }

        private void InputMapName_Load(object sender, EventArgs e)
        {
            //this.Close();
            //this.panel1.BackgroundImage = Image.FromFile(file_name);
        }

        public void button1_Click(object sender, EventArgs e)
        {
            fileName = map_name_textBox1.Text;
            //String s = sender.ToString();
            //Debug.WriteLine(s);
           // if (fileName.Trim() == String.Empty)

            /*
            if (fileName.Trim() == "")
                return ; // Returns true if no input or only space is found
            */
           if (fileName.Trim() == String.Empty)
                return ;
            this.Close();
        }
    }
}
