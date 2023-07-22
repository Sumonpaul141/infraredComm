using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace infraredCommApp
{
    public class DeviceUseInformation
    {
        public int  nDeviceNo;
        public int  nTotalTimes;
        public int  nTotalTime;
        public int  nMaxTime;
        public int  nMinTime;
        public int  nAverageTime;
        public int  nPlayNums;
        public int  nTotalPlayTime;
        public int  nMaxPlayTime;
        public int  nMinPlayTime;



        public DeviceUseInformation()
        {

            nDeviceNo = 0;
            nTotalTimes = 0;
            nTotalTime = 0;
            nMaxTime = 0;
            nMinTime = 0;
            nAverageTime = 0;
            nPlayNums = 0;
            nTotalPlayTime = 0;
            nMaxPlayTime = 0;
            nMinPlayTime = 0;

        }

    }
}
