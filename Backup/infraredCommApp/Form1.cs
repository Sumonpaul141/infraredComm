using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.IO.Ports;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;


using Microsoft.VisualBasic.FileIO;


using FTD2XX_NET;


namespace infraredCommApp
{


    public partial class Form1 : Form
    {
        private string printingText;
        private int printingPosition;
        

        private Font printFontName;
        private Font printFontDate;
        private Font printFontCourse;
        private Font printFontMark;
        private Font printFontMain;


        public static int gAgeIndex;
        public static int gSexal;
        public static int gPlace;

        private bool bClickDeviceSet = false;
        private bool bClickGetLog = false;

        //ボタンコントロール配列のフィールドを作成
        private System.Windows.Forms.Button[] testButtons;

        public static int gnBtnNo;

        public static System.Threading.Mutex mymutex;


        public static UInt32 u32DeviceMode;

        public static string appName = "Stapm2011";
        public static string USBSN = "";//"UEGG37RW2011";//"NECEAAA001";


        public static List<contentsInfo> gconINFO = new List<contentsInfo>(); // list for content information

        public static List<ContentPlayingInfo> gContPLAY = new List<ContentPlayingInfo>();


        public int nIBCCount = 0;

        public int gnDeviceID = 0;
        
        static FTDI myFtdiDevice;
        static int FT232L_online = 0;

        public Thread buttonprocessthread;

        //global variables for function
        string gstrQuizP = "";
        string gstrQuizA = "";
        int gnAns = 0;

        static int gnPlayNums = 0;
        static int gnPlayTotalTime = 0;

        
        string logname;

        string[] logtime = new string[500];
        string[] logrecord = new string[500];

        int lognum = 0;

        static int nButtonNum = 0;

        public string strShow = "";

        static bool gModeSend = false;


        public Thread getlog, U4ModeStart;


        public static string logpath = "";

        public static string workfolder = "";

        public static bool gbSaveLogData = false;
        
        public static string ibcfolder = "";

               
        public static bool gb_FinalSetup = false;

        public static int nRFChnLog = 20; // log file transmitting RF channel

        public static string strSETUPpassword = "";

        
        //public static List<ContentInfo> gContentINFO = new List<ContentInfo>(); //list for content information

        public static List<AnswerRecord> gUserRecord = new List<AnswerRecord>(); // list for user's answer record

        

        public static List<UsedDeviceInfo> gUsedDevice = new List<UsedDeviceInfo>(); // list for using device


        public static string szQuizTitle = "";
        public static string szQuizAns ="";

        public Form1()
        {
            InitializeComponent();



            //load the basic parameters
            string apppath = System.AppDomain.CurrentDomain.BaseDirectory.ToString();
            string config = apppath + "\\" + "config.txt";
            if (File.Exists(config))
            {
                StreamReader sr = new StreamReader(config);
                try
                {

                    Form1.workfolder = sr.ReadLine();
                    Form1.logpath = sr.ReadLine();

                    Form1.gb_FinalSetup = bool.Parse(sr.ReadLine());

                    Form1.nRFChnLog = int.Parse(sr.ReadLine());

                    Form1.strSETUPpassword = sr.ReadLine();

                    Form1.ibcfolder = sr.ReadLine();

                    Form1.gbSaveLogData = bool.Parse(  sr.ReadLine());

                    
                }
                catch
                {


                }

                sr.Close();

            }//existed
            else
            {

                Form1.workfolder = "c:\\" + appName + "\\";
                Form1.logpath = "c:\\" + appName + "\\Log\\";

                Form1.nRFChnLog = 20;

                Form1.gb_FinalSetup = false;

                Form1.strSETUPpassword = "";

                Form1.gbSaveLogData = false;
                


                
                //if (result == DialogResult.Yes)
                {

                    

                    new setupbasic().ShowDialog();



                    if (!Directory.Exists(workfolder)) //如果不存在就建立 
                    {
                        Directory.CreateDirectory(workfolder);
                    }

                    if (!Directory.Exists(logpath)) //如果不存在就建立 
                    {
                        Directory.CreateDirectory(logpath);
                    }

                }
                


                //save the setting
                apppath = System.AppDomain.CurrentDomain.BaseDirectory.ToString();
                config = apppath + "\\" + "config.txt";
                if (File.Exists(config))
                {
                    File.Delete(config);
                }

                StreamWriter sw = new StreamWriter(config);

                sw.WriteLine(Form1.workfolder);
                sw.WriteLine(Form1.logpath);
                sw.WriteLine(Form1.gb_FinalSetup);
                sw.WriteLine(Form1.nRFChnLog);
                sw.WriteLine(Form1.strSETUPpassword);
                sw.WriteLine(Form1.ibcfolder);
                sw.WriteLine(Form1.gbSaveLogData);
                
                sw.Close();


            }
            /////////////////////////////////////////////////
            //
            // here we create a list for contents list
            string szTitle, temp, szFilePath;
            UInt32 u32CCID;


            gconINFO.Clear();


            if (Directory.Exists(ibcfolder))
            {



                string[] fileslist =
                        System.IO.Directory.GetFiles(Form1.ibcfolder, "*.ibc", System.IO.SearchOption.AllDirectories);


                for (int i = 0; i < fileslist.Length; i++)
                {
                    contentsInfo coninfotemp = new contentsInfo();
                    //save the path
                    coninfotemp.SetContentsIbcPath(fileslist[i]);

                    // get CID and Title
                    szFilePath = fileslist[i];

                    temp = getFolderNameOnly(szFilePath);

                    u32CCID = Convert.ToUInt32(temp, 16);

                    szTitle = getContentTitle(szFilePath);

                    coninfotemp.SetContentsID(u32CCID);
                    coninfotemp.SetContentTitle(szTitle);

                    //get the quiz problem
                    if (fep_Search_AnswerNo(szFilePath) == true)
                    {
                        coninfotemp.SetAnswerSelection(gnAns);
                        coninfotemp.SetQuiz(gstrQuizP);
                        coninfotemp.SetQuizAns(gstrQuizA);

                        if (gnAns > 0) // valid selection for quiz
                        {
                            coninfotemp.SetContentsQuiz( true );
                        }
                        else
                        {
                            coninfotemp.SetContentsQuiz(false);
                        }

                        
                        //add the information to list
                        gconINFO.Add(coninfotemp);

                    }



                } //for i

            }

            mymutex = new System.Threading.Mutex();




        }


        private void SetupDeviceUsingList()
        {

            listBoxDevUsing.Items.Clear();

            

            foreach (UsedDeviceInfo udi in Form1.gUsedDevice)
            {
                string strShow = "　　" + udi.nDeviceNo.ToString("d2")
                    + "　　　　" + udi.dtStartTime.ToString("HH:mm:ss")
                    + "　　　　";

                

                UInt32 u32Mode = udi.u32Mode;

                if ((u32Mode & 0x1000) == 0x1000)
                {
                    strShow += "体験談";

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


                    if ((u32Mode & 0x1000) == 0x1000) strShow += "・";

                    strShow += "クイズ" + strName;
                }



                listBoxDevUsing.Items.Add(　strShow );

            }

            if (checkBoxDevNo.Checked)
            {
                listBoxDevUsing.Sorted = true;
                listBoxDevUsing.Sorted = false;
            }

        }




        private void Form1_Load(object sender, EventArgs e)
        {
            string[] portnames = SerialPort.GetPortNames();
            Boolean bCom = false;


            mymutex.WaitOne();

          
            /////////////////////////////////////////////
            bool bDebug = false;

            if (bDebug == false)
            {

                if (IrDeviceOpen() == -1)
                {

                    MessageBox.Show("赤外線送信機に接続してください。");
                    this.Close();

                }
                else　// found the USB device and check if it is the right device
                {
                    bCom = true;

                    FT232L_online = 1;

                    bCom = sendcommand("HELL2", false);


                    bCom = sendcommand("CINIT", false);
                    Thread.Sleep(1000);

                    myFtdiDevice.Purge(FTDI.FT_PURGE.FT_PURGE_RX | FTDI.FT_PURGE.FT_PURGE_TX);

                    IrDeviceTimeout(2000); //1 second wailt


                    // after open the FT232L, we will try to connect with device
                    bCom = sendcommand("HELL2", false);

                    if (bCom == false)
                    {
                        MessageBox.Show("読み込み装置に接続してください。");
                        this.Close();
                    }
                    

                }
            }


            //main interface init.
            //QuizcheckBox1.Checked = true;
            //ExpcheckBox2.Checked = false;
            radioButton1.Checked = true;

            button3.Enabled = true;
            PrintBtn.Enabled = false;
           

            checkBoxInput.Checked = false;

            gAgeIndex = 0;
            gSexal = 0;
            gPlace = 0;
            

            
            

            ///////////////////////////////////////////////////////////////
            //ボタンコントロール配列の作成（ここでは5つ作成）
            this.testButtons = new System.Windows.Forms.Button[10];

            //ボタンコントロールのインスタンス作成し、プロパティを設定する
            this.SuspendLayout();
            for (int i = 0; i < this.testButtons.Length; i++)
            {
                //インスタンス作成
                this.testButtons[i] = new System.Windows.Forms.Button();
                //プロパティ設定
                this.testButtons[i].Name = i.ToString();
                this.testButtons[i].Text = "詳細";
                this.testButtons[i].Size = new Size(60, 24);
                this.testButtons[i].Location = new Point( groupBox2.Location.X + panel3.Location.X + 10,  
                                                    groupBox2.Location.Y + panel3.Location.Y +  10+ i * 40);

                this.testButtons[i].Visible = false;


                //イベントハンドラに関連付け
                this.testButtons[i].Click +=
                    new EventHandler(this.testButtons_Click);

                
                
            }

            //フォームにコントロールを追加
            this.Controls.AddRange(this.testButtons);
            this.ResumeLayout(false);

            for (int i = 0; i < this.testButtons.Length; i++)
            {

                this.testButtons[i].BringToFront();
            }


            //load the device used information
            string classpath = workfolder + "deviceInUsed.dev";
            if (File.Exists(classpath))
            {
                bool berror = false;

                FileStream fs = new FileStream(classpath, FileMode.Open);
                BinaryFormatter b = new BinaryFormatter();
                
                try
                {
                    gUsedDevice = ( List< UsedDeviceInfo> )(b.Deserialize(fs));
                    
                }
                catch (Exception eee)
                {

                    MessageBox.Show(e.GetType().FullName);
                    fs.Close();


                    FileStream fileStream1 = new FileStream(classpath, FileMode.Create);
                    BinaryFormatter b1 = new BinaryFormatter();
                    b.Serialize(fileStream1, gUsedDevice);
                    fileStream1.Close();

                    berror = true;
                }

                if (berror == false) fs.Close();


            }
            else
            {
                //we create a new one


                // save it to binary file
                FileStream fileStream = new FileStream(classpath, FileMode.Create);
                BinaryFormatter b = new BinaryFormatter();
                b.Serialize(fileStream, gUsedDevice );
                fileStream.Close();

            }


            sendcommand("SETDV:1:500" , false);
            //set the RF channel
            string strCMD = "RFCHN:5";
            sendcommand(strCMD, false);

            
            strCMD = "RSMON";
            sendcommand(strCMD, false);

            strCMD = "MONTM:20";
            sendcommand(strCMD, false);


            labelUsedDevNum.Text = "貸出中端末台数：" + gUsedDevice.Count.ToString();

            SetupDeviceUsingList();

            IrDeviceTimeout(10000);


            labelstatus.Text = "起動が成功した";
            labelstatus.ForeColor = Color.LimeGreen;

            mymutex.ReleaseMutex();
                        

        }






