using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.IO.Ports;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;



namespace infraredCommApp
{


    public partial class Form1 : Form
    {

        // GLOBAL DEFINES
              
        public static string appName = "FlowLine2022";
        public static string logpath = "";
        public static string workfolder = "";
        public static string ibcfolder = "";

               
       
        public Form1()
        {
            InitializeComponent();

            
            //load the basic parameters
            string apppath = System.AppDomain.CurrentDomain.BaseDirectory.ToString();
            string config = apppath + "\\" + "config.txt";
            if (File.Exists(config))
            {
                StreamReader sr = new StreamReader(config);
                try
                {

                    Form1.workfolder = sr.ReadLine();
                    Form1.logpath = sr.ReadLine();
                    Form1.ibcfolder = sr.ReadLine();
                                       
                    
                }
                catch
                {


                }

                sr.Close();

            }//existed
            else
            {

                Form1.workfolder = "c:\\" + appName + "\\";
                Form1.logpath = "c:\\" + appName + "\\Log\\";

                
                {

                    

                    new setupbasic().ShowDialog();



                    if (!Directory.Exists(workfolder)) //create new folder, if no exist
                    {
                        Directory.CreateDirectory(workfolder);
                    }

                    if (!Directory.Exists(logpath)) //ceate new folder, if no exist
                    {
                        Directory.CreateDirectory(logpath);
                    }

                }
                


                //save the setting
                apppath = System.AppDomain.CurrentDomain.BaseDirectory.ToString();
                config = apppath + "\\" + "config.txt";
                if (File.Exists(config))
                {
                    File.Delete(config);
                }

                StreamWriter sw = new StreamWriter(config);

                sw.WriteLine(Form1.workfolder);
                sw.WriteLine(Form1.logpath);
                sw.WriteLine(Form1.ibcfolder);
                               
                sw.Close();


            }
            /////////////////////////////////////////////////
            //
           
        }



        private void Form1_Load(object sender, EventArgs e)
        {
                    
           
           

                                              

        }




                      

        private void button2_Click(object sender, EventArgs e)
        {
           

            string apppath = System.AppDomain.CurrentDomain.BaseDirectory.ToString();
            string config = apppath + "\\" + "config.txt";
            if (File.Exists(config))
            {
                File.Delete(config);
            }
            StreamWriter sw = new StreamWriter(config);

            sw.WriteLine(Form1.workfolder);
            sw.WriteLine(Form1.logpath);
            sw.WriteLine(Form1.ibcfolder);
            
                        
            sw.Close();

            this.Close();
           
        }

       

        

        private void button1_Click(object sender, EventArgs e)
        {

            setupbasic fsetup = new setupbasic();

            if ( fsetup.ShowDialog() == DialogResult.OK )
            //if (new setupbasic().ShowDialog() == DialogResult.OK)
            {

  

            }
          

        }

       



      


     


    }
}
