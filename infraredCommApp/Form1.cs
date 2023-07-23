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
using Microsoft.VisualBasic.ApplicationServices;
//using static System.Net.Mime.MediaTypeNames;
//using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Image = System.Drawing.Image;
using System.Linq;
using System.Xml.Linq;
using System.Drawing.Drawing2D;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Windows.Forms.DataVisualization.Charting;
using System.Data.SqlClient;
using ExcelDataReader;
using System.Reflection;
using System.Globalization;
using System.Windows.Threading;
using Timer = System.Windows.Forms.Timer;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Reflection.Emit;
using System.Runtime.InteropServices.ComTypes;

namespace infraredCommApp
{


    public partial class Form1 : Form
    {
        List<QuizAnsInformation> BarGrapggStoryINFOALl = new List<QuizAnsInformation>();
        static DataTable dtBarGrapggStoryINFOALl = new DataTable();
        public string AnalyzedData = "";
        public string QuizId = "";
        public string Accurate = "";
        //public List<Dictionary<string, string>> DictionaryByID = new List<Dictionary<string, string>>();
        //public List<Dictionary<string, string>> DictionaryByAccurate = new List<Dictionary<string, string>>();
        //public List<Dictionary<string, string>> DictionaryByAll = new List<Dictionary<string, string>>();
        public List<Dictionary<string, string>> ExportDataDictionary = new List<Dictionary<string, string>>();
        Dictionary<string, string> TitleDictionary = new Dictionary<string, string>();
        public List<QuizAnsInformation> QuizAnsInformationResult = new List<QuizAnsInformation>();

        public static List<tagu> taglist = new List<tagu>();

        public static string FromDate = "";
        public static string ToDate = "";
        public static string Type = "";
        public static string[] TagNameAll = null;
        public static DataTable dtTagNameAll = new DataTable();
        //public static int counter = 0;

        public static double hours =0;
        public static int FirstDay = 0; 
        public static int LastDay = 0;
        public static double percentOfDays = 0;
        public static double percentOfHours = 0;
        



        public static int tagDateFirstMonth = 0;
        public static int tagInitialDateFirstMonth = 0;
        public static int tagDateLastMonth = 0;
        public static int Month = 1;
        public static int HourCount = 1;
        


        public static int HeatMapConsider = 0;
        static int xMouseRightClick = 0;
        static int yMouseRightClick = 0;
        string tagID = "";
        string tagName = "";
        string filePathNew = "";
        public static  double Ni, Nmin, Nmax, Vr, Vb, X;


        static int PictureBoxActualWidth;
        static int PictureBoxActualHeight;

        private string printingText;
        private int printingPosition;


        private Font printFontName;
        private Font printFontDate;
        private Font printFontNo;
        private Font printFontTitle;
        private Font printFontText;
        private Font printFontQuiz;
        private Font printFontAns;

        private Font printFontCourse;
        private Font printFontMark;
        private Font printFontMain;


        public static string strSettingup = "";

        public static int gAgeIndex;
        public static int gSexal;
        public static int gPlace;

        public static UInt32 u32CertificateNo;


        private bool bClickDeviceSet = false;
        private bool bClickGetLog = false;
        // Atik Global Variable
        List<Map> gitems = new List<Map>();// item=
        public static string imageFileName = "";
        int flag = 0;

        //ボタンコントロール配列のフィールドを作成 (Create field for button control array)
        private System.Windows.Forms.Button[] testButtons;

        public static int gnBtnNo;

        public static System.Threading.Mutex mymutex;


        public static UInt32 u32DeviceMode;

        //public static string appName = "Stapm2021";
        public static string USBSN = "ChargeControlF"; //"NECUSE";//"UEGG37RW2011";//"NECEAAA001";


        //public static List<contentsInfo> gconINFO = new List<contentsInfo>(); // list for content information

        //public static List<ContentPlayingInfo> gContPLAY = new List<ContentPlayingInfo>();


        public int nIBCCount = 0;

        public int gnDeviceID = 0;

        // static FTDI myFtdiDevice;
        static int FT232L_online = 0;

        public bool bNewUser = false;

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

        public static DataTable HeatMapSorted=new DataTable();
        public static DataTable HeatMapUnSorted=new DataTable();
        public static DataTable HeatMapUnSortedAll = new DataTable();
        
        public static DataTable HeatMapSortedIndividual = new DataTable();
        
        // public static string logpath = "";

        //public static string workfolder = "";

        public  static bool gbSaveLogData = false;

        //public static string ibcfolder = "";


        public static bool gb_FinalSetup = false;

        public static int nRFChnLog = 20; // log file transmitting RF channel

        public static string strSETUPpassword = "";


        //public static List<ContentInfo> gContentINFO = new List<ContentInfo>(); //list for content information

        public static List<AnswerRecord> gUserRecord = new List<AnswerRecord>(); // list for user's answer record



        //public static List<UsedDeviceInfo> gUsedDevice = new List<UsedDeviceInfo>(); // list for using device

        //public static List<VisitorInfo> gVisitorINFO = new List<VisitorInfo>(); // list for visitor name

        public static string szQuizTitle = "";
        public static string szQuizAns = "";


        // GLOBAL DEFINES

        public static string appName = "FlowLine2022";
        public static string logpath = "";
        public static string workfolder = "";
        public static string workfolder2 = "";
        public static string ibcfolder = "";

        public static List<ContentPlayingInfo> gContPLAY = new List<ContentPlayingInfo>();
        public static List<contentsInfo> gconINFO = new List<contentsInfo>(); // list for content information


        // Timer
        private Timer timer;
        private Bitmap heatmap;

        //public AnimatedHeatmap()
        //{
        //    // Initialize the heatmap image with a blank bitmap
        //    heatmap = new Bitmap(Width, Height);
        //    // Initialize the timer and set the interval to 100 ms
        //    timer = new Timer();
        //    timer.Interval = 100;
        //    timer.Tick += Timer_Tick;
        //    // Start the timer
        //    timer.Start();
        //}
        private void Timer_Tick(object sender, EventArgs e)
        {
            if (FromDate != "")
            {
                Thread.Sleep(200);
                map_comboBox1.SelectedIndex = 1;
                map_comboBox1.SelectedIndex = 2;
            }
            // Trigger a redraw of the control
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            // Draw the updated heatmap onto the control
            //e.Graphics.DrawImage(heatmap, 0, 0);
            //if (FromDate != "")
            //{
            //    map_comboBox1.SelectedIndex = 2;
            //}
            base.OnPaint(e);
        }
        public Form1()
        {
            // Timer

            // Initialize the heatmap image with a blank bitmap
            heatmap = new Bitmap(Width, Height);
            // Initialize the timer and set the interval to 100 ms
            timer = new Timer();
            timer.Interval = 500;
            timer.Tick += Timer_Tick;
            // Start the timer
            timer.Start();

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
                    Form1.ibcfolder = sr.ReadLine();
                }
                catch
                {


                }

                sr.Close();

            }
            //existed
            else
            {

                Form1.workfolder = "c:\\" + appName + "\\";
                Form1.logpath = "c:\\" + appName + "\\Log\\";


                {



                    new setupbasic().ShowDialog();



                    if (!Directory.Exists(workfolder)) //create new folder, if no exist
                    {
                        Directory.CreateDirectory(workfolder);
                    }

                    if (!Directory.Exists(logpath)) //ceate new folder, if no exist
                    {
                        Directory.CreateDirectory(logpath);
                    }

                }



                //save the setting
                apppath = System.AppDomain.CurrentDomain.BaseDirectory.ToString();
                config = apppath + "\\" + "atikconfig.txt";
                System.Console.WriteLine("-----" + config);

                if (File.Exists(config))
                {
                    File.Delete(config);
                }

                StreamWriter sw = new StreamWriter(config);

                sw.WriteLine(Form1.workfolder);
                sw.WriteLine(Form1.logpath);
                sw.WriteLine(Form1.ibcfolder);

                sw.Close();


            }
            /////////////////////////////////////////////////
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
                            coninfotemp.SetContentsQuiz(true);
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