        /////////////////////////////////////////////////////
        // create RS232 connection
        public int IrDeviceOpen()
        {

            UInt32 ftdiDeviceCount = 0;
            FTDI.FT_STATUS ftStatus = FTDI.FT_STATUS.FT_OK;




            // Create new instance of the FTDI device class
            myFtdiDevice = new FTDI();


            
            // Determine the number of FTDI devices connected to the machine
            ftStatus = myFtdiDevice.GetNumberOfDevices(ref ftdiDeviceCount);
            // Check status
            if (ftStatus != FTDI.FT_STATUS.FT_OK)
            {
                MessageBox.Show("デバイス情報を取得できず");

                return -1;
            }

            // If no devices available, return
            if (ftdiDeviceCount == 0)
            {
                MessageBox.Show("接続されるデバイスがありません。");

                return -1;

            }

            // Allocate storage for device info list
            FTDI.FT_DEVICE_INFO_NODE[] ftdiDeviceList = new FTDI.FT_DEVICE_INFO_NODE[ftdiDeviceCount];

            // Populate our device list
            ftStatus = myFtdiDevice.GetDeviceList(ftdiDeviceList);

            if (ftStatus == FTDI.FT_STATUS.FT_OK)
            {

                //for (UInt32 i = 0; i < ftdiDeviceCount; i++)
                //{
                //    Console.WriteLine("Device Index: " + i.ToString());
                //    Console.WriteLine("Flags: " + String.Format("{0:x}", ftdiDeviceList[i].Flags));
                //    Console.WriteLine("Type: " + ftdiDeviceList[i].Type.ToString());
                //    Console.WriteLine("ID: " + String.Format("{0:x}", ftdiDeviceList[i].ID));
                //    Console.WriteLine("Location ID: " + String.Format("{0:x}", ftdiDeviceList[i].LocId));
                //    Console.WriteLine("Serial Number: " + ftdiDeviceList[i].SerialNumber.ToString());
                //    Console.WriteLine("Description: " + ftdiDeviceList[i].Description.ToString());
                //    Console.WriteLine("");
                //}
            }

            // A6007Ql5
            // find this serialNumber
            UInt32 nIndexSerial = 0xffffffff;

            for (UInt32 i = 0; i < ftdiDeviceCount; i++)
            {
                if (ftdiDeviceList[i].SerialNumber == Form1.USBSN)
                {
                    nIndexSerial = i;

                    break;
                }

            }

            if (Form1.USBSN == "")
            {

                nIndexSerial = 0;

            }
            else
            {
                if (nIndexSerial == 0xffffffff)
                {
                    MessageBox.Show("この管理ソフトに対応する充電器がありません");

                    this.Close();

                    return -1;
                }

            }


            // Open first device in our list by serial number
            ftStatus = myFtdiDevice.OpenBySerialNumber(ftdiDeviceList[nIndexSerial].SerialNumber);
            if (ftStatus != FTDI.FT_STATUS.FT_OK)
            {
                MessageBox.Show("デバイスに接続できません");

                this.Close();

                return -1;
            }

            // Set up device data parameters
            // Set Baud rate to 921600
            //cccc


            uint speed = 923076; // -1043478 * 5 / 1000;

            ftStatus = myFtdiDevice.SetBaudRate(speed);
            if (ftStatus != FTDI.FT_STATUS.FT_OK)
            {
                MessageBox.Show("通信速度の設定ができません");

                return -1;

            }

            // Set data characteristics - Data bits, Stop bits, Parity
            ftStatus = myFtdiDevice.SetDataCharacteristics(FTDI.FT_DATA_BITS.FT_BITS_8, FTDI.FT_STOP_BITS.FT_STOP_BITS_1, FTDI.FT_PARITY.FT_PARITY_EVEN);
            if (ftStatus != FTDI.FT_STATUS.FT_OK)
            {
                MessageBox.Show("通信条件の設定ができません");

                return -1;
            }

            // Set flow control - set RTS/CTS flow control
            ftStatus = myFtdiDevice.SetFlowControl(FTDI.FT_FLOW_CONTROL.FT_FLOW_NONE, 0x11, 0x13);
            if (ftStatus != FTDI.FT_STATUS.FT_OK)
            {
                MessageBox.Show("通信フローの設定ができません");

                return -1;
            }

            // Set read timeout to 3 seconds, write timeout to infinite
            ftStatus = myFtdiDevice.SetTimeouts(5000, 5000);
            if (ftStatus != FTDI.FT_STATUS.FT_OK)
            {
                MessageBox.Show("通信タイムアウトの設定ができません");

                return -1;
            }


            return 0;
        }

        ///////////////////////

        public int IrDeviceTimeout(uint nTime)
        {
            FTDI.FT_STATUS ftStatus = FTDI.FT_STATUS.FT_OK;

            // Set read timeout to 3 seconds, write timeout to infinite
            ftStatus = myFtdiDevice.SetTimeouts(nTime, 5000);
            if (ftStatus != FTDI.FT_STATUS.FT_OK)
            {
                MessageBox.Show("通信タイムアウトの設定ができません");

                return -1;
            }

            return 0;


        }


        //////////////////////////////////////////////

        public int IrDeviceClose()
        {

            FTDI.FT_STATUS ftStatus = FTDI.FT_STATUS.FT_OK;

            // Close our device
            ftStatus = myFtdiDevice.Close();

            return 0;
        }


        public int IrDeviceClearBuffer()
        {
            FTDI.FT_STATUS ftStatus = FTDI.FT_STATUS.FT_OK;
            byte[] readData = new byte[128];
            UInt32 numBytesRead = 0;

            if (FT232L_online == 0) return -1;

            // Check the amount of data available to read
            // In this case we know how much data we are expecting, 
            // so wait until we have all of the bytes we have sent.
            UInt32 numBytesAvailable = 0;
            Thread.Sleep(1);


            // Now that we have the amount of data we want available, read it

            // Note that the Read method is overloaded, so can read string or byte array data
            numBytesAvailable = 128;
            numBytesRead = 132;
            while (numBytesRead >= numBytesAvailable)
            {
                ftStatus = myFtdiDevice.Read(readData, numBytesAvailable, ref numBytesRead);
                if (ftStatus != FTDI.FT_STATUS.FT_OK)
                {
                    MessageBox.Show("ポートデータの読込みが失敗しました。");
                    return -1;
                }
                Thread.Sleep(1);

            }

            return 0;

        }

        public int receivepacket(byte[] buf)
        {
            FTDI.FT_STATUS ftStatus = FTDI.FT_STATUS.FT_OK;
            UInt32 numBytesAvailable = 32;

            if (FT232L_online == 0) return -1;

            cleanBuf(buf, 32);


            // Now that we have the amount of data we want available, read it


            UInt32 numBytesRead = 0;
            // Note that the Read method is overloaded, so can read string or byte array data
            ftStatus = myFtdiDevice.Read(buf, numBytesAvailable, ref numBytesRead);

            if (ftStatus != FTDI.FT_STATUS.FT_OK)
            {
                return -1;
            }
            return 0;
        }



        public int sendpacket(byte[] data, int begin, int length)
        {

            FTDI.FT_STATUS ftStatus = FTDI.FT_STATUS.FT_OK;

            byte[] buf = new byte[256];

            if (FT232L_online == 0) return -1;

            buf[0] = 0x06;
            buf[1] = 0xAA;
            //buf[2] = (byte)(length);

            for (int i = 0; i < length; i++)
            {
                buf[i + 2] = data[i + begin];
            }
            buf[255] = 0x09;

            buf[254] = 0;

            for (int i = 0; i < 254; i++) buf[254] += buf[i];


            UInt32 numBytesWritten = 0;
            // Note that the Write method is overloaded, so can write string or byte array data

            //we check if the buffer is empty



            ftStatus = myFtdiDevice.Write(buf, buf.Length, ref numBytesWritten);

            if (ftStatus != FTDI.FT_STATUS.FT_OK)
            {
                return -1;
            }

            return 0;
            //serialPort1.Write(buf, 0, 32);
            // serialPort1.
        }

        //bool _7d = false;

        public int SendpacketFast(byte[] data, int length)
        {

            FTDI.FT_STATUS ftStatus = FTDI.FT_STATUS.FT_OK;

            byte[] buf = new byte[256];
            if (FT232L_online == 0) return -1;



            buf[0] = 0x06;
            buf[1] = 0xAA;


            int outputIndex = 0, inputIndex = 0;
            int totalLen = length;
            int packetlen;
            int m, i;
            byte[] outputbuf = new byte[256 * 1000 + 32];

            totalLen = length;
            outputIndex = 0;
            inputIndex = 0;

            while (totalLen > 0)
            {

                //add head
                for (m = 0; m < 2; m++) outputbuf[outputIndex + m] = buf[m];

                if (totalLen < 252)
                {
                    packetlen = totalLen;
                    //outputbuf[outputIndex + 3] = (byte)(packetlen);
                }
                else
                    packetlen = 252;



                // copy the data
                for (i = 0; i < packetlen; i++)
                {

                    outputbuf[outputIndex + 2 + i] = data[inputIndex + i];
                }

                outputbuf[outputIndex + 255] = 0x09;

                outputbuf[outputIndex + 254] = 0x00;
                for (i = 0; i < 254; i++) outputbuf[outputIndex + 254] += outputbuf[outputIndex + i];



                totalLen = totalLen - packetlen;
                inputIndex = inputIndex + packetlen;

                outputIndex = outputIndex + 256;


            }//kk



            if (outputIndex > 0)
            {
                UInt32 numBytesWritten = 0;
                // Note that the Write method is overloaded, so can write string or byte array data

                ftStatus = myFtdiDevice.Write(outputbuf, outputIndex, ref numBytesWritten);



                if (ftStatus != FTDI.FT_STATUS.FT_OK)
                {
                    return -1;
                }

            }



            return 1;

        }

