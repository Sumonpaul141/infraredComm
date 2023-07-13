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
    public partial class deviceUsingInfo : Form
    {

        int nDeviceDetail = -1;


        List<DeviceUseInformation> gDeviceUseINFO = new List<DeviceUseInformation>();


        public deviceUsingInfo()
        {
            InitializeComponent();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {




        }

        private void deviceUsingInfo_Load(object sender, EventArgs e)
        {

            for (int i = 1; i < 51; i++)
            {

                listBoxDevList.Items.Add("端末" + i.ToString());

            }


            listBox1.Items.Add("コースA");
            listBox1.Items.Add("コースB");
            listBox1.Items.Add("コースC");
            listBox1.Items.Add("コースD");
            listBox1.Items.Add("コースE");

            radioButton1.Checked = true;

            for (int i = 0; i < 5; i++)
            {

                listBox1.SetSelected(i, true);
            }


            for (int i = 0; i < 50; i++)
            {
                listBoxDevList.SetSelected(i, true);

            }


        }

        private void buttonALLYES_Click(object sender, EventArgs e)
        {

            for (int i = 0; i < 50; i++)
            {
                listBoxDevList.SetSelected(i, true);

            }


        }

        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 50; i++)
            {
                listBoxDevList.SetSelected(i, false);

            }
        }

       
        



        private void buttonOK_Click(object sender, EventArgs e)
        {

            //CSV file output
            gDeviceUseINFO.Clear();

            bool bFound = false;


            if (listBoxDevList.SelectedItems.Count == 0)
            {

                MessageBox.Show("集計対象端末を指定してください。");
                return;


            }


            // get the device selected information
            for (int i = 0; i < listBoxDevList.SelectedItems.Count; i++)
            {
                int nIndex = listBoxDevList.SelectedIndices[i];


                DeviceUseInformation duiTemp = new DeviceUseInformation();

                duiTemp.nDeviceNo = nIndex + 1;

                gDeviceUseINFO.Add(duiTemp);


            }//for

            // get the period information for calculateion

            DateTime dtLOGStart, dtLOGEnd;
            string d, f;

            f = "yyyy-MM-dd HH:mm:ss";



            DateTime dtStart, dtEnd, dtTemp;

            dtTemp = dateTimePicker1.Value;

            d = dtTemp.Date.ToString("yyyy-MM-dd") + " 00:00:01";
            dtStart = DateTime.ParseExact(d, f, null);

            dtTemp = dateTimePicker2.Value;

            d = dtTemp.Date.ToString("yyyy-MM-dd") + " 23:59:59";
            dtEnd = DateTime.ParseExact(d, f, null);

            if (checkBox1.Checked == false)
            {
                int nCompanre;

                nCompanre = System.DateTime.Compare(dtEnd, dtStart);

                if (nCompanre == -1)
                {
                    MessageBox.Show("正しい期間をしてください。");
                    return;

                }

                dtLOGStart = dtStart;
                dtLOGEnd = dtEnd;
            }
            else
            {

                dtLOGStart = DateTime.MinValue;
                dtLOGEnd = DateTime.MaxValue;
            }


            // the device mode informatino
            UInt32 u32ModeMask = 0x0;

            if (checkBoxExp.Checked) u32ModeMask |= 0x1000;

            if (listBox1.SelectedItems.Count > 0)
            {



                for (int i = 0; i < listBox1.SelectedItems.Count; i++)
                {

                    int nIndex = listBox1.SelectedIndices[i];

                    UInt32 u32Mask1 = 0x0001;

                    u32ModeMask |= (u32Mask1 << nIndex);

                } //for i
            }

            // begin calculation
            string loginfopath = Form1.workfolder + "DeviceUseResult.csv";

            if (File.Exists(loginfopath) == false)
            {

                MessageBox.Show("ログファイルがありません");
                return;
            }

            StreamReader sr = new StreamReader(loginfopath, Encoding.GetEncoding("Shift_JIS"));

            string text;
            string szTemp1;

            int nDeviceNoTemp;
            UInt32 u32ModeTemp;
            DateTime dtRunTemp;
            int nUsedTimeTemp;
            int nPlayTimeTemp;
            int nPlayTimes;

            string strSave = "Device No,Active Mode,Date,Time,Rental time,Play Numbers,Play time,Sex,Age, User SN, IsStory, QuizCourse \r\n";
            string strTempSave = "";

            text = sr.ReadLine();//skip title

            while (sr.Peek() > -1)
            {
                text = sr.ReadLine();

                strTempSave = text;

                if (text == "") break;

                // analysis this line

                //device no
                szTemp1 = text.Substring(0, text.IndexOf(","));
                nDeviceNoTemp = int.Parse(szTemp1);

                //mode
                text = text.Substring(text.IndexOf(",") + 1, text.Length - text.IndexOf(",") - 1);
                szTemp1 = text.Substring(0, text.IndexOf(","));
                u32ModeTemp = Convert.ToUInt32(szTemp1, 16);

                // date
                text = text.Substring(text.IndexOf(",") + 1, text.Length - text.IndexOf(",") - 1);
                szTemp1 = text.Substring(0, text.IndexOf(","));
                d = szTemp1;
                text = text.Substring(text.IndexOf(",") + 1, text.Length - text.IndexOf(",") - 1);
                szTemp1 = text.Substring(0, text.IndexOf(","));
                d = d + " " + szTemp1;

                dtRunTemp = DateTime.Parse(d);

                // used time

                text = text.Substring(text.IndexOf(",") + 1, text.Length - text.IndexOf(",") - 1);
                szTemp1 = text.Substring(0, text.IndexOf(","));
                nUsedTimeTemp = int.Parse(szTemp1);


                // playtimes

                text = text.Substring(text.IndexOf(",") + 1, text.Length - text.IndexOf(",") - 1);
                szTemp1 = text.Substring(0, text.IndexOf(","));
                nPlayTimes = int.Parse(szTemp1);

                // play total time

                text = text.Substring(text.IndexOf(",") + 1, text.Length - text.IndexOf(",") - 1);
                szTemp1 = text.Substring(0, text.IndexOf(","));
                nPlayTimeTemp = int.Parse(szTemp1);



                int nCompanre;


                //check date 
                if (checkBox1.Checked == false)
                {

                    nCompanre = System.DateTime.Compare(dtStart, dtRunTemp);

                    if (nCompanre >= 1) continue;

                    nCompanre = System.DateTime.Compare(dtRunTemp, dtEnd);

                    if (nCompanre >= 1) continue;

                }
                else
                {
                    nCompanre = System.DateTime.Compare(dtLOGStart, dtRunTemp);
                    if (nCompanre >= 1)
                    {
                        dtLOGStart = dtRunTemp;
                    }

                    nCompanre = System.DateTime.Compare(dtLOGEnd, dtRunTemp);
                    if (nCompanre < 0)
                    {
                        dtLOGEnd = dtRunTemp;
                    }

                }

                // check if this is the log record that we need with the condition
                foreach (DeviceUseInformation dui in gDeviceUseINFO)
                {

                    if (dui.nDeviceNo == nDeviceNoTemp)
                    {
                        if ((u32ModeTemp & u32ModeMask) != 0)
                        {
                            bFound = true;


                            strSave += strTempSave + ",";



                            if ((u32ModeTemp & 0x1000) == 0x1000)
                            {

                                strSave += "震災体験談";

                            }
                            else
                            {
                                strSave += "NON";
                            }

                            if ((u32ModeTemp & 0x0FFF) != 0)
                            {
                                string strName = "";
                                byte u8Course = (byte)((u32ModeTemp & 0xFFF));


                                switch (u8Course)
                                {
                                    case 1:
                                        strName = "A";
                                        break;

                                    case 2:
                                        strName = "B";
                                        break;

                                    case 4:
                                        strName = "C";
                                        break;

                                    case 8:
                                        strName = "D";
                                        break;

                                    case 16:
                                        strName = "E";
                                        break;



                                }



                                strSave += ",クイズ" + strName + ",";
                            }
                            else strSave += ",NON";


                            strSave += "\r\n";

                            break;
                        }
                        

                    }//if 
                } //foreach






            }
            sr.Close();


            if (bFound == false)
            {


                MessageBox.Show("集計条件を満たす結果がありませんでした。");
                return;


            }

            //save the result to CSV file
            // here we output the csv file
            //  title, times, total time, max time, min time, average time
            // open the save diaolge
            //SaveFileDialogクラスのインスタンスを作成
            SaveFileDialog sfd = new SaveFileDialog();

            

            //はじめのファイル名を指定する
            sfd.FileName = "新しいファイル.csv";
            //はじめに表示されるフォルダを指定する
            //sfd.InitialDirectory = @"C:\";
            //[ファイルの種類]に表示される選択肢を指定する
            sfd.Filter = "CSVファイル(*.csv;*.CSV)|*.csv;*.CSV";
            //[ファイルの種類]ではじめに
            //「すべてのファイル」が選択されているようにする
            sfd.FilterIndex = 2;
            //タイトルを設定する
            sfd.Title = "保存先のファイルを選択してください";
            //ダイアログボックスを閉じる前に現在のディレクトリを復元するようにする
            sfd.RestoreDirectory = true;
            //既に存在するファイル名を指定したとき警告する
            //デフォルトでTrueなので指定する必要はない
            sfd.OverwritePrompt = true;
            //存在しないパスが指定されたとき警告を表示する
            //デフォルトでTrueなので指定する必要はない
            sfd.CheckPathExists = true;

            //ダイアログを表示する
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                //OKボタンがクリックされたとき
                //選択されたファイル名を表示する
                string szFilepath = sfd.FileName;

                bool bJPN = true;

                System.IO.StreamWriter sw;

                if (bJPN)
                {

                    sw = new System.IO.StreamWriter(
                       sfd.FileName, false, System.Text.Encoding.GetEncoding("shift_jis"));
                }
                else
                {
                    sw = new System.IO.StreamWriter(
                            sfd.FileName, false, System.Text.Encoding.GetEncoding("gb2312"));
                }

                //write the abstract information
                sw.WriteLine( strSave );

                
                sw.Close();
            }

            this.Close();


        }

        private void button3_Click(object sender, EventArgs e)
        {
            


            for (int i = 0; i < 5; i++)
            {

                listBox1.SetSelected(i, true);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 5; i++)
            {

                listBox1.SetSelected(i, false);
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

            if (checkBox1.Checked == true)
            {
                dateTimePicker1.Enabled = false;
                dateTimePicker2.Enabled = false;

            }
            else
            {
                dateTimePicker1.Enabled = true;
                dateTimePicker2.Enabled = true;

            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //CSV file output
            
            

            bool bFound = false;

            gDeviceUseINFO.Clear();

            if (listBoxDevList.SelectedItems.Count == 0)
            {

                MessageBox.Show("集計対象端末を指定してください。");
                return;


            }


            // get the device selected information
            for (int i = 0; i < listBoxDevList.SelectedItems.Count; i++)
            {
                int nIndex = listBoxDevList.SelectedIndices[i];


                DeviceUseInformation duiTemp = new DeviceUseInformation();

                duiTemp.nDeviceNo = nIndex + 1;

                gDeviceUseINFO.Add( duiTemp );


            }//for

            // get the period information for calculateion

            DateTime dtLOGStart, dtLOGEnd;
            string d, f;

            f = "yyyy-MM-dd HH:mm:ss";



            DateTime dtStart, dtEnd, dtTemp;

            dtTemp = dateTimePicker1.Value;

            d = dtTemp.Date.ToString("yyyy-MM-dd") + " 00:00:01";
            dtStart = DateTime.ParseExact(d, f, null);

            dtTemp = dateTimePicker2.Value;

            d = dtTemp.Date.ToString("yyyy-MM-dd") + " 23:59:59";
            dtEnd = DateTime.ParseExact(d, f, null);

            if (checkBox1.Checked == false)
            {
                int nCompanre;

                nCompanre = System.DateTime.Compare(dtEnd, dtStart);

                if (nCompanre == -1)
                {
                    MessageBox.Show("正しい期間をしてください。");
                    return;

                }

                dtLOGStart = dtStart;
                dtLOGEnd = dtEnd;
            }
            else
            {

                dtLOGStart = DateTime.MinValue;
                dtLOGEnd = DateTime.MaxValue;
            }


            // the device mode informatino
            UInt32 u32ModeMask = 0x0;

            if ( checkBoxExp.Checked ) u32ModeMask |= 0x1000;

           　if ( listBox1.SelectedItems.Count > 0)
            {
                
                

                 for (int i = 0; i < listBox1.SelectedItems.Count; i++)
                {
                                                   
                    int nIndex =     listBox1.SelectedIndices[i];

                     UInt32 u32Mask1 = 0x0001;
                    
                     u32ModeMask |=  ( u32Mask1 << nIndex );

                 } //for i
            }

            // begin calculation
             string loginfopath = Form1.workfolder + "DeviceUseResult.csv";

             if (File.Exists(loginfopath) == false)
             {
                 MessageBox.Show("ログファイルがありません");
                 return;

             }


            StreamReader sr = new StreamReader(loginfopath, Encoding.GetEncoding("Shift_JIS"));

            string text;
            string szTemp1;

            int nDeviceNoTemp ;
            UInt32 u32ModeTemp;
            DateTime dtRunTemp;
            int     nUsedTimeTemp;
            int nPlayTimeTemp;
            int nPlayTimes;

            text = sr.ReadLine();//skip title

            while (sr.Peek() > -1)
            {
                text = sr.ReadLine();

                if (text == "") break;

                // analysis this line
                
                //device no
                szTemp1 = text.Substring(0, text.IndexOf(","));
                nDeviceNoTemp = int.Parse( szTemp1 );

                //mode
                text = text.Substring(text.IndexOf(",") + 1, text.Length - text.IndexOf(",") - 1);
                szTemp1 = text.Substring(0, text.IndexOf(","));
                u32ModeTemp = Convert.ToUInt32( szTemp1, 16);
                
                // date
                text = text.Substring(text.IndexOf(",") + 1, text.Length - text.IndexOf(",") - 1);
                szTemp1 = text.Substring(0, text.IndexOf(","));
                d = szTemp1;
                text = text.Substring(text.IndexOf(",") + 1, text.Length - text.IndexOf(",") - 1);
                szTemp1 = text.Substring(0, text.IndexOf(","));
                d = d + " " + szTemp1;
                
                dtRunTemp = DateTime.Parse(d);

                // used time
                 
                text = text.Substring(text.IndexOf(",") + 1, text.Length - text.IndexOf(",") - 1);
                szTemp1 = text.Substring(0, text.IndexOf(","));
                nUsedTimeTemp = int.Parse(szTemp1);


                // playtimes
                
                text = text.Substring(text.IndexOf(",") + 1, text.Length - text.IndexOf(",") - 1);
                szTemp1 = text.Substring(0, text.IndexOf(","));
                nPlayTimes = int.Parse(szTemp1);

                // play total time
                
                text = text.Substring(text.IndexOf(",") + 1, text.Length - text.IndexOf(",") - 1);
                szTemp1 = text.Substring(0, text.IndexOf(","));
                nPlayTimeTemp = int.Parse(szTemp1);



                int nCompanre;

                
                //check date 
                if (checkBox1.Checked == false)
                {
                    
                    nCompanre = System.DateTime.Compare(dtStart, dtRunTemp);

                    if (nCompanre >= 1) continue;

                    nCompanre = System.DateTime.Compare(dtRunTemp, dtEnd);

                    if (nCompanre >= 1) continue;

                }
                else
                {
                    nCompanre = System.DateTime.Compare(dtLOGStart, dtRunTemp);
                    if (nCompanre >= 1)
                    {
                        dtLOGStart = dtRunTemp;
                    }

                    nCompanre = System.DateTime.Compare(dtLOGEnd, dtRunTemp);
                    if (nCompanre < 0)
                    {
                        dtLOGEnd = dtRunTemp;
                    }

                }

                // check if this is the log record that we need with the condition
                foreach ( DeviceUseInformation dui in gDeviceUseINFO )
                {
                
                    if ( dui.nDeviceNo == nDeviceNoTemp )
                    {
                        if ( (u32ModeTemp & u32ModeMask) != 0 )
                        {
                            bFound = true;

                            if (dui.nTotalTimes == 0)
                            {
                                dui.nMaxTime = nUsedTimeTemp;
                                dui.nMinTime = nUsedTimeTemp;
                                dui.nMinPlayTime = nPlayTimeTemp;
                                dui.nMaxPlayTime = nPlayTimeTemp;
                            }

                            //this is the record we need
                            dui.nTotalTimes ++;
                            dui.nTotalTime += nUsedTimeTemp;

                            dui.nPlayNums += nPlayTimes;
                            dui.nTotalPlayTime += nPlayTimeTemp;

                            if ( dui.nMinTime > nUsedTimeTemp ) dui.nMinTime = nUsedTimeTemp;

                            if ( dui.nMaxTime < nUsedTimeTemp ) dui.nMaxTime = nUsedTimeTemp;

                            if (dui.nMinPlayTime > nPlayTimeTemp) dui.nMinPlayTime = nPlayTimeTemp;
                            if (dui.nMaxPlayTime < nPlayTimeTemp) dui.nMaxPlayTime = nPlayTimeTemp;

                            dui.nAverageTime = dui.nTotalTime / dui.nTotalTimes;


                            break;
                        }




                    }//if 
                } //foreach


               
                


            }
            sr.Close();


            if (bFound == false)
            {


                MessageBox.Show("集計条件を満たす結果がありませんでした。");
                return;


            }

            //here we show the result

            if (gDeviceUseINFO.Count > 0)
            {

                deviceprocess();
            }
            


/*
            //save the result to CSV file
            // here we output the csv file
            //  title, times, total time, max time, min time, average time
            // open the save diaolge
            //SaveFileDialogクラスのインスタンスを作成
            SaveFileDialog sfd = new SaveFileDialog();

            string szTemp = "";

            //はじめのファイル名を指定する
            sfd.FileName = "新しいファイル.csv";
            //はじめに表示されるフォルダを指定する
            //sfd.InitialDirectory = @"C:\";
            //[ファイルの種類]に表示される選択肢を指定する
            sfd.Filter = "CSVファイル(*.csv;*.CSV)|*.csv;*.CSV";
            //[ファイルの種類]ではじめに
            //「すべてのファイル」が選択されているようにする
            sfd.FilterIndex = 2;
            //タイトルを設定する
            sfd.Title = "保存先のファイルを選択してください";
            //ダイアログボックスを閉じる前に現在のディレクトリを復元するようにする
            sfd.RestoreDirectory = true;
            //既に存在するファイル名を指定したとき警告する
            //デフォルトでTrueなので指定する必要はない
            sfd.OverwritePrompt = true;
            //存在しないパスが指定されたとき警告を表示する
            //デフォルトでTrueなので指定する必要はない
            sfd.CheckPathExists = true;

            //ダイアログを表示する
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                //OKボタンがクリックされたとき
                //選択されたファイル名を表示する
                string szFilepath = sfd.FileName;

                bool bJPN = true;

                System.IO.StreamWriter sw;

                if (bJPN)
                {

                    sw = new System.IO.StreamWriter(
                       sfd.FileName, false, System.Text.Encoding.GetEncoding("shift_jis"));
                }
                else
                {
                    sw = new System.IO.StreamWriter(
                            sfd.FileName, false, System.Text.Encoding.GetEncoding("gb2312"));
                }

                //write the abstract information
                szTemp = "start date, " + dtLOGStart.Date.ToShortDateString() + ","
                    + "end date, "
                    + dtLOGEnd.ToShortDateString();
                sw.WriteLine(szTemp);

                // write data

                // device no, used times, used total time, max play time, min play time, averge time
                //  title, times, total time, max time, min time, average time
                //szTemp = "Title, Visit Times, Total Visiting Time, Max Visiting Time, Min Visiting Time, Average Time, Max playtime,Min play Time, play times";
                szTemp = "Device No, Total used Times, total used time, max used time, min used time, average used time, max play time, min play time, total playtime, total play number";
                sw.WriteLine(szTemp);

                foreach (DeviceUseInformation dui in gDeviceUseINFO)
                {
                    if (dui.nTotalTimes == 0) continue;

                    szTemp = dui.nDeviceNo.ToString() + ","
                            + dui.nTotalTimes.ToString() + ","
                            + dui.nTotalTime.ToString() + ","
                            + dui.nMaxTime.ToString() + ","
                            + dui.nMinTime.ToString() + ","
                            + dui.nAverageTime.ToString() + ","
                            + dui.nMaxPlayTime.ToString() + ","
                            + dui.nMinPlayTime.ToString() + ","
                            + dui.nTotalPlayTime.ToString() + ","
                            + dui.nPlayNums.ToString();

                    sw.WriteLine(szTemp);

                }
                

                sw.Close();
            }

*/



            //this.Close();   


        }


        private void deviceprocess()
        {

            textBox1.Clear();

            if (gDeviceUseINFO.Count == 0) return;

            string szTemp = "";


            if (radioButton1.Checked == true)
            {
                gDeviceUseINFO.Sort(delegate(DeviceUseInformation dui1, DeviceUseInformation dui2)
                { return dui1.nDeviceNo - dui2.nDeviceNo; });

            }
            else if (radioButton2.Checked == true)
            {
                gDeviceUseINFO.Sort(delegate(DeviceUseInformation dui1, DeviceUseInformation dui2)
                { return dui2.nTotalTimes - dui1.nTotalTimes; });


            }
            else
            {
                gDeviceUseINFO.Sort(delegate(DeviceUseInformation dui1, DeviceUseInformation dui2)
                { return dui2.nTotalTime - dui1.nTotalTime; });

            }

            foreach (DeviceUseInformation dui in gDeviceUseINFO)
            {
                if (dui.nTotalTimes == 0) continue;

                float fHour = 0;

                fHour = dui.nTotalTime / 3600f;

                
                szTemp += "端末番号:" + string.Format("{0, -2}", dui.nDeviceNo )  
                       +  " 利用回数:" + string.Format("{0, -6}", dui.nTotalTimes )  
                       +  " 利用時間:" + fHour.ToString("F3") + "時間" + "\r\n";



            }

            textBox1.Text = szTemp;


        }



        private void button5_Click(object sender, EventArgs e)
        {

            deviceUsedListShow fduls = new deviceUsedListShow();


            fduls.ShowDialog();




        }

        private void button6_Click(object sender, EventArgs e)
        {
            dateTimePicker1.Value = DateTime.Now;
            dateTimePicker2.Value = DateTime.Now;

            checkBox1.Checked = false;


        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            deviceprocess();

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            deviceprocess();

        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            deviceprocess();

        }  //func





    }
}
