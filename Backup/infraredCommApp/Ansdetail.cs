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
    public partial class Ansdetail : Form
    {
        public Ansdetail()
        {
            InitializeComponent();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        ///////////////////////////////////////////////////////////////

    public string GetQuiz(UInt32 u32CIDT)
    {

            string strQ = "";
            foreach (contentsInfo ctf in Form1.gconINFO )
            {

                if (ctf.GetContentID() == u32CIDT)
                {

                    strQ = ctf.GetQuiz();

                    break;


                }

            }

            return strQ;

    }

    public int GetAns(UInt32 u32CIDT)
    {

        int nA = 0;
        foreach (contentsInfo ctf in Form1.gconINFO)
        {
            if (ctf.GetContentID() == u32CIDT)
            {

                nA = ctf.GetQuizAnsNum();

                break;
            }

        }

        return nA;
    }


    public string GetAnsDetail(UInt32 u32CIDT)
    {
        string strAND = "";

        foreach (contentsInfo ctf in Form1.gconINFO)
        {
            if (ctf.GetContentID() == u32CIDT)
            {
                strAND = ctf.GetQuizAns();

                break;

            }

        }

        return strAND;

    }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            if ( Form1.gUserRecord.Count > 0)
            {

                int i = 0;
                

                //prepare pen
                Font fnt1 = new Font("ＭＳ Ｐゴシック", 11);

                int nXX = 0;
                int nYY = 0;
                
                int nW = panel1.Size.Width - nXX;
                

                Rectangle rect = new Rectangle(nXX, nYY, nW, panel1.Size.Height - nYY*2);

                
                //draw the result here
                foreach (AnswerRecord AnsPt in  Form1.gUserRecord)
                {

                    if (i != Form1.gnBtnNo)
                    {
                        i++;
                        continue;
                    }
                    

                    // quiz title
                    string strprint = "タイトル：" + AnsPt.strTitle + "\r\n\r\n";
                    
                    //quiz problem
                    strprint += "問題：" + "\r\n" +GetQuiz(AnsPt.u32CID) + "\r\n\r\n";

                    strprint += "解答：" + AnsPt.nAns.ToString() + "　　"
                        + "正解："  + GetAns( AnsPt.u32CID ).ToString() + "　　"  
                        + "判定：";

                    
                    if (AnsPt.bCorrect)
                    {
                        strprint += "○";
                    }
                    else
                    {
                        strprint += "×";

                    }

                    strprint += "\r\n \r\n";

                    //input activity information
                    strprint += "解答開始時刻：" + AnsPt.dtStartTime.ToString("yyyy/MM/dd  HH:mm:ss") + "\r\n";

                    strprint += "解答終了時刻：" + AnsPt.dtEndTime.ToString(  "yyyy/MM/dd  HH:mm:ss") + "\r\n";

                    strprint += "解答入力時刻：" + AnsPt.dtQuiz.ToString(     "yyyy/MM/dd  HH:mm:ss") + "\r\n";

                    strprint += "\r\n";

                    //answer in detail
                    strprint += "クイズ解説：" + "\r\n" 
                        + GetAnsDetail( AnsPt.u32CID);

                    e.Graphics.DrawString(strprint, fnt1, Brushes.Black, rect);

                                       

                    break;
                }



            }



        }
    }






}