        public void cleanBuf(byte[] bbuf, int len)
        {

            int i;


            for (i = 0; i < len; i++)
            {

                bbuf[i] = 0x0;

            }

        }


        string getFolderNameOnly(string filepath)
        {
            byte[] buf = new byte[128];

            string stFolderName = "";

            string stBuffer = "";


            //open file
            System.IO.FileStream fsbin =
                new System.IO.FileStream(filepath, System.IO.FileMode.Open, System.IO.FileAccess.Read);

            //get the filename length
            fsbin.Read(buf, 0, 128);

            int filenamelength = buf[9];

            byte[] temp = new byte[filenamelength];

            for (int i = 0; i < filenamelength; i++)
                temp[i] = buf[10 + i];


            // get the folder name
            stFolderName = System.Text.Encoding.ASCII.GetString(temp);

            stFolderName = stFolderName.Substring(0, stFolderName.IndexOf("/"));

            fsbin.Close();

            stBuffer = stFolderName;

            return stBuffer;
        }


        /// <summary>
        /// ///////////////////////////////////////////////////////////////////////////
        /// </summary>
        string getContentTitle(string filepath)
        {
            byte[] buf = new byte[256];

            string stTitle = "";

            string stFolderName = "";
            string stFileNameA = "";

            long nCurrentPos = 0;

            //open file
            System.IO.FileStream fsbin =
                new System.IO.FileStream(filepath, System.IO.FileMode.Open, System.IO.FileAccess.Read);

            //get the filename length
            fsbin.Read(buf, 0, 128);


            int filenamelength = buf[9];

            byte[] temp = new byte[filenamelength];

            for (int i = 0; i < filenamelength; i++)
                temp[i] = buf[10 + i];



            // get the folder name
            stFolderName = System.Text.Encoding.ASCII.GetString(temp);

            stFolderName = stFolderName.Substring(0, stFolderName.IndexOf("/"));

            long lIBCFileLength = fsbin.Length;

            //search for TEXTDATA.TXT
            while (lIBCFileLength > 0)
            {
                fsbin.Seek(nCurrentPos, SeekOrigin.Begin);

                fsbin.Read(buf, 0, 64);


                int filenamelength1 = buf[9];

                UInt32 u32fileLength = BitConverter.ToUInt32(buf, 1);


                byte[] bufFileName = new byte[filenamelength1];
                //check the file name
                for (int i = 0; i < filenamelength1; i++)
                    bufFileName[i] = buf[10 + i];

                // get the folder name
                stFileNameA = System.Text.Encoding.ASCII.GetString(bufFileName);
                stFileNameA = stFileNameA.Substring(stFileNameA.LastIndexOf("/") + 1, stFileNameA.Length - stFileNameA.LastIndexOf("/") - 1);

                // search content title
                if (stFileNameA == "CONTENTNAME.TXT")
                {

                    // read out the SN information
                    // cal the data start pos
                    int nDataStart = buf[0] + (int)nCurrentPos;

                    fsbin.Seek(nDataStart, SeekOrigin.Begin);

                    byte[] bufTitle = new byte[(int)u32fileLength];

                    fsbin.Read(bufTitle, 0, (int)u32fileLength);


                    stTitle = System.Text.Encoding.Unicode.GetString(bufTitle);

                    break;
                }
                else
                {
                    //move to next data block
                    nCurrentPos += buf[0] + BitConverter.ToUInt32(buf, 1);

                    lIBCFileLength -= buf[0] + BitConverter.ToUInt32(buf, 1);

                }


            }



            fsbin.Close();


            return stTitle;
        }







        public void button_process( )
        {
            string strCMD = "";
            bool bRtn;
            byte[] buftemp = new byte[256];
            int nSleeptimer = 1000;
            int nbuttonNo;

            nbuttonNo = nButtonNum;

            
            strShow = "通信を準備しています。";
            
             switch (nbuttonNo)
            {
                case 1:
                    strCMD = "IRFST:Scon1.ibc";
                    nSleeptimer = 1000;
                    break;

                case 2:
                    strCMD = "IRFST:Scon2.ibc";
                    nSleeptimer = 1600;
                    break;

                case 3:
                    strCMD = "IRFST:Scon3.ibc";
                    nSleeptimer = 3000;
                    break;


            }

             // start IrFast 

             bRtn = sendcommand(strCMD, false);

             // here we wait for ACK from the device
             //IrDeviceTimeout(5000); //1 second wailt

             Thread.Sleep(3000);
             strShow = "赤外線瞬時通信でコンテンツを送信しています。";
             

            /*

             try
             {
                 receivepacket(buftemp);
             }
             catch (Exception eee)
             {


                 return;
             }

             if (System.Text.ASCIIEncoding.ASCII.GetString(buftemp, 0, 32).IndexOf("SFILES") == -1)
             {
                 status1.Text = strwait;
                 enablebutton(true);
                 return;
             }
            */
             Thread.Sleep(nSleeptimer);
             strShow = "コンテンツの送信が完了しました。";
             

             Thread.Sleep(nSleeptimer　+ 15000);

             
             
             gModeSend = false;
             
        }



        ///////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////
        // bNoAck = false: check ACK here
        // bNoAck = true;   no check ACK here
        public bool sendcommand(string cmd, bool bNoAck)
        {
            byte[] buf = new byte[256];
            int count;
            long u32Len;

            string temp = cmd;
            
            byte[] buftemp = new byte[256];




            for (int i = 0; i < 256; i++) buf[i] = 0x00;

            buf[0] = 0x00; // command

            //Buffer.BlockCopy(buf, 5, (byte)cmd, 0, cmd.Length);

            //set the length of the data 
            u32Len = cmd.Length;


            buf[1] = (byte)(u32Len);


            for (int i = 0; i < cmd.Length; i++)
            {

                buf[i + 2] = (byte)cmd[i];

            }

            //send out command
            count = cmd.Length + 2;
            //sendpacket(buf, 0, count);
            send(buf, count);


            if (cmd == "GFILE")
            {

                try
                {
                    receivefile(workfolder);

                }
                catch (Exception e)
                {
                    MessageBox.Show(e.ToString());
                    return false;


                }
                return true;

            }

            if (cmd == "GCONF")
            {

                try
                {
                    receivefile(workfolder);

                }
                catch (Exception e)
                {
                    MessageBox.Show(e.ToString());
                    return false;


                }
                return true;

            }

            else if (cmd.StartsWith("FORMT"))
            {

                try
                {
                    receivepacket(buftemp);
                }
                catch (Exception e)
                {
                    return false;
                }
                if (System.Text.ASCIIEncoding.ASCII.GetString(buftemp, 0, 32).IndexOf("FORMTS") != -1)
                    return true;
                else
                    return false;
            }

            else if (cmd.StartsWith("IRRST"))
            {

                try
                {
                    receivepacket(buftemp);
                }
                catch (Exception e)
                {
                    return false;
                }
                if (System.Text.ASCIIEncoding.ASCII.GetString(buftemp, 0, 32).IndexOf("IRRSTS") != -1)
                    return true;
                else
                    return false;
            }

            else if (cmd.StartsWith("SETTM"))
            {

                try
                {
                    receivepacket(buftemp);
                }
                catch (Exception e)
                {
                    return false;
                }
                if (System.Text.ASCIIEncoding.ASCII.GetString(buftemp, 0, 32).IndexOf("SETTMS") != -1)
                    return true;
                else
                    return false;
            }

            else if (cmd.StartsWith("HELL2"))
            {

                try
                {
                    receivepacket(buftemp);
                }
                catch (Exception e)
                {
                    return false;
                }
                if (System.Text.ASCIIEncoding.ASCII.GetString(buftemp, 0, 32).IndexOf("HELL2S") != -1)
                    return true;
                else
                    return false;
            }


            else if (cmd.StartsWith("SETDT"))
            {

                try
                {
                    receivepacket(buftemp);
                }
                catch (Exception e)
                {
                    return false;
                }
                if (System.Text.ASCIIEncoding.ASCII.GetString(buftemp, 0, 32).IndexOf("SETDTS") != -1)
                    return true;
                else
                    return false;
            }

            else if (cmd.StartsWith("RESET"))
            {

                try
                {
                    receivepacket(buftemp);
                }
                catch (Exception e)
                {
                    return false;
                }
                if (System.Text.ASCIIEncoding.ASCII.GetString(buftemp, 0, 32).IndexOf("RESETS") != -1)
                    return true;
                else
                    return false;
            }


            else if (cmd.StartsWith("MKCON"))
            {

                try
                {
                    receivepacket(buftemp);
                }
                catch (Exception e)
                {
                    return false;
                }
                if (System.Text.ASCIIEncoding.ASCII.GetString(buftemp, 0, 32).IndexOf("MKCONS") != -1)
                    return true;
                else
                    return false;
            }



            else if (cmd == "CINIT")
            {

                try
                {
                    receivepacket(buftemp);
                }
                catch (Exception e)
                {
                    return false;
                }
                if (System.Text.ASCIIEncoding.ASCII.GetString(buftemp, 0, 32).IndexOf("CINITS") != -1)
                    return true;
                else
                    return false;
            }



            else if (cmd == "HELLO")
            {


                try
                {
                    receivepacket(buftemp);
                }
                catch (Exception e)
                {
                    return false;
                }
                if (System.Text.ASCIIEncoding.ASCII.GetString(buftemp, 0, 32).IndexOf("HELLOS") != -1)
                    return true;
                else
                    return false;
            }


            else if (cmd == "SETDV")
            {

                try
                {
                    receivepacket(buftemp);
                }
                catch (Exception e)
                {
                    return false;
                }
                if (System.Text.ASCIIEncoding.ASCII.GetString(buftemp, 0, 32).IndexOf("SETDVS") != -1)
                    return true;
                else
                    return false;
            }

            else if (cmd.StartsWith("GINFO"))
            {

                return true;

            }


            else if (cmd.StartsWith("SHUTD"))
            {

                if (bNoAck == true) return true;


                try
                {
                    receivepacket(buftemp);
                }
                catch (Exception e)
                {
                    return false;
                }
                if (System.Text.ASCIIEncoding.ASCII.GetString(buftemp, 0, 32).IndexOf("SHUTDS") != -1)
                    return true;
                else
                    return false;
            }


            else if (cmd.StartsWith("U4REQ"))
            {

                if (bNoAck == true) return true;


                try
                {
                    receivepacket(buftemp);
                }
                catch (Exception e)
                {
                    return false;
                }
                if (System.Text.ASCIIEncoding.ASCII.GetString(buftemp, 0, 32).IndexOf("U4REQS") != -1)
                    return true;
                else
                    return false;
            }


            else if (cmd.StartsWith("IRFST"))
            {

                if (bNoAck == true) return true;


                try
                {
                    receivepacket(buftemp);
                }
                catch (Exception e)
                {
                    return false;
                }
                if (System.Text.ASCIIEncoding.ASCII.GetString(buftemp, 0, 32).IndexOf("IRFSTS") != -1)
                    return true;
                else
                    return false;
            }


            else if (cmd.StartsWith("U4END"))
            {

                if (bNoAck == true) return true;


                try
                {
                    receivepacket(buftemp);
                }
                catch (Exception e)
                {
                    return false;
                }
                if (System.Text.ASCIIEncoding.ASCII.GetString(buftemp, 0, 32).IndexOf("U4ENDS") != -1)
                    return true;
                else
                    return false;
            }

            else if (cmd.StartsWith("SDLOG"))
            {

                if (bNoAck == true) return true;


                try
                {
                    receivepacket(buftemp);
                }
                catch (Exception e)
                {
                    return false;
                }
                if (System.Text.ASCIIEncoding.ASCII.GetString(buftemp, 0, 32).IndexOf("SDLOGS") != -1)
                    return true;
                else
                    return false;


            }

            else if (cmd.StartsWith("SDCON"))
            {

                if (bNoAck == true) return true;


                try
                {
                    receivepacket(buftemp);
                }
                catch (Exception e)
                {
                    return false;
                }
                if (System.Text.ASCIIEncoding.ASCII.GetString(buftemp, 0, 32).IndexOf("SDCONS") != -1)
                    return true;
                else
                    return false;


            }

            else if (cmd.StartsWith("RMLOG"))
            {
                if (bNoAck == true) return true;


                try
                {
                    receivepacket(buftemp);
                }
                catch (Exception e)
                {
                    return false;
                }
                if (System.Text.ASCIIEncoding.ASCII.GetString(buftemp, 0, 32).IndexOf("RMLOGS") != -1)
                    return true;
                else
                    return false;


            }

            else if (cmd.StartsWith("RMUSR"))
            {
                if (bNoAck == true) return true;


                try
                {
                    receivepacket(buftemp);
                }
                catch (Exception e)
                {
                    return false;
                }
                if (System.Text.ASCIIEncoding.ASCII.GetString(buftemp, 0, 32).IndexOf("RMUSRS") != -1)
                    return true;
                else
                    return false;


            }


            else if (cmd.StartsWith("RFCHN"))
            {

                try
                {
                    receivepacket(buftemp);
                }
                catch (Exception e)
                {
                    return false;
                }
                if (System.Text.ASCIIEncoding.ASCII.GetString(buftemp, 0, 32).IndexOf("RFCHNS") != -1)
                    return true;
                else
                    return false;

            }
            else if (cmd.StartsWith("STPIR"))
            {

                try
                {
                    receivepacket(buftemp);
                }
                catch (Exception e)
                {
                    return false;
                }
                if (System.Text.ASCIIEncoding.ASCII.GetString(buftemp, 0, 32).IndexOf("STPIRS") != -1)
                    return true;
                else
                    return false;
            }
            return false;
        }



