using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace newsatnp
{
    public class Locationinfo
    {
        public UInt32 uUID;
        public DateTime uStartDay;
        public int DeviceID;
        public int continuenumber;

        public Locationinfo()
        {
            uUID = 0;
            uStartDay = DateTime.Now;
            DeviceID = 0;
            continuenumber = 0;
        }

        public void CCopy(Locationinfo bbb)
        {
            uUID = bbb.uUID;
            uStartDay = bbb.uStartDay;
            DeviceID = bbb.DeviceID;
            continuenumber = bbb.continuenumber;
        }
    }
}
