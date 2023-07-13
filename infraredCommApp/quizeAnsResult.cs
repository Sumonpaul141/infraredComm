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
    public partial class quizeAnsResult : Form
    {

        List<QuizAnsInformation> gQuizAnsINFO = new List<QuizAnsInformation>();
        public string AnalyzedData = "";

        public quizeAnsResult()
        {
            InitializeComponent();
        }

        private void quizeAnsResult_Load(object sender, EventArgs e)
        {
            radioButton1.Checked = true;


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

        private void button6_Click(object sender, EventArgs e)
        {
            dateTimePicker1.Value = DateTime.Now;
            dateTimePicker2.Value = DateTime.Now;

            checkBox1.Checked = false;
        }



        private void quizprocess()
        {

            if (gQuizAnsINFO.Count == 0) return;

            //show the result to the listbox
            textBox1.Clear();

            if (radioButton2.Checked == true)
            {
                // show at quiz ID

                gQuizAnsINFO.Sort(delegate (QuizAnsInformation qai1, QuizAnsInformation qai2) { return (qai2.nTotalAccessNum) - qai1.nTotalAccessNum; });

            }
            else if (radioButton1.Checked)
            {
                // show at quiz correct ratio
                gQuizAnsINFO.Sort(delegate (QuizAnsInformation qai1, QuizAnsInformation qai2)
                { return qai2.nCorrectRatio - qai1.nCorrectRatio; });


            }
            else
            {
                gQuizAnsINFO.Sort(delegate (QuizAnsInformation qai1, QuizAnsInformation qai2)
                { return qai1.u32CID.CompareTo(qai2.u32CID); });

            }



            string szTemp1 = "";

            foreach (QuizAnsInformation qai in gQuizAnsINFO)
            {


                szTemp1 += "コンテンツID:" + qai.u32CID.ToString("X8") + "  "
                        + "正解率:" + string.Format("{0, 3}", qai.nCorrectRatio) + "%  "
                        + "利用回数:" + qai.nTotalAccessNum.ToString()
                        + "\r\n";

            }

            textBox1.Text = szTemp1;
            AnalyzedData = szTemp1;
            this.Close();

        }
        /// <summary>
        /// //////////////////////////////////////////////////////////////////////
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {

            //give a summary of the quiz answer result
            //CSV file output
            gQuizAnsINFO.Clear();

            bool bFound = false;

            textBox1.Text = "";



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




            // begin calculation
            string loginfopath = Form1.workfolder + "ContentPlayResult.csv";

            if (File.Exists(loginfopath) == false)
            {
                MessageBox.Show("コンテンツ再生記録ファイルがありません");
                return;

            }


            StreamReader sr = new StreamReader(loginfopath, Encoding.GetEncoding("Shift_JIS"));

            string text;
            string szTemp1;

            UInt32 u32CIDTemp = 0;
            int nUsedTimeTemp = 0;
            DateTime dtUsedTiming;
            bool bQuizTemp = false;
            bool bCorrectAnsTemp = false;
            int nInputAns2;

            text = sr.ReadLine();//skip the head

            while (sr.Peek() > -1)
            {

                text = sr.ReadLine();

                if (text == "") break;

                // analysis this line
                //skip the user SN
                szTemp1 = text.Substring(0, text.IndexOf(","));

                //get the CID
                text = text.Substring(text.IndexOf(",") + 1, text.Length - text.IndexOf(",") - 1);
                szTemp1 = text.Substring(0, text.IndexOf(","));
                u32CIDTemp = Convert.ToUInt32(szTemp1, 16);

                // date
                text = text.Substring(text.IndexOf(",") + 1, text.Length - text.IndexOf(",") - 1);
                szTemp1 = text.Substring(0, text.IndexOf(","));
                d = szTemp1;
                text = text.Substring(text.IndexOf(",") + 1, text.Length - text.IndexOf(",") - 1);
                szTemp1 = text.Substring(0, text.IndexOf(","));
                d = d + " " + szTemp1;

                dtUsedTiming = DateTime.Parse(d);

                // content using  timing
                text = text.Substring(text.IndexOf(",") + 1, text.Length - text.IndexOf(",") - 1);
                szTemp1 = text.Substring(0, text.IndexOf(","));
                nUsedTimeTemp = int.Parse(szTemp1);


                // skip end mode
                text = text.Substring(text.IndexOf(",") + 1, text.Length - text.IndexOf(",") - 1);
                szTemp1 = text.Substring(0, text.IndexOf(","));


                // get Quiz mode
                text = text.Substring(text.IndexOf(",") + 1, text.Length - text.IndexOf(",") - 1);
                szTemp1 = text.Substring(0, text.IndexOf(","));
                bQuizTemp = bool.Parse(szTemp1);

                // get Answer Correct mode
                text = text.Substring(text.IndexOf(",") + 1, text.Length - text.IndexOf(",") - 1);
                szTemp1 = text.Substring(0, text.IndexOf(","));
                bCorrectAnsTemp = bool.Parse(szTemp1);

                // get input answer No
                text = text.Substring(text.IndexOf(",") + 1, text.Length - text.IndexOf(",") - 1);
                //szTemp1 = text.Substring(0, text.IndexOf(","));
                nInputAns2 = int.Parse(text);



                //if this is not quiz, we skip this line record
                if (bQuizTemp == false) continue;

                if (nInputAns2 == 0) continue; //uncompleted answer record, ignore it

                int nCompanre;

                //check date 
                if (checkBox1.Checked == false)
                {

                    nCompanre = System.DateTime.Compare(dtStart, dtUsedTiming);

                    if (nCompanre >= 1) continue;

                    nCompanre = System.DateTime.Compare(dtUsedTiming, dtEnd);

                    if (nCompanre >= 1) continue;

                }
                else
                {
                    nCompanre = System.DateTime.Compare(dtLOGStart, dtUsedTiming);
                    if (nCompanre >= 1)
                    {
                        dtLOGStart = dtUsedTiming;
                    }

                    nCompanre = System.DateTime.Compare(dtLOGEnd, dtUsedTiming);
                    if (nCompanre < 0)
                    {
                        dtLOGEnd = dtUsedTiming;
                    }

                }

                bool bFound2 = false;

                bFound = true;

                // check the content quiz answer condition
                foreach (QuizAnsInformation qai in gQuizAnsINFO)
                {

                    //if the content quiz is in list already
                    if (qai.u32CID == u32CIDTemp)
                    {
                        // already exist, we only modify it
                        qai.nTotalAccessNum++;

                        if (bCorrectAnsTemp) qai.nCorrectAnsNum++;

                        qai.nTotalUsedTime += nUsedTimeTemp;

                        if (qai.nMaxUsedTime < nUsedTimeTemp) qai.nMaxUsedTime = nUsedTimeTemp;

                        if (qai.nMinUsedTime > nUsedTimeTemp) qai.nMinUsedTime = nUsedTimeTemp;

                        qai.nAverageUsedTime = qai.nTotalUsedTime / qai.nTotalUsedTime;

                        qai.nCorrectRatio = (qai.nCorrectAnsNum * 100) / qai.nTotalAccessNum;

                        bFound2 = true;

                        break;

                    }

                }// new foreach

                if (bFound2 == false)
                {
                    //no such record CID, we will add new one for it
                    // add a new one to the list
                    QuizAnsInformation qaiTemp = new QuizAnsInformation();

                    qaiTemp.nTotalAccessNum++;

                    if (bCorrectAnsTemp) qaiTemp.nCorrectAnsNum++;

                    qaiTemp.nTotalUsedTime += nUsedTimeTemp;

                    qaiTemp.u32CID = u32CIDTemp;

                    if (qaiTemp.nMaxUsedTime < nUsedTimeTemp) qaiTemp.nMaxUsedTime = nUsedTimeTemp;

                    if (qaiTemp.nMinUsedTime > nUsedTimeTemp) qaiTemp.nMinUsedTime = nUsedTimeTemp;

                    qaiTemp.nAverageUsedTime = qaiTemp.nTotalUsedTime / qaiTemp.nTotalUsedTime;

                    qaiTemp.nCorrectRatio = (qaiTemp.nCorrectAnsNum * 100) / qaiTemp.nTotalAccessNum;

                    gQuizAnsINFO.Add(qaiTemp);

                }


            }
            sr.Close();


            if (bFound == false)
            {


                MessageBox.Show("集計条件を満たす結果がありませんでした。");
                return;


            }


            quizprocess();



        }

        private void buttonOK_Click(object sender, EventArgs e)
        {

            string strSave = "";

            //give a summary of the quiz answer result
            //CSV file output
            gQuizAnsINFO.Clear();

            bool bFound = false;



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




            // begin calculation
            string loginfopath = Form1.workfolder + "ContentPlayResult.csv";

            if (File.Exists(loginfopath) == false)
            {
                MessageBox.Show("コンテンツ再生記録ファイルがありません");
                return;

            }


            StreamReader sr = new StreamReader(loginfopath, Encoding.GetEncoding("Shift_JIS"));

            string text;
            string szTemp1;

            UInt32 u32CIDTemp = 0;
            int nUsedTimeTemp = 0;
            DateTime dtUsedTiming;
            bool bQuizTemp = false;
            bool bCorrectAnsTemp = false;

            string strTempSave = "";

            strSave = "user_SN, content ID, date, time, play time, end mode, quiz, correct answer \r\n";

            text = sr.ReadLine();//skip the head

            while (sr.Peek() > -1)
            {

                text = sr.ReadLine();

                if (text == "") break;

                strTempSave = text;

                // analysis this line
                //skip the user SN
                szTemp1 = text.Substring(0, text.IndexOf(","));

                //get the CID
                text = text.Substring(text.IndexOf(",") + 1, text.Length - text.IndexOf(",") - 1);
                szTemp1 = text.Substring(0, text.IndexOf(","));
                u32CIDTemp = Convert.ToUInt32(szTemp1, 16);

                // date
                text = text.Substring(text.IndexOf(",") + 1, text.Length - text.IndexOf(",") - 1);
                szTemp1 = text.Substring(0, text.IndexOf(","));
                d = szTemp1;
                text = text.Substring(text.IndexOf(",") + 1, text.Length - text.IndexOf(",") - 1);
                szTemp1 = text.Substring(0, text.IndexOf(","));
                d = d + " " + szTemp1;

                dtUsedTiming = DateTime.Parse(d);

                // content using  timing
                text = text.Substring(text.IndexOf(",") + 1, text.Length - text.IndexOf(",") - 1);
                szTemp1 = text.Substring(0, text.IndexOf(","));
                nUsedTimeTemp = int.Parse(szTemp1);


                // skip end mode
                text = text.Substring(text.IndexOf(",") + 1, text.Length - text.IndexOf(",") - 1);
                szTemp1 = text.Substring(0, text.IndexOf(","));


                // get Quiz mode
                text = text.Substring(text.IndexOf(",") + 1, text.Length - text.IndexOf(",") - 1);
                szTemp1 = text.Substring(0, text.IndexOf(","));
                bQuizTemp = bool.Parse(szTemp1);

                // get Answer Correct mode
                text = text.Substring(text.IndexOf(",") + 1, text.Length - text.IndexOf(",") - 1);
                szTemp1 = text.Substring(0, text.IndexOf(","));
                bCorrectAnsTemp = bool.Parse(szTemp1);



                // get Answer Correct mode
                text = text.Substring(text.IndexOf(",") + 1, text.Length - text.IndexOf(",") - 1);
                //szTemp1 = text.Substring(0, text.IndexOf(","));
                int nInputAns2 = int.Parse(text);

                //if this is not quiz, we skip this line record
                if (bQuizTemp == false) continue;

                if (nInputAns2 == 0) continue;

                int nCompanre;

                //check date 
                if (checkBox1.Checked == false)
                {

                    nCompanre = System.DateTime.Compare(dtStart, dtUsedTiming);

                    if (nCompanre >= 1) continue;

                    nCompanre = System.DateTime.Compare(dtUsedTiming, dtEnd);

                    if (nCompanre >= 1) continue;

                }
                else
                {
                    nCompanre = System.DateTime.Compare(dtLOGStart, dtUsedTiming);
                    if (nCompanre >= 1)
                    {
                        dtLOGStart = dtUsedTiming;
                    }

                    nCompanre = System.DateTime.Compare(dtLOGEnd, dtUsedTiming);
                    if (nCompanre < 0)
                    {
                        dtLOGEnd = dtUsedTiming;
                    }

                }



                bFound = true;


                strSave += strTempSave + "\r\n";



            }
            sr.Close();


            if (bFound == false)
            {


                MessageBox.Show("集計条件を満たす結果がありませんでした。");
                return;


            }



            //output the result to CSV file
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


                sw.WriteLine(strSave);

                sw.Close();
            }

            this.Close();

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            quizprocess();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            quizprocess();

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            quizprocess();
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            quizprocess();

        }

        private void button6_Click_1(object sender, EventArgs e)
        {

        }//funciton end

        private void buttonOK_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