        ///////////////////////////////////////////////////


        void send(byte[] buf, int count)
        {
            byte[] buftemp = new byte[256];

            for (int i = 0; i < count; i += 252)
            {

                if (count < i + 252)
                {
                    sendpacket(buf, i, count - i);
                }
                else
                    sendpacket(buf, i, 252);


            }


        }


        ////////////////////////////////////////////////////////////

        public bool receivefile(string savepath)
        {
            string filename = "";
            byte[] buf = new byte[32];
            int Len = 0;

            //get log file name 
            receivepacket(buf);


            Len = buf[3];


            //if (Len > 255) return false;

            /*
            try
            {
                filename = System.Text.ASCIIEncoding.ASCII.GetString(buf, 4, Len);
            }
            catch (Exception prob)
            {
                logname = "";
                return false;
            }
            */

            filename = "LOGFILE.LOG";

            File.Delete( savepath + filename );

            logname += filename;
            logname += " ";
            try
            {
                byte[] buflong = new byte[1000000];

                FileStream fs = new FileStream(savepath + filename, FileMode.Create);

                int end = receivelong(buflong);

                fs.Write(buflong, 0, end);


                fs.Close();
            }
            catch (Exception pro)
            {
                logname = "";
                return false;
            }
            //label4.Text = "GetLog Success" + logname;
            //listBox4.Items.Add(System.DateTime.Now.ToString() + ": " + filename + " received" );
            logtime[lognum] = System.DateTime.Now.ToString("HH:mm:ss");
            logrecord[lognum] = filename + "が受信された";
            Console.Beep(1200, 100);
            Thread.Sleep(100);
            return true;
        }



        ///////////////////////////////////////////////////

        int receivelong(byte[] buf)
        {
            bool first = true;


            int i, offset, index;
            int FileLength, packetLen;

            byte[] temp = new byte[32];


            receivepacket(temp);

            if (temp[0] != 0x06)
            {
                return 0;
            }


            index = 0;
            FileLength = 0;

            while (true)
            {

                if (first)
                {
                    // get the packet length

                    FileLength = temp[3] + temp[4] * 256 + temp[5] * 256 * 256 + temp[6] * 256 * 256 * 256;

                    // should check if it is a data
                    //offset = 9;  // for there are 3 bytes for head (size 2B)  + (DATA 1B)
                    offset = 7; // 4B for lenghth, 1B for DATA
                    first = false;
                    index = 0;


                    /////////////////////////////////
                    if (FileLength < 23) packetLen = FileLength;  //32 - 4 - 5   24- 5
                    else packetLen = 23;

                    FileLength = FileLength - packetLen;


                    for (i = 0; i < packetLen; i++)
                    {
                        buf[i + index] = temp[i + offset];
                    }

                    index = index + packetLen;

                    if (FileLength <= 0) return (index);
                }
                else
                {
                    offset = 2;

                    if (FileLength < 28) packetLen = FileLength; //32 - 4
                    else packetLen = 28;

                    FileLength = FileLength - packetLen;


                    for (i = 0; i < packetLen; i++)
                    {
                        buf[i + index] = temp[i + offset];
                    }

                    index = index + packetLen;

                    if (FileLength <= 0) return (index);

                }

                receivepacket(temp);

                if (temp[0] != 0x06)
                {
                    return 0;
                }
            } //while


        }

        

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (gModeSend == true)
            {

                
            }
           

            if ( gModeSend == false )  
            {
                

            }



        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void GetLogBtn_Click(object sender, EventArgs e)
        {

            if (bClickGetLog) return;
            bClickGetLog = true;
            

            GetLogBtn.Enabled = false;


            labelstatus.ForeColor = Color.Blue;
            labelstatus.Text = "操作履歴の読込中";

            labelstatus.Refresh();

            PrintBtn.Enabled = false;
            
            gUserRecord.Clear();

            panel3.Refresh();

            myFtdiDevice.Purge(FTDI.FT_PURGE.FT_PURGE_RX | FTDI.FT_PURGE.FT_PURGE_TX);

            //U4ModeStart = new Thread(new ThreadStart(u4startfun));
            //U4ModeStart.IsBackground = true;
            //U4ModeStart.Start();
            //Thread.Sleep(1000);

            u4startfun( 1 );

            
            string szLogPath = workfolder + "LOGFILE.LOG";

            //check if there is a log file
            if (File.Exists( szLogPath ) == false )
            {

                labelstatus.ForeColor = Color.Red;
                labelstatus.Text = "操作履歴データがない";

                //etLogBtn.Enabled = true;
                timer2.Start();
                return;
            }

 
            

            gnDeviceID = 0;
            
            //here analysize the LOGFILE
            gUserRecord.Clear();  /// clear the previous record for a new process
            gContPLAY.Clear();

            gnPlayNums = 0;
            gnPlayTotalTime = 0;


            if (ScanLogFile(szLogPath) == true)
            {

                PrintBtn.Enabled = false;

            }
            else
            {
                PrintBtn.Enabled = false;
            }


            for (int k = 0; k < 10; k++)
            {

                testButtons[k].Visible = false;
            }

            panel3.Refresh();


            if (gnDeviceID > 0)
            {
                //DevIDlabel.Text = "利用端末番号：" + gnDeviceID.ToString();

                //the device is back , we will finish the trace of this device
                foreach (UsedDeviceInfo udi in gUsedDevice)
                {
                    if (udi.nDeviceNo == gnDeviceID) // found the device
                    {

                        //input the user information
                        if (checkBoxInput.Checked)
                        {

                            new SEXAGEInput().ShowDialog();

                        }


                        udi.dtReturnTime = DateTime.Now;
                        //add the user SN 
                        UInt32 u32UserSN;

                        DateTime dtBegin = DateTime.Parse("2011/01/01");

                         TimeSpan  tsTemp1 = udi.dtReturnTime - dtBegin;

                        u32UserSN = (UInt32)(tsTemp1.TotalSeconds);


                        u32DeviceMode = udi.u32Mode;

                        //save the device information to a CSV

                        fep_save_Device_Using_Info(udi, u32UserSN);

                        fep_save_Content_Play_Info( udi, u32UserSN );            

                        


                        // backup  the logdate
                        // filename is year-month-day-userSN.LOG
                        if (gbSaveLogData)
                        {
                            if (Directory.Exists(logpath) == false)
                            {

                                Directory.CreateDirectory(logpath);
                            }

                            string strLogbackupname = logpath + udi.dtReturnTime.ToString("yyyy-MM-dd") + "-" + u32UserSN.ToString()
                                + ".LOG";
                            File.Copy(szLogPath, strLogbackupname, true);
                        }


                        gUsedDevice.Remove(udi);
  
                        break;

                    }


                }


            }
            else
            {

                
            }

            if (gUserRecord.Count > 0) PrintBtn.Enabled = true;
            else PrintBtn.Enabled = false;

            labelUsedDevNum.Text = "貸出中端末台数：" + gUsedDevice.Count.ToString();

            labelstatus.ForeColor = Color.LimeGreen;
            labelstatus.Text = "端末" + gnDeviceID.ToString() + "の操作履歴を読み込んだ";

            SetupDeviceUsingList();

            //GetLogBtn.Enabled = true;
            timer2.Start();
        }

