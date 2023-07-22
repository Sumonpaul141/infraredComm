using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace infraredCommApp
{
    public class AnswerRecord
    {
        public UInt32 u32CID;
        public int nAns;
        public bool   bCorrect;
        public string strTitle;
        public DateTime dtQuiz;
        public DateTime dtStartTime;
        public DateTime dtEndTime;
        public int nEndMode;  // 0 normal end, 1 terminated, 2 interrupt switch
        
        

        public AnswerRecord()
        {
            u32CID = 0;
            
            nAns = 0;
            bCorrect = false;
            strTitle = "";
            dtQuiz = DateTime.Now;
            dtStartTime = DateTime.Now;
            dtEndTime = DateTime.Now;
            nEndMode = -1;
            

        }


        public  void Resets(   )
        {
            u32CID = 0;
            nAns = 0;
            bCorrect = false;
            
            strTitle = "";
            dtQuiz = DateTime.Now;
            dtStartTime = DateTime.Now;
            dtEndTime = DateTime.Now;
            nEndMode = -1;

        }


        public void Copy(AnswerRecord ans2)
        {

            u32CID = ans2.u32CID;
            nAns = ans2.nAns;
            bCorrect = ans2.bCorrect;
            
            strTitle = ans2.strTitle;
            dtQuiz = ans2.dtQuiz;
            dtStartTime = ans2.dtStartTime;
            dtEndTime = ans2.dtEndTime;
            nEndMode = ans2.nEndMode;

        }


    }
}