            //
            ExcelFile();

        }
        private static DataTable GetDataTabletFromCSVFile(string csv_file_path)
        {
            DataTable csvData = new DataTable();

            try
            {

                using (TextFieldParser csvReader = new TextFieldParser(csv_file_path))
                {
                    csvReader.SetDelimiters(new string[] { "," });
                    csvReader.HasFieldsEnclosedInQuotes = true;
                    string[] colFields = csvReader.ReadFields();
                    foreach (string column in colFields)
                    {
                        DataColumn datecolumn = new DataColumn(column);
                        datecolumn.AllowDBNull = true;
                        csvData.Columns.Add(datecolumn);
                    }

                    while (!csvReader.EndOfData)
                    {
                        string[] fieldData = csvReader.ReadFields();
                        //Making empty value as null
                        for (int i = 0; i < fieldData.Length; i++)
                        {
                            if (fieldData[i] == "")
                            {
                                fieldData[i] = null;
                            }
                        }
                        csvData.Rows.Add(fieldData);
                    }
                }
            }
            catch (Exception ex)
            {
            }
            return csvData;
        }
        void ExcelFile()
        {
            string FilePath = workfolder + "Contentid.CSV";

            DataTable csvData = GetDataTabletFromCSVFile(FilePath);
            TagLocationSet();
        }
        void  TagLocationSet()
        {
            string FilePath = workfolder + "Contentid.CSV";
            DataTable csvData = GetDataTabletFromCSVFile(FilePath);
            string name ="";
            name = "3";
            var targetMap = gitems.Where(o => o.MapFileName == name);
            string mapTagName = "";
            Map map = new Map("", "");
            List<HeatMap> HeatMapList = new List<HeatMap>();
            List<HeatMap> HeatMapListAll = new List<HeatMap>();

            if(FromDate!=null&& FromDate != "")
            {
                tagDateFirstMonth = Convert.ToInt16(Convert.ToDateTime(FromDate).Month);
                tagInitialDateFirstMonth = tagDateFirstMonth;
                tagDateLastMonth = Convert.ToInt16(Convert.ToDateTime(ToDate).Month);
            }

            foreach (var item in targetMap)
            {
                map = new Map(item.MapFileName, item.MapName);
                if (item.taglist != null)
                {
                    taglist = item.taglist;
                    foreach (tagu taguSingle in item.taglist)
                    {
                        for(int i = 0;i < csvData.Rows.Count;i++)
                        {
                            //   CultureInfo culture = new CultureInfo("en-US");
                           // DateTime tempDate2 = DateTime.ParseExact(csvData.Rows[i]["Date"].ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
                            //if (taguSingle.tagId.ToString() == csvData.Rows[i]["Id"].ToString()&& tempDate2 >= Convert.ToDateTime(FromDate).Date && tempDate2 <= Convert.ToDateTime(ToDate).Date)
                            string from = FromDate;
                            string To = ToDate;

                            string strDateTime = csvData.Rows[i]["Date"].ToString() + " " + csvData.Rows[i]["Time"].ToString();
                            DateTime dtDateTime = Convert.ToDateTime(strDateTime);
                            if (taguSingle.tagId.ToString() == csvData.Rows[i]["Id"].ToString() && dtDateTime >= Convert.ToDateTime(FromDate) && dtDateTime <= Convert.ToDateTime(ToDate))
                            {
                                HeatMap htMap = new HeatMap();
                                htMap.tagId= taguSingle.tagId;
                                htMap.tagname = taguSingle.tagname;
                                htMap.pointx = taguSingle.pointx;
                                htMap.pointy = taguSingle.pointy;
                                htMap.tagtype = taguSingle.tagtype;
                                //htMap.tagDate = tempDate2;
                                htMap.tagDate = dtDateTime;                                
                                HeatMapList.Add(htMap);
                            }
                            // Not in The List
                            if (taguSingle.tagId.ToString() == csvData.Rows[i]["Id"].ToString() )
                            {
                                HeatMap htMap = new HeatMap();
                                htMap.tagId = taguSingle.tagId;
                                htMap.tagname = taguSingle.tagname;
                                htMap.pointx = taguSingle.pointx;
                                htMap.pointy = taguSingle.pointy;
                                htMap.tagtype = taguSingle.tagtype;
                                //htMap.tagDate = tempDate2;
                                htMap.tagDate = dtDateTime;
                                HeatMapListAll.Add(htMap);
                            }

                        }
                        
                    }

                    foreach (HeatMap htMap in HeatMapList)
                    {
                        // March Test
                        HeatMap htMap2 = new HeatMap();
                        htMap2 = htMap;
                    }
                    var table = ListToDataTable(HeatMapList);
                    var table2 = ListToDataTable(HeatMapListAll);
                    //HeatMapUnSorted = table;
                    //var query = from row in table.AsEnumerable()
                    //            group row by row.Field<string>("tagId") into sales
                    //            orderby sales.Key
                    //            select new
                    //            {
                    //                Name = sales.Key,
                    //                CountOfClients = sales.Count()
                    //            };

                    var query = from row in table.AsEnumerable()
                                group row by row.Field<string>("tagId") into sales
                                orderby sales.Count()
                                select new
                                {
                                    Name = sales.Key,
                                    CountOfClients = sales.Count().ToString()

                                };
                    
                    var query2 = table.AsEnumerable()  
                                .GroupBy(r => new { tagId = r["tagId"], tagname = r["tagname"], pointx = r["pointx"], pointy = r["pointy"], tagDate = r["tagDate"] })
                                .Select(g =>
                                {
                                    var row = table.NewRow();
                                    //row["PK"] = g.Min(r => r.Field<int>("PK"));
                                    row["tagId"] = g.Key.tagId;
                                    row["tagname"] = g.Key.tagname;
                                    row["pointx"] = g.Key.pointx;
                                    row["pointy"] = g.Key.pointy;
                                    row["tagDate"] = g.Key.tagDate;                                   
                                    return row;
                                })
                                .CopyToDataTable();
                  
                    HeatMapUnSorted = query2;

                    var QueryAll = table2.AsEnumerable()
                               .GroupBy(r => new { tagId = r["tagId"], tagname = r["tagname"], pointx = r["pointx"], pointy = r["pointy"], tagDate = r["tagDate"] })
                               .Select(g =>
                               {
                                   var row = table.NewRow();
                                   //row["PK"] = g.Min(r => r.Field<int>("PK"));
                                   row["tagId"] = g.Key.tagId;
                                   row["tagname"] = g.Key.tagname;
                                   row["pointx"] = g.Key.pointx;
                                   row["pointy"] = g.Key.pointy;
                                   row["tagDate"] = g.Key.tagDate;


                                   return row;

                               })
                               .CopyToDataTable();

                    HeatMapUnSortedAll = QueryAll;

                    // print result

                    HeatMapSorted = CreateDataTable(query);

                    var query3 = HeatMapSorted.AsEnumerable()
                           .GroupBy(r => new { CountIndividual = r["CountOfClients"]})
                           .Select(g =>
                           {
                               var row = HeatMapSorted.NewRow();

                               //row["PK"] = g.Min(r => r.Field<int>("PK"));
                               row["CountOfClients"] = g.Key.CountIndividual;                              

                               return row;

                           })
                           .CopyToDataTable();
                    HeatMapSortedIndividual = query3;

                    foreach (var salesman in query)
                    {
                        var s = salesman;
                        //Console.WriteLine("{0}\t{1}", salesman.Name, salesman.CountOfClients);
                    }

                }
            }
        }

        public static DataTable CreateDataTable(IEnumerable source)
        {
            var table = new DataTable();
            int index = 0;
            var properties = new List<PropertyInfo>();
            foreach (var obj in source)
            {
                if (index == 0)
                {
                    foreach (var property in obj.GetType().GetProperties())
                    {
                        if (Nullable.GetUnderlyingType(property.PropertyType) != null)
                        {
                            continue;
                        }
                        properties.Add(property);
                        table.Columns.Add(new DataColumn(property.Name, property.PropertyType));
                    }
                }
                object[] values = new object[properties.Count];
                for (int i = 0; i < properties.Count; i++)
                {
                    values[i] = properties[i].GetValue(obj);
                }
                table.Rows.Add(values);
                index++;
            }
            return table;
        }
        public DataTable ListToDataTable(List<HeatMap> list)
        {
            //DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            dt.TableName = "ChartTable";
            dt.Columns.Add("tagId", typeof(string));
            dt.Columns.Add("tagname", typeof(string));
            dt.Columns.Add("pointx", typeof(string));
            dt.Columns.Add("pointy", typeof(string));
            dt.Columns.Add("tagtype", typeof(string));
            dt.Columns.Add("tagDate", typeof(DateTime));
            foreach (HeatMap item in list)
            {
                DataRow dtrRS = dt.NewRow();
                //dtrRS["xPositionValue"] = sit.u32CID.ToString("X8");
                //dtrRS["yPositionValue"] = sit.nTotalAccessNum.ToString();
                dtrRS["tagId"] = item.tagId;
                dtrRS["tagname"] = item.tagname;
                dtrRS["pointx"] = item.pointx;
                dtrRS["pointy"]= item.pointy;
                dtrRS["tagtype"]= item.tagtype;
                dtrRS["tagDate"] = item.tagDate;
                dt.Rows.Add(dtrRS);
            }
            //ds.Tables.Add(dt);
            return dt;
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


        public void fep_save_Content_Play_Info(UInt32 u32UserSN)
        {

            if (gContPLAY.Count == 0) return;

            //write a head
            string strTemp = "User SN, Content ID, Date, Time, Play Time, EndMode, IsQuiz, IsCorrect Ans, inputed Ans, UID, RFID";
            //string strIds = "UID, RFID, IdType, DATE, TIME";
            string strIds = "Id, IdType, Date, Time";


            // open the DB text file
            string deviceusedresultPath = Form1.workfolder + "ContentPlayResult.csv";
            string uIdAndRfidPth = Form1.workfolder + "Contentid.csv";

            if (File.Exists(deviceusedresultPath) == true)
            {
                strTemp = "";
            }
            if(File.Exists(uIdAndRfidPth) == true)
            {
                strIds = "";
            }



            System.IO.StreamWriter DURw = new System.IO.StreamWriter(deviceusedresultPath, true,
                       System.Text.Encoding.GetEncoding("Shift_Jis"));
            System.IO.StreamWriter IdsWrite = new System.IO.StreamWriter(uIdAndRfidPth, true,
                       System.Text.Encoding.GetEncoding("Shift_Jis"));

            if (strTemp.Length > 0) DURw.WriteLine(strTemp);
            if (strIds.Length > 0) IdsWrite.WriteLine(strIds);
            //IdsWrite.WriteLine("UID, RFID");


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
                   + cpi.nInputAns.ToString() + ","
                   + cpi.UID.ToString() + ","
                   + cpi.RFID.ToString();


                DURw.WriteLine(strTemp);
               
                string cUID = "", cRFID = "", cDate = "", cTime = "";
                cUID = cpi.UID.ToString();
                cRFID = cpi.RFID.ToString();
                cDate = cpi.dtStartTime.ToString("yyyy-MM-dd");
                cTime = cpi.dtStartTime.ToString("HH:mm:ss");

                if (cUID != "" || cRFID != "")
                {
                    if(cUID != "" && cRFID == "")
                    {
                        strIds = cpi.UID.ToString() + ","
                        + 0 + ","
                        + cDate + ","
                        + cTime + ", ";
                        IdsWrite.WriteLine(strIds);
                    }
                    else if (cUID == "" && cRFID != "")
                    {
                        strIds = cpi.RFID.ToString() + ","
                        + 1 + ","
                        + cDate + ","
                        + cTime + ", ";
                        IdsWrite.WriteLine(strIds);
                    }
                    else
                    {
                        strIds = cpi.UID.ToString() + ","
                        + 0 + ","
                        + cDate + ","
                        + cTime + ", ";
                        IdsWrite.WriteLine(strIds);

                        strIds = cpi.RFID.ToString() + ","
                        + 1 + ","
                        + cDate + ","
                        + cTime + ", ";
                        IdsWrite.WriteLine(strIds);
                    }
                }


                

            }//foreach



            DURw.Close();
            IdsWrite.Close();

        }

        bool fep_Search_AnswerNo(string filepath)
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
                                System.Text.Encoding.GetEncoding("utf-8"));

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

                                while (nTemp < nBranchNum)
                                {
                                    if (int.Parse(row[4 + nTemp]) > 0)
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



        private void Form1_Load(object sender, EventArgs e)
        {
            // July
            this.add_map_button1.Visible = false;
            this.delete_map_button8.Visible = false;
            this.set_map_label1.Visible = false;
            this.map_comboBox1.Visible = false;
            this.Exit_map_edit_button9.Visible = false;

            lblProgBarTagLoadPercent.Visible = false;
            lblFromDate.Visible = false;
            lblToDate.Visible = false;
            label1.Visible = false;
            label2.Visible = false;
            this.progBarTagLoad.Visible = false;



            PictureBoxActualWidth = pictureBox1.Width;
            PictureBoxActualHeight = pictureBox1.Height;
            //string projectPath = System.Windows.Forms.Application.StartupPath;
            //int length = projectPath.Length - 10;
            //String projectPathFull = projectPath.Substring(0, length);
            //workfolder = projectPathFull + "\\Image\\";



            string logDirPath = Form1.logpath;
            string[] files = System.IO.Directory.GetFiles(
                     logDirPath, "*", System.IO.SearchOption.AllDirectories);



            //FileStream fs = new FileStream(files[nIndex], FileMode.Open, FileAccess.Read);

            int nIndex = files.Length;

            while (nIndex > 0)
            {
                nIndex--;
                gContPLAY.Clear();

                ScanLogFile(files[nIndex]);

                fep_save_Content_Play_Info(00000);
                
            }
            pannel_map_loader(1);
            //string fileName = workfolder + "obj";
            //List<Map> obj2 = (List<Map>)LoadFromBinaryFile(fileName);
            //foreach (Map obj in obj2)
            //{
            //    map_comboBox1.Items.Add(obj.MapFileName);
            //}



        }
        public void pannel_map_loader(Int32 combo_index)
        {
            //string file_name;
            //combo_index = combo_index + 1;
            //file_name = Application.StartupPath + "\\Resources\\maps" + combo_index.ToString() + ".jpg";
            //pictureBox1.Image= Image.FromFile(file_name);
            //this.panel1.BackgroundImageLayout = ImageLayout.Stretch;
        }
        private void ProgressBarTagLoad(double value)
        {
            if (progBarTagLoad.Value < 100 && value<=100)
            {
                progBarTagLoad.Value =Convert.ToInt32(value);
                lblProgBarTagLoadPercent.Text = progBarTagLoad.Value.ToString() + "%";
            }
            else
            {
                progBarTagLoad.Value = 0;
            }
        }
        private void map_comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //string fileName = workfolder + "Image\\obj";
            //if (File.Exists(fileName))
            //{
            //    gitems = null;
            //    gitems = (List<Map>)LoadFromBinaryFile(fileName);
            //}
            //if (map_comboBox1.SelectedIndex != -1)
            if (map_comboBox1.SelectedValue != null)
            {
                if(HeatMapConsider==1)
                {
                    TagLocationSet();
                }
                HeatMapConsider = 0;


                if (map_comboBox1.SelectedValue.ToString() != "infraredCommApp.Map" && map_comboBox1.SelectedValue.ToString() != "")
                {
                    // January  
                    // taglist.Clear();
                    //taglist2.Clear();

                    string name = map_comboBox1.SelectedValue.ToString();
                    int width = pictureBox1.Width;
                    int height = pictureBox1.Height;
                    pictureBox1.Image = Image.FromFile(workfolder + "Image\\" + name + ".jpeg", true);
                    var filePath = workfolder + "Image\\" + name + ".jpeg";
                    Bitmap bmap = new Bitmap(filePath);
                    if (Width < pictureBox1.Image.Width || height < pictureBox1.Image.Height)
                    {
                        this.pictureBox1.Size = new System.Drawing.Size(PictureBoxActualWidth, PictureBoxActualHeight);
                        pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                    }
                    else
                    {
                        pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
                        fillPictureBox(pictureBox1, bmap, width, height);
                    }
                    // New code 15 December
                    lblCboImageName.Text = " MapName : " + map_comboBox1.Text + " MapFileName : " + map_comboBox1.SelectedValue.ToString();

                    Bitmap OriginalBitmap = new Bitmap(filePath);

                    float scale = Math.Min((float)width / (float)OriginalBitmap.Width, (float)height / (float)OriginalBitmap.Height);
                    int widthToScale = (int)(OriginalBitmap.Width * scale);
                    int heightToScale = (int)(OriginalBitmap.Height * scale);
                    float x1 = (width - widthToScale) / 2;
                    var resized = new Bitmap(pictureBox1.Width, pictureBox1.Height);
                    var g = Graphics.FromImage(resized);
                    if (width > widthToScale)
                    {
                        g.DrawImage(OriginalBitmap, x1, 0, widthToScale, height);
                    }
                    else
                    {
                        g.DrawImage(OriginalBitmap, 0, 0, widthToScale, height);
                    }
                    g.Dispose();
                    pictureBox1.Image = resized;

                    //var resized = new Bitmap(pictureBox1.Width, pictureBox1.Height);
                    Bitmap arrowBitmap = new Bitmap(workfolder + "Resources\\2.png");
                    Bitmap copy = new Bitmap(resized);
                    Graphics g2 = Graphics.FromImage(copy);
                    Bitmap arrowBitmap1 = new Bitmap(workfolder + "Resources\\1.png");
                    Graphics g1 = Graphics.FromImage(copy);
                    var targetMap = gitems.Where(o => o.MapFileName == name);
                    Map map = new Map("", "");




                    string mapTagName = "";
                    foreach (var item in targetMap)
                    {
                        map = new Map(item.MapFileName, item.MapName);
                        if (item.taglist != null)
                        {
                            taglist = item.taglist;
                            foreach (tagu taguSingle in item.taglist)
                            {
                                if (taguSingle.tagtype == 1)
                                {
                                    //g1.DrawImage(arrowBitmap1, new Point(taguSingle.pointx, taguSingle.pointy));
                                    g1.DrawImage(arrowBitmap1, new Point(taguSingle.pointx +Convert.ToInt32((Convert.ToDouble( taguSingle.pointx)*0.365)), taguSingle.pointy+ Convert.ToInt32((Convert.ToDouble(taguSingle.pointy) * 0.30))));
                                }
                                else if (taguSingle.tagtype == 2)
                                {
                                    //g2.DrawImage(arrowBitmap, new Point(taguSingle.pointx, taguSingle.pointy));
                                    g2.DrawImage(arrowBitmap, new Point(taguSingle.pointx + Convert.ToInt32((Convert.ToDouble(taguSingle.pointx) * 0.365)), taguSingle.pointy + Convert.ToInt32((Convert.ToDouble(taguSingle.pointy) * 0.30))));
                                }
                            }

                            foreach (tagu taguSingle in item.taglist)
                            {
                                // January Test                       
                                mapTagName = mapTagName + " " + taguSingle.tagname;
                                lblTagNameTest.Text = mapTagName;
                            }

                        }


                        //if (item.taglist1 != null)
                        //{

                        //    taglist= item.taglist1;
                        //    foreach (tagu taguSingle in item.taglist1)
                        //    {
                        //        // January Test                       
                        //       // lblTagNameTest.Text = mapTagName + " " + taguSingle.tagname;

                        //        g1.DrawImage(arrowBitmap1, new Point(taguSingle.pointx, taguSingle.pointy));
                        //    }
                        //    foreach (tagu taguSingle in item.taglist1)
                        //    {
                        //        // January Test                       
                        //        mapTagName = mapTagName + " " + taguSingle.tagname;
                        //        lblTagNameTest.Text = mapTagName;
                        //    }
                        //}
                    }
                    //pictureBox1.Image = copy;
                    //htMap.pointx = taguSingle.pointx;
                    //htMap.pointy = taguSingle.pointy;
                    // Heat Map

                    // COlor
                    System.Drawing.Color c = System.Drawing.ColorTranslator.FromHtml("#F5F7F8");
                    String strHtmlColor = System.Drawing.ColorTranslator.ToHtml(c);

                    //string[] BlueColor = { "#ccd9ff", "#b3c6ff", "#99b3ff", "#809fff", "#668cff", "#4d79ff", "#3366ff", "#1a53ff", "#0040ff", "#0039e6" };
                    //string[] RedColor = { "#ffcccc", "#ffb3b3", "#ff9999", "#ff8080", "#ff8080", "#ff6666", "#3366ff", "#ff4d4d", "#ff3333", "#ff1a1a" };


                    Graphics gs = Graphics.FromImage(copy);
                    int position = 820;
                    int positionYellow = 820;
                    int div = 0;


                    DataTable dtTagNameAllOwn = new DataTable();
                    dtTagNameAllOwn.Columns.Add("TagNameAll", typeof(String));
                    //double Ni, Nmin, Nmax, Vr, Vb, X;
                    int divider = 0;
                    if (name == "5")
                    {
                        if (Type=="Day")
                        {
                            lblFromDate.Text =Convert.ToDateTime( FromDate).Date.ToString("dd/MM/yyyy");
                            lblToDate.Text = Convert.ToDateTime(ToDate).Date.ToString("dd/MM/yyyy");
                        }
                        else
                        {
                            lblFromDate.Text = FromDate;
                            lblToDate.Text = ToDate;
                        }
                        

                        int colorCountBlue = 9;
                        int colorCountRGB = 0;
                        string Count = "";

                        for (int i = 0; i < HeatMapSorted.Rows.Count; i++)
                        {
                            
                            for (int j = 0; j < HeatMapUnSorted.Rows.Count; j++)
                            {
                               
                                //double Ni, Nmin, Nmax, Vr, Vb,X;
                                for (int m = 0; m < HeatMapSortedIndividual.Rows.Count ; m++)
                                {
                                    int dividerPosition;
                                    dividerPosition = 800 / HeatMapSortedIndividual.Rows.Count;

                                    Nmin = Convert.ToInt32(HeatMapSortedIndividual.Rows[0]["CountOfClients"].ToString());
                                    Nmax = Convert.ToInt32(HeatMapSortedIndividual.Rows[HeatMapSortedIndividual.Rows.Count-1]["CountOfClients"].ToString());
                                    if(Nmax == Nmin)
                                    {
                                        Nmax = Nmax + 1;
                                    }
                                    Ni=(( Convert.ToInt32(HeatMapSortedIndividual.Rows[m]["CountOfClients"].ToString())- Nmin)/(Nmax- Nmin))*100;
                                    //X = Ni;
                                    Vr = (Ni * 255) / 100;
                                    Vb =((100-Ni) *255)/ 100;
                                    if(Vr>255)
                                    {
                                        Vr = 255;
                                    }
                                    else if(Vr<0)
                                    {
                                        Vr = 0;
                                    }
                                    if (Vb > 255)
                                    {
                                        Vb = 255;
                                    }
                                    else if (Vb < 0)
                                    {
                                        Vb = 0;
                                    }
                                    if (HeatMapSorted.Rows[i]["Name"].ToString() == HeatMapUnSorted.Rows[j]["tagId"].ToString() && HeatMapSorted.Rows[i]["CountOfClients"].ToString() == HeatMapSortedIndividual.Rows[m]["CountOfClients"].ToString())
                                    {
                                        int u = Convert.ToInt16(Convert.ToDateTime(HeatMapUnSorted.Rows[j]["tagDate"].ToString()).Month);
                                        lblMonth.Text = tagDateFirstMonth.ToString();
                                        //lblDate.Text = HeatMapUnSorted.Rows[j]["tagDate"].ToString();
                                        for (int htm = tagInitialDateFirstMonth; htm <= tagDateFirstMonth; htm++)
                                        {
                                            //Days

                                            if (Type == "Day")
                                            {
                                                for (int htn = FirstDay; htn <= Month; htn++)
                                                {
                                                    lblDate.Text = htn.ToString() + "/" + htm.ToString() + "/" + "2023";
                                                    int day = Convert.ToInt16(Convert.ToDateTime(HeatMapUnSorted.Rows[j]["tagDate"].ToString()).Day);
                                                    if (htm == Convert.ToInt16(Convert.ToDateTime(HeatMapUnSorted.Rows[j]["tagDate"].ToString()).Month) && htn == day)
                                                    {

                                                        if (colorCountBlue < 0)
                                                        {
                                                            colorCountBlue = 0;
                                                        }
                                                        int fg = 0;// Lagbe
                                                        for (int dti = 0; dti < dtTagNameAll.Rows.Count; dti++)
                                                        {
                                                            fg = 0;
                                                            string tgn1 = HeatMapUnSorted.Rows[j]["tagname"].ToString();
                                                            string tgn2 = dtTagNameAll.Rows[dti]["TagNameAll"].ToString();
                                                            if (HeatMapUnSorted.Rows[j]["tagname"].ToString() == dtTagNameAll.Rows[dti]["TagNameAll"].ToString())
                                                            {
                                                                Color c1 = Color.FromArgb(200, Convert.ToInt32(Vr), 0, Convert.ToInt32(Vb));
                                                                //gs.FillEllipse(new SolidBrush(c1), Convert.ToUInt32(HeatMapUnSorted.Rows[j]["pointx"].ToString()), Convert.ToUInt32(HeatMapUnSorted.Rows[j]["pointy"].ToString()), 30, 30);
                                                                int RatioX = Convert.ToInt32((Convert.ToDouble(Convert.ToUInt32(HeatMapUnSorted.Rows[j]["pointx"].ToString())) * 0.365));
                                                                int RatioY = Convert.ToInt32((Convert.ToDouble(Convert.ToUInt32(HeatMapUnSorted.Rows[j]["pointy"].ToString())) * 0.30));
                                                                gs.FillEllipse(new SolidBrush(c1), Convert.ToUInt32(HeatMapUnSorted.Rows[j]["pointx"].ToString())+ RatioX, Convert.ToUInt32(HeatMapUnSorted.Rows[j]["pointy"].ToString())+ RatioY, 30, 30);
                                                                //Convert.ToInt32((Convert.ToDouble(taguSingle.pointx) * 0.365))
                                                                string id = HeatMapSorted.Rows[i]["Name"].ToString();
                                                                string x = HeatMapUnSorted.Rows[j]["pointx"].ToString();
                                                                string y = HeatMapUnSorted.Rows[j]["pointy"].ToString();
                                                                fg = 1;

                                                                DataRow dRow = dtTagNameAllOwn.NewRow();
                                                                string k = tgn1;
                                                                dRow["TagNameAll"] = tgn1;
                                                                //counter= counter+1;
                                                                dtTagNameAllOwn.Rows.Add(dRow);
                                                            }
                                                           
                                                        }
                                                        //if(fg==0)
                                                        //{
                                                        //    Color c2 = Color.FromArgb(255, 255, 0);
                                                        //    gs.FillEllipse(new SolidBrush(c2), Convert.ToUInt32(HeatMapUnSorted.Rows[j]["pointx"].ToString()), Convert.ToUInt32(HeatMapUnSorted.Rows[j]["pointy"].ToString()), 30, 30);

                                                        //    string id = HeatMapSorted.Rows[i]["Name"].ToString();
                                                        //    string x = HeatMapUnSorted.Rows[j]["pointx"].ToString();
                                                        //    string y = HeatMapUnSorted.Rows[j]["pointy"].ToString();

                                                        //}
                                                    }
                                                }
                                            }
                                            else
                                            {
                                                for (int htn = FirstDay; htn <= Month; htn++)
                                                {
                                                    // Hour
                                                    for (int hto = 1; hto <= HourCount; hto++)
                                                    {
                                                        //lblDate.Text = htn.ToString() + "/" + htm.ToString() + "/" + "2023";
                                                        string time= Convert.ToDateTime(HeatMapUnSorted.Rows[j]["tagDate"].ToString()).TimeOfDay.ToString();        
                                                        //lblDate.Text = htn.ToString() + "/" + htm.ToString() + "/" + "2023 "+ time;
                                                        int day = Convert.ToInt16(Convert.ToDateTime(HeatMapUnSorted.Rows[j]["tagDate"].ToString()).Day);
                                                        int hour= Convert.ToInt16(Convert.ToDateTime(HeatMapUnSorted.Rows[j]["tagDate"].ToString()).Hour);
                                                        lblDate.Text = htn.ToString() + "/" + htm.ToString() + "/" + "2023 " + hto.ToString()+":00:00";

                                                        if (htm == Convert.ToInt16(Convert.ToDateTime(HeatMapUnSorted.Rows[j]["tagDate"].ToString()).Month) && htn == day&& hto == hour  )
                                                        {

                                                            if (colorCountBlue < 0)
                                                            {
                                                                colorCountBlue = 0;
                                                            }
                                                            for (int dti = 0; dti < dtTagNameAll.Rows.Count; dti++)
                                                            {
                                                                
                                                                string tgn1 = HeatMapUnSorted.Rows[j]["tagname"].ToString();
                                                                string tgn2 = dtTagNameAll.Rows[dti]["TagNameAll"].ToString();
                                                                if (HeatMapUnSorted.Rows[j]["tagname"].ToString() == dtTagNameAll.Rows[dti]["TagNameAll"].ToString())
                                                                {
                                                                    Color c1 = Color.FromArgb(200, Convert.ToInt32(Vr), 0, Convert.ToInt32(Vb));
                                                                    gs.FillEllipse(new SolidBrush(c1), Convert.ToUInt32(HeatMapUnSorted.Rows[j]["pointx"].ToString()), Convert.ToUInt32(HeatMapUnSorted.Rows[j]["pointy"].ToString()), 30, 30);

                                                                    string id = HeatMapSorted.Rows[i]["Name"].ToString();
                                                                    string x = HeatMapUnSorted.Rows[j]["pointx"].ToString();
                                                                    string y = HeatMapUnSorted.Rows[j]["pointy"].ToString();

                                                                    DataRow dRow = dtTagNameAllOwn.NewRow();
                                                                    string k = tgn1;
                                                                    dRow["TagNameAll"] = tgn1;
                                                                    //counter= counter+1;
                                                                    dtTagNameAllOwn.Rows.Add(dRow);
                                                                }

                                                            }


                                                            //Color c1 = Color.FromArgb(200, Convert.ToInt32(Vr), 0, Convert.ToInt32(Vb));
                                                            //gs.FillEllipse(new SolidBrush(c1), Convert.ToUInt32(HeatMapUnSorted.Rows[j]["pointx"].ToString()), Convert.ToUInt32(HeatMapUnSorted.Rows[j]["pointy"].ToString()), 30, 30);

                                                            //string id = HeatMapSorted.Rows[i]["Name"].ToString();
                                                            //string x = HeatMapUnSorted.Rows[j]["pointx"].ToString();
                                                            //string y = HeatMapUnSorted.Rows[j]["pointy"].ToString();
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                        
                                        
                                        string htIv = HeatMapSortedIndividual.Rows[m]["CountOfClients"].ToString();
                                        divider = 800 / HeatMapSortedIndividual.Rows.Count;
                                       
                                        if (htIv != Count.ToString())
                                        {
                                            colorCountRGB++;
                                            div = div + 1;
                                            using (Font myFont = new Font("Arial", 10))
                                            {
                                                Color c2 = Color.FromArgb(200, Convert.ToInt32(Vr), 0, Convert.ToInt32(Vb));
                                                //position = position + divider;
                                                position = position - divider;
                                                gs.DrawString(div.ToString(), myFont, Brushes.Green, new Point(1530, position + dividerPosition / 2));
                                                //gs.FillRectangle(new SolidBrush(c2), 1200, position, 30, dividerPosition);
                                                gs.FillRectangle(new SolidBrush(c2), 1550, position, 30, dividerPosition);

                                                Color c3 = Color.FromArgb(255, 255, 0);
                                                gs.DrawString("0", myFont, Brushes.Green, new Point(1530, positionYellow + dividerPosition / 4));
                                                //gs.FillRectangle(new SolidBrush(c3), 1200, positionYellow, 30, dividerPosition);
                                                gs.FillRectangle(new SolidBrush(c3), 1550, positionYellow, 30, dividerPosition);
                                            }
                                        }

                                        if (HeatMapSorted.Rows[i]["CountOfClients"].ToString() != Count.ToString())
                                        {
                                            colorCountBlue--;
                                            Count = HeatMapSorted.Rows[i]["CountOfClients"].ToString();
                                        }
                                    }
                            }
                                
                            }
                            Count = HeatMapSorted.Rows[i]["CountOfClients"].ToString();
                            
                            
                        }

                        // Other Color
                        DataTable dtTagNameAllExtra = new DataTable();
                        dtTagNameAllExtra.Columns.Add("TagNameAll", typeof(String));

                        for (int i = 0; i < dtTagNameAll.Rows.Count; i++)
                        {
                            int flag = 0;
                            string flName = "";
                            for (int j = 0; j < dtTagNameAllOwn.Rows.Count; j++)
                            {
                                string tgn1 = dtTagNameAll.Rows[i]["TagNameAll"].ToString();
                                string tgn2 = dtTagNameAllOwn.Rows[j]["TagNameAll"].ToString();
                                
                                if (tgn1==tgn2)
                                {
                                    flag = 1;
                                    
                                }
                                flName = tgn1;
                            }
                            if(flag==0)
                            {
                                DataRow dRow = dtTagNameAllExtra.NewRow();
                                string k = flName;
                                dRow["TagNameAll"] = flName;
                                dtTagNameAllExtra.Rows.Add(dRow);
                            }
                        }

                        for (int i = 0; i < dtTagNameAllExtra.Rows.Count; i++)
                        {

                            for (int j = 0; j < HeatMapUnSortedAll.Rows.Count; j++)
                            {
                                if (HeatMapUnSortedAll.Rows[j]["tagname"].ToString() == dtTagNameAllExtra.Rows[i]["TagNameAll"].ToString())
                                {
                                    //Color c1 = Color.FromArgb(200, Convert.ToInt32(Vr), 0, Convert.ToInt32(Vb));
                                    Color c1 = Color.FromArgb(255, 255, 0);
                                    //gs.FillEllipse(new SolidBrush(c1), Convert.ToUInt32(HeatMapUnSortedAll.Rows[j]["pointx"].ToString()), Convert.ToUInt32(HeatMapUnSortedAll.Rows[j]["pointy"].ToString()), 30, 30);
                                    int RatioX = Convert.ToInt32((Convert.ToDouble(Convert.ToUInt32(HeatMapUnSortedAll.Rows[j]["pointx"].ToString())) * 0.365));
                                    int RatioY = Convert.ToInt32((Convert.ToDouble(Convert.ToUInt32(HeatMapUnSortedAll.Rows[j]["pointy"].ToString())) * 0.30));
                                    //gs.FillEllipse(new SolidBrush(c1), Convert.ToUInt32(HeatMapUnSorted.Rows[j]["pointx"].ToString()) + RatioX, Convert.ToUInt32(HeatMapUnSorted.Rows[j]["pointy"].ToString()) + RatioY, 30, 30);

                                    gs.FillEllipse(new SolidBrush(c1), Convert.ToUInt32(HeatMapUnSortedAll.Rows[j]["pointx"].ToString()) + RatioX, Convert.ToUInt32(HeatMapUnSortedAll.Rows[j]["pointy"].ToString()) + RatioY, 30, 30);

                                }
                            }
                        }
                        // Other color end

                        if (tagDateLastMonth == tagDateFirstMonth)
                        {
                            if (Month <LastDay)
                            {
                                Month++;
                                if (Type == "Day")
                                {
                                    percentOfDays++;
                                    double totaldays = (Convert.ToDateTime(ToDate) - Convert.ToDateTime(FromDate)).TotalDays;
                                    double percent = (percentOfDays / totaldays) * 100;
                                    ProgressBarTagLoad(percent);
                                }
                            }
                            else
                            {
                                Month = 1;
                                if (tagDateFirstMonth < tagDateLastMonth)
                                {
                                    tagDateFirstMonth++;
                                }
                                else
                                {
                                    tagDateFirstMonth = Convert.ToInt16(Convert.ToDateTime(FromDate).Month);
                                    percentOfDays = 0;
                                }
                                if (Type == "Day")
                                {
                                    percentOfDays++;
                                    double totaldays = (Convert.ToDateTime(ToDate) - Convert.ToDateTime(FromDate)).TotalDays;
                                    double percent = (percentOfDays / totaldays) * 100;
                                    ProgressBarTagLoad(percent);
                                }

                            }
                        }
                        else
                        {

                            if (Month < 31)
                            {
                                Month++;
                                if (Type == "Day")
                                {
                                    percentOfDays++;
                                    double totaldays = (Convert.ToDateTime(ToDate) - Convert.ToDateTime(FromDate)).TotalDays;
                                    double percent = (percentOfDays / totaldays) * 100;
                                    ProgressBarTagLoad(percent);
                                }
                            }
                            else
                            {
                                Month = 1;
                                if (tagDateFirstMonth < tagDateLastMonth)
                                {
                                    tagDateFirstMonth++;
                                }
                                else
                                {
                                    tagDateFirstMonth = Convert.ToInt16(Convert.ToDateTime(FromDate).Month);
                                    //percentOfDays = 0;
                                }
                                if (Type == "Day")
                                {
                                    percentOfDays++;
                                    double totaldays = (Convert.ToDateTime(ToDate) - Convert.ToDateTime(FromDate)).TotalDays;
                                    double percent = (percentOfDays / totaldays) * 100;
                                    ProgressBarTagLoad(percent);
                                }
                            }
                        }
                        if (Type == "Hour")
                        {
                            if (HourCount < 24)
                            {
                                HourCount++;

                                double TotalHours = (Convert.ToDateTime(ToDate) - Convert.ToDateTime(FromDate)).TotalHours;
                                if (percentOfHours < TotalHours)
                                {
                                    percentOfHours++;
                                    //double TotalHours = (Convert.ToDateTime(ToDate) - Convert.ToDateTime(FromDate)).TotalHours;
                                    double percent = (percentOfHours / TotalHours) * 100;
                                    ProgressBarTagLoad(percent);
                                }
                                else
                                {
                                    percentOfHours = 0;
                                }

                            }
                            else
                            {
                                HourCount = 1;
                            }
                        }



                    }
                    pictureBox1.Image = copy;
                    
                }
                else
                {
                    pictureBox1.Image = null;
                }
                // panel1.Size = new Size(500, 400);            
                // panel1.Location = new Point(500, 31);
            }
            
        }

        // Timer



        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            //this.BtnClick(null, null);
            Thread.Sleep(3000);
            if(FromDate!="")
            {
                map_comboBox1.SelectedIndex = 2;
            }
           
        }
        // Haider
        static public void fillPictureBox(PictureBox pbox, Bitmap bmp, float width, float height)
        {
            float scale = Math.Min((float)width / (float)bmp.Width, (float)height / (float)bmp.Height);
            int widthToScale = (int)(bmp.Width * scale);
            int heightToScale = (int)(bmp.Height * scale);
            float x = (width - widthToScale) / 2;
            var resized = new Bitmap(pbox.Width, pbox.Height);
            var g = Graphics.FromImage(resized);
            if (width > widthToScale)
            {
                g.DrawImage(bmp, x, 0, widthToScale, height);

            }
            else
            {
                g.DrawImage(bmp, 0, 0, widthToScale, height);
            }
            g.Dispose();
            pbox.Image = resized;

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
            sw.WriteLine(Form1.ibcfolder);
            sw.Close();
            this.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {

            setupbasic fsetup = new setupbasic();

            if (fsetup.ShowDialog() == DialogResult.OK)            
            {



            }


        }
        private void ExportClicked(object sender, EventArgs e)
        {
            Common.ExportToCsv(ExportDataDictionary);
        }

        private void buttonQuizTotal_Click(object sender, EventArgs e)
        {
            //quizeAnsResult f2 = new quizeAnsResult();
            //f2.Show();
            txtAnalyzedData.SendToBack();
            chartWithData.SendToBack();
            pictureBox1.SendToBack();
            //List<StoryInformation> gStoryINFOALl = new List<StoryInformation>();
            
            quizeAnsResult f2 = new quizeAnsResult();
            f2.ShowDialog();
            ControlGroupBox.Visible = true;
            //txtAnalyzedData.Text = f2.AnalyzedData;
            //AnalyzedData = f2.AnalyzedData;
            //QuizId = f2.rdoQuizId;
            //Accurate = f2.rdoAccurate;
            //DictionaryByID = f2.dictionaryByID;
            //DictionaryByAccurate = f2.dictionaryByAccurate;
            //DictionaryByAll = f2.dictionaryByALL;
            TitleDictionary = f2.titleDictionary;
            BarGrapggStoryINFOALl = quizeAnsResult.gQuizAnsINFO;
            dtBarGrapggStoryINFOALl = quizeAnsResult.dtQuizeTitle;
            resultListView.Visible = true;
            QuizAnsInformationResult = f2.quizAnsInformationResultList;
            PopulateList(resultListView, f2.quizAnsInformationResultList);

        }

        private void PopulateList(System.Windows.Forms.ListView listViewQuiz, List<QuizAnsInformation> quizList)
        {
            ExportDataDictionary.Clear();
            listViewQuiz.Items.Clear();
            listViewQuiz.Columns.Clear();

            listViewQuiz.View = View.Details;
            listViewQuiz.HeaderStyle = ColumnHeaderStyle.Nonclickable;

            listViewQuiz.Columns.Add("コンテンツID", 100);
            listViewQuiz.Columns.Add("Title", 100);
            listViewQuiz.Columns.Add("正解率", 100);
            listViewQuiz.Columns.Add("利用回数", 100);
            
            foreach (var quizInfo in quizList)
            {
                ListViewItem item = new ListViewItem(quizInfo.u32CID.ToString("X8"));
                var title = "N/A";
                if (TitleDictionary.ContainsKey(quizInfo.u32CID.ToString()))
                {
                    title = TitleDictionary[quizInfo.u32CID.ToString()];
                }
                item.SubItems.Add(title);
                item.SubItems.Add(string.Format("{0, 3}", quizInfo.nCorrectRatio) + "%  ");
                item.SubItems.Add(quizInfo.nTotalAccessNum.ToString());
                listViewQuiz.Items.Add(item);
                ExportDataDictionary.Add(GetDictinaryValue(quizInfo, title));
            }
        }

        private Dictionary<string, string> GetDictinaryValue(QuizAnsInformation qai, string quizTitle)
        {
            return new Dictionary<string, string>
                                {
                                    { "コンテンツID", "-" + qai.u32CID.ToString("X8") },
                                    { "Title", quizTitle },
                                    { "正解率", string.Format("{0, 3}", qai.nCorrectRatio) + "%  " },
                                    { "利用回数", qai.nTotalAccessNum.ToString() }
                                };
        }
        private void buttonGuideTotal_Click(object sender, EventArgs e)
        {
            
            chartWithData.BringToFront();
            pictureBox1.SendToBack();

             
            List<StoryInformation> gStoryINFOALl = new List<StoryInformation>();

            ExpRankResult Err = new ExpRankResult();
            Err.ShowDialog();
            gStoryINFOALl = ExpRankResult.gStoryINFO;
            if (gStoryINFOALl.Count!= 0)
            {
                DataSet ds = ToDataSet(gStoryINFOALl);
                
                chartWithData.DataSource = ds;
                //var name = chartWithData.Series;
                chartWithData.Series["Series1"].XValueMember = "xPositionValue";
                chartWithData.Series["Series1"].YValueMembers = "yPositionValue";
                chartWithData.DataBind();
                chartWithData.Series["Series1"].ChartType = SeriesChartType.Column;
                //chartWithData.Titles.Add("Museum Chart");
                if(chartWithData.Titles.Count==0)
                {
                    chartWithData.Titles.Add("Museum Chart");
                }
                //chartWithData.Legends.All;
                //chartWithData.Series["Series1"].Points.DataBindXY(ds, "DATE", ds, "VALUE");

                //chartWithData.Series["Series1"].Legend = "xPositionValue";
                //chartWithData.Series["Series1"].Legend = "yPositionValue";
                chartWithData.Series["Series1"].IsVisibleInLegend = true;


                //chartWithData.Legends.Add(new Legend("Series1"));

                //// Set Docking of the Legend chart to the Default Chart Area.
                //chartWithData.Legends["Series1"].DockedToChartArea = "Default";

                //// Assign the legend to Series1.
                //chartWithData.Series["Series1"].Legend = "Legend2";
                //chartWithData.Series["Series1"].IsVisibleInLegend = true;
                chartWithData.Series["Series1"].MarkerSize = 10;
            }
        }
        
        public static DataSet ToDataSet(List<QuizAnsInformation> list)
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            dt.TableName = "ChartTable";
            dt.Columns.Add("xPositionValue", typeof(string));
            dt.Columns.Add("yPositionValue", typeof(string));
            foreach (QuizAnsInformation sit in list)
            {
                for (int i = 0; i < dtBarGrapggStoryINFOALl.Rows.Count; i++)
                {
                    if (dtBarGrapggStoryINFOALl.Rows[i]["u32ContentID"].ToString() == sit.u32CID.ToString())
                    {
                        DataRow dtrRS = dt.NewRow();
                        dtrRS["xPositionValue"] = sit.u32CID.ToString("X8");
                        //dtrRS["yPositionValue"] = sit.nTotalAccessNum.ToString();
                        dtrRS["yPositionValue"] = sit.nTotalAccessNum.ToString();
                        dt.Rows.Add(dtrRS);
                    }
                }
            }
            ds.Tables.Add(dt);
            return ds;
        }
        public static DataSet ToDataSet(List<StoryInformation> list)
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            dt.TableName = "ChartTable";
            dt.Columns.Add("xPositionValue", typeof(string));
            dt.Columns.Add("yPositionValue", typeof(string));
            foreach (StoryInformation sit in list)
            {
                DataRow dtrRS = dt.NewRow();
                dtrRS["xPositionValue"] = sit.u32CID.ToString("X8");
                dtrRS["yPositionValue"] = sit.nTotalAccessNum.ToString();
                dt.Rows.Add(dtrRS);
            }
            ds.Tables.Add(dt);
            return ds;
        }
        
        private void buttonFLowLineAnalysis_Click(object sender, EventArgs e)
        {
            HeatMapConsider = 1;
            //DDia f2 = new DDia();
            //f2.Show();
            HeatMapGraph f2 = new HeatMapGraph();
            f2.ShowDialog();

            //f2.Show();
            //FromDate = HeatMapGraph.FromDate.Trim() + " 00:00:01";
            //ToDate = HeatMapGraph.ToDate.Trim() + " 23:59:59";

            FromDate = HeatMapGraph.FromDate.Trim();
            ToDate = HeatMapGraph.ToDate.Trim();
            Type = HeatMapGraph.Type.Trim();
            int counter = HeatMapGraph.counter;
            //DataTable dtTagNameAll = new DataTable();
            //TagNameAll[counter] = HeatMapGraph.TagNameAll[counter];
            //DataTable dtTagNameAll = new DataTable();
            dtTagNameAll = HeatMapGraph.dtTagNameAll;           

            FirstDay = Convert.ToInt16(Convert.ToDateTime(FromDate).Day);
            LastDay = Convert.ToInt16(Convert.ToDateTime(ToDate).Day);

            TimeSpan diff = Convert.ToDateTime(ToDate) -Convert.ToDateTime( FromDate);
            double hours = diff.TotalHours;

            button＿MapEdit_Click( sender, e);
            map_comboBox1.SelectedIndex= 2;
        }

        private void button＿MapEdit_Click(object sender, EventArgs e)
        {
            // July
            this.add_map_button1.Visible = true;
            this.delete_map_button8.Visible = true;
            this.set_map_label1.Visible = true;
            this.map_comboBox1.Visible = true;
            this.Exit_map_edit_button9.Visible = true;

            lblProgBarTagLoadPercent.Visible = true;
            lblFromDate.Visible = true;
            lblToDate.Visible = true;
            label1.Visible = true;
            label2.Visible = true;
            this.progBarTagLoad.Visible = true;
            

            pictureBox1.BringToFront();
            chartWithData.SendToBack();

            string fileName = workfolder + "Image\\obj";
            if (File.Exists(fileName))
            {
                //List<Map> gitem = (List<Map>)LoadFromBinaryFile(fileName); // load 
                gitems = null;
                gitems = (List<Map>)LoadFromBinaryFile(fileName); // load                 
                map_comboBox1.DataSource = gitems;               
                map_comboBox1.DisplayMember = "MapName";
                map_comboBox1.ValueMember = "MapFileName";
                // MapName='Map-1'
                // MapFileName='Map-1' 
                // End
                if(gitems.Count>0)
                {
                    map_comboBox1.SelectedIndex = -1;
                    map_comboBox1.SelectedIndex = 0;
                    lblCboImageName.Text = " MapName : " + map_comboBox1.Text + " MapFileName : " + map_comboBox1.SelectedValue.ToString();

                }

                // lblCboImageName.Text = map_comboBox1.Text;

            }


            this.map_button.Enabled = false;
            //this.edit_button7.Enabled = true;
            this.add_map_button1.Enabled = true;
            this.delete_map_button8.Enabled = true;
            this.set_map_label1.Enabled = true;
            this.map_comboBox1.Enabled = true;
            this.Exit_map_edit_button9.Enabled = true;

           // map_comboBox1.SelectedIndex = 0;

            //declare list<map>
            // load and initialize  list map here
            // initialize combox based on list map
            //string fileName = workfolder + "obj";
            //string fileNameData = workfolder + "obj";
            //List<Map> items = new List<Map>();
            //List<Map> obj2 = (List<Map>)LoadFromBinaryFile(fileNameData);

            //foreach (Map obj in obj2)
            //{
            //    items.Add(new Map(obj.MapFileName, obj.MapName));
            //}
            //items.Add(new Map(InputMapName.fileName, obj2.Count + 1));


            // show the map of the first item in combox


        }

        private void add_map_button1_Click(object sender, EventArgs e)
        {
            // New Picturbox
            OpenFileDialog opnfd = new OpenFileDialog();
            opnfd.Filter = "Image Files (*.jpg;*.jpeg;.*.gif;)|*.jpg;*.jpeg;.*.gif";
            // pick the image from Computer folder
            if (opnfd.ShowDialog() == DialogResult.OK)
            {
                string file_name;
                file_name = opnfd.FileName;
                string MapFileName = opnfd.FileName;

                // Image name or Filename  : Give Image File name

                InputMapName map_name = new InputMapName();
                map_name.ShowDialog();
                //add map file and map name to gitem
              
                imageFileName = InputMapName.fileName.Trim();
               // imageFileName = InputMapName.fileName.Trim();
                //lblimage.Text = imageFileName;
                lblimage.Visible = false;
                //string destinationPath = workfolder + "Image\\" + InputMapName.fileName.Trim() + ".jpeg";
                string destinationPath = workfolder + "Image\\" + (gitems.Count + 1).ToString() + ".jpeg";
                string MapFilename = (gitems.Count + 1).ToString();
                if (File.Exists(destinationPath))
                {
                    //File.Delete(destinationPath);
                    //MessageBox.Show("This name already exist");
                    //  return;
                    destinationPath = workfolder + "Image\\" + (gitems.Count +2).ToString() + ".jpeg";
                    MapFilename = (gitems.Count + 2).ToString();
                }
                // Save the image to work folder
                //File.Copy(MapFileName, destinationPath);
                filePathNew = destinationPath;
                lblimage.Text = MapFilename;
                File.Copy(MapFileName, destinationPath);
                string mapName = InputMapName.fileName;
                Map map = new Map(MapFilename, mapName);
                //map.taglist = taglist;
                /* List<tagu> taglist2 = new List<tagu>();
                taglist = taglist2;*/
                taglist.Clear();
                gitems.Add(map);
                // January
                /*
                map.taglist1=taglist;
                map.taglist2=taglist2;

                gitems.Add(map);
                */
                map_comboBox1.DataSource = gitems;
                map_comboBox1.DisplayMember = "MapName";
                map_comboBox1.ValueMember = "MapFileName";
                //Show the map in picbox 
                pictureBox1.Image = Image.FromFile(file_name);
                int width = pictureBox1.Width;
                int height = pictureBox1.Height;
                //var filePath = workfolder + "Image\\" + name + ".jpeg";
                Bitmap bmap = new Bitmap(MapFileName);
                //fillPictureBox(pictureBox1, bmap, width, height);
                if (Width < pictureBox1.Image.Width || height < pictureBox1.Image.Height)
                {
                    this.pictureBox1.Size = new System.Drawing.Size(PictureBoxActualWidth, PictureBoxActualHeight);
                    pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                }
                else
                {
                    pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
                    fillPictureBox(pictureBox1, bmap, width, height);
                }                
                flag = 1;
            }



        }

        // For save info 
        public static void SaveToBinaryFile(object obj, string path)
        {
            FileStream fs = new FileStream(path,
                FileMode.Create,
                FileAccess.Write);
            BinaryFormatter bf = new BinaryFormatter();
            //serialize and write
            bf.Serialize(fs, obj);
            fs.Close();
        }
        public static object LoadFromBinaryFile(string path)
        {
            FileStream fs = new FileStream(path,
                FileMode.Open,
                FileAccess.Read);
            BinaryFormatter f = new BinaryFormatter();
            // read and deserialize 
            object obj = f.Deserialize(fs);
            fs.Close();

            return obj;
        }

        private void Exit_map_edit_button9_Click(object sender, EventArgs e)
        {
            // January
            //taglist = null;
            //taglist2 = null;
            this.map_button.Enabled = true;
           // this.edit_button7.Enabled = false;
            this.add_map_button1.Enabled = false;
            this.delete_map_button8.Enabled = false;
            this.set_map_label1.Enabled = false;
            this.map_comboBox1.Enabled = false;
            this.Exit_map_edit_button9.Enabled = false;
            // July
            this.add_map_button1.Visible = false;
            this.delete_map_button8.Visible = false;
            this.set_map_label1.Visible = false;
            this.map_comboBox1.Visible = false;
            this.Exit_map_edit_button9.Visible = false;

            map_comboBox1.SelectedIndex = -1;
            pictureBox1.Image = null;
            // map_comboBox1.Items.Clear();
            lblCboImageName.Text = "";

            string fileNameData = workfolder + "Image\\obj";

            SaveToBinaryFile(gitems, fileNameData);
            flag = 0;
            lblimage.Text = "";
            filePathNew = "";

        }


        private void delete_map_button8_Click(object sender, EventArgs e)
        {
            string fileNameData = workfolder + "Image\\obj";

            string itemFileName = map_comboBox1.SelectedValue.ToString();
            string itemFileNamePath = workfolder + "Image\\"+ itemFileName+".jpeg";

            gitems.RemoveAll(r => r.MapFileName== itemFileName);

            SaveToBinaryFile(gitems, fileNameData);
            map_comboBox1.SelectedIndex = 0;
          
            pictureBox1.Dispose();           
            
        }


        public bool ScanLogFile(string strLogFile)
        {
            DateTime dtTemp;

            // March Honey
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

            DateTime dtStart = DateTime.Today;
            DateTime dtEnd = DateTime.Today;
            DateTime dtDeviceDate = DateTime.Today;

            UInt32 u32CID = 0;
            UInt32 u32TempCID = 0;

            AnswerRecord TempAns = new AnswerRecord();

            bool bError = false;

            dtTemp = DateTime.Now;


            byte u8Second, u8Minute, u8Hour, u8Month, u8Day;
            UInt32 rFID = 0;
            string uID = "";
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

                    case 01:// GET UID
                        rFID = BitConverter.ToUInt32(bs, nPos + 4);
                        //uID = rFID.ToString("X8");
                        TempAns.UID = rFID.ToString("X8");
                        nPos += 8;                        
                        break;

                    case 0x02:// GET SID
                        nPos += 8;
                        break;

                    case 03:// GET RFID
                        rFID = BitConverter.ToUInt32(bs, nPos + 4);
                        TempAns.RFID = rFID.ToString("X8");
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
                        TempAns.UID = "";
                        nPos += 8;
                        break;


                    case 0x05://playing is eneded


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


                        ////////////////////////////////////////////////////////////////////
                        // record the content playing information to the ContentPlayingInfo class

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
                            temp_contentplayInfo.UID = TempAns.UID;
                            temp_contentplayInfo.RFID = TempAns.RFID;
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
                            foreach (contentsInfo coninfo in gconINFO)
                            //for (int i = 0; i < gconINFO.Count; i++)
                            {
                                if (coninfo.GetContentID() == u32CID && coninfo.bQuiz == true) // found the content
                                {

                                    TempAns.nAns = nBranchNo;

                                    if (coninfo.GetQuizAnsNum() == nBranchNo)
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

                    case 0x11:// mode change
                        nPos += 8;
                        break;


                    default:

                        bError = true;
                        break;

                }//switch

            }//while

            return true;
        }

        private void RadioAscDescChanged(object sender, EventArgs e)
        {
            resultListView.Visible = true;
            
            if (rdoAccurate.Checked)
            {
                PopulateList(resultListView, QuizAnsInformationResult.OrderBy(x => x.nCorrectRatio).ToList());
            }
            else if (rdoQuizId.Checked)
            {
                PopulateList(resultListView, QuizAnsInformationResult.OrderBy(x => x.u32CID).ToList());

            }
            else
            {
                PopulateList(resultListView, QuizAnsInformationResult);
            }
        }

        private void btnBarGraph_Click(object sender, EventArgs e)
        {
            chartWithData.BringToFront();
            pictureBox1.SendToBack();
            txtAnalyzedData.SendToBack();

            //List<StoryInformation> gStoryINFOALl = new List<StoryInformation>();

            //ExpRankResult Err = new ExpRankResult();
            //Err.ShowDialog();
            //gStoryINFOALl = ExpRankResult.gStoryINFO;
            if (BarGrapggStoryINFOALl.Count != 0)
            {
                DataSet ds = ToDataSet(BarGrapggStoryINFOALl);

                chartWithData.DataSource = ds;
                //var name = chartWithData.Series;
                chartWithData.Series["Series1"].XValueMember = "xPositionValue";
                chartWithData.Series["Series1"].YValueMembers = "yPositionValue";
                chartWithData.DataBind();
                chartWithData.Series["Series1"].ChartType = SeriesChartType.Column;
                var pixelWidth = 300 / chartWithData.Series["Series1"].Points.Count;
                var maxWidth = pixelWidth > 50 ? 50 : pixelWidth;
                chartWithData.Series["Series1"]["PixelPointWidth"] = maxWidth.ToString();
                chartWithData.Series["Series1"].IsValueShownAsLabel = true;
                chartWithData.Series["Series1"].SmartLabelStyle.Enabled = false;
                chartWithData.Series["Series1"]["LabelPlacement"] = "Inside";
                chartWithData.ChartAreas[0].AxisX.Interval = 1;
               

                for (int i = 0; i < chartWithData.Series["Series1"].Points.Count; i++)
                {
                    DataPoint dataPoint = chartWithData.Series["Series1"].Points[i];
                    var y = dataPoint.YValues[0];
                    var val = BarGrapggStoryINFOALl.Where(x => x.nTotalAccessNum == y).FirstOrDefault()?.u32CID.ToString();
                    var label = "";
                    if (!string.IsNullOrWhiteSpace(val) && TitleDictionary.ContainsKey(val))
                    {
                        label = TitleDictionary[val];
                        dataPoint.Label = "  " + label;
                    }

                    if (y > 100)
                    {
                        dataPoint.LabelAngle = 90;

                    }

                }

                //chartWithData.Titles.Add("Museum Chart");
                if (chartWithData.Titles.Count == 0)
                {
                    chartWithData.Titles.Add("Museum Chart");
                }
                //chartWithData.Legends.All;
                //chartWithData.Series["Series1"].Points.DataBindXY(ds, "DATE", ds, "VALUE");

                //chartWithData.Series["Series1"].Legend = "xPositionValue";
                //chartWithData.Series["Series1"].Legend = "yPositionValue";

                chartWithData.Series["Series1"].IsVisibleInLegend = true;


                //chartWithData.Legends.Add(new Legend("Series1"));

                //// Set Docking of the Legend chart to the Default Chart Area.
                //chartWithData.Legends["Series1"].DockedToChartArea = "Default";

                //// Assign the legend to Series1.
                //chartWithData.Series["Series1"].Legend = "Legend2";
                //chartWithData.Series["Series1"].IsVisibleInLegend = true;
                chartWithData.Series["Series1"].MarkerSize = 10;
            }

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            chartWithData.SendToBack();
            pictureBox1.SendToBack();
            txtAnalyzedData.SendToBack();
            resultListView.BringToFront();
        }

        private void FindDataButtonClick(object sender, EventArgs e)
        {
            List<ContentPlayResultModel> list = Common.ReadCsvFile(workfolder + "ContentPlayResult.csv");
            var quizData = list.Where(x => x.IsQuiz).ToList();
            var guideData = list.Where(x => !x.IsQuiz).ToList();
            Common.WriteCsvFile<ContentPlayResultModel>(quizData, workfolder + "QuizData.csv");
            Common.WriteCsvFile<ContentPlayResultModel>(quizData, workfolder + "GuideData.csv");
            var lissItemCount = list.Count;
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            switch (e.Button)
            {
                case MouseButtons.Right:                    
                    xMouseRightClick = e.X;
                    yMouseRightClick = e.Y;
                    break;
            }
        }
       
        private void 赤外線ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Type 2

            tagaddC TAC = new tagaddC();
            TAC.ShowDialog();            
            tagID = tagaddC.ID;
            tagName = tagaddC.Name;
            if (tagName != "" && tagName != null)
            {
                // 2nd Tag
                int x = 0;
                int y = 0;
                x = xMouseRightClick;
                y = yMouseRightClick;

                string name = "";
                var filePath = "";
               if (lblimage.Text != "")
                {
                    name = lblimage.Text;
                    filePath = filePathNew;
                }
                else
                {
                    name = map_comboBox1.SelectedValue.ToString();
                    filePath = workfolder + "Image\\" + name + ".jpeg";
                }
               //Friday
                    //string name = map_comboBox1.SelectedValue.ToString();
                //var filePath = workfolder + "Image\\" + name + ".jpeg";
                Bitmap OriginalBitmap = new Bitmap(filePath);
                int width = pictureBox1.Width;
                int height = pictureBox1.Height;
                float scale = Math.Min((float)width / (float)OriginalBitmap.Width, (float)height / (float)OriginalBitmap.Height);
                int widthToScale = (int)(OriginalBitmap.Width * scale);
                int heightToScale = (int)(OriginalBitmap.Height * scale);
                float x1 = (width - widthToScale) / 2;
                var resized = new Bitmap(pictureBox1.Width, pictureBox1.Height);
                var g = Graphics.FromImage(resized);
                if (width > widthToScale)
                {
                    g.DrawImage(OriginalBitmap, x1, 0, widthToScale, height);
                }
                else
                {
                    g.DrawImage(OriginalBitmap, 0, 0, widthToScale, height);
                }
                g.Dispose();
                pictureBox1.Image = resized;

                Bitmap arrowBitmap2 = new Bitmap(workfolder + "Resources\\2.png");
                Bitmap copy = new Bitmap(resized);

                Graphics g2 = Graphics.FromImage(copy);

                tagu Single = new tagu();
                Single.pointx = x;
                Single.pointy = y;
                Single.tagname = tagName;
               // Single.tagId = Convert.ToInt32(tagID);//tag type need
                Single.tagId = tagID;//tag type need
                Single.tagtype = 2;//tag type need

                taglist.Add(Single);

                Bitmap arrowBitmap1 = new Bitmap(workfolder + "Resources\\1.png");
                Graphics g1 = Graphics.FromImage(copy);
               
                foreach (tagu taguSingle in taglist)
                {
                    if (taguSingle.tagtype == 1)
                    {
                        g1.DrawImage(arrowBitmap1, new Point(taguSingle.pointx, taguSingle.pointy));
                    }
                    else if (taguSingle.tagtype == 2)
                    {
                        g2.DrawImage(arrowBitmap2, new Point(taguSingle.pointx, taguSingle.pointy));
                    }
                }
                pictureBox1.Image = copy;

                var targetMap = gitems.Where(o => o.MapFileName == name);
                Map map = new Map("", "");
                foreach (var item in targetMap)
                {
                    map = new Map(item.MapFileName, item.MapName);
                    map.taglist = taglist;
                }
                // January
                //if (lblimage.Text == "")
                //{
                    gitems = gitems.Except(targetMap).ToList();
                    gitems.Add(map);
                //}

                
            }

        }
        
        private void コンテンツToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Type 1
            int x = 0;
            int y = 0;

            x = xMouseRightClick;
            y = yMouseRightClick;

            tagaddC TAC = new tagaddC();
            TAC.ShowDialog();             
            tagID = tagaddC.ID;
            tagName = tagaddC.Name;
            if (tagName != "" && tagName != null)
            {
                string name = "";
                var filePath = "";
                if (lblimage.Text != "")
                {
                    name = lblimage.Text;
                    filePath = filePathNew;
                }
                else
                {
                    name = map_comboBox1.SelectedValue.ToString();
                    filePath = workfolder + "Image\\" + name + ".jpeg";
                }
                //string name = map_comboBox1.SelectedValue.ToString();
                //var filePath = workfolder + "Image\\" + name + ".jpeg";
                Bitmap OriginalBitmap = new Bitmap(filePath);
                int width = pictureBox1.Width;
                int height = pictureBox1.Height;
                float scale = Math.Min((float)width / (float)OriginalBitmap.Width, (float)height / (float)OriginalBitmap.Height);
                int widthToScale = (int)(OriginalBitmap.Width * scale);
                int heightToScale = (int)(OriginalBitmap.Height * scale);
                float x1 = (width - widthToScale) / 2;
                var resized = new Bitmap(pictureBox1.Width, pictureBox1.Height);
                var g = Graphics.FromImage(resized);
                if (width > widthToScale)
                {
                    g.DrawImage(OriginalBitmap, x1, 0, widthToScale, height);

                }
                else
                {
                    g.DrawImage(OriginalBitmap, 0, 0, widthToScale, height);
                }
                g.Dispose();
                pictureBox1.Image = resized;

                Bitmap arrowBitmap1 = new Bitmap(workfolder + "Resources\\1.png");
                Bitmap copy = new Bitmap(resized);

                Graphics g2 = Graphics.FromImage(copy);


                tagu Single = new tagu();
                Single.pointx = x;
                Single.pointy = y;
                Single.tagname = tagName;
                Single.tagId = tagID;
               // Single.tagId = Convert.ToInt32(tagID);
                Single.tagtype = 1;//tag type need

                taglist.Add(Single);

                // For 1st Tag
                Bitmap arrowBitmap2 = new Bitmap(workfolder + "Resources\\2.png");
                Graphics g1 = Graphics.FromImage(copy);
               
                foreach (tagu taguSingle in taglist)
                {
                    if (taguSingle.tagtype == 1)
                    {
                        g1.DrawImage(arrowBitmap1, new Point(taguSingle.pointx, taguSingle.pointy));
                    }
                    else if(taguSingle.tagtype == 2)
                    {
                        g2.DrawImage(arrowBitmap2, new Point(taguSingle.pointx, taguSingle.pointy));
                    }
                }
                //g2.DrawImage(arrowBitmap, new Point(x, y));
                pictureBox1.Image = copy;
                // copy.Save(...);
                var targetMap = gitems.Where(o => o.MapFileName == name);
                Map map = new Map("", "");
                foreach (var item in targetMap)
                {
                    map = new Map(item.MapFileName, item.MapName);
                    map.taglist = taglist;
                    //map.taglist2 = taglist2;
                }
                // January
               // if (lblimage.Text == "")
                //{
                    gitems = gitems.Except(targetMap).ToList();
                    gitems.Add(map);
               // }
                
            }

        }

        // February
        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                xMouseRightClick = e.X;
                yMouseRightClick = e.Y;
                
                pictureBox1.Cursor = ImageArea(pictureBox1).Contains(e.Location) ?
                                                            Cursors.Hand : Cursors.Default;
            }
        }

        Rectangle ImageArea(PictureBox pbox)
        {
            
            int x = 0;
            int y = 0;

            x = xMouseRightClick;
            y = yMouseRightClick;
            foreach (tagu taguSingle in taglist)
            {
                if (taguSingle.pointx + 10 >= x && taguSingle.pointx - 10 <= x)
                {
                    if (taguSingle.pointy + 10 >= y && taguSingle.pointy - 10 <= y)
                    {
                       // return new Rectangle(taguSingle.pointx, taguSingle.pointy, taguSingle.pointx, taguSingle.pointy);
                        return new Rectangle(taguSingle.pointx, taguSingle.pointy, 50, 50);
                    }
                }
               // g1.DrawImage(arrowBitmap1, new Point(taguSingle.pointx, taguSingle.pointy));
            }
            
            return new Rectangle(0, 0, 0, 0);
        }
        // February
        private void 削除ToolStripMenuItem_Click(object sender, EventArgs e)
        {          

            int x = 0;
            int y = 0;

            x = xMouseRightClick;
            y = yMouseRightClick;
            foreach (tagu taguSingle in taglist)
            {
                if (taguSingle.pointx + 10 >= x && taguSingle.pointx - 10 <= x)
                {
                    if (taguSingle.pointy + 10 >= y && taguSingle.pointy - 10 <= y)
                    {
                        DialogResult result = MessageBox.Show("本当に削除しますか？", "質問",MessageBoxButtons.OKCancel);
                        if(result == DialogResult.OK)
                        {
                            var targetTag = taglist.Where(o => o.tagId == taguSingle.tagId);
                           
                            //int index = map_comboBox1.SelectedIndex;
                            taglist = taglist.Except(targetTag).ToList();
                            //map_comboBox1.SelectedIndex = 0;

                            //map_comboBox1.SelectedIndex = index;
                            //gitems.Add(map);

                            // Delete
                            string name = map_comboBox1.SelectedValue.ToString();
                            var filePath = workfolder + "Image\\" + name + ".jpeg";
                            Bitmap OriginalBitmap = new Bitmap(filePath);
                            int width = pictureBox1.Width;
                            int height = pictureBox1.Height;
                            float scale = Math.Min((float)width / (float)OriginalBitmap.Width, (float)height / (float)OriginalBitmap.Height);
                            int widthToScale = (int)(OriginalBitmap.Width * scale);
                            int heightToScale = (int)(OriginalBitmap.Height * scale);
                            float x1 = (width - widthToScale) / 2;
                            var resized = new Bitmap(pictureBox1.Width, pictureBox1.Height);
                            var g = Graphics.FromImage(resized);
                            if (width > widthToScale)
                            {
                                g.DrawImage(OriginalBitmap, x1, 0, widthToScale, height);

                            }
                            else
                            {
                                g.DrawImage(OriginalBitmap, 0, 0, widthToScale, height);
                            }
                            g.Dispose();
                            pictureBox1.Image = resized;

                            Bitmap arrowBitmap1 = new Bitmap(workfolder + "Resources\\1.png");
                            Bitmap copy = new Bitmap(resized);
                            Graphics g2 = Graphics.FromImage(copy);
                           
                            Bitmap arrowBitmap2 = new Bitmap(workfolder + "Resources\\2.png");
                            Graphics g1 = Graphics.FromImage(copy);
                           
                            foreach (tagu taguSingle2 in taglist)
                            {
                                if (taguSingle2.tagtype == 1)
                                {
                                    g1.DrawImage(arrowBitmap1, new Point(taguSingle2.pointx, taguSingle2.pointy));
                                }
                                else if (taguSingle2.tagtype == 2)
                                {
                                    g2.DrawImage(arrowBitmap2, new Point(taguSingle2.pointx, taguSingle2.pointy));
                                }
                            }
                            pictureBox1.Image = copy;
                            var targetMap = gitems.Where(o => o.MapFileName == name);
                            Map map = new Map("", "");
                            foreach (var item in targetMap)
                            {
                                map = new Map(item.MapFileName, item.MapName);
                                map.taglist = taglist;
                            }
                            gitems = gitems.Except(targetMap).ToList();
                            gitems.Add(map);
                            //Delete
                        }
                    }
                }
            }
            
        }       
    }

}

[Serializable()]
public class Map
{
    private string MapFileName;
    [NonSerialized()]
    private string MapName;
    //(omitted)
}
//contentsInfo Calss

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

// AnswerRecord Class
namespace infraredCommApp
{
    public class AnswerRecord
    {
        public UInt32 u32CID;
        public int nAns;
        public bool bCorrect;
        public string strTitle;
        public DateTime dtQuiz;
        public DateTime dtStartTime;
        public DateTime dtEndTime;
        public int nEndMode;  // 0 normal end, 1 terminated, 2 interrupt switch
        public string UID;
        public string RFID;


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
            UID = "";
            RFID = "";
        }


        public void Resets()
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