        /// <summary>
        /// ////////////////////////////////////////////////////////////////////
        /// 
        public void fep_save_Content_Play_Info(UsedDeviceInfo udi, UInt32 u32UserSN)
        {

            if (gContPLAY.Count == 0) return;

            //write a head
            string strTemp = "User SN, Content ID, Date, Time, Play Time, EndMode, IsQuiz, IsCorrect Ans, inputed Ans";

            

            // open the DB text file
            string deviceusedresultPath = Form1.workfolder + "ContentPlayResult.csv";

            if ( File.Exists( deviceusedresultPath) == true )
            {

                strTemp = "";
            }



            System.IO.StreamWriter DURw = new System.IO.StreamWriter(deviceusedresultPath, true,
                       System.Text.Encoding.GetEncoding("Shift_Jis"));

            if (strTemp.Length > 0) DURw.WriteLine(strTemp);


            foreach (ContentPlayingInfo cpi in gContPLAY)
            {

                 strTemp = u32UserSN.ToString() + ","
                    + cpi.u32CID.ToString("X8") + ","
                    + cpi.dtStartTime.ToString("yyyy-MM-dd") + ","
                    + cpi.dtStartTime.ToString("HH:mm:ss") + ", "
                    + cpi.nPlayTime.ToString() + ","
                    + cpi.nEndMode.ToString() + ","
                    + cpi.bQuiz.ToString() + ","
                    + cpi.bCorrectAns.ToString() + "," 
                    + cpi.nInputAns.ToString() ;


                 DURw.WriteLine(strTemp);
                    

            }//foreach

            

            DURw.Close();

        }


        ////////////////////////////////////////////////////////////////////////
        public void fep_save_Device_Using_Info( UsedDeviceInfo udi, UInt32 u32UserSN )
        {

            string strTemp = "";

            // open the DB text file

                        string deviceusedresultPath = Form1.workfolder + "DeviceUseResult.csv";

                        if (File.Exists(deviceusedresultPath) == false )
                        {
                            strTemp = "Device No, Active Mode, Date, Time, Rental time, Play Numbers, Play time, Sex, Age, address, User SN \r\n";
                        }


                        
                        System.IO.StreamWriter DURw = new System.IO.StreamWriter(deviceusedresultPath, true,
                                   System.Text.Encoding.GetEncoding("Shift_Jis"));


                        TimeSpan tsTemp1 = udi.dtReturnTime - udi.dtStartTime;

                        int nTemp =(int)( tsTemp1.TotalSeconds);


                        //get the user information

                        string strUserInfor = "";
                        
                        if (checkBoxInput.Checked)
                        {
                            //sex -1:unknown, 1:male  2:female
                            // age
                            // -1:unknow, 0:under 10s, 1:10s, 2:20s,3:30s, 4:40s, 5:50s, 6:60s, 7:above 70
                            
                            if ( gSexal == 0 )
                            {

                                strUserInfor += "M,";
                            }
                            else
                            {
                                strUserInfor += "F,";
                            }

                            

                            switch (gAgeIndex)
                            {
                                case 1:
                                    strUserInfor += "10歳以下,";
                                    break;

                                case 2:
                                    strUserInfor += "10代,";
                                    break;

                                case 3:
                                    strUserInfor += "20代,";
                                    break;

                                case 4:
                                    strUserInfor += "30代,";
                                    break;

                                case 5:
                                    strUserInfor += "40代,";
                                    break;

                                case 6:
                                    strUserInfor += "50代,";
                                    break;

                                case 7:
                                    strUserInfor += "60代,";
                                    break;

                                case 8:
                                    strUserInfor += "70代,";
                                    break;

                                case 9:
                                    strUserInfor += "80代以上,";
                                    break;

                                case 0:
                                default:
                                    strUserInfor += "不明,";
                                    break;


                            }


                            switch (gPlace)
                            {
                                case 0:
                                    strUserInfor += "小千谷市,";
                                    break;


                                case 1:
                                    strUserInfor += "長岡市,";
                                    break;

                                case 2:
                                    strUserInfor += "県内,";
                                    break;

                                case 3:
                                    strUserInfor += "県外,";
                                    break;

                                case 4:
                                    strUserInfor += "海外,";
                                    break;

                                case 5:
                                    strUserInfor += "不明,";
                                    break;

                             }


                        }
                        else
                        {
                            //there is no such inforamtion
                            //sex 0:unknown, 1:male  2:female
                            // age
                            // -1:unknow, 0:under 10s, 1:10s, 2:20s,3:30s, 4:40s, 5:50s, 6:60s, 7:above 70
                            strUserInfor += "N,N,N,";


                        }

                        

                        strUserInfor += u32UserSN.ToString() ;

                        strTemp += udi.nDeviceNo.ToString() + ","
                              + udi.u32Mode.ToString("X8") + ","
                              + udi.dtStartTime.ToString("yyyy-MM-dd") + ","
                              + udi.dtStartTime.ToString("HH:mm:ss") + ", "
                              + nTemp.ToString() + ","
                              + gnPlayNums.ToString() + ","
                              + gnPlayTotalTime.ToString() + "," + strUserInfor;  


                        DURw.WriteLine(strTemp);

                        DURw.Close();




        }



        public bool ScanLogFile(string strLogFile)
        {

            
            DateTime dtTemp;
                      



            // here we open the logfile and get the data for content using
            System.IO.FileStream fs = new System.IO.FileStream(
                    strLogFile,
                    System.IO.FileMode.Open,
                    System.IO.FileAccess.Read);

            int nLogDataLength = (int)(fs.Length);

            byte[] bs = new byte[fs.Length];

            fs.Read(bs, 0, bs.Length);
            //閉じる
            fs.Close();

            // start to scan the log data
            // skip the head
            int nPos = 32;
            
            gnDeviceID = bs[nPos] + bs[nPos + 1] * 256;

            string s2;

            nPos += 2;

            byte bCommand = 0;

            byte u8Para = 0;

            DateTime dtStart = DateTime.Today ;
            DateTime dtEnd = DateTime.Today;
            DateTime dtDeviceDate = DateTime.Today;

            UInt32 u32CID = 0;
            UInt32 u32TempCID = 0;

            AnswerRecord TempAns = new AnswerRecord();

            bool bError = false;

            dtTemp = DateTime.Now;


            byte u8Second, u8Minute, u8Hour, u8Month, u8Day;
            UInt16 u16Year;

            while (nPos < nLogDataLength)
            {

                if (bError == true) break;

                bCommand = bs[nPos];

                switch (bCommand)
                {
                    case 0x00: // NOP
                        nPos++;
                        break;

                    case 0x01:// GET UID
                        nPos += 8;
                        break;

                    case 0x02:// GET SID
                        nPos += 8;
                        break;

                    case 0x03:// GET RFID
                        nPos += 8;
                        break;


                    case 0x04: //start play CID

                        TempAns.Resets();

                        u32CID = BitConverter.ToUInt32(bs, nPos + 4); //get the content ID

                        u32TempCID = 0;

                        dtStart = dtDeviceDate;

                        u8Second = bs[nPos + 1];//ss
                        u8Minute = bs[nPos + 2];//mm
                        u8Hour = bs[nPos + 3]; //hh


                        s2 = u8Hour.ToString() + ":" + u8Minute.ToString() + ":" + u8Second.ToString();
                        //文字列をDateTime値に変換する
                        dtStart = DateTime.Parse(s2);
                       
                        TempAns.u32CID = u32CID;
                        TempAns.dtStartTime = dtStart;

                        nPos += 8;
                        break;


                    case 0x05://playing is eneded


                        u32TempCID = BitConverter.ToUInt32(bs, nPos + 4); //get the content ID

                        if ( (u32TempCID != TempAns.u32CID ))
                        {

                            TempAns.Resets();
                            u32CID = 0;
                            u32TempCID = 0;

                            nPos += 8;

                            break;

                        }

                        dtEnd = dtDeviceDate;

                        u8Second = bs[nPos + 1];//ss
                        u8Minute = bs[nPos + 2];//mm
                        u8Hour = bs[nPos + 3]; //hh


                        s2 = u8Hour.ToString() + ":" + u8Minute.ToString() + ":" + u8Second.ToString();
                        //文字列をDateTime値に変換する
                        dtEnd = DateTime.Parse(s2);


                        ////////////////////////////////////////////////////////////////////
                        // record the content playing information to the CSV

                        //if ( TempAns.bReady )
                        {

                            //TempAns.dtStartTime = dtStart;
                            TempAns.dtEndTime = dtEnd;
                            
                            gnPlayNums++;
                            TimeSpan tsTemp;

                            TempAns.nEndMode = 0;

                            tsTemp = dtEnd - dtStart;

                            gnPlayTotalTime += (int)(tsTemp.TotalSeconds);


                            //add this play event to contents playing list
                            ContentPlayingInfo temp_contentplayInfo = new ContentPlayingInfo();

                            temp_contentplayInfo.bQuiz = false;

                            //check if it is a quiz
                            foreach (contentsInfo coninfo in gconINFO)
                            {
                                if (coninfo.GetContentID() == u32TempCID) // found the content
                                {

                                    //check if it is a quiz
                                    temp_contentplayInfo.bQuiz = coninfo.bQuiz;

                                }

                            }

                            temp_contentplayInfo.u32CID = TempAns.u32CID;

                            temp_contentplayInfo.nInputAns = TempAns.nAns;
                            
                            temp_contentplayInfo.bCorrectAns = TempAns.bCorrect;
                            temp_contentplayInfo.dtStartTime = TempAns.dtStartTime;
                            temp_contentplayInfo.nPlayTime = (int)(tsTemp.TotalSeconds);
                            temp_contentplayInfo.nEndMode = TempAns.nEndMode;

                            gContPLAY.Add(temp_contentplayInfo);

                            if (temp_contentplayInfo.bQuiz == false)
                            {

                                TempAns.Resets();
                                u32CID = 0;
                                u32TempCID = 0;

                                nPos += 8;

                                break;

                            }

                            if (u32TempCID == 0xA0000000) // example quiz
                            {
                                TempAns.Resets();
                                u32CID = 0;
                                u32TempCID = 0;

                                nPos += 8;

                                break;

                            }

                            bool bFound2 = false;
                            //valid timing data
                            foreach (AnswerRecord anss in gUserRecord)
                            {

                                if (anss.u32CID == TempAns.u32CID ) // already one
                                {
                                    anss.Copy(TempAns);
                                    bFound2 = true;
                                    break;
                                }


                            }

                            if (bFound2 == false)
                            {
                                AnswerRecord  AnsTemp = new AnswerRecord();

                                AnsTemp.Copy(TempAns);

                                
                                gUserRecord.Add(AnsTemp); //add a new record

                            }



                        }


                        u32CID = 0;
                        u32TempCID = 0;
                        TempAns.Resets();
                        
                        nPos += 8;
                        break;

                    case 0x06://playing is terminated

                        u32TempCID = BitConverter.ToUInt32(bs, nPos + 4); //get the content ID

                        if ((u32TempCID != TempAns.u32CID))
                        {

                            TempAns.Resets();
                            u32CID = 0;
                            u32TempCID = 0;

                            nPos += 8;

                            break;

                        }

                        dtEnd = dtDeviceDate;

                        u8Second = bs[nPos + 1];//ss
                        u8Minute = bs[nPos + 2];//mm
                        u8Hour = bs[nPos + 3]; //hh


                        s2 = u8Hour.ToString() + ":" + u8Minute.ToString() + ":" + u8Second.ToString();
                        //文字列をDateTime値に変換する
                        dtEnd = DateTime.Parse(s2);

                        //if ( TempAns.bReady )
                        {

                            //TempAns.dtStartTime = dtStart;
                            TempAns.dtEndTime = dtEnd;

                            TempAns.nEndMode = 1;

                            gnPlayNums++;

                            TimeSpan tsTemp;

                            tsTemp = dtEnd - dtStart;

                            gnPlayTotalTime += (int)(tsTemp.TotalSeconds);

                            


                            //add this play event to contents playing list
                            ContentPlayingInfo temp_contentplayInfo = new ContentPlayingInfo();

                            temp_contentplayInfo.bQuiz = false;

                            //check if it is a quiz
                            foreach (contentsInfo coninfo in gconINFO)
                            {
                                if (coninfo.GetContentID() == u32TempCID) // found the content
                                {

                                    //check if it is a quiz
                                    temp_contentplayInfo.bQuiz = coninfo.bQuiz;

                                }

                            }

                            temp_contentplayInfo.u32CID = TempAns.u32CID;

                            temp_contentplayInfo.nInputAns = TempAns.nAns;
                            
                            temp_contentplayInfo.bCorrectAns = TempAns.bCorrect;
                            temp_contentplayInfo.dtStartTime = TempAns.dtStartTime;
                            temp_contentplayInfo.nPlayTime = (int)(tsTemp.TotalSeconds);
                            temp_contentplayInfo.nEndMode = TempAns.nEndMode;

                            gContPLAY.Add(temp_contentplayInfo);

                            /*
                            bool bFound2 = false;
                            //valid timing data
                            foreach (AnswerRecord anss in gUserRecord)
                            {

                                if (anss.u32CID == TempAns.u32CID) // already one
                                {
                                    anss.Copy(TempAns);
                                    bFound2 = true;
                                    break;
                                }


                            }

                            if (bFound2 == false)
                            {
                                AnswerRecord AnsTemp = new AnswerRecord();

                                AnsTemp.Copy(TempAns);


                                gUserRecord.Add(AnsTemp); //add a new record

                            }
                            */





                        }


                        u32CID = 0;
                        u32TempCID = 0;
                        TempAns.Resets();

                                            

                        
                        nPos += 8;
                        break;

                    case 0x07:// select a branch
                        {

                            
                            
                            //get the scene NO and branch NO
                            u8Para = bs[nPos + 4];

                            int nSceneNo = (u8Para >> 2);
                            int nBranchNo = (u8Para & 0x03) + 1;

                                                        
                            //check the result
                            foreach ( contentsInfo coninfo in gconINFO )
                            //for (int i = 0; i < gconINFO.Count; i++)
                            {
                                if ( coninfo.GetContentID() == u32CID && coninfo.bQuiz == true ) // found the content
                                {
                                    
                                    TempAns.nAns = nBranchNo;

                                    if ( coninfo.GetQuizAnsNum() == nBranchNo)
                                    {                                                      
                                        TempAns.bCorrect = true;                                      
                                    }
                                    else
                                    {
                                        TempAns.bCorrect = false;                                                                                
                                    }

                                    TempAns.strTitle = coninfo.GetQuizTitle();
                                    TempAns.u32CID = u32CID;

                                    //record the quiz time
                                    TempAns.dtQuiz = dtDeviceDate;

                                    u8Second = bs[nPos + 1];//ss
                                    u8Minute = bs[nPos + 2];//mm
                                    u8Hour = bs[nPos + 3]; //hh


                                    s2 = u8Hour.ToString() + ":" + u8Minute.ToString() + ":" + u8Second.ToString();
                                    //文字列をDateTime値に変換する
                                    TempAns.dtQuiz = DateTime.Parse(s2);

                                                                                                            
                                    break;

                                }//found the item
                                
                            } //foreach


                        }



                        nPos += 5;
                        break;

                    case 0x08:// power ON

                        nPos += 5; //4
                        break;

                    case 0x09:// power OFF

                        nPos += 5; //4
                        break;

                    case 0x0A:// Get PANID

                        nPos += 8;
                        break;

                    case 0x0B:// Operation date TIME(３B) +DATE(4B)

                        

                        u8Second = bs[nPos + 1];//ss
                        u8Minute = bs[nPos + 2];//mm
                        u8Hour = bs[nPos + 3]; //hh

                        u16Year = BitConverter.ToUInt16(bs, nPos + 4);
                        u8Month = bs[nPos + 6];
                        u8Day = bs[nPos + 7];

                        //string s1 = "1992/2/16 12:15:12";

                        string s1 = u16Year.ToString() + "/" + u8Month.ToString() + "/" + u8Day.ToString() + " "
                            + u8Hour.ToString() + ":" + u8Minute.ToString() + ":" + u8Second.ToString();
                        //文字列をDateTime値に変換する
                        dtDeviceDate = DateTime.Parse(s1);
                        
                        

                        nPos += 8;
                        break;

                    case 0x0C://Start FM guide Start
                        nPos += 4;
                        break;

                    case 0x0D: //Start FM guide End
                        nPos += 4;
                        break;

                    case 0x0E: // Charge start
                        nPos += 5;
                        break;

                    case 0x0F:// Charge end
                        nPos += 5;
                        break;


                    default:

                        bError = true;

                        break;

                }//switch


            }//while


            
            return true;
        }

