using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using Microsoft.VisualBasic.FileIO;
using System.Linq;
using System.Collections;

namespace infraredCommApp
{
    public partial class quizeAnsResult : Form
    {

        public static List<QuizAnsInformation> gQuizAnsINFO = new List<QuizAnsInformation>();
        public static DataTable dtQuizeTitle = new DataTable();

        public static DataTable gconINFOSortedByQuizeID = new DataTable();
        public static DataTable gconINFOSortedByAccurate = new DataTable();
        public static DataTable gconINFOSortedByAccurateNTotal = new DataTable();

        public string AnalyzedData = "";
        public string rdoQuizId;
        public string rdoAccurate;

        //public List<Dictionary<string, string>> dictionaryByID = new List<Dictionary<string, string>>();
        //public List<Dictionary<string, string>> dictionaryByAccurate = new List<Dictionary<string, string>>();
        //public List<Dictionary<string, string>> dictionaryByALL = new List<Dictionary<string, string>>();
        public Dictionary<string, string> titleDictionary = new Dictionary<string, string>();

        public List<QuizAnsInformation> quizAnsInformationResultList = new List<QuizAnsInformation>();

        // GLOBAL DEFINES
        public static string appName = "FlowLine2022";
        public static string logpath = "";
        public static string workfolder = "";
        public static string workfolder2 = "";
        public static string ibcfolder = "";
        public static List<ContentPlayingInfo> gContPLAY = new List<ContentPlayingInfo>();
        public static List<contentsInfo> gconINFO = new List<contentsInfo>(); // list for content information
        //public bool bQuiz;
        //public UInt32 u32ContentID;
        //public string strIbcPath;
        //public int nCorrectAns;
        //public string strQuiz;
        //public string strAnswer;
        //public string strTitle;
        //global variables for function

        string gstrQuizP = "";
        string gstrQuizA = "";
        int gnAns = 0;

        private bool _isQuiz = true;


        public quizeAnsResult(bool isQuiz)
        {
            _isQuiz = isQuiz;
            InitializeComponent();
            this.Text = isQuiz ? "Aggregation for Quiz" : "Aggregation for Guide";

            //For Quize Title
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
            ibcfolder=$"C:\\{Form1.workfolder}\\IBCQ\\";
            if (Directory.Exists(Form1.ibcfolder))
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
                    if (fep_Search_AnswerNo(szFilePath) == _isQuiz)
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
                }
            }

