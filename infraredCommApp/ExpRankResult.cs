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
    public partial class ExpRankResult : Form
    {


       public static List<StoryInformation> gStoryINFO = new List<StoryInformation>();


        public ExpRankResult()
        {
            InitializeComponent();
        }

        private void ExpRankResult_Load(object sender, EventArgs e)
        {

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
        
        private void button1_Click(object sender, EventArgs e)
        {
            //bool tmp = true;
            //give a summary of the quiz answer result
            //CSV file output
            gStoryINFO.Clear();

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

            text = sr.ReadLine(); // skip the title

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

                dtUsedTiming = Common.GetValidDateTime(d);

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




                //if this is not a story, we skip this line record
                if (bQuizTemp == true) continue;

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

                // check the story content condition
                foreach (StoryInformation sif in gStoryINFO)
                {

                    //if the story content is in list already
                    if (sif.u32CID == u32CIDTemp)
                    {
                        // already exist, we only modify it
                        sif.nTotalAccessNum++;

                        sif.nTotalUsedTime += nUsedTimeTemp;

                        if (sif.nMaxUsedTime < nUsedTimeTemp) sif.nMaxUsedTime = nUsedTimeTemp;

                        if (sif.nMinUsedTime > nUsedTimeTemp) sif.nMinUsedTime = nUsedTimeTemp;

                        sif.nAverageUsedTime = sif.nTotalUsedTime / sif.nTotalUsedTime;

                        bFound2 = true;

                        break;

                    }

                }// new foreach
                //July
                if (bFound2 == false)
                {
                    //no such record CID, we will add new one for it
                    // add a new one to the list
                    StoryInformation sitTemp = new StoryInformation();


                    sitTemp.u32CID = u32CIDTemp;

                    sitTemp.nTotalAccessNum++;

                    sitTemp.nTotalUsedTime += nUsedTimeTemp;

                    if (sitTemp.nMaxUsedTime < nUsedTimeTemp) sitTemp.nMaxUsedTime = nUsedTimeTemp;

                    if (sitTemp.nMinUsedTime > nUsedTimeTemp) sitTemp.nMinUsedTime = nUsedTimeTemp;

                    sitTemp.nAverageUsedTime = sitTemp.nTotalUsedTime / sitTemp.nTotalUsedTime;

                    gStoryINFO.Add(sitTemp);


                }


            }
            sr.Close();


            if (bFound == false)
            {


                MessageBox.Show("集計条件を満たす結果がありませんでした。");
                return;


            }



            rankprocess();
            this.Close();
        } 

       
        private void rankprocess()
        {

            if (gStoryINFO.Count == 0) return;

            //show the result to the listbox
            textBox1.Clear();

            string szTemp1 = "";

            if (checkBox2.Checked == false)
            {

                gStoryINFO.Sort(delegate (StoryInformation sit1, StoryInformation sit2) { return sit2.nTotalAccessNum - sit1.nTotalAccessNum; });
            }
            else
            {

                gStoryINFO.Sort(delegate (StoryInformation sit1, StoryInformation sit2)
                { return sit1.u32CID.CompareTo(sit2.u32CID); });
            }

            foreach (StoryInformation sit in gStoryINFO)
            {
                szTemp1 += "コンテンツID:" + sit.u32CID.ToString("X8") + "  "
                        + "利用回数:" + sit.nTotalAccessNum.ToString() + "\r\n";


            }

            textBox1.Text = szTemp1;

        }



        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

            rankprocess();

        }


    }
}