        ///////////////////////////////////////////////////////////////////////////
        public int GetDeviceNo(string strLogFile)
        {

            int nDevNo = 0;

 
            // here we open the logfile and get the data for content using
            System.IO.FileStream fs = new System.IO.FileStream(
                    strLogFile,
                    System.IO.FileMode.Open,
                    System.IO.FileAccess.Read);

            int nLogDataLength = (int)(fs.Length);

            byte[] bs = new byte[fs.Length];

            fs.Read(bs, 0, bs.Length);
            //閉じる
            fs.Close();

            // start to scan the log data
            // skip the head
            int nPos = 32;

            nDevNo = bs[nPos] + bs[nPos + 1] * 256;

            

            return nDevNo;
        }



        /// <summary>
        /// /////////////////////////////////////////////////////////////////////////
        /// 
        /// 
        bool fep_Search_AnswerNo(string filepath )
        {
            bool bSuc = false;

            byte[] buf = new byte[256];



            
            string stFolderName = "";
            string stFileNameA = "";

            gstrQuizA = "";
            gstrQuizP = "";
            gnAns = 0;


            long nCurrentPos = 0;

            //open file
            System.IO.FileStream fsbin =
                new System.IO.FileStream(filepath, System.IO.FileMode.Open, System.IO.FileAccess.Read);

            //get the filename length
            fsbin.Read(buf, 0, 128);


            int filenamelength = buf[9];

            byte[] temp = new byte[filenamelength];

            for (int i = 0; i < filenamelength; i++)
                temp[i] = buf[10 + i];



            // get the folder name
            stFolderName = System.Text.Encoding.ASCII.GetString(temp);

            stFolderName = stFolderName.Substring(0, stFolderName.IndexOf("/"));

            long lIBCFileLength = fsbin.Length;

            //search for TEXTDATA.TXT
            while (lIBCFileLength > 0)
            {
                fsbin.Seek(nCurrentPos, SeekOrigin.Begin);

                fsbin.Read(buf, 0, 64);


                int filenamelength1 = buf[9];

                UInt32 u32fileLength = BitConverter.ToUInt32(buf, 1);


                byte[] bufFileName = new byte[filenamelength1];
                //check the file name
                for (int i = 0; i < filenamelength1; i++)
                    bufFileName[i] = buf[10 + i];

                // get the folder name
                stFileNameA = System.Text.Encoding.ASCII.GetString(bufFileName);
                stFileNameA = stFileNameA.Substring(stFileNameA.LastIndexOf("/") + 1, stFileNameA.Length - stFileNameA.LastIndexOf("/") - 1);

                // search content information file
                if (stFileNameA == "CONTENTINFO.CSV")
                {

                    // read out the SN information
                    // cal the data start pos
                    int nDataStart = buf[0] + (int)nCurrentPos;

                    fsbin.Seek(nDataStart, SeekOrigin.Begin);

                    byte[] bufData = new byte[(int)u32fileLength]; //get all the file data

                    fsbin.Read(bufData, 0, (int)u32fileLength);

                    // save the CSV file to workspace
                    string tempcsvfile = workfolder + "TEMP.CSV";

                    if (File.Exists(tempcsvfile))
                    {
                        File.Delete(tempcsvfile);
                    }

                    System.IO.FileStream csvtempst =
                        new System.IO.FileStream(tempcsvfile, System.IO.FileMode.CreateNew, System.IO.FileAccess.Write);

                    csvtempst.Write(bufData, 0, (int)u32fileLength);

                    csvtempst.Close();

                    //check the CSV file here
                    TextFieldParser parser = new TextFieldParser(tempcsvfile,
                                System.Text.Encoding.GetEncoding("Shift_JIS"));

                    int i = 0;
                    int nTemp;

                    using (parser)
                    {
                        parser.TextFieldType = FieldType.Delimited;
                        parser.SetDelimiters(","); // 区切り文字はコンマ


                        while (!parser.EndOfData)
                        {
                            string[] row = parser.ReadFields(); // 1行読み込み

                            if (i == 0)
                            {
                                i++;
                                continue;  //skip the first line
                            }


                            int nTempScene = int.Parse(row[0]);

                            int nBranchNum = int.Parse(row[3]);

                            if (nBranchNum > 0) // found the selection scene 
                            {

                                nTemp = 0;

                                while ( nTemp < nBranchNum )
                                {
                                        if ( int.Parse( row[ 4 + nTemp ]) > 0 )
                                        {

                                            //found the correction selection

                                            gnAns = nTemp + 1; // selection is from 1
                                            fsbin.Close();

                                            gstrQuizP = row[1];
                                            gstrQuizA = row[2];

                                            bSuc = true;


                                            return bSuc;

                                        }

                                        nTemp++;


                                }//while nbranchnu
                                                    
                            }//if found the scene


                        }
                    }

                    break;
                }
                else
                {
                    //move to next data block
                    nCurrentPos += buf[0] + BitConverter.ToUInt32(buf, 1);

                    lIBCFileLength -= buf[0] + BitConverter.ToUInt32(buf, 1);

                }


            }



            fsbin.Close();


            return bSuc;
        }







