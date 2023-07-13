using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace infraredCommApp
{
    [Serializable]
    public class UsedDeviceInfo
    {

        public  int nDeviceNo;
        public  DateTime dtStartTime;
        public  DateTime dtReturnTime;
        public  UInt32 u32Mode;

        public  UsedDeviceInfo()
        {
            nDeviceNo = 0;
            dtStartTime = DateTime.Now;
            dtReturnTime = DateTime.Now;
            u32Mode = 0;

        }

        

    }
}
