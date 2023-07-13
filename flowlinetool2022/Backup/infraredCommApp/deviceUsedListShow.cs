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
    public partial class deviceUsedListShow : Form
    {
        public deviceUsedListShow()
        {
            InitializeComponent();
        }

        private void deviceUsedListShow_Load(object sender, EventArgs e)
        {

            if (Form1.gUsedDevice.Count == 0) return;

            DateTime dtNow = DateTime.Now;

            string strDevListInfo = "貸出中端末の一覧表　　　"　+ dtNow.ToString("yyyy/mm/dd  HH:mm:ss"   )  + "\r\n\r\n\r\n";
                        
            


            foreach (UsedDeviceInfo udi in Form1.gUsedDevice)
            {
                TimeSpan tsTemp = dtNow - udi.dtStartTime;

                strDevListInfo += "端末番号：" + udi.nDeviceNo.ToString("d3")
                    + "　　貸出時刻：" + udi.dtStartTime.ToString("HH:mm:ss")
                    + "　　経過時間：" + tsTemp.Hours.ToString("d2") + "時間"
                            + tsTemp.Minutes.ToString("d2") + "分"
                            + tsTemp.Seconds.ToString("d2") + "秒"
                    + "　　動作モード：";


                UInt32 u32Mode = udi.u32Mode;

                if ((u32Mode & 0x1000) == 0x1000)
                {
                    strDevListInfo += "震災体験談";

                }

                if ((u32Mode & 0x0FFF) != 0)
                {
                    string strName = "";
                    byte u8Course = (byte)((u32Mode & 0xFFF));


                    switch (u8Course)
                    {
                        case 1:
                            strName = "A";
                            break;

                        case 2:
                            strName = "B";
                            break;

                        case 4:
                            strName = "C";
                            break;

                        case 8:
                            strName = "D";
                            break;

                        case 16:
                            strName = "E";
                            break;



                    }

                    if ((u32Mode & 0x1000) == 0x1000)
                    {

                        strDevListInfo += "・";
                    }


                    strDevListInfo += "クイズ" + strName;
                }

                strDevListInfo += "\r\n\r\n";

                

            }

            
            textBox1.Text = strDevListInfo;

            //textBox1.Enabled = false;
            
        }
    }
}