        public void u4startfun(  int nMode )  // nMode 0- delete the LOG
        {


            bool bRtn = false;
            string strCMD;
            int ii;

            //int    nRFChnLog = 25;

            byte[] buftemp = new byte[32];

            myFtdiDevice.Purge(FTDI.FT_PURGE.FT_PURGE_RX | FTDI.FT_PURGE.FT_PURGE_TX);


            strCMD = "SUMON"; //stop monitoring device
            sendcommand(strCMD, false);


            //1) change the RF channel for receiving Logfile
            strCMD = "RFCHN:" + nRFChnLog.ToString();
            bRtn = sendcommand(strCMD, false);

            Thread.Sleep(100);

            //sendcommand("HELLO", false);

            File.Delete(workfolder + "LOGFILE.LOG");

            
            for (ii = 0; ii < 1; ii++)  // for default device  max try number is 3
            {

                //uploading = "U4 開始中";

                // start U4
                strCMD = "U4REQ:" +  Form1.nRFChnLog.ToString();
                bRtn = sendcommand(strCMD, false);


                // here we wait for ACK from the device

                IrDeviceTimeout(6000); //1 second wailt
                try
                {
                    receivepacket(buftemp);
                }
                catch (Exception eee)
                {
                    MessageBox.Show(eee.GetType().FullName);
                    continue;
                }

                if (System.Text.ASCIIEncoding.ASCII.GetString(buftemp, 0, 32).IndexOf("U4SUSS") == -1)
                {
                    continue;
                }

                Thread.Sleep(100);

                if (nMode == 0)
                {

                    //set the date for the device
                    strCMD = "SETDT:" + System.DateTime.Now.ToString("yyyy/MM/dd");

                    sendcommand(strCMD, false);

                    Thread.Sleep(100);


                    strCMD = "RMLOG:0";
                    sendcommand(strCMD, false);

                    

                }



                //sendcommand("HELLO", false);
                Thread.Sleep(500);

                //uploading = "端末" + ii.ToString() + "からログを受信している";

                 strCMD = "SDLOG:" + ii.ToString();
                 sendcommand(strCMD, false);


                 IrDeviceTimeout(2000); //1 second wailt
                 try
                 {
                       receivepacket(buftemp);
                 }
                 catch (Exception eee)
                 {
                        MessageBox.Show(eee.GetType().FullName);
                        continue;
                 }
                 
                 if (System.Text.ASCIIEncoding.ASCII.GetString(buftemp, 0, 32).IndexOf("LOGLEN:") == -1)
                 {
                        continue;
                 }


                  //wait for the end of transmiting of LOG file
                  IrDeviceTimeout(20000);
                  try
                  {

                        receivepacket(buftemp);


                  }
                  catch (Exception eee)
                  {
                        MessageBox.Show(eee.GetType().FullName);
                        continue;
                  }



                    IrDeviceTimeout(15000);

                    if (System.Text.ASCIIEncoding.ASCII.GetString(buftemp, 0, 32).IndexOf("GETLOG") != -1)
                    {

                        //start to get LOGFILE
                        bRtn = sendcommand("GFILE", false);

                        Thread.Sleep(100);

                        if (bRtn)
                        {
                            labelstatus.ForeColor = Color.LimeGreen;
                            labelstatus.Text = "端末状態を読み込んだ";
                        }
                        else
                        {

                            labelstatus.ForeColor = Color.Red;
                            labelstatus.Text = "エラーが発生、再送中";
                        }

                       

                    }

                    


            }   // for ii


            //strCMD = "RFCHN:" + nRFChnState.ToString();
            //sendcommand("RFCHN:2", false);
            //sendcommand(strCMD, false);

            // quit the U4
            strCMD = "U4END";
            sendcommand(strCMD, false);

            //mymutex.ReleaseMutex();

            //gbBUSY = false;
            //gbButtonEnable = true;
            //uploading = "";

            //bTimer2Run = false;
            


        }

        private void button2_Click(object sender, EventArgs e)
        {
           

            string apppath = System.AppDomain.CurrentDomain.BaseDirectory.ToString();
            string config = apppath + "\\" + "config.txt";
            if (File.Exists(config))
            {
                File.Delete(config);
            }
            StreamWriter sw = new StreamWriter(config);

            sw.WriteLine(Form1.workfolder);
            sw.WriteLine(Form1.logpath);
            sw.WriteLine(Form1.gb_FinalSetup);
            sw.WriteLine(Form1.nRFChnLog);
            sw.WriteLine(Form1.strSETUPpassword);
            sw.WriteLine(Form1.ibcfolder);
            sw.WriteLine(Form1.gbSaveLogData);

                        
            sw.Close();

            
            //save the current device in used
            string classpath = workfolder + "deviceInUsed.dev";


            {
                //we create a new one

                
                // save it to binary file
                FileStream fileStream = new FileStream(classpath, FileMode.Create);
                BinaryFormatter b = new BinaryFormatter();
                b.Serialize(fileStream, gUsedDevice );
                fileStream.Close();

            }
            
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            bool bRtn = false;
            string strCMD;
            byte[] buftemp = new byte[32];

            if (bClickDeviceSet) return;
            bClickDeviceSet = true;

            button3.Enabled = false;

            

            labelstatus.ForeColor = Color.Blue;
            labelstatus.Text = "端末モードを設定している";
            labelstatus.Refresh();

            UInt32 u32ID = 0x00FA0000;

            //check the mode is avaiable
            if (ExpcheckBox2.Checked) u32ID = u32ID | 0x00001000;

            if (QuizcheckBox1.Checked)
            {

                //check the quiz level
                UInt32 u32Level = 0;
                if (radioButton1.Checked) u32Level = 0x0001;
                else if (radioButton2.Checked) u32Level = 0x0002;
                else if (radioButton3.Checked) u32Level = 0x0004;
                else if (radioButton4.Checked) u32Level = 0x0008;
                else if (radioButton5.Checked) u32Level = 0x0010;


                u32ID = u32ID | u32Level;

            }


            
            //here we will use U4 mode to get the device information
            ///////////////////////////////////////////////////////////
            labelstatus.ForeColor = Color.Blue;
            labelstatus.Text = "端末情報の読込中";
            labelstatus.Refresh();

            myFtdiDevice.Purge(FTDI.FT_PURGE.FT_PURGE_RX | FTDI.FT_PURGE.FT_PURGE_TX);

                       
            u4startfun(  0 );


            string szLogPath = workfolder + "LOGFILE.LOG";

            //check if there is a log file
            if (File.Exists( szLogPath ) == false )
            {
                labelstatus.ForeColor = Color.Red;
                labelstatus.Text = "端末情報取得失敗";

                //button3.Enabled = true;

                timer2.Start();
               return;
            }

            
            gnDeviceID = 0;
            
            gnDeviceID = GetDeviceNo(szLogPath);

            if (gnDeviceID  == 0)
            {
                labelstatus.ForeColor = Color.Red;

                labelstatus.Text = "端末番号がない";

                //button3.Enabled = true;


                timer2.Start();
                return;
            }
            else
            {
                labelstatus.ForeColor = Color.LimeGreen;
                labelstatus.Text = gnDeviceID.ToString() + "端末の番号取得";

            }


            Thread.Sleep(100); //wait 0.5second


            // send the IR ID for selected Mode
            strCMD = "IRSND:" + u32ID.ToString("X8");
            bRtn = sendcommand(strCMD, false);
            


            
             labelstatus.ForeColor = Color.LimeGreen;
            labelstatus.Text =  "端末"　+ gnDeviceID.ToString() +  "の動作モードを設定した";

            

                       


            //add the device information to device using condition list
            // check if the device is in list already
            UsedDeviceInfo udiTemp = null;

            foreach (UsedDeviceInfo udi in gUsedDevice)
            {

                if (udi.nDeviceNo == gnDeviceID)
                {
                    udiTemp = udi;

                }
            }

            if (udiTemp == null)
            {
                udiTemp = new UsedDeviceInfo();
                gUsedDevice.Add(udiTemp);
            }
            udiTemp.nDeviceNo = gnDeviceID;
            udiTemp.dtStartTime = DateTime.Now;
            udiTemp.dtReturnTime = DateTime.Now;
            udiTemp.u32Mode = u32ID;


            labelUsedDevNum.Text = "貸出中端末台数：" + gUsedDevice.Count.ToString();

            SetupDeviceUsingList();

            //button3.Enabled = true;

            timer2.Start();

        }

        private void ExpcheckBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (ExpcheckBox2.Checked == false)
            {
                if (QuizcheckBox1.Checked == false)
                    QuizcheckBox1.Checked = true;


            }

            
        }

        private void QuizcheckBox1_CheckedChanged(object sender, EventArgs e)
        {



            if (QuizcheckBox1.Checked == true )
            {
                panel1.Enabled = true;

                
            }
            else
            {

                panel1.Enabled = false;

                if (ExpcheckBox2.Checked == false)  ExpcheckBox2.Checked = true;
            }



        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (Form1.gb_FinalSetup == true)
            {
                if (new password().ShowDialog() != DialogResult.OK) return; //terminate the program
            }


           

            setupbasic fsetup = new setupbasic();


            if ( fsetup.ShowDialog() == DialogResult.OK )
            //if (new setupbasic().ShowDialog() == DialogResult.OK)
            {

                /////////////////////////////////////////////////
                //
                // here we create a list for contents list
                string szTitle, temp, szFilePath;
                
                gconINFO.Clear();


                


                string[] fileslist =
                        System.IO.Directory.GetFiles(Form1.ibcfolder, "*.ibc", System.IO.SearchOption.AllDirectories);


                for (int i = 0; i < fileslist.Length; i++)
                {
                    contentsInfo coninfotemp = new contentsInfo();

                    //save the path
                    coninfotemp.SetContentsIbcPath(fileslist[i]);

                    // get CID and Title
                    szFilePath = fileslist[i];

                    temp = getFolderNameOnly(szFilePath);

                    UInt32 u32CCID = Convert.ToUInt32(temp, 16);

                    szTitle = getContentTitle(szFilePath);

                    coninfotemp.SetContentsID(u32CCID);
                    coninfotemp.SetContentTitle(szTitle);

                    //get the quiz problem
                    if (fep_Search_AnswerNo(szFilePath) == true)
                    {
                        coninfotemp.SetAnswerSelection(gnAns);
                        coninfotemp.SetQuiz(gstrQuizP);
                        coninfotemp.SetQuizAns(gstrQuizA);

                        coninfotemp.bQuiz = true;

                        

                    }
                    else
                    {
                        coninfotemp.bQuiz = false; // a normal content
                    }


                    //add the information to list
                    gconINFO.Add(coninfotemp);

                } //for i


            }

            labelUsedDevNum.Text = "貸出中端末台数：" + gUsedDevice.Count.ToString();

            SetupDeviceUsingList();

            

        }

