using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace infraredCommApp
{
    public class QuizAnsInformation
    {

        public UInt32 u32CID { get; set; }
        public int nTotalAccessNum { get; set; }
        public int nCorrectAnsNum { get; set; }
        public int nMaxUsedTime { get; set; }
        public int nMinUsedTime { get; set; }
        public int nTotalUsedTime { get; set; }
        public int nAverageUsedTime { get; set; }
        public int nCorrectRatio { get; set; }


        public QuizAnsInformation()
        {
            u32CID = 0;
            nTotalAccessNum = 0;
            nCorrectAnsNum = 0;
            nMaxUsedTime = 0;
            nMinUsedTime = 100000;
            nTotalUsedTime = 0;
            nAverageUsedTime = 0;
            nCorrectRatio = 0;

        }





    }
}
