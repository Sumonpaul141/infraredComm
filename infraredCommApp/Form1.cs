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
        public bool isQuizAnalyzing = true;

        public static List<tagu> taglist = new List<tagu>();

        public static string FromDate = "";
        public static string ToDate = "";
        public static string Type = "";
        public static string[] TagNameAll = null;
        public static DataTable dtTagNameAll = new DataTable();
        public static bool isHourlyView = false;
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




        public static string strSettingup = "";

        public static int gAgeIndex;
        public static int gSexal;
        public static int gPlace;

        public static UInt32 u32CertificateNo;


        // Atik Global Variable
        List<Map> gitems = new List<Map>();
        //BindingList<Map> bindingList = new BindingList<Map>();
        //public static string imageFileName = "";
        int flag = 0;

        private System.Windows.Forms.Button[] testButtons;

        public static int gnBtnNo;

        public static System.Threading.Mutex mymutex;


        public static UInt32 u32DeviceMode;

        //public static string appName = "Stapm2021";
        public static string USBSN = "ChargeControlF"; //"NECUSE";//"UEGG37RW2011";//"NECEAAA001";


        public int nIBCCount = 0;

        public int gnDeviceID = 0;

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

        public static DataTable HeatMapSorted = new DataTable();
        public static DataTable HeatMapUnSorted = new DataTable();
        public static DataTable HeatMapUnSortedAll = new DataTable();
        public static DataTable HeatMapSortedIndividual = new DataTable();

        public  static bool gbSaveLogData = false;


        public static bool gb_FinalSetup = false;

        public static int nRFChnLog = 20; // log file transmitting RF channel

        public static string strSETUPpassword = "";


        //public static List<ContentInfo> gContentINFO = new List<ContentInfo>(); //list for content information

        public static List<AnswerRecord> gUserRecord = new List<AnswerRecord>(); // list for user's answer record

        public static string szQuizTitle = "";
        public static string szQuizAns = "";


        // GLOBAL DEFINES

        public static string appName = "FlowLine2022";
        public static string logpath = "";
        public static string workfolder = "";
        public static string workfolder2 = "";
        public static string ibcfolder = "";
        public static string imageFolder = "";
        public static List<ContentPlayingInfo> gContPLAY = new List<ContentPlayingInfo>();
        public static List<contentsInfo> gconINFO = new List<contentsInfo>(); // list for content information


        // Timer
        private Timer timer;
        private int timerSpeed = 30;
        private int timerStartPosition = 300;
        private Bitmap heatmap;
        private List<string> selectedTags = new List<string>();

        // For animation 
        private DateTime currentDate = DateTime.Now;
        private int currentCordinateIndex = 0;
        private List<HeatMapCordinateDTO> heatMapCordinates;
        private List<HeatMapCordinateWithMapDTO> heatMapCordinatesWithMap;
        private List<Bitmap> generatedMaps = new List<Bitmap>();
        private List<HeatMapCordinateDTO> lastPointColor = new List<HeatMapCordinateDTO>();
        private Bitmap imageToDrawTags;
        private Graphics graphics;
        private double minNumberOfClient;
        private double maxNumberOfClient;

        //for blink
        private bool isShow;
        private bool isPlayingHeadMap = false;
        private Bitmap imageWithoutTags;
        private List<Color> colors = new List<Color>();

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
        //private void Timer_Tick(object sender, EventArgs e)
        //{
        //    if (FromDate != "")
        //    {
        //        Thread.Sleep(200);
        //        map_comboBox1.SelectedIndex = 1;
        //        map_comboBox1.SelectedIndex = 2;
        //    }
        //    // Trigger a redraw of the control
        //    Invalidate();
        //}

        //protected override void OnPaint(PaintEventArgs e)
        //{
        //    // Draw the updated heatmap onto the control
        //    //e.Graphics.DrawImage(heatmap, 0, 0);
        //    //if (FromDate != "")
        //    //{
        //    //    map_comboBox1.SelectedIndex = 2;
        //    //}
        //    base.OnPaint(e);
        //}
        public Form1()
        {
            // Timer

            // Initialize the heatmap image with a blank bitmap
            heatmap = new Bitmap(Width, Height);
            // Initialize the timer and set the interval to 100 ms
            // timer = new Timer();
            //timer.Interval = 500;
            //timer.Tick += Timer_Tick;
            // Start the timer
            //timer.Start();

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
                    if (!Directory.Exists(Form1.workfolder))
                    {
                        Directory.CreateDirectory(Form1.workfolder);
                    }
                    if (!Directory.Exists(Form1.logpath))
                    {
                        Directory.CreateDirectory(Form1.logpath);
                    }
                    if (!Directory.Exists(Form1.ibcfolder))
                    {
                        Directory.CreateDirectory(Form1.ibcfolder);
                    }

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
                Form1.imageFolder = "c:\\" + appName + "\\Image\\";
                Form1.ibcfolder = "c:\\" + appName + "\\IBCQ\\";


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

                    if (!Directory.Exists(imageFolder)) //ceate new folder, if no exist
                    {
                        Directory.CreateDirectory(imageFolder);
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
            // TagLocationSet("3");
            this.buttonFLowLineAnalysis.Visible = false;
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

        public List<Dictionary<string, string>> ReadCsv(string filePath)
        {
            List<Dictionary<string, string>> csvData = new List<Dictionary<string, string>>();

            using (var reader = new StreamReader(filePath))
            {
                var headers = reader.ReadLine().Split(',');

                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');

                    Dictionary<string, string> row = new Dictionary<string, string>();

                    for (int i = 0; i < headers.Length; i++)
                    {
                        row.Add(headers[i], values[i]);
                    }

                    csvData.Add(row);
                }
            }

            return csvData;
        }
        void TagLocationSet(string name)
        {
            string FilePath = workfolder + "Contentid.CSV";
            DataTable csvData = GetDataTabletFromCSVFile(FilePath);

            var map = gitems.FirstOrDefault(o => o.MapFileName == name);
            List<HeatMap> HeatMapListDateTimeFiltered = new List<HeatMap>();
            List<HeatMap> HeatMapListAll = new List<HeatMap>();

            if(!string.IsNullOrWhiteSpace(FromDate) && !string.IsNullOrWhiteSpace(ToDate))
            {
                tagDateFirstMonth = Convert.ToInt16(Convert.ToDateTime(FromDate).Month);
                tagInitialDateFirstMonth = tagDateFirstMonth;
                tagDateLastMonth = Convert.ToInt16(Convert.ToDateTime(ToDate).Month);
            }
            if (map != null && map.taglist != null)
            {
                taglist = map.taglist;
                foreach (tagu taguSingle in map.taglist)
                {
                    for (int i = 0; i < csvData.Rows.Count; i++)
                    {

                        string strDateTime = csvData.Rows[i]["Date"].ToString() + " " + csvData.Rows[i]["Time"].ToString();
                        DateTime dtDateTime = Convert.ToDateTime(Common.GetValidDateTime(strDateTime));
                        if (taguSingle.tagId.ToString() == csvData.Rows[i]["Id"].ToString())
                        {
                            HeatMap htMap = new HeatMap() 
                            {
                                tagId = taguSingle.tagId,
                                tagname = taguSingle.tagname,
                                pointx = taguSingle.pointx,
                                pointy = taguSingle.pointy,
                                tagtype = taguSingle.tagtype,
                                tagDate = dtDateTime,
                            };

                            if (htMap.tagDate >= Convert.ToDateTime(FromDate) && htMap.tagDate <= Convert.ToDateTime(ToDate))
                            {
                                HeatMapListDateTimeFiltered.Add(htMap);
                            }
                            HeatMapListAll.Add(htMap);
                        }

                    }

                }

                var heatMapListDateTimeFilteredTable = ListToDataTable(HeatMapListDateTimeFiltered);
                var heatMapListTableAll = ListToDataTable(HeatMapListAll);


                var query = from row in heatMapListDateTimeFilteredTable.AsEnumerable()
                            group row by row.Field<string>("tagId") into sales
                            orderby sales.Count()
                            select new
                            {
                                Name = sales.Key,
                                CountOfClients = sales.Count().ToString()
                            };

                

                HeatMapUnSorted = heatMapListDateTimeFilteredTable.AsEnumerable()
                            .GroupBy(r => new { tagId = r["tagId"], tagname = r["tagname"], pointx = r["pointx"], pointy = r["pointy"], tagDate = r["tagDate"] })
                            .Select(g =>
                            {
                                var row = heatMapListDateTimeFilteredTable.NewRow();
                                row["tagId"] = g.Key.tagId;
                                row["tagname"] = g.Key.tagname;
                                row["pointx"] = g.Key.pointx;
                                row["pointy"] = g.Key.pointy;
                                row["tagDate"] = g.Key.tagDate;
                                return row;
                            })
                            .CopyToDataTable();

                //HeatMapUnSorted = HeatMapListDateTimeFiltered.Select(g =>
                //{
                //    var row = heatMapListDateTimeFilteredTable.NewRow();
                //    row["tagId"] = g.tagId;
                //    row["tagname"] = g.tagname;
                //    row["pointx"] = g.pointx;
                //    row["pointy"] = g.pointy;
                //    row["tagDate"] = g.tagDate;
                //    return row;
                //})
                //.CopyToDataTable();

                HeatMapUnSortedAll = heatMapListTableAll.AsEnumerable()
                           .GroupBy(r => new { tagId = r["tagId"], tagname = r["tagname"], pointx = r["pointx"], pointy = r["pointy"], tagDate = r["tagDate"] })
                           .Select(g =>
                           {
                               var row = heatMapListDateTimeFilteredTable.NewRow();
                               row["tagId"] = g.Key.tagId;
                               row["tagname"] = g.Key.tagname;
                               row["pointx"] = g.Key.pointx;
                               row["pointy"] = g.Key.pointy;
                               row["tagDate"] = g.Key.tagDate;
                               return row;

                           })
                           .CopyToDataTable();

                // print result

                HeatMapSorted = CreateDataTable(query);
                //var x = CreateDataTable(query);

                HeatMapSortedIndividual = HeatMapSorted.AsEnumerable()
                       .GroupBy(r => new { CountIndividual = r["CountOfClients"] })
                       .Select(g =>
                       {
                           var row = HeatMapSorted.NewRow();

                               //row["PK"] = g.Min(r => r.Field<int>("PK"));
                               row["CountOfClients"] = g.Key.CountIndividual;

                           return row;

                       })
                       .CopyToDataTable();

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
            string strTemp = "User SN, Content ID, Date, Time, Play Time, EndMode, IsQuiz, IsCorrect Ans, inputed Ans";
            //string strIds = "UID, RFID, IdType, DATE, TIME";
            string strIds = "Id, IdType, Date, Time";


            // open the DB text file
            string deviceusedresultPath = Form1.workfolder + "ContentPlayResult.csv";
            string uIdAndRfidPth = Form1.workfolder + "Contentid.csv";

            if (File.Exists(deviceusedresultPath))
            {
                strTemp = "";
            }
            if(File.Exists(uIdAndRfidPth))
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
                   + cpi.dtStartTime.ToString("HH:mm:ss") + ","
                   + cpi.nPlayTime.ToString() + ","
                   + cpi.nEndMode.ToString() + ","
                   + cpi.bQuiz.ToString() + ","
                   + cpi.bCorrectAns.ToString() + ","
                   + cpi.nInputAns.ToString();


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
                        + cTime;
                        IdsWrite.WriteLine(strIds);
                    }
                    else if (cUID == "" && cRFID != "")
                    {
                        strIds = cpi.RFID.ToString() + ","
                        + 1 + ","
                        + cDate + ","
                        + cTime ;
                        IdsWrite.WriteLine(strIds);
                    }
                    else
                    {
                        strIds = cpi.UID.ToString() + ","
                        + 0 + ","
                        + cDate + ","
                        + cTime ;
                        IdsWrite.WriteLine(strIds);

                        strIds = cpi.RFID.ToString() + ","
                        + 1 + ","
                        + cDate + ","
                        + cTime ;
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
            this.prevButton.Visible = false;
            this.nextButton.Visible = false;


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

                ChangeLocation();

                while (nIndex > 0)
                {
                    nIndex--;
                    gContPLAY.Clear();

                    ScanLogFile(files[nIndex]);

                    fep_save_Content_Play_Info(00000);

                }
            

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

        private void SelectionCommited(object sender, EventArgs e)
        {
            map_comboBox1_SelectedIndexChanged(sender, e);
        }
        private void map_comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (map_comboBox1.SelectedValue != null)
            {
                this.buttonFLowLineAnalysis.Visible = true;

                if (HeatMapConsider==1)
                {
                    TagLocationSet(map_comboBox1.SelectedValue.ToString());
                }
                HeatMapConsider = 0;

                string name = "";
                if (map_comboBox1.SelectedValue.ToString() != "infraredCommApp.Map" && map_comboBox1.SelectedValue.ToString() != "")
                {
                    name = map_comboBox1.SelectedValue.ToString();
                }
                else
                {
                    name = (map_comboBox1.SelectedValue as Map).MapFileName;
                }

                
                pictureBox1.Image = Image.FromFile(workfolder + "Image\\" + name + ".jpeg", true);
                var filePath = workfolder + "Image\\" + name + ".jpeg";
                Bitmap bmap = new Bitmap(filePath);
                if (pictureBox1.Width < pictureBox1.Image.Width || pictureBox1.Height < pictureBox1.Image.Height)
                {
                    this.pictureBox1.Size = new System.Drawing.Size(PictureBoxActualWidth, PictureBoxActualHeight);
                    pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                }
                else
                {
                    pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
                }
                lblCboImageName.Text = " MapName : " + map_comboBox1.Text + " MapFileName : " + map_comboBox1.SelectedValue.ToString();

                var targetMap = gitems.FirstOrDefault(o => o.MapFileName == name);
                taglist = targetMap.taglist;
                var imageToDraw = RedrawMapAndUpdateTagListAndGetCopiedFile(filePath, targetMap.taglist);

                AllWorkDoneForImage5(name, imageToDraw, HeatMapSorted, HeatMapUnSorted, HeatMapUnSortedAll, HeatMapSortedIndividual);

            }

        }

        private string GetTagNames(Map map)
        {
            var mapTagNameString = "";
            foreach (tagu tag in map.taglist)
            {
                mapTagNameString +=  tag.tagname + " ";
            }
            return mapTagNameString;
        }

        private void AllWorkDoneForImage5(string mapFileName, Bitmap imageToDraw, DataTable heatMapSorted, DataTable heatMapUnSorted, DataTable heatMapUnSortedAll, DataTable heatMapSortedIndividual)
        {


            int position = 820;
            int positionYellow = 820;
            int div = 0;


            DataTable dtTagNameAllOwn = new DataTable();
            dtTagNameAllOwn.Columns.Add("TagNameAll", typeof(String));
            int divider = 0;

            Graphics imageGraphics = Graphics.FromImage(imageToDraw);

            if (mapFileName == "5")
            {
                if (Type == "Day")
                {
                    lblFromDate.Text = Convert.ToDateTime(FromDate).Date.ToString("dd/MM/yyyy");
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

                for (int i = 0; i < heatMapSorted.Rows.Count; i++)
                {

                    for (int j = 0; j < heatMapUnSorted.Rows.Count; j++)
                    {

                        //double Ni, Nmin, Nmax, Vr, Vb,X;
                        for (int m = 0; m < heatMapSortedIndividual.Rows.Count; m++)
                        {
                            int dividerPosition;
                            dividerPosition = 800 / heatMapSortedIndividual.Rows.Count;

                            Nmin = Convert.ToInt32(heatMapSortedIndividual.Rows[0]["CountOfClients"].ToString());
                            Nmax = Convert.ToInt32(heatMapSortedIndividual.Rows[heatMapSortedIndividual.Rows.Count - 1]["CountOfClients"].ToString());
                            if (Nmax == Nmin)
                            {
                                Nmax = Nmax + 1;
                            }
                            Ni = ((Convert.ToInt32(heatMapSortedIndividual.Rows[m]["CountOfClients"].ToString()) - Nmin) / (Nmax - Nmin)) * 100;
                            //X = Ni;
                            Vr = (Ni * 255) / 100;
                            Vb = ((100 - Ni) * 255) / 100;
                            if (Vr > 255)
                            {
                                Vr = 255;
                            }
                            else if (Vr < 0)
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
                            if (heatMapSorted.Rows[i]["Name"].ToString() == heatMapUnSorted.Rows[j]["tagId"].ToString() && heatMapSorted.Rows[i]["CountOfClients"].ToString() == heatMapSortedIndividual.Rows[m]["CountOfClients"].ToString())
                            {
                                int u = Convert.ToInt16(Convert.ToDateTime(heatMapUnSorted.Rows[j]["tagDate"].ToString()).Month);
                                //lblDate.Text = HeatMapUnSorted.Rows[j]["tagDate"].ToString();
                                for (int htm = tagInitialDateFirstMonth; htm <= tagDateFirstMonth; htm++)
                                {
                                    //Days

                                    if (Type == "Day")
                                    {
                                        for (int htn = FirstDay; htn <= Month; htn++)
                                        {
                                            int day = Convert.ToInt16(Convert.ToDateTime(heatMapUnSorted.Rows[j]["tagDate"].ToString()).Day);
                                            if (htm == Convert.ToInt16(Convert.ToDateTime(heatMapUnSorted.Rows[j]["tagDate"].ToString()).Month) && htn == day)
                                            {

                                                if (colorCountBlue < 0)
                                                {
                                                    colorCountBlue = 0;
                                                }

                                                for (int dti = 0; dti < dtTagNameAll.Rows.Count; dti++)
                                                {
                                                    string tgn1 = heatMapUnSorted.Rows[j]["tagname"].ToString();
                                                    string tgn2 = dtTagNameAll.Rows[dti]["TagNameAll"].ToString();
                                                    if (heatMapUnSorted.Rows[j]["tagname"].ToString() == dtTagNameAll.Rows[dti]["TagNameAll"].ToString())
                                                    {
                                                        Color c1 = Color.FromArgb(200, Convert.ToInt32(Vr), 0, Convert.ToInt32(Vb));
                                                        //gs.FillEllipse(new SolidBrush(c1), Convert.ToUInt32(HeatMapUnSorted.Rows[j]["pointx"].ToString()), Convert.ToUInt32(HeatMapUnSorted.Rows[j]["pointy"].ToString()), 30, 30);
                                                        int RatioX = Convert.ToInt32((Convert.ToDouble(Convert.ToUInt32(heatMapUnSorted.Rows[j]["pointx"].ToString())) * 0.365));
                                                        int RatioY = Convert.ToInt32((Convert.ToDouble(Convert.ToUInt32(heatMapUnSorted.Rows[j]["pointy"].ToString())) * 0.30));
                                                        imageGraphics.FillEllipse(new SolidBrush(c1), Convert.ToUInt32(heatMapUnSorted.Rows[j]["pointx"].ToString()) + RatioX, Convert.ToUInt32(heatMapUnSorted.Rows[j]["pointy"].ToString()) + RatioY, 30, 30);


                                                        DataRow dRow = dtTagNameAllOwn.NewRow();

                                                        dRow["TagNameAll"] = tgn1;
                                                        //counter= counter+1;
                                                        dtTagNameAllOwn.Rows.Add(dRow);
                                                    }

                                                }

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
                                                string time = Convert.ToDateTime(heatMapUnSorted.Rows[j]["tagDate"].ToString()).TimeOfDay.ToString();
                                                //lblDate.Text = htn.ToString() + "/" + htm.ToString() + "/" + "2023 "+ time;
                                                int day = Convert.ToInt16(Convert.ToDateTime(heatMapUnSorted.Rows[j]["tagDate"].ToString()).Day);
                                                int hour = Convert.ToInt16(Convert.ToDateTime(heatMapUnSorted.Rows[j]["tagDate"].ToString()).Hour);
                                                if (htm == Convert.ToInt16(Convert.ToDateTime(heatMapUnSorted.Rows[j]["tagDate"].ToString()).Month) && htn == day && hto == hour)
                                                {

                                                    if (colorCountBlue < 0)
                                                    {
                                                        colorCountBlue = 0;
                                                    }
                                                    for (int dti = 0; dti < dtTagNameAll.Rows.Count; dti++)
                                                    {

                                                        string tgn1 = heatMapUnSorted.Rows[j]["tagname"].ToString();
                                                        string tgn2 = dtTagNameAll.Rows[dti]["TagNameAll"].ToString();
                                                        if (heatMapUnSorted.Rows[j]["tagname"].ToString() == dtTagNameAll.Rows[dti]["TagNameAll"].ToString())
                                                        {
                                                            Color c1 = Color.FromArgb(200, Convert.ToInt32(Vr), 0, Convert.ToInt32(Vb));
                                                            imageGraphics.FillEllipse(new SolidBrush(c1), Convert.ToUInt32(heatMapUnSorted.Rows[j]["pointx"].ToString()), Convert.ToUInt32(heatMapUnSorted.Rows[j]["pointy"].ToString()), 30, 30);

                                                            string id = heatMapSorted.Rows[i]["Name"].ToString();
                                                            string x = heatMapUnSorted.Rows[j]["pointx"].ToString();
                                                            string y = heatMapUnSorted.Rows[j]["pointy"].ToString();

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


                                string htIv = heatMapSortedIndividual.Rows[m]["CountOfClients"].ToString();
                                divider = 800 / heatMapSortedIndividual.Rows.Count;

                                if (htIv != Count.ToString())
                                {
                                    colorCountRGB++;
                                    div = div + 1;
                                    using (Font myFont = new Font("Arial", 10))
                                    {
                                        Color c2 = Color.FromArgb(200, Convert.ToInt32(Vr), 0, Convert.ToInt32(Vb));
                                        //position = position + divider;
                                        position = position - divider;
                                        imageGraphics.DrawString(div.ToString(), myFont, Brushes.Green, new Point(1530, position + dividerPosition / 2));
                                        //gs.FillRectangle(new SolidBrush(c2), 1200, position, 30, dividerPosition);
                                        imageGraphics.FillRectangle(new SolidBrush(c2), 1550, position, 30, dividerPosition);

                                        Color c3 = Color.FromArgb(255, 255, 0);
                                        imageGraphics.DrawString("0", myFont, Brushes.Green, new Point(1530, positionYellow + dividerPosition / 4));
                                        //gs.FillRectangle(new SolidBrush(c3), 1200, positionYellow, 30, dividerPosition);
                                        imageGraphics.FillRectangle(new SolidBrush(c3), 1550, positionYellow, 30, dividerPosition);
                                    }
                                }

                                if (heatMapSorted.Rows[i]["CountOfClients"].ToString() != Count.ToString())
                                {
                                    colorCountBlue--;
                                    Count = heatMapSorted.Rows[i]["CountOfClients"].ToString();
                                }
                            }
                        }

                    }
                    Count = heatMapSorted.Rows[i]["CountOfClients"].ToString();


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

                        if (tgn1 == tgn2)
                        {
                            flag = 1;

                        }
                        flName = tgn1;
                    }
                    if (flag == 0)
                    {
                        DataRow dRow = dtTagNameAllExtra.NewRow();
                        string k = flName;
                        dRow["TagNameAll"] = flName;
                        dtTagNameAllExtra.Rows.Add(dRow);
                    }
                }

                for (int i = 0; i < dtTagNameAllExtra.Rows.Count; i++)
                {

                    for (int j = 0; j < heatMapUnSortedAll.Rows.Count; j++)
                    {
                        if (heatMapUnSortedAll.Rows[j]["tagname"].ToString() == dtTagNameAllExtra.Rows[i]["TagNameAll"].ToString())
                        {
                            //Color c1 = Color.FromArgb(200, Convert.ToInt32(Vr), 0, Convert.ToInt32(Vb));
                            Color c1 = Color.FromArgb(255, 255, 0);
                            //gs.FillEllipse(new SolidBrush(c1), Convert.ToUInt32(HeatMapUnSortedAll.Rows[j]["pointx"].ToString()), Convert.ToUInt32(HeatMapUnSortedAll.Rows[j]["pointy"].ToString()), 30, 30);
                            int RatioX = Convert.ToInt32((Convert.ToDouble(Convert.ToUInt32(heatMapUnSortedAll.Rows[j]["pointx"].ToString())) * 0.365));
                            int RatioY = Convert.ToInt32((Convert.ToDouble(Convert.ToUInt32(heatMapUnSortedAll.Rows[j]["pointy"].ToString())) * 0.30));
                            //gs.FillEllipse(new SolidBrush(c1), Convert.ToUInt32(HeatMapUnSorted.Rows[j]["pointx"].ToString()) + RatioX, Convert.ToUInt32(HeatMapUnSorted.Rows[j]["pointy"].ToString()) + RatioY, 30, 30);

                            imageGraphics.FillEllipse(new SolidBrush(c1), Convert.ToUInt32(heatMapUnSortedAll.Rows[j]["pointx"].ToString()) + RatioX, Convert.ToUInt32(heatMapUnSortedAll.Rows[j]["pointy"].ToString()) + RatioY, 30, 30);

                        }
                    }
                }
                // Other color end

                if (tagDateLastMonth == tagDateFirstMonth)
                {
                    if (Month < LastDay)
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
                            tagDateFirstMonth = Convert.ToInt16(Convert.ToDateTime(FromDate == "" ? DateTime.Now.ToString() : FromDate).Month);
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
        }

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
        static public Bitmap fillPictureBox(PictureBox pbox, Bitmap bmp)
        {

            float scale = Math.Min((float)pbox.Width / (float)bmp.Width, (float)pbox.Height / (float)bmp.Height);
            int widthToScale = (int)(bmp.Width * scale);
            int heightToScale = (int)(bmp.Height * scale);
            float x = (pbox.Width - widthToScale) / 2;
            var resized = new Bitmap(pbox.Width, pbox.Height);
            var g = Graphics.FromImage(resized);
            if (pbox.Width > widthToScale)
            {
                g.DrawImage(bmp, x, 0, widthToScale, pbox.Height);

            }
            else
            {
                g.DrawImage(bmp, 0, 0, widthToScale, pbox.Height);
            }
            g.Dispose();
            pbox.Image = resized;
            return resized;
        }

        private void ButtonManage(bool isVisible)
        {
            // ai 4 ta show hobe kon butto
            ShowMapControls(isVisible);
            ShowHeatMapControls(!isVisible);
            ShowBarGraphControls(false);

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
            isQuizAnalyzing = true;
            txtAnalyzedData.SendToBack();
            chartWithData.SendToBack();
            pictureBox1.SendToBack();
            resultListView.BringToFront();
            //List<StoryInformation> gStoryINFOALl = new List<StoryInformation>();
            ChangeLocation();
            quizeAnsResult f2 = new quizeAnsResult(isQuizAnalyzing);
            f2.ShowDialog();
            ShowBarGraphControls(true);
            ShowMapControls(false);
            ShowHeatMapControls(false);
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
            QuizAnsInformationResult = f2.quizAnsInformationResultList;
            PopulateList(resultListView, f2.quizAnsInformationResultList);
        }

        private void PopulateList(System.Windows.Forms.ListView listViewQuiz, List<QuizAnsInformation> quizList, bool isQuiz = true)
        {
            ExportDataDictionary.Clear();
            listViewQuiz.Items.Clear();
            listViewQuiz.Columns.Clear();

            listViewQuiz.View = View.Details;
            listViewQuiz.HeaderStyle = ColumnHeaderStyle.Nonclickable;


            var quizHeader = new List<string>() { "Serial No." , "コンテンツID", "タイトル", "Corrent ans", "Incorrect ans", "正解率", "再生回数"};
            var guideHeader = new List<string>() { "Serial No.", "コンテンツID", "タイトル", "全部再生数", "一部再生数", "全部再生率", "再生回数"};

            if (isQuiz)
            {
                quizHeader.ForEach(head => listViewQuiz.Columns.Add(head));
            }
            else
            {
                guideHeader.ForEach(head => listViewQuiz.Columns.Add(head));
            }


            for (int i = 0; i < quizList.Count; i++)
            {
                var quizInfo = quizList[i];
                ListViewItem item = new ListViewItem($"{i+1}");
                //ListViewItem item = new ListViewItem(quizInfo.u32CID.ToString("X8"));
                item.SubItems.Add(quizInfo.u32CID.ToString("X8"));
                var title = "N/A";
                if (TitleDictionary.ContainsKey(quizInfo.u32CID.ToString()))
                {
                    title = TitleDictionary[quizInfo.u32CID.ToString()];
                }
                item.SubItems.Add(title);

                if (isQuiz)
                {
                    item.SubItems.Add(quizInfo.nCorrectAnsNum.ToString());
                    item.SubItems.Add((quizInfo.nTotalAccessNum - quizInfo.nCorrectAnsNum).ToString());
                }
                else
                {
                    item.SubItems.Add(quizInfo.nCompletedAns.ToString());
                    item.SubItems.Add((quizInfo.nTotalAccessNum - quizInfo.nCompletedAns).ToString());
                }

                item.SubItems.Add(string.Format("{0, 3}", isQuiz ? quizInfo.nCorrectRatio : quizInfo.nCompletedRatio) + "%  ");

                item.SubItems.Add(quizInfo.nTotalAccessNum.ToString());

                listViewQuiz.Items.Add(item);
                ExportDataDictionary.Add(GetDictinaryValue(quizInfo, title, isQuiz));
            }
            for (int i = 0; i < listViewQuiz.Columns.Count; i++)
            {
                listViewQuiz.Columns[i].AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);
            }
            resultListView.Visible = true;
        }

        private Dictionary<string, string> GetDictinaryValue(QuizAnsInformation qai, string quizTitle, bool isQuiz)
        {
            if (isQuiz)
            {
                return new Dictionary<string, string>
                                {
                                    { "コンテンツID", "-" + qai.u32CID.ToString("X8") },
                                    { "タイトル", quizTitle },
                                    { "Correct ans", qai.nCorrectAnsNum.ToString() },
                                    { "Incorrect ans", (qai.nTotalAccessNum - qai.nCorrectAnsNum).ToString() },
                                    { "正解率", string.Format("{0, 3}", qai.nCorrectRatio) + "%  " },
                                    { "再生回数", qai.nTotalAccessNum.ToString() },

                                };
            }
            else
            {
                return new Dictionary<string, string>
                                {
                                    { "コンテンツID", "-" + qai.u32CID.ToString("X8") },
                                    { "タイトル", quizTitle },
                                    { "全部再生数", qai.nCompletedAns.ToString() },
                                    { "一部再生数", (qai.nTotalAccessNum - qai.nCompletedAns).ToString() },
                                    { "全部再生率", string.Format("{0, 3}", qai.nCompletedRatio) + "%  " },
                                    { "再生回数", qai.nTotalAccessNum.ToString() },

                                };
            }

        }

        private void ButtonGuideClicked(object sender, EventArgs e)
        {
            ShowBarGraphControls(true);
            ShowHeatMapControls(false);
            ShowMapControls(false);
            isQuizAnalyzing = false;
            txtAnalyzedData.SendToBack();
            chartWithData.SendToBack();
            pictureBox1.SendToBack();
            //List<StoryInformation> gStoryINFOALl = new List<StoryInformation>();

            quizeAnsResult f2 = new quizeAnsResult(isQuizAnalyzing);
            f2.ShowDialog();
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
            PopulateList(resultListView, f2.quizAnsInformationResultList, false);
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
                chartWithData.Series["Series1"].IsVisibleInLegend = false;
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


                //chartWithData.Legends.Add(new Legend("Series1"));

                //// Set Docking of the Legend chart to the Default Chart Area.
                //chartWithData.Legends["Series1"].DockedToChartArea = "Default";

                //// Assign the legend to Series1.
                //chartWithData.Series["Series1"].Legend = "Legend2";
                //chartWithData.Series["Series1"].IsVisibleInLegend = true;
                chartWithData.Series["Series1"].MarkerSize = 10;
            }
        }
        
        public DataSet ToDataSet(List<QuizAnsInformation> list)
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            dt.TableName = "ChartTable";
            dt.Columns.Add("xPositionValue", typeof(string));
            dt.Columns.Add("yPositionIncorrect", typeof(string));
            dt.Columns.Add("yPositionCorrect", typeof(string));
            foreach (QuizAnsInformation sit in list)
            {
                for (int i = 0; i < dtBarGrapggStoryINFOALl.Rows.Count; i++)
                {
                    if (dtBarGrapggStoryINFOALl.Rows[i]["u32ContentID"].ToString() == sit.u32CID.ToString())
                    {
                        DataRow dtrRS = dt.NewRow();
                        dtrRS["xPositionValue"] = sit.u32CID.ToString("X8");
                        if (isQuizAnalyzing)
                        {
                            dtrRS["yPositionIncorrect"] = (sit.nTotalAccessNum - sit.nCorrectAnsNum).ToString();
                            dtrRS["yPositionCorrect"] = sit.nCorrectAnsNum.ToString();
                        }
                        else
                        {
                            dtrRS["yPositionIncorrect"] = (sit.nTotalAccessNum - sit.nCompletedAns).ToString();
                            dtrRS["yPositionCorrect"] = sit.nCompletedAns.ToString();
                        }
                        
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

        //private void buttonFLowLineAnalysis_Click(object sender, EventArgs e)
        //{
        //    HeatMapConsider = 1;
        //    var heatmapImageName = map_comboBox1.SelectedValue.ToString();
        //    HeatMapGraph f2 = new HeatMapGraph(heatmapImageName);
        //    var dialogResult = f2.ShowDialog();
        //    if (dialogResult == DialogResult.OK)
        //    {
        //        FromDate = HeatMapGraph.FromDate.Trim();
        //        ToDate = HeatMapGraph.ToDate.Trim();
        //        Type = HeatMapGraph.Type.Trim();
        //        int counter = HeatMapGraph.counter;
        //        dtTagNameAll = HeatMapGraph.dtTagNameAll;
        //        FirstDay = Convert.ToInt16(Convert.ToDateTime(FromDate).Day);
        //        LastDay = Convert.ToInt16(Convert.ToDateTime(ToDate).Day);
        //        TimeSpan diff = Convert.ToDateTime(ToDate) - Convert.ToDateTime(FromDate);
        //        double hours = diff.TotalHours;
        //        button＿MapEdit_Click(sender, e);
        //        ButtonManage(false);
        //        //map_comboBox1.SelectedIndex = 2;
        //        // GenerateHeatMap(heatmapImageName, HeatMapGraph.SelectedTags);
        //    }

        //}

        private void buttonFLowLineAnalysis_Click(object sender, EventArgs e)
        {
            var heatmapImageName = map_comboBox1.SelectedValue.ToString();
            HeatMapGraph f2 = new HeatMapGraph(heatmapImageName, Form1.workfolder);
            var dialogResult = f2.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                FromDate = HeatMapGraph.FromDate.Trim();
                //FromDate = "1/1/2023 12:00:00 AM";
                ToDate = HeatMapGraph.ToDate.Trim();
                //ToDate = "1/30/2023 12:00:00 AM";
                Type = HeatMapGraph.Type.Trim();
                isHourlyView = HeatMapGraph.IsHourlyView;
                int counter = HeatMapGraph.counter;
                dtTagNameAll = HeatMapGraph.dtTagNameAll;
                FirstDay = Convert.ToInt16(Convert.ToDateTime(FromDate).Day);
                LastDay = Convert.ToInt16(Convert.ToDateTime(ToDate).Day);
                lblFromDate.Text = Convert.ToDateTime(FromDate).ToShortDateString();
                lblToDate.Text = Convert.ToDateTime(ToDate).ToShortDateString();
                TimeSpan diff = Convert.ToDateTime(ToDate) - Convert.ToDateTime(FromDate);
                double hours = diff.TotalHours;
                ButtonManage(false);
                //GenerateHeatMap(heatmapImageName, HeatMapGraph.SelectedTags);
                //GenerateNewHeatMap(heatmapImageName, HeatMapGraph.SelectedTags);
                HeatMapGenerate(heatmapImageName, HeatMapGraph.SelectedTags);
            }

        }

        private void HeatMapGenerate(string heatmapImageName, List<string> selectedTags)
        {
            var image = Image.FromFile(workfolder + "Image\\" + heatmapImageName + ".jpeg", true);

            var currentMap = gitems.FirstOrDefault(x => x.MapFileName == heatmapImageName);
            var currentMapFilePath = workfolder + "Image\\" + heatmapImageName + ".jpeg";
            DataTable csvData = GetDataTabletFromCSVFile(workfolder + "Contentid.CSV");

            var allHeatMapList = new List<HeatMap>();
            var allHeatMapCordinatesList = new List<HeatMapCordinateDTO>();
            var filteredByDateTimeHeatMapList = new List<HeatMap>();

            Bitmap originalBitmap = new Bitmap(currentMapFilePath);
            var resizedImage = Common.FillPictureBox(pictureBox1, originalBitmap);

            Graphics painter = Graphics.FromImage(resizedImage);


            var mapTags = currentMap.taglist.Where(x => selectedTags.Contains(x.tagname));
            foreach (var taguSingle in mapTags)
            {
                for (int i = 0; i < csvData.Rows.Count; i++)
                {
                    string strDateTime = csvData.Rows[i]["Date"].ToString() + " " + csvData.Rows[i]["Time"].ToString();
                    DateTime dtDateTime = Convert.ToDateTime(Common.GetValidDateTime(strDateTime));
                    if (taguSingle.tagId.ToString() == csvData.Rows[i]["Id"].ToString())
                    {
                        HeatMap htMap = new HeatMap()
                        {
                            tagId = taguSingle.tagId,
                            tagname = taguSingle.tagname,
                            pointx = taguSingle.pointx,
                            pointy = taguSingle.pointy,
                            tagtype = taguSingle.tagtype,
                            tagDate = dtDateTime,
                        };

                        if (htMap.tagDate >= Convert.ToDateTime(FromDate) && htMap.tagDate <= Convert.ToDateTime(ToDate))
                        {
                            filteredByDateTimeHeatMapList.Add(htMap);
                        }
                    }
                }
            }
            Dictionary<String, int> tagCountCache = new Dictionary<String, int>();
            var tagWiseCount = GetClientCountFromHeatMapList(filteredByDateTimeHeatMapList);
            var maxClientCount = tagWiseCount.Max(x => x.CountOfClients);
            var dateWiseSortedList = filteredByDateTimeHeatMapList.OrderBy(x => x.tagDate).ToList();
            var heatMapWithImage = new List<HeatMapCordinateWithMapDTO>();
            for (DateTime date = DateTime.Parse(FromDate); date <= DateTime.Parse(ToDate); date = date.AddDays(1))
            {
                var currentDayTags = dateWiseSortedList.FindAll(x => x.tagDate.ToShortDateString().Equals(date.ToShortDateString()));
                if(currentDayTags != null && currentDayTags.Any())
                {
                    var perTagCountList = currentDayTags.GroupBy(x => x.tagname)
                                        .Select(x => new HeatMapCordinateDTO
                                        {
                                            Name = x.Key,
                                            CountOfClients = x.Count(),
                                            PointX = x.First().pointx,
                                            PointY = x.First().pointy,
                                            OccuredDate = x.First().tagDate,
                                            Id = x.First().tagId
                                        })
                                        .ToList();
                    for (int i = 0; i < perTagCountList.Count; i++)
                    {
                        var currentTag = perTagCountList[i];
                        if (tagCountCache.ContainsKey(currentTag.Id))
                        {
                            tagCountCache[currentTag.Id] = tagCountCache[currentTag.Id] + currentTag.CountOfClients;
                        }else
                        {
                            tagCountCache.Add(currentTag.Id, currentTag.CountOfClients);
                        }
                        Color color = GetColorToPlot(maxClientCount, tagCountCache[currentTag.Id]);
                        painter.FillEllipse(new SolidBrush(color), currentTag.PointX, currentTag.PointY, 30, 30);
                        heatMapWithImage.Add(new HeatMapCordinateWithMapDTO()
                        {
                            HeatMapCordinate = currentTag, 
                            MapImage = new Bitmap(resizedImage)
                        });
                    }
                } 
                else
                {
                    heatMapWithImage.Add(new HeatMapCordinateWithMapDTO()
                    {
                        HeatMapCordinate = new HeatMapCordinateDTO() 
                        {
                            OccuredDate = date
                        },
                        MapImage = new Bitmap(resizedImage)
                    });
                }
            }

            DrawFixedColorBar(15, graphics);

            this.heatMapCordinatesWithMap = heatMapWithImage;
            currentDate = DateTime.Parse(FromDate);

            this.prevButton.Visible = true;
            this.nextButton.Visible = true;

            timer = new Timer
            {
                Interval = timerStartPosition,
            };
            timerLabel.Text = timerStartPosition.ToString();
            timer.Tick += new EventHandler(ViewSingleCordinate);
            timer.Start();
            isPlayingHeadMap = true;
        }

        private Color GetColorToPlot(double maxAmount,double currentAmount)
        {
            double singleUnit = 255 / maxAmount;
            double redVal = currentAmount * singleUnit;
            if(redVal > 255)
            {
                redVal = 255;
            }
            var blueVal = 255 - redVal;
            var color = Color.FromArgb((int)Math.Round(redVal), 0, (int)Math.Round(blueVal));
            Console.WriteLine($"max - {maxAmount} current - {currentAmount} singleUnit - {singleUnit} color - {color}");
            return color;
        }

        private string getSpeedValue(bool isPlay, int speed)
        {
            var playPauseText = isPlay ? "Pause" : "Play";
            //return playPauseText;
            return $"{playPauseText} {speed / timerSpeed} X";
        }

        private void ChangeSpeed(bool isIncrease)
        {
            if (timer == null || !isPlayingHeadMap) return;
            if (isIncrease)
            {
                timer.Interval += timerSpeed;
            } 
            else
            {
                if (timer.Interval <= timerSpeed) return;
                timer.Interval -= timerSpeed;
            }
            //playPauseButton.Text = getSpeedValue(isPlayingHeadMap, timer.Interval);
            timerLabel.Text = timer.Interval.ToString();
        }

        private void TooglePlayPause()
        {
            if (timer == null) return;
            timerLabel.Text = timer.Interval.ToString();
            if (isPlayingHeadMap)
            {
                timer.Stop();
                playPauseButton.Text = "Play";
            }
            else
            {
                timer.Start();
                playPauseButton.Text = "Pause";
            }
            isPlayingHeadMap = !isPlayingHeadMap;
        }

        private void GenerateHeatMap(string heatmapImageName, List<string> selectedTagIds) 
        {
            var image = Image.FromFile(workfolder + "Image\\" + heatmapImageName + ".jpeg", true);

            var currentMap = gitems.FirstOrDefault(x => x.MapFileName == heatmapImageName);
            var currentMapFilePath = workfolder + "Image\\" + heatmapImageName + ".jpeg";
            DataTable csvData = GetDataTabletFromCSVFile(workfolder + "Contentid.CSV");

            var allHeatMapList = new List<HeatMap>();
            var allHeatMapCordinatesList = new List<HeatMapCordinateDTO>();
            var filteredByDateTimeHeatMapList = new List<HeatMap>();

            var mapTags = currentMap.taglist.Where(x => selectedTagIds.Contains(x.tagname));
            foreach(var taguSingle in mapTags)
            {
                for (int i = 0; i < csvData.Rows.Count; i++)
                {
                    string strDateTime = csvData.Rows[i]["Date"].ToString() + " " + csvData.Rows[i]["Time"].ToString();
                    DateTime dtDateTime = Convert.ToDateTime(Common.GetValidDateTime(strDateTime));
                    if (taguSingle.tagId.ToString() == csvData.Rows[i]["Id"].ToString())
                    {
                        HeatMap htMap = new HeatMap()
                        {
                            tagId = taguSingle.tagId,
                            tagname = taguSingle.tagname,
                            pointx = taguSingle.pointx,
                            pointy = taguSingle.pointy,
                            tagtype = taguSingle.tagtype,
                            tagDate = dtDateTime,
                        };

                        if (htMap.tagDate >= Convert.ToDateTime(FromDate) && htMap.tagDate <= Convert.ToDateTime(ToDate))
                        {
                            filteredByDateTimeHeatMapList.Add(htMap);
                        }

                        //allHeatMapList.Add(htMap);

                    } 
                }
            }

            var matchedTagWiseClientCount = GetClientCountFromHeatMapList(filteredByDateTimeHeatMapList);
            var foundTagIds = matchedTagWiseClientCount.Select(t => t.Name);
            var unmatchedHeatMaps = mapTags.Where(x => !foundTagIds.Contains(x.tagId))
                                      .Select(x => new HeatMap()
                                      {
                                          tagId = x.tagId,
                                          tagname = x.tagname,
                                          pointx = x.pointx,
                                          pointy = x.pointy,
                                          tagtype = x.tagtype,
                                          tagDate = DateTime.Now
                                      }).ToList();
            var unmatchedTagWiseClientCount = GetClientCountFromHeatMapList(unmatchedHeatMaps);

            allHeatMapCordinatesList.AddRange(matchedTagWiseClientCount);
            allHeatMapCordinatesList.AddRange(unmatchedTagWiseClientCount);
            allHeatMapCordinatesList = allHeatMapCordinatesList.OrderBy(x => x.OccuredDate).ToList();

            Bitmap originalBitmap = new Bitmap(currentMapFilePath);
            var resizedImage = Common.FillPictureBox(pictureBox1, originalBitmap);
            this.imageWithoutTags = new Bitmap(resizedImage);
            this.colors.Clear();
            StartHeatMapDrawAnimation(resizedImage, allHeatMapCordinatesList, pictureBox1);
        }

        private void GenerateNewHeatMap(string heatmapImageName, List<string> selectedTagIds)
        {
            var image = Image.FromFile(workfolder + "Image\\" + heatmapImageName + ".jpeg", true);

            var currentMap = gitems.FirstOrDefault(x => x.MapFileName == heatmapImageName);
            var currentMapFilePath = workfolder + "Image\\" + heatmapImageName + ".jpeg";
            DataTable csvData = GetDataTabletFromCSVFile(workfolder + "Contentid.CSV");

            var allHeatMapList = new List<HeatMap>();
            var allHeatMapCordinatesList = new List<HeatMapCordinateDTO>();
            var filteredByDateTimeHeatMapList = new List<HeatMap>();

            var mapTags = currentMap.taglist.Where(x => selectedTagIds.Contains(x.tagname));
            foreach (var taguSingle in mapTags)
            {
                for (int i = 0; i < csvData.Rows.Count; i++)
                {
                    string strDateTime = csvData.Rows[i]["Date"].ToString() + " " + csvData.Rows[i]["Time"].ToString();
                    DateTime dtDateTime = Convert.ToDateTime(Common.GetValidDateTime(strDateTime));
                    if (taguSingle.tagId.ToString() == csvData.Rows[i]["Id"].ToString())
                    {
                        HeatMap htMap = new HeatMap()
                        {
                            tagId = taguSingle.tagId,
                            tagname = taguSingle.tagname,
                            pointx = taguSingle.pointx,
                            pointy = taguSingle.pointy,
                            tagtype = taguSingle.tagtype,
                            tagDate = dtDateTime,
                        };

                        if (htMap.tagDate >= Convert.ToDateTime(FromDate) && htMap.tagDate <= Convert.ToDateTime(ToDate))
                        {
                            filteredByDateTimeHeatMapList.Add(htMap);
                        }
                    }
                }
            }

            var sortedHeatMapList = filteredByDateTimeHeatMapList.OrderBy(x => x.tagDate).ToList();
            var countsPerDayPerTagId = GetCountsPerDayPerTagId(sortedHeatMapList);

            Bitmap originalBitmap = new Bitmap(currentMapFilePath);
            var resizedImage = Common.FillPictureBox(pictureBox1, originalBitmap);
            this.imageWithoutTags = new Bitmap(resizedImage);
            this.colors.Clear();
            StartHeatMapDrawAnimation(resizedImage, countsPerDayPerTagId, pictureBox1);
        }

        private List<HeatMapCordinateDTO> GetClientCountFromHeatMapList(List<HeatMap> maps)
        {
            return maps
                .GroupBy(row => row.tagId)
                .OrderBy(group => group.Count())
                .Select(sales => new HeatMapCordinateDTO
                {
                    Name = sales.Key,
                    CountOfClients = sales.Count(),
                    PointX = sales.First().pointx,
                    PointY = sales.First().pointy,
                    OccuredDate = sales.First().tagDate
                })
                .ToList();
        }
        public static List<HeatMapCordinateDTO> GetCountsPerDayPerTagId(List<HeatMap> heatMapList)
        {
            return heatMapList
                .GroupBy(hm => new { hm.tagId, hm.tagDate.Date })
                .Select(group => new HeatMapCordinateDTO
                {
                    Name = group.First().tagname,
                    CountOfClients = group.Count(),
                    PointX = group.First().pointx,
                    PointY = group.First().pointy,
                    OccuredDate = group.Key.Date
                })
                .ToList();
        }

        public void DrawMultiColorRectangle(Graphics g, List<Color> colors, int startX, int startY, int width, int height)
        {
            colors.Sort((a,b) => a.R.CompareTo(b.R));
            //colors.InsertRange(0, new List<Color> { Color.Yellow });
            int colorHeight = height / colors.Count;

            startY += height;

            for (int i = colors.Count - 1; i >= 0; i--)
            {
                SolidBrush brush = new SolidBrush(colors[i]);
                g.FillRectangle(brush, startX, startY - (i * colorHeight), width, colorHeight);
                brush.Dispose();

                // Draw index beside color
                string indexText = i.ToString();
                Font font = new Font("Arial", 10);
                SolidBrush textBrush = new SolidBrush(Color.Black);
                g.DrawString(indexText, font, textBrush, startX + width + 5, startY - (i * colorHeight) + colorHeight / 2 - 8);
                font.Dispose();
                textBrush.Dispose();
            }
        }

        public void DrawFixedColorBar(int numberOfBarItem, Graphics graphics)
        {
            var barColors = new List<Color>();
            if(numberOfBarItem > 0)
            {
                var divideValue = 255 / numberOfBarItem;
                var redColorValue = 255;
                for (int i = 0; i < numberOfBarItem; i++)
                {
                    barColors.Add(Color.FromArgb(255, redColorValue, 0, 255 - redColorValue));
                    redColorValue -= divideValue;
                }
            }
            DrawMultiColorRectangle(graphics, barColors, 1630, -100, 30, 880);
        }

        public void StartHeatMapDrawAnimation(Bitmap imageToDrawTags, List<HeatMapCordinateDTO> heatMapCordinates, PictureBox pictureBox)
        {
            //generatedMaps.Clear();
            //this.imageToDrawTags = imageToDrawTags;
            ////this.heatMapCordinates = heatMapCordinates;
            //this.graphics = Graphics.FromImage(imageToDrawTags);

            if (heatMapCordinates.Any())
            {
                minNumberOfClient = heatMapCordinates.Min(x => x.CountOfClients);
                maxNumberOfClient = heatMapCordinates.Max(x => x.CountOfClients);

                if (maxNumberOfClient == minNumberOfClient)
                {
                    maxNumberOfClient++;
                }

                this.progBarTagLoad.Visible = true;
                this.lblProgBarTagLoadPercent.Visible = true;
                this.prevButton.Visible = true;
                this.nextButton.Visible = true;
                DrawFixedColorBar(15, Graphics.FromImage(imageToDrawTags));
                this.heatMapCordinatesWithMap = Common.DrawAllCordinates(imageToDrawTags, heatMapCordinates, minNumberOfClient, maxNumberOfClient);
                currentDate = DateTime.Parse(FromDate);

                timer = new Timer
                {
                    Interval = timerStartPosition,
                };
                timerLabel.Text = timerStartPosition.ToString();
                timer.Tick += new EventHandler(ViewSingleCordinate);
                timer.Start();
                isPlayingHeadMap = true;
            }
            else
            {
                MessageBox.Show("No data found");
                pictureBox.Image = imageToDrawTags;
            }


        }
        
        private void ViewSingleCordinate(object sender, EventArgs e)
        {
            Console.WriteLine(currentCordinateIndex);
            if (currentCordinateIndex < heatMapCordinatesWithMap.Count)
            {
                HeatMapCordinateDTO cordinate = heatMapCordinatesWithMap[currentCordinateIndex].HeatMapCordinate;
                currentDateLabel.Text = GetDateShowValue(isHourlyView, cordinate.OccuredDate);
                pictureBox1.Image = heatMapCordinatesWithMap[currentCordinateIndex].MapImage;
                currentCordinateIndex++;
                double parcentage = (double.Parse(currentCordinateIndex.ToString()) / double.Parse(heatMapCordinatesWithMap.Count.ToString())) * 100;
                Console.WriteLine(parcentage);
                ProgressBarTagLoad(parcentage);
            }
            else
            {
                ((Timer)sender).Stop();
            }
        }

        private string GetDateShowValue(bool withTime, DateTime dateTime)
        {
            var currentDateString = $"Current date: {dateTime.ToShortDateString()}";
            if (withTime)
            {
                currentDateString += $" Time : {dateTime.ToShortTimeString()}";
            }
            Console.WriteLine(currentDateString);
            return currentDateString;
        }

        private void button＿MapEdit_Click(object sender, EventArgs e)
        {
            //run koren
            ButtonManage(true);
            //ChangeLocation();

            pictureBox1.BringToFront();
            chartWithData.SendToBack();

            string fileName = workfolder + "Image\\obj";
            if (File.Exists(fileName))
            {
                gitems.Clear();
                gitems = (List<Map>)LoadFromBinaryFile(fileName); // load                             
                map_comboBox1.DataSource = gitems;
                map_comboBox1.DisplayMember = "MapName";
                map_comboBox1.ValueMember = "MapFileName";

                if (gitems.Count > 0)
                {
                    //map_comboBox1.SelectedIndex = -1;
                    map_comboBox1.SelectedIndex = 0;
                    lblCboImageName.Text = " MapName : " + map_comboBox1.Text + " MapFileName : " + map_comboBox1.SelectedValue.ToString();
                }
            }
            EnableMapSpecificButtons();
        }

       private void EnableMapSpecificButtons()
       {
            this.map_button.Enabled = false;
            this.add_map_button1.Enabled = true;
            this.delete_map_button8.Enabled = true;
            this.set_map_label1.Enabled = true;
            this.map_comboBox1.Enabled = true;
            this.Exit_map_edit_button9.Enabled = true;
       }

       private void ShowHeatMapControls(bool isVisible)
       {
            progBarTagLoad.Visible = isVisible;
            lblProgBarTagLoadPercent.Visible = isVisible;
            label1.Visible = isVisible;
            label2.Visible = isVisible;
            lblToDate.Visible = isVisible;
            lblFromDate.Visible = isVisible;
            animationControlGBox.Visible = isVisible;
            currentDateLabel.Visible = isVisible;
       }

        private void ShowMapControls(bool isVisible)
        {
            add_map_button1.Visible = isVisible;
            delete_map_button8.Visible = isVisible;
            set_map_label1.Visible = isVisible;
            Exit_map_edit_button9.Visible = isVisible;
            map_comboBox1.Visible = isVisible;
            map_button.Enabled = !isVisible;
            buttonFLowLineAnalysis.Visible = isVisible;
        }

        private void ShowBarGraphControls(bool isVisible)
        {
            BarGraphGroupBox.Visible = isVisible;
        }

        private void ChangeLocation()
       {
            //add_map_button1.Location = new Point(10, 300);
            //delete_map_button8.Location = new Point(10, 350);
            //map_comboBox1.Location = new Point(10, 400);
            //Exit_map_edit_button9.Location = new Point(10, 450);
            //lblTagNameTest.Location = new Point(10, 500);
            //prevButton.Location = new Point(10, 530);
            //prevButton.Location = new Point(10, 530);

            //ControlGroupBox.Location = new Point(0, 500);
            //chartWithData.Size = new Size(800, 400);

            //animationControlGBox.Location = new Point(10, 400);
            //animationControlGBox.BringToFront();

            //buttonSetup.Location = new Point(10, 300);
            //buttonExit.Location = new Point(10, 350);
        }
        private void AddMapImageAndFillPictureBoxWithResizedImage(object sender, EventArgs e)
       {
            // New Picturbox
            OpenFileDialog opnfd = new OpenFileDialog();
            opnfd.Filter = "Image Files (*.jpg;*.jpeg;.*.gif;)|*.jpg;*.jpeg;.*.gif";
            // pick the image from Computer folder
            if (opnfd.ShowDialog() == DialogResult.OK)
            {
                string MapFileName = opnfd.FileName;
                InputMapName map_name = new InputMapName();
                map_name.ShowDialog();              
                //imageFileName = InputMapName.fileName.Trim();
                lblimage.Visible = false;
                var itemsNo = 1;
                var path = workfolder + "Image\\";
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                string destinationPath = workfolder + "Image\\" + (gitems.Count + itemsNo).ToString() + ".jpeg";
                string MapFilename = (gitems.Count + itemsNo).ToString();
                while (File.Exists(destinationPath))
                {
                    destinationPath = workfolder + "Image\\" + (gitems.Count +itemsNo).ToString() + ".jpeg";
                    MapFilename = (gitems.Count + itemsNo).ToString();
                    itemsNo++;
                }
                filePathNew = destinationPath;
                lblimage.Text = MapFilename;
                File.Copy(MapFileName, destinationPath);
                string mapName = InputMapName.fileName;
                Map map = new Map(MapFilename, mapName);
                taglist.Clear();
                gitems.Add(map);
                pictureBox1.Image = Image.FromFile(MapFileName);
                Bitmap bmap = new Bitmap(MapFileName);
                pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
                Common.FillPictureBox(pictureBox1, bmap);
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

            var mapForDelete = gitems.FirstOrDefault(r => r.MapFileName== itemFileName);
            if(mapForDelete != null)
            {
                gitems.Remove(mapForDelete);
                map_comboBox1.SelectedIndex = 0;
                pictureBox1.Dispose();
            }
            
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

                        TempAns.dtStartTime = dtDeviceDate;

                        u8Second = bs[nPos + 1];//ss
                        u8Minute = bs[nPos + 2];//mm
                        u8Hour = bs[nPos + 3]; //hh


                        s2 = u8Hour.ToString() + ":" + u8Minute.ToString() + ":" + u8Second.ToString();
                        //文字列をDateTime値に変換する
                        dtStart = DateTime.Parse(s2);

                        TempAns.u32CID = u32CID;
                        
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
                        TempAns.dtStartTime = dtDeviceDate;

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
                PopulateList(resultListView, QuizAnsInformationResult.OrderBy(x => x.nTotalAccessNum).ToList(), isQuizAnalyzing);
            }
            else if (rdoQuizId.Checked)
            {
                PopulateList(resultListView, QuizAnsInformationResult.OrderBy(x => x.u32CID).ToList(), isQuizAnalyzing);

            }
            else
            {
                PopulateList(resultListView, QuizAnsInformationResult);
            }
        }

        private void SetupChartSeriesConfig(string seriesName)
        {
            chartWithData.Series[seriesName]["PixelPointWidth"] = 50.ToString();
            chartWithData.Series[seriesName].IsValueShownAsLabel = true;
            chartWithData.Series[seriesName].LabelForeColor = System.Drawing.Color.Red;
            chartWithData.Series[seriesName].Font = new Font(FontFamily.GenericSansSerif, 14, FontStyle.Bold);
            chartWithData.Series[seriesName].SmartLabelStyle.Enabled = false;
            chartWithData.Series[seriesName]["LabelPlacement"] = "Inside";
        }

        //private void btnBarGraph_Click(object sender, EventArgs e)
        //{
        //    chartWithData.BringToFront();
        //    pictureBox1.SendToBack();
        //    txtAnalyzedData.SendToBack();

        //    //List<StoryInformation> gStoryINFOALl = new List<StoryInformation>();

        //    //ExpRankResult Err = new ExpRankResult();
        //    //Err.ShowDialog();
        //    //gStoryINFOALl = ExpRankResult.gStoryINFO;
        //    if (BarGrapggStoryINFOALl.Count != 0)
        //    {
        //        DataSet ds = ToDataSet(BarGrapggStoryINFOALl);
        //        chartWithData.DataSource = ds;
        //        //var name = chartWithData.Series;
        //        chartWithData.Series["Series1"].XValueMember = "xPositionValue";
        //        chartWithData.Series["Series2"].YValueMembers = "yPositionCorrect";
        //        chartWithData.Series["Series1"].YValueMembers = "yPositionIncorrect";
        //        chartWithData.DataBind();
        //        //chartWithData.Series["Series1"]["PixelPointWidth"] = maxWidth.ToString();
        //        //chartWithData.Series["Series2"]["PixelPointWidth"] = maxWidth.ToString();
        //        chartWithData.Series["Series1"].IsValueShownAsLabel = true;
        //        chartWithData.Series["Series2"].IsValueShownAsLabel = true;
        //        chartWithData.Series["Series1"].Color = System.Drawing.Color.Red;
        //        //chartWithData.Series["Series2"].IsValueShownAsLabel = true;
        //        //chartWithData.Series["Series1"].LabelForeColor = System.Drawing.Color.Red;
        //        //chartWithData.Series["Series1"].Font = new Font(FontFamily.GenericSansSerif, 14, FontStyle.Bold);
        //        //chartWithData.Series["Series1"].SmartLabelStyle.Enabled = false;
        //        //chartWithData.Series["Series1"]["LabelPlacement"] = "Inside";
        //        //chartWithData.ChartAreas[0].AxisX.Interval = 1;
        //        //chartWithData.ChartAreas[0].AxisY.LabelStyle.Angle = 0; // Horizontal labels
        //        //chartWithData.ChartAreas[0].AxisX.LabelStyle.Angle = 0; // Horizontal labels


        //        //for (int i = 0; i < chartWithData.Series["Series1"].Points.Count; i++)
        //        //{
        //        //    DataPoint dataPoint = chartWithData.Series["Series1"].Points[i];
        //        //    var y = dataPoint.YValues[0];
        //        //    var val = BarGrapggStoryINFOALl.Where(x => x.nTotalAccessNum == y).FirstOrDefault()?.u32CID.ToString();
        //        //    var label = "";
        //        //    if (!string.IsNullOrWhiteSpace(val) && TitleDictionary.ContainsKey(val))
        //        //    {
        //        //        label = TitleDictionary[val];
        //        //        dataPoint.Label = "  " + label;
        //        //    }

        //        //    if (y > 100)
        //        //    {
        //        //        dataPoint.LabelAngle = 90;
        //        //        dataPoint.LabelForeColor = System.Drawing.Color.White;

        //        //    }

        //        //}

        //        if (chartWithData.Titles.Count == 0)
        //        {
        //            chartWithData.Titles.Add("Museum Chart");
        //        }

        //        chartWithData.Series["Series1"].IsVisibleInLegend = true;
        //        chartWithData.Series["Series1"].MarkerSize = 10;
        //    }

        //}

        private void btnBarGraph_Click(object sender, EventArgs e)
        {
            chartWithData.BringToFront();
            pictureBox1.SendToBack();
            txtAnalyzedData.SendToBack();
            chartWithData.Series["Correct"].Points.Clear();
            chartWithData.Series["Incorrect"].Points.Clear();

            List<string> selectedIDs = dtBarGrapggStoryINFOALl.AsEnumerable()
                                                .Where(row => row["u32ContentID"] != DBNull.Value)
                                                .Select(row => row["u32ContentID"].ToString())
                                                .ToList();
            var selectedItemsForChart = BarGrapggStoryINFOALl.Where(x => selectedIDs.Contains(x.u32CID.ToString())).ToList();
            if (selectedItemsForChart.Count != 0)
            {
                for (int i = 0; i < selectedItemsForChart.Count; i++)
                {
                    var sit = selectedItemsForChart[i];
                    //var xValue = $"{sit.u32CID}({i + 1})";
                    var xValue = $"{i + 1}";
                    if (isQuizAnalyzing)
                    {
                        var incorrectVal = (sit.nTotalAccessNum - sit.nCorrectAnsNum).ToString();
                        var correctVal = sit.nCorrectAnsNum.ToString();
                        chartWithData.Series["Correct"].Points.AddXY(xValue, correctVal);
                        chartWithData.Series["Incorrect"].Points.AddXY(xValue, incorrectVal);

                    }
                    else
                    {
                        var incompleteVal = (sit.nTotalAccessNum - sit.nCompletedAns).ToString();
                        var completeVal = sit.nCompletedAns.ToString();
                        chartWithData.Series["Correct"].Points.AddXY(xValue, completeVal);
                        chartWithData.Series["Incorrect"].Points.AddXY(xValue, incompleteVal);
                    }
                }

                chartWithData.Series["Incorrect"].Color = System.Drawing.Color.Red;
                chartWithData.Series["Correct"].Color = System.Drawing.Color.SkyBlue;
                chartWithData.Series["Incorrect"].IsValueShownAsLabel = true;
                chartWithData.Series["Correct"].IsValueShownAsLabel = true;
                chartWithData.Series["Correct"].IsXValueIndexed = true;
                chartWithData.ChartAreas[0].AxisX.Interval = 1;
                chartWithData.ChartAreas[0].AxisX.IsMarginVisible = false;

                if (chartWithData.Titles.Count == 0)
                {
                    chartWithData.Titles.Add("Museum Chart");
                }
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
            AddTagOnImage(tagType: 2);
        }

        private void SetTagNameAndIdFromTagPopUpDialog()
        {
            tagaddC TAC = new tagaddC();
            TAC.ShowDialog();
            tagID = tagaddC.ID;
            tagName = tagaddC.Name;
        }

        private void AddTagOnImage(int tagType = 1)
        {
            SetTagNameAndIdFromTagPopUpDialog();
            if (!string.IsNullOrWhiteSpace(tagName) && !string.IsNullOrWhiteSpace(tagID))
            {
                string mapFileName;
                string mapFilePath;

                if (lblimage.Text != "")
                {
                    mapFileName = lblimage.Text;
                    mapFilePath = filePathNew;
                }
                else
                {
                    mapFileName = map_comboBox1.SelectedValue.ToString();
                    mapFilePath = workfolder + "Image\\" + mapFileName + ".jpeg";
                }

                Map mapItem = new Map("", "");

                for (int i = 0; i < gitems.Count; i++)
                {
                    if (gitems[i].MapFileName == mapFileName)
                    {
                        mapItem = gitems[i];
                        var tags = new List<tagu>();
                        tags.Add(new tagu()
                        {
                            pointx = xMouseRightClick,
                            pointy = yMouseRightClick,
                            tagname = tagName,
                            tagId = tagID,
                            tagtype = tagType
                        });
                        tags.AddRange(mapItem.taglist);
                        mapItem.taglist = tags;
                    }

                }
                RedrawMapAndUpdateTagList(mapFilePath, mapItem.taglist);
                SetLatestMapData(mapFileName, mapItem.taglist);

            }
        }
        
        private void コンテンツToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddTagOnImage(tagType: 1);
        }

        private void PlayPauseButtonClick(object sender, EventArgs e)
        {
            TooglePlayPause();
        }

        private void SpeedPlusButtonClick(object sender, EventArgs e)
        {
            ChangeSpeed(true);
        }

        private void SpeedMinusButtonClick(object sender, EventArgs e)
        {
            ChangeSpeed(false);
        }

        private void ReplayButtonClick(object sender, EventArgs e)
        {
            if (HeatMapGraph.SelectedTags.Count <= 0) return;
            generatedMaps.Clear();
            currentCordinateIndex = 0;
            ButtonManage(false);
            timerStartPosition = timer == null ? timerStartPosition : timer.Interval;
            timer.Start();
        }

        private void PrevButtonClick(object sender, EventArgs e)
        {
            if(currentCordinateIndex > 1)
            {
                currentCordinateIndex -= 2;
                ViewSingleCordinate(timer, null);
            }

        }

        private void NextButtonClick(object sender, EventArgs e)
        {
            ViewSingleCordinate(timer, null);
        }

        private void RedrawMapAndUpdateTagList(string mapFilePath, List<tagu> tags)
        {
            Bitmap OriginalBitmap = new Bitmap(mapFilePath);
            var resizedImage = Common.FillPictureBox(pictureBox1, OriginalBitmap);
            Bitmap copiedResizedImage = new Bitmap(resizedImage);
            Common.DrawImageAndTags(workfolder, copiedResizedImage, tags, pictureBox1);
        }

        private Bitmap RedrawMapAndUpdateTagListAndGetCopiedFile(string mapFilePath, List<tagu> tags)
        {
            Bitmap OriginalBitmap = new Bitmap(mapFilePath);
            var resizedImage = Common.FillPictureBox(pictureBox1, OriginalBitmap);
            Bitmap copiedResizedImage = new Bitmap(resizedImage);
            Common.DrawImageAndTags(workfolder, copiedResizedImage, tags, pictureBox1);
            return copiedResizedImage;
        }

        private void SetLatestMapData(string mapFileName, List<tagu> tags)
        {
            var targetMap = gitems.FirstOrDefault(o => o.MapFileName == mapFileName);
            targetMap.taglist = tags;
            gitems = gitems.Where(o => o.MapFileName != mapFileName).ToList();
            gitems.Add(targetMap);
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
            
            var clickedXPosition = xMouseRightClick;
            var clickedYPosition = yMouseRightClick;

            foreach (tagu taguSingle in taglist)
            {
                if (taguSingle.pointx + 20 >= clickedXPosition && taguSingle.pointx - 20 <= clickedXPosition)
                {
                    if (taguSingle.pointy + 20 >= clickedYPosition && taguSingle.pointy - 20 <= clickedYPosition)
                    {
                        return new Rectangle(taguSingle.pointx, taguSingle.pointy, 50, 50);
                    }
                }
            }
            
            return new Rectangle(0, 0, 0, 0);
        }
        // February
        private void 削除ToolStripMenuItem_Click(object sender, EventArgs e)
        {          

            int clickedXPoint = xMouseRightClick;
            int clickedYPoint = yMouseRightClick;

            foreach (tagu taguSingle in taglist)
            {
                if (taguSingle.pointx + 10 >= clickedXPoint && taguSingle.pointx - 10 <= clickedXPoint)
                {
                    if (taguSingle.pointy + 10 >= clickedYPoint && taguSingle.pointy - 10 <= clickedYPoint)
                    {
                        DialogResult result = MessageBox.Show("本当に削除しますか？", "質問",MessageBoxButtons.OKCancel);
                        if(result == DialogResult.OK)
                        {
                            var targetTag = taglist.Where(o => o.tagId == taguSingle.tagId);
                            taglist = taglist.Except(targetTag).ToList();
                            string mapFileName = map_comboBox1.SelectedValue.ToString();
                            var mapFilePath = workfolder + "Image\\" + mapFileName + ".jpeg";
                            RedrawMapAndUpdateTagList(mapFilePath, taglist);
                            SetLatestMapData(mapFileName, taglist);
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