        private void PrintBtn_Click(object sender, EventArgs e)
        {

            

            if (gUserRecord.Count == 0) return;


            if (textBox1.Text == "")
            {
                MessageBox.Show("利用者氏名又はニックネームを入力してください。");
                return;
            }

            labelstatus.ForeColor = Color.Blue;
            labelstatus.Text = "修了証を印刷している";


            //印刷に使うフォントを指定する
            printFontName = new Font("ＭＳ Ｐゴシック", 21f);
            printFontDate = new Font("ＭＳ Ｐゴシック", 15f);
            printFontCourse = new Font("ＭＳ Ｐゴシック", 18f);
            printFontMark = new Font("ＭＳ Ｐゴシック", 26f);
            printFontMain = new Font("ＭＳ Ｐゴシック", 8.5f);

            //PrintDocumentオブジェクトの作成
            System.Drawing.Printing.PrintDocument pd =
                new System.Drawing.Printing.PrintDocument();
            //PrintPageイベントハンドラの追加
            pd.PrintPage +=
                new System.Drawing.Printing.PrintPageEventHandler(pd_PrintPage);
            //印刷を開始する
            pd.Print();


            //textBox1.Text = "";
            //gUserRecord.Clear();

            panel3.Refresh();




        }





        private void pd_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            int i = 0;
            float fFh;
            float fPrtOffsetX = -3.0f;
            float fPrtOffsetY = -3.5f;

            float fQuizX = 53.0f + fPrtOffsetX, fQuizY = 85.0f + fPrtOffsetY, fQuizW = 55f, fQuizH = 13f;
            float fAnsX = 125.0f + fPrtOffsetX, fAnsY = 85.0f + fPrtOffsetY, fAnsW = 72f, fAnsH = 13f;
            float fMarkX = 21.5f + fPrtOffsetX, fMarkY = 85f + fPrtOffsetY;

            
            float fDistance = 103.5f - 85f;


            string strQuizProblem = "";
            string strQuizAnswer = "";

            string strOK = "○";
            string strERR = "×";
            string strOK1 = "正解";
            string strERR1 = "不正解";

            //name 
            printingText = textBox1.Text ;
            
                       

            e.Graphics.PageUnit = GraphicsUnit.Millimeter;
            e.Graphics.PageScale = 1;

            fFh = printFontName.GetHeight(e.Graphics); 
            //印刷する初期位置を決定
            float x = 10.5f + fPrtOffsetX;
            float y = 8f + fPrtOffsetY + (11f - fFh )/2;

                        
            //一行書き出す
            e.Graphics.DrawString(printingText, printFontName, Brushes.Black, x, y);
                

            // date
            DateTime dtToday = DateTime.Today;

            printingText = dtToday.ToString("yyyy年M月d日");

            fFh = printFontDate.GetHeight(e.Graphics); 

            //印刷する初期位置を決定
            
            x = 156f + fPrtOffsetX;
            y = 8f + fPrtOffsetY + (11- fFh)/2;

            //一行書き出す
            e.Graphics.DrawString(printingText, printFontDate, Brushes.Black, x, y);


            //print the couse name
            printingText = "";

            switch ((u32DeviceMode & 0x0000001F))
            {
                case 0x0001:

                    printingText = "そなえちゃんチャレンジコース";
                    break;

                case 0x0002:
                    printingText = "しんぼうくんチャレンジコース";
                    break;

                case 0x0004:
                    printingText = "なまず先生チャレンジコース";
                    break;

                case 0x0008:
                    printingText = "そなエ門チャレンジコース";
                    break;

                case 0x0010:
                    printingText = "そなコイズチャレンジコース";
                    break;

            }

            fFh = printFontCourse.GetHeight(e.Graphics); 


            x = 58f + fPrtOffsetX;
            y = 28f + fPrtOffsetY + (8 - fFh )/2;

            //一行書き出す
            e.Graphics.DrawString(printingText, printFontCourse, Brushes.Black, x, y);


            //record print
            foreach (AnswerRecord AnsIndex in gUserRecord)
            {
                               
                                                             
                //get the quiz information for this Content ID
                foreach ( contentsInfo ConTemp in gconINFO )
                {
                    if ( ConTemp.GetContentID() == AnsIndex.u32CID ) 
                    {
                        strQuizProblem = ConTemp.GetQuiz();
                        strQuizAnswer = ConTemp.GetQuizAns();



                        break;
                    }
                    

                }


                //print quiz result Mark
                x = fMarkX + 1f;
                y = fMarkY;

                if (AnsIndex.bCorrect)
                {
                    printingText = strOK;
                }
                else
                {
                    printingText = strERR;
                }

                e.Graphics.DrawString(printingText, printFontMark, Brushes.Black, x, y);

                y = fMarkY + 9.4f;
                if (AnsIndex.bCorrect)
                {
                    x += 3f;
                    printingText = strOK1;
                }
                else
                {
                    x += 1f;
                    printingText = strERR1;
                }

                e.Graphics.DrawString(printingText, printFontMain, Brushes.Black, x, y);


                
                printingText = strQuizProblem;
                printingPosition = 0;

                                
                if (printingPosition == 0)
                {
                    //改行記号を'\n'に統一する
                    printingText = printingText.Replace("\r\n", "\n");
                    printingText = printingText.Replace("\r", "\n");
                }


                //印刷する初期位置を決定
                x = fQuizX;
                y = fQuizY;

                fFh = printFontMain.GetHeight(e.Graphics); 

                //1ページに収まらなくなるか、印刷する文字がなくなるかまでループ
                while ( ( (fQuizY + fQuizH) > y + fFh ) &&
                    ( printingPosition < printingText.Length ) )
                {
                    string line = "";
                    for (; ; )
                    {
                        //印刷する文字がなくなるか、
                        //改行の時はループから抜けて印刷する
                        if (printingPosition >= printingText.Length ||
                            printingText[printingPosition] == '\n')
                        {
                            printingPosition++;
                            break;
                        }
                        //一文字追加し、印刷幅を超えるか調べる
                        line += printingText[printingPosition];
                        if (e.Graphics.MeasureString(line, printFontMain).Width
                            > fQuizW )
                        {
                            //印刷幅を超えたため、折り返す
                            line = line.Substring(0, line.Length - 1);
                            break;
                        }
                        //印刷文字位置を次へ
                        printingPosition++;
                    }
                    //一行書き出す
                    e.Graphics.DrawString(line, printFontMain, Brushes.Black, x, y);
                    //次の行の印刷位置を計算
                    y += printFontMain.GetHeight(e.Graphics) + 0.5f;
                }

                ///////////////////////////////////////////////////////////////////////////////////////////////
                //print answer
                printingText = strQuizAnswer;
                printingPosition = 0;


                if (printingPosition == 0)
                {
                    //改行記号を'\n'に統一する
                    printingText = printingText.Replace("\r\n", "\n");
                    printingText = printingText.Replace("\r", "\n");
                }


                //印刷する初期位置を決定
                x =  fAnsX;
                y =  fAnsY;

                
                //1ページに収まらなくなるか、印刷する文字がなくなるかまでループ
                while (  ((fAnsY + fAnsH) > y + fFh ) &&
                    ( printingPosition < printingText.Length ) )
                {
                    string line = "";
                    for (; ; )
                    {
                        //印刷する文字がなくなるか、
                        //改行の時はループから抜けて印刷する
                        if (printingPosition >= printingText.Length ||
                            printingText[printingPosition] == '\n')
                        {
                            printingPosition++;
                            break;
                        }
                        //一文字追加し、印刷幅を超えるか調べる
                        line += printingText[printingPosition];
                        if (e.Graphics.MeasureString(line, printFontMain).Width
                            > fAnsW )
                        {
                            //印刷幅を超えたため、折り返す
                            line = line.Substring(0, line.Length - 1);
                            break;
                        }
                        //印刷文字位置を次へ
                        printingPosition++;
                    }
                    //一行書き出す
                    e.Graphics.DrawString(line, printFontMain, Brushes.Black, x, y);
                    //次の行の印刷位置を計算
                    y += printFontMain.GetHeight(e.Graphics) + 0.5f;
                }


                // print 
                // mark, Quiz, Answer
                fMarkY += fDistance;
                fQuizY += fDistance;
                fAnsY += fDistance;


                i++;



            }//answer record 

            labelstatus.ForeColor = Color.LimeGreen;
            labelstatus.Text = "修了証を印刷した";
            
        }


        //Buttonのクリックイベントハンドラ
        private void testButtons_Click(object sender, EventArgs e)
        {


            string strBtnName = ((System.Windows.Forms.Button)sender).Name;

            gnBtnNo = int.Parse(strBtnName);

            

            Ansdetail fansdetail = new Ansdetail();
            
            fansdetail.ShowDialog();

            

        }


        



        private void Panel3_Paint(object sender, PaintEventArgs e)
        {


            if (gUserRecord.Count > 0)
            {

                int i = 1;

                //prepare pen
                Font fnt1 = new Font("ＭＳ Ｐゴシック", 12);

                Rectangle rect = new Rectangle(80, 0, panel3.Size.Width, fnt1.Height + 10);

                


                //draw the result here
                foreach (AnswerRecord AnsPt in gUserRecord)
                {
                    string strprint = "";

                    rect.Y = 10 + rect.Height * (i - 1);

                    strprint = " ";

                    testButtons[i - 1].Location = new Point(groupBox2.Location.X + panel3.Location.X + 10,
                                                    groupBox2.Location.Y + panel3.Location.Y + rect.Y);

                    testButtons[i - 1].Visible = true;




                    if (AnsPt.bCorrect)
                    {
                        strprint += "○";
                    }
                    else
                    {
                        strprint += "×";

                    }

                    strprint += " 　　  " + AnsPt.nAns.ToString() + "       " + AnsPt.strTitle;



                    e.Graphics.DrawString(strprint, fnt1, Brushes.Black, rect);

                    i++;

                    if (i >= 11) // too many results
                        break;
                }



            }
            else
            {
                for (int i = 0; i < testButtons.Length; i++)
                {
                    testButtons[i].Visible = false;
                }


            }


        }

        private void button4_Click(object sender, EventArgs e)
        {
            
            new deviceUsingInfo().ShowDialog();

        }

        private void checkBoxDevNo_CheckedChanged(object sender, EventArgs e)
        {
            SetupDeviceUsingList();

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void labelstatus_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        
        private void buttonQuizRate_Click(object sender, EventArgs e)
        {
            new quizeAnsResult().ShowDialog();
        }

        private void buttonRank_Click(object sender, EventArgs e)
        {

            new ExpRankResult().ShowDialog();

        }

        private void button5_Click_1(object sender, EventArgs e)
        {

            textBox1.Clear();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            
            timer2.Stop();
            if (bClickDeviceSet)
            {
                bClickDeviceSet = false;
                button3.Enabled = true;
            }

            if (bClickGetLog)
            {
                bClickGetLog = false;
                GetLogBtn.Enabled = true;


            }

        }

        
       


    }
}
