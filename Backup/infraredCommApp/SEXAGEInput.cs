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
    public partial class SEXAGEInput : Form
    {
        public SEXAGEInput()
        {
            InitializeComponent();
        }

        private void SEXAGEInput_Load(object sender, EventArgs e)
        {

            comboBoxAge.Items.Add("不明");
            comboBoxAge.Items.Add("10歳以下");
            comboBoxAge.Items.Add("10代");
            comboBoxAge.Items.Add("20代");
            comboBoxAge.Items.Add("30代");
            comboBoxAge.Items.Add("40代");
            comboBoxAge.Items.Add("50代");
            comboBoxAge.Items.Add("60代");
            comboBoxAge.Items.Add("70代");
            comboBoxAge.Items.Add("80代以上");

            comboBoxAge.SelectedIndex = Form1.gAgeIndex;

            
            comboBoxPlace.Items.Add("小千谷市");
            comboBoxPlace.Items.Add("長岡市");
            comboBoxPlace.Items.Add("県内");
            comboBoxPlace.Items.Add("県外");
            comboBoxPlace.Items.Add("海外");
            comboBoxPlace.Items.Add("不明");
            

            comboBoxPlace.SelectedIndex = Form1.gPlace;



            if (Form1.gSexal == 0)
            {
                radioButtonMale.Checked = true;
                radioButtonFemale.Checked = false;
            }
            else
            {
                radioButtonMale.Checked = false;
                radioButtonFemale.Checked = true;
            }
                


        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (radioButtonMale.Checked) Form1.gSexal = 0;
            else Form1.gSexal = 1;


            Form1.gAgeIndex = comboBoxAge.SelectedIndex;

            Form1.gPlace = comboBoxPlace.SelectedIndex;

            this.Close();

        }
    }
}
