using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace infraredCommApp
{
    public class ContentPlayingInfo
    {
        public UInt32 u32CID;
        public DateTime dtStartTime;
        public int nPlayTime;
        public int nEndMode;  // 0 normal end, 1 terminated, 2 interrupt switch
        public bool bQuiz;
        public bool bCorrectAns;
        public int nInputAns;


        public ContentPlayingInfo()
        {
            u32CID = 0;
            dtStartTime = DateTime.Now;
            nPlayTime = 0;
            nEndMode = -1;
            bQuiz = false;
            bCorrectAns = false;
            nInputAns = 0;
            

        }


    }
}
