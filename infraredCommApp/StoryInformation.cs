using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace infraredCommApp
{
    public class StoryInformation
    {

        public UInt32 u32CID;
        public int nTotalAccessNum;
        public int nMaxUsedTime;
        public int nMinUsedTime;
        public int nTotalUsedTime;
        public int nAverageUsedTime;


        public StoryInformation()
        {
            u32CID = 0;
            nTotalAccessNum = 0;
            nMaxUsedTime = 0;
            nMinUsedTime = 100000;
            nTotalUsedTime = 0;
            nAverageUsedTime = 0;

        }


    }
}
