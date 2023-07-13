using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace infraredCommApp
{
    public class contentsInfo
    {
        public bool bQuiz;
        public UInt32 u32ContentID;
        public string strIbcPath;
        public int nCorrectAns;
        public string strQuiz;
        public string strAnswer;
        public string strTitle;


        public contentsInfo()
        {
            bQuiz = false;

            u32ContentID = 0;
            strIbcPath = "";
            nCorrectAns = 0;
            strTitle = "";
            strQuiz = "";
            strAnswer = "";


        }

        public void Reset()
        {
            bQuiz = false;
            u32ContentID = 0;
            strIbcPath = "";
            nCorrectAns = 0;
            strTitle = "";
            strQuiz = "";
            strAnswer = "";


        }

        public void SetContentsQuiz(bool bStatus)
        {

            bQuiz = bStatus;

        }

        public void SetContentsID(UInt32 u32ID)
        {

            u32ContentID = u32ID;

        }

        public void SetContentTitle(string strT)
        {

            strTitle = strT;
        }

        public void SetContentsIbcPath(string strPath)
        {

            strIbcPath = strPath;

        }

        public void SetAnswerSelection(int nAns)
        {
            nCorrectAns = nAns;

        }

        public void SetQuiz(string strQp)
        {

            strQuiz = strQp;
        }

        public void SetQuizAns(string strAns)
        {

            strAnswer = strAns;

        }



        public bool GetContentQuiz()
        {

            return bQuiz;
        }

        public UInt32 GetContentID()
        {

            return u32ContentID;
        }

        public string GetIbcPath()
        {

            return strIbcPath;
        }

        public string GetQuiz()
        {

            return strQuiz;
        }

        public string GetQuizAns()
        {
            return strAnswer;

        }

        public int GetQuizAnsNum()
        {

            return nCorrectAns;
        }



        public string GetQuizTitle()
        {
            return strTitle;
        }



    }
}