            GetlistBoxItemsData();
        }
        private void GetlistBoxItemsData()
        {
            var table = ListToDataTable(gconINFO);
            //public bool bQuiz;
            //public UInt32 u32ContentID;
            //public string strIbcPath;
            //public int nCorrectAns;
            //public string strQuiz;
            //public string strAnswer;
            //public string strTitle;

            var query2 = table.AsEnumerable()
                            .GroupBy(r => new { u32ContentID = r["u32ContentID"], strTitle = r["strTitle"] })
                            .Select(g =>
                            {
                                var row = table.NewRow();
                                row["u32ContentID"] = g.Key.u32ContentID;
                                row["strTitle"] = g.Key.strTitle;
                                return row;
                            })
                            .CopyToDataTable();
            DataTable dtQuizeData = query2;

            listBoxAllData.DataSource = dtQuizeData;
            listBoxAllData.DisplayMember = "strTitle";
            listBoxAllData.ValueMember = "u32ContentID";
            listBoxAllData.SelectionMode = SelectionMode.MultiSimple;


            //var HeatMapSorted = CreateDataTable(query);

            //var SortedByQuizeID = table.AsEnumerable()
            //       .GroupBy(r => new { CountIndividual = r["u32ContentID"] })
            //       .Select(g =>
            //       {
            //           var row = table.NewRow();

            //           //row["PK"] = g.Min(r => r.Field<int>("PK"));
            //           row["u32ContentID"] = g.Key.CountIndividual;

            //           return row;

            //       })
            //       .CopyToDataTable();


            ////var SortedByQuizeID = from row in table.AsEnumerable()
            ////  group row by row.Field<string>("u32ContentID") into sales
            ////  orderby sales.
            ////                      select new
            ////  {
            ////      Name = sales.Key,
            ////      CountOfClients = sales.Count().ToString()

            ////  };
            //SortedByQuizeID.DefaultView.Sort = "u32ContentID ASC";
            //var SortedByQuizeIDNew = SortedByQuizeID.DefaultView.ToTable();

            //gconINFOSortedByQuizeID = SortedByQuizeID;


            //var SortedByAccurate= table.AsEnumerable()
            //    .GroupBy(r => new { CountIndividual = r["u32ContentID"] })
            //    .Select(g =>
            //    {
            //        var row = table.NewRow();

            //        //row["PK"] = g.Min(r => r.Field<int>("PK"));
            //        row["u32ContentID"] = g.Key.CountIndividual;

            //        return row;

            //    })
            //    .CopyToDataTable();
            //gconINFOSortedByAccurate = SortedByAccurate;


            //////var SortedByQuizeID = ListToDataTableForSorting(gconINFO);

            //////SortedByQuizeID.DefaultView.Sort = "u32ContentID ASC";
            //////var SortedByQuizeIDNew = SortedByQuizeID.DefaultView.ToTable();

            //////gconINFOSortedByQuizeID = SortedByQuizeIDNew;

            //////var SortedByAccurate = ListToDataTableForSorting(gconINFO);
            //////SortedByAccurate.DefaultView.Sort = "nCorrectAns ASC";
            //////var SortedByAccurateNew = SortedByAccurate.DefaultView.ToTable();
            //////gconINFOSortedByAccurate = SortedByAccurateNew;


          

        }
        public DataTable ListToDataTableForSorting(List<contentsInfo> list)
        {
            DataTable dt = new DataTable();
            dt.TableName = "ChartTable";
            dt.Columns.Add("u32ContentID", typeof(int));
            dt.Columns.Add("strTitle", typeof(string));
            dt.Columns.Add("nCorrectAns", typeof(int));
            foreach (contentsInfo item in list)
            {
                try
                {
                    DataRow dtrRS = dt.NewRow();
                    dtrRS["u32ContentID"] = item.u32ContentID;
                    dtrRS["strTitle"] = item.strTitle;
                    dtrRS["nCorrectAns"] = item.nCorrectAns;
                    dt.Rows.Add(dtrRS);
                }
                catch
                {

                }

            }
            return dt;
        }
        public DataTable ListToDataTableForSortingAccurate(List<QuizAnsInformation> list)
        {
            DataTable dt = new DataTable();
            dt.TableName = "ChartTable";
            dt.Columns.Add("u32CID", typeof(int));
            dt.Columns.Add("nTotalAccessNum", typeof(int));
            dt.Columns.Add("nMaxUsedTime", typeof(int));

            dt.Columns.Add("nMinUsedTime", typeof(int));
            dt.Columns.Add("nTotalUsedTime", typeof(int));
            dt.Columns.Add("nAverageUsedTime", typeof(int));
            dt.Columns.Add("nCorrectRatio", typeof(int));
            foreach (QuizAnsInformation item in list)
            {
                DataRow dtrRS = dt.NewRow();
                dtrRS["u32CID"] = item.u32CID;
                dtrRS["nTotalAccessNum"] = item.nTotalAccessNum;
                dtrRS["nMaxUsedTime"] = item.nMaxUsedTime;

                dtrRS["nMinUsedTime"] = item.nMinUsedTime;
                dtrRS["nTotalUsedTime"] = item.nTotalUsedTime;
                dtrRS["nAverageUsedTime"] = item.nMaxUsedTime;
                dtrRS["nCorrectRatio"] = item.nCorrectRatio;


                dt.Rows.Add(dtrRS);
            }
            return dt;
        }
        public DataTable ListToDataTable(List<contentsInfo> list)
        {
            //DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            dt.TableName = "ChartTable";
            dt.Columns.Add("u32ContentID", typeof(string));
            dt.Columns.Add("strTitle", typeof(string));
            //dt.Columns.Add("pointx", typeof(string));
            //dt.Columns.Add("pointy", typeof(string));
            //dt.Columns.Add("tagtype", typeof(string));
            foreach (contentsInfo item in list)
            {
                DataRow dtrRS = dt.NewRow();
                //dtrRS["xPositionValue"] = sit.u32CID.ToString("X8");
                //dtrRS["yPositionValue"] = sit.nTotalAccessNum.ToString();
                dtrRS["u32ContentID"] = item.u32ContentID;
                dtrRS["strTitle"] = item.strTitle;
                //dtrRS["pointx"] = item.pointx;
                //dtrRS["pointy"] = item.pointy;
                //dtrRS["tagtype"] = item.tagtype;
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
        //Haze
        private void quizprocess()
        {
            if (gQuizAnsINFO.Count == 0) return;
            //show the result to the listbox
            textBox1.Clear();
            dtQuizeTitle.Columns.Clear();
            if (radioButton2.Checked == true)
            {
                // show at quiz ID
                gQuizAnsINFO.Sort(delegate (QuizAnsInformation qai1, QuizAnsInformation qai2) { return (qai2.nTotalAccessNum) - qai1.nTotalAccessNum; });

            }
            else if (radioButton1.Checked)
            {
                // show at quiz correct ratio
                gQuizAnsINFO.Sort(delegate (QuizAnsInformation qai1, QuizAnsInformation qai2)
                { return qai2.nCorrectRatio - qai1.nCorrectRatio; });


            }
            else
            {
                gQuizAnsINFO.Sort(delegate (QuizAnsInformation qai1, QuizAnsInformation qai2)
                { return qai1.u32CID.CompareTo(qai2.u32CID); });

            }

            dtQuizeTitle.Columns.Add("strTitle", typeof(String));           
            dtQuizeTitle.Columns.Add("u32ContentID", typeof(String));           

            foreach (var item in listBoxAllData.SelectedItems.Cast<DataRowView>())
            {

                DataRow dRow = dtQuizeTitle.NewRow();
                string k = item.Row[1].ToString();
                dRow["strTitle"] = item.Row[1].ToString();
                dRow["u32ContentID"] = item.Row[0].ToString();
                //counter= counter+1;
                //listBoxAllData.DisplayMember = "strTitle";
                //listBoxAllData.ValueMember = "u32ContentID";

                dtQuizeTitle.Rows.Add(dRow);
                titleDictionary.Add(item.Row[0].ToString(), item.Row[1].ToString());
            }

            string szTemp1 = "";
            quizAnsInformationResultList.Clear();
            foreach (QuizAnsInformation qai in gQuizAnsINFO)
            {
                for (int i = 0; i < dtQuizeTitle.Rows.Count; i++)
                {
                    if (dtQuizeTitle.Rows[i]["u32ContentID"].ToString() == qai.u32CID.ToString())
                    {
                        szTemp1 += "コンテンツID:" + qai.u32CID.ToString("X8") + "  "
                        + "正解率:" + string.Format("{0, 3}", qai.nCorrectRatio) + "%  "
                        + "利用回数:" + qai.nTotalAccessNum.ToString()
                        + "\r\n";
                        //dictionaryByALL.Add(GetDictinaryValue(qai));
                        quizAnsInformationResultList.Add(qai);
                    }

                }

            }
            textBox1.Text = szTemp1;
            AnalyzedData = szTemp1;

            
            this.Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {

            //give a summary of the quiz answer result
            //CSV file output
            gQuizAnsINFO.Clear();

            bool bFound = false;

            textBox1.Text = "";



            // get the period information for calculateion

            DateTime dtLOGStart, dtLOGEnd;
            string d, f;

            f = "yyyy-MM-dd HH:mm:ss";

            DateTime dtStart, dtEnd;

            var dateStartCheckboxValue = dateTimePicker1.Value.Date.ToString("yyyy-MM-dd") + " 00:00:01";
            dtStart = DateTime.ParseExact(dateStartCheckboxValue, f, null);

            var dateEndCheckboxValue = dateTimePicker2.Value.Date.ToString("yyyy-MM-dd") + " 23:59:59";
            dtEnd = DateTime.ParseExact(dateEndCheckboxValue, f, null);

            if (checkBox1.Checked == false)
            {
                int nCompanre;

                nCompanre = System.DateTime.Compare(dtEnd, dtStart);

                if (nCompanre == -1)
                {
                    MessageBox.Show("正しい期間をしてください。");
                    return;

                }

                dtLOGStart = dtStart;
                dtLOGEnd = dtEnd;
            }
            else
            {

                dtLOGStart = DateTime.MinValue;
                dtLOGEnd = DateTime.MaxValue;
            }




            // begin calculation
            string loginfopath = Form1.workfolder + "ContentPlayResult.csv";

            if (File.Exists(loginfopath) == false)
            {
                MessageBox.Show("コンテンツ再生記録ファイルがありません");
                return;

            }


            StreamReader sr = new StreamReader(loginfopath, Encoding.GetEncoding("Shift_JIS"));

            string text;
            string szTemp1;

            UInt32 u32CIDTemp = 0;
            int nUsedTimeTemp = 0, EndMode = 0;
            DateTime dtUsedTiming;
            bool bQuizTemp = false;
            bool bCorrectAnsTemp = false;
            int nInputAns2;

            text = sr.ReadLine();//skip the head

            while (sr.Peek() > -1)
            {

                text = sr.ReadLine();

                if (text == "") break;

                var firstRowData = text.Split(',');

                // analysis this line
                //skip the user SN

                //get the CID
                u32CIDTemp = Convert.ToUInt32(firstRowData[1], 16);

                // date
                dtUsedTiming = Common.GetValidDateTime(firstRowData[2] + " " + firstRowData[3]);

                // content using  timing
                nUsedTimeTemp = int.Parse(firstRowData[4]);

                EndMode = int.Parse(firstRowData[5]);

                // get Quiz mode
                bQuizTemp = bool.Parse(firstRowData[6]);

                // get Answer Correct mode
                bCorrectAnsTemp = bool.Parse(firstRowData[7]);

                // get input answer No
                nInputAns2 = int.Parse(firstRowData[8]);

                //if this is not quiz, we skip this line record
                // if (bQuizTemp == true) continue;

                //if (nInputAns2 == 0) continue; //uncompleted answer record, ignore it

                int nCompanre;

                //check date 
                if (checkBox1.Checked == false)
                {

                    nCompanre = System.DateTime.Compare(dtStart, dtUsedTiming);

                    if (nCompanre >= 1) continue;

                    nCompanre = System.DateTime.Compare(dtUsedTiming, dtEnd);

                    if (nCompanre >= 1) continue;

                }
                else
                {
                    nCompanre = System.DateTime.Compare(dtLOGStart, dtUsedTiming);
                    if (nCompanre >= 1)
                    {
                        dtLOGStart = dtUsedTiming;
                    }

                    nCompanre = System.DateTime.Compare(dtLOGEnd, dtUsedTiming);
                    if (nCompanre < 0)
                    {
                        dtLOGEnd = dtUsedTiming;
                    }

                }

                bool bFound2 = false;

                bFound = true;

                // check the content quiz answer condition
                foreach (QuizAnsInformation qai in gQuizAnsINFO)
                {

                    //if the content quiz is in list already
                    if (qai.u32CID == u32CIDTemp)
                    {
                        // already exist, we only modify it
                        qai.nTotalAccessNum++;

                        if (bCorrectAnsTemp) qai.nCorrectAnsNum++;
                        if (EndMode == 0) qai.nCompletedAns++;

                        qai.nTotalUsedTime += nUsedTimeTemp;

                        if (qai.nMaxUsedTime < nUsedTimeTemp) qai.nMaxUsedTime = nUsedTimeTemp;

                        if (qai.nMinUsedTime > nUsedTimeTemp) qai.nMinUsedTime = nUsedTimeTemp;

                        qai.nAverageUsedTime = qai.nTotalUsedTime / qai.nTotalUsedTime;

                        qai.nCorrectRatio = (qai.nCorrectAnsNum * 100) / qai.nTotalAccessNum;
                        qai.nCompletedRatio = (qai.nCompletedAns * 100) / qai.nTotalAccessNum;

                        bFound2 = true;

                        break;

                    }

                }// new foreach

                if (bFound2 == false)
                {
                    //no such record CID, we will add new one for it
                    // add a new one to the list
                    QuizAnsInformation qaiTemp = new QuizAnsInformation();

                    qaiTemp.nTotalAccessNum++;

                    if (bCorrectAnsTemp) qaiTemp.nCorrectAnsNum++;
                    if (EndMode == 0) qaiTemp.nCompletedAns++;

                    qaiTemp.nTotalUsedTime += nUsedTimeTemp;

                    qaiTemp.u32CID = u32CIDTemp;

                    if (qaiTemp.nMaxUsedTime < nUsedTimeTemp) qaiTemp.nMaxUsedTime = nUsedTimeTemp;

                    if (qaiTemp.nMinUsedTime > nUsedTimeTemp) qaiTemp.nMinUsedTime = nUsedTimeTemp;

                    qaiTemp.nAverageUsedTime = qaiTemp.nTotalUsedTime / qaiTemp.nTotalUsedTime;

                    qaiTemp.nCorrectRatio = (qaiTemp.nCorrectAnsNum * 100) / qaiTemp.nTotalAccessNum;

                    gQuizAnsINFO.Add(qaiTemp);

                }


            }
            sr.Close();


            if (bFound == false)
            {


                MessageBox.Show("集計条件を満たす結果がありませんでした。");
                return;


            }

            // Lagbe
            quizprocess();


        }

        private void button6_Click_1(object sender, EventArgs e)
        {

        }//funciton end

        private void buttonOK_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBoxAllData.ClearSelected();
        }

        private void btnSelectAll_Click(object sender, EventArgs e)
        { 
            for (int i = 0; i < listBoxAllData.Items.Count; i++)
            {
                listBoxAllData.SetSelected(i, true);
            }
        }
    }
}
