using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Threading;

namespace infraredCommApp
{
    public partial class setupbasic : Form
    {
        public bool bRemoveDeviceInfo = false;

        public setupbasic()
        {
            InitializeComponent();
        }

        private void setupbasic_Load(object sender, EventArgs e)
        {
            checkBoxDevInfoReset.Checked = false;

            //init the workfolder and logfolder
            workfolder.Text = Form1.workfolder;
            logfolder.Text = Form1.logpath;

            ibcfolder.Text = Form1.ibcfolder;
            
            Setuplockcheckbox.Checked = Form1.gb_FinalSetup;

            checkBox3.Checked = Form1.gbSaveLogData;

            logRFChn.Text = Form1.nRFChnLog.ToString();
            
            

            //if (Form1.idnum > 0) deviceSetupStatus.Text = "既に設定が指定された。";


        }

        private void workfoldersetup_Click(object sender, EventArgs e)
        {

            FolderBrowserDialog fbd = new FolderBrowserDialog();

            //上部に表示する説明テキストを指定する
            fbd.Description = "作業用フォルダを指定してください。";
            //ルートフォルダを指定する
            //デフォルトでDesktop
            fbd.RootFolder = Environment.SpecialFolder.Desktop;
            //最初に選択するフォルダを指定する
            //RootFolder以下にあるフォルダである必要がある
            if (Form1.workfolder == "") Form1.workfolder = "C:\\" + Form1.appName + "\\";

            fbd.SelectedPath = Form1.workfolder; // @"C:\Windows";
            //ユーザーが新しいフォルダを作成できるようにする
            //デフォルトでTrue
            fbd.ShowNewFolderButton = true;

            //ダイアログを表示する
            if (fbd.ShowDialog(this) == DialogResult.OK)
            {
                //選択されたフォルダを表示する
                //onsole.WriteLine(fbd.SelectedPath);
                Form1.workfolder = fbd.SelectedPath + "\\";

                workfolder.Text = Form1.workfolder;

            }
        }

        private void logfoldersetup_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();

            //上部に表示する説明テキストを指定する
            fbd.Description = "ログデータ保存用フォルダを指定してください。";
            //ルートフォルダを指定する
            //デフォルトでDesktop
            fbd.RootFolder = Environment.SpecialFolder.Desktop;
            //最初に選択するフォルダを指定する
            //RootFolder以下にあるフォルダである必要がある
            if (Form1.logpath == "") Form1.logpath = @"C:\\";

            fbd.SelectedPath = Form1.logpath; // @"C:\Windows";
            //ユーザーが新しいフォルダを作成できるようにする
            //デフォルトでTrue
            fbd.ShowNewFolderButton = true;

            //ダイアログを表示する
            if (fbd.ShowDialog(this) == DialogResult.OK)
            {
                //選択されたフォルダを表示する
                //onsole.WriteLine(fbd.SelectedPath);
                Form1.logpath = fbd.SelectedPath + "\\";

                logfolder.Text = Form1.logpath;

            }
        }

        private void deviceIDSetup_Click(object sender, EventArgs e)
        {

            FolderBrowserDialog fbd = new FolderBrowserDialog();

            //上部に表示する説明テキストを指定する
            fbd.Description = "作業用フォルダを指定してください。";
            //ルートフォルダを指定する
            //デフォルトでDesktop
            fbd.RootFolder = Environment.SpecialFolder.Desktop;
            //最初に選択するフォルダを指定する
            //RootFolder以下にあるフォルダである必要がある
            if (Form1.ibcfolder == "") Form1.ibcfolder = "C:\\" + Form1.appName + "\\";

            fbd.SelectedPath = Form1.ibcfolder; // @"C:\Windows";
            //ユーザーが新しいフォルダを作成できるようにする
            //デフォルトでTrue
            fbd.ShowNewFolderButton = true;

            //ダイアログを表示する
            if (fbd.ShowDialog(this) == DialogResult.OK)
            {
                //選択されたフォルダを表示する
                //onsole.WriteLine(fbd.SelectedPath);
                Form1.ibcfolder = fbd.SelectedPath + "\\";

                ibcfolder.Text = Form1.ibcfolder;

            }
            ////////
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }






        private void button1_Click(object sender, EventArgs e)
        {

            bool bOK = true;


            if (Setuplockcheckbox.Checked)
            {
                if (password.Text == "")
                {
                    MessageBox.Show("暗証番号を入力してください");
                    bOK = false;
                }
            }

            if (bOK)
            {

                Form1.gb_FinalSetup = Setuplockcheckbox.Checked;

                Form1.workfolder = workfolder.Text;
                Form1.logpath = logfolder.Text;

                Form1.nRFChnLog = int.Parse(logRFChn.Text);

                Form1.strSETUPpassword = password.Text;

                Form1.gbSaveLogData = checkBox3.Checked;


                if (!Directory.Exists(ibcfolder.Text))
                {

                    MessageBox.Show("コンテンツファイルのフォルダーを指定してください");
                    bOK = false;

                }
            }


            if ( bOK )
            {

                Form1.ibcfolder = ibcfolder.Text;



                ////////////////////////////////////////////
                // save the current setting
                if (!Directory.Exists(Form1.workfolder)) //如果不存在就建立 
                {
                    Directory.CreateDirectory(Form1.workfolder);
                }

                if (!Directory.Exists(Form1.logpath)) //如果不存在就建立 
                {
                    Directory.CreateDirectory(Form1.logpath);
                }

                if (checkBoxDevInfoReset.Checked)
                {

                    string deviceusedresultPath = Form1.workfolder + "DeviceUseResult.csv";
                    File.Delete(deviceusedresultPath);

                    

                    deviceusedresultPath = Form1.workfolder + "ContentPlayResult.csv";
                    File.Delete(deviceusedresultPath);



                }

                if (checkBox1.Checked)
                {

                    Form1.gUsedDevice.Clear();

                }

                this.Close();
            }
        }

        

        
    }
}
