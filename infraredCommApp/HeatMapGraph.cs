using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace infraredCommApp
{
    public partial class HeatMapGraph : Form
    {
        public static string FromDate = string.Empty;
        public static string ToDate = string.Empty;
        public static string Type = string.Empty;
        public static string[] TagNameAll ;
        public static int counter =0;
        public static DataTable dtTagNameAll = new DataTable();

        List<Map> gitems = new List<Map>();
        public static List<tagu> taglist = new List<tagu>();       
        public static string workfolder = "";
        public static DataTable HeatMapSorted = new DataTable();
        public static DataTable HeatMapUnSorted = new DataTable();
        static int PictureBoxActualWidth;
        static int PictureBoxActualHeight;
        public HeatMapGraph()
        {
            InitializeComponent();
            string fileName = "C:\\testfolder\\Image\\obj";
            workfolder = "C:\\testfolder\\";
            gitems = null;
            gitems = (List<Map>)LoadFromBinaryFile(fileName);

            //InitializeComponent();
            //workfolder = "C:\\testfolder\\";
            //string name = "5";
            //PictureBox.Image = Image.FromFile(workfolder + "Image\\" + name + ".jpeg", true);
        }

        //private void buttonFLowLineAnalysis_Click(object sender, EventArgs e)
        //{
        //    //DDia f2 = new DDia();
        //    //f2.Show();
        //    quizeAnsResult f2 = new quizeAnsResult();
        //    f2.Show();
        //}
        //private void button6_Click(object sender, EventArgs e)
        //{
        //    dateTimePicker1.Value = DateTime.Now;
        //    dateTimePicker2.Value = DateTime.Now;

        //    checkBox1.Checked = false;
        //}

        private void button1_Click(object sender, EventArgs e)
        {
            //TagLocationSet();
            //GetItemsData();
            //counter = listBoxAllData.SelectedItems.Count;
            //for (int i = 0; i < listBoxAllData.SelectedItems.Count; i++)
            //{
            //    //if (listBoxAllData.Items[i]. == true)
            //        TagNameAll[i] = listBoxAllData.Items[i].ToString();
            //}
            int m = -1;
            //DataTable dtTagNameAll = new DataTable();

            dtTagNameAll.Columns.Add("TagNameAll", typeof(String));

            //foreach (DataRow row in dt.Rows)
            //{
            //    //need to set value to NewColumn column
            //    row["NewColumn"] = 0;   // or set it to some other value
            //}
            //DataRow userRow = dt.NewRow();

            

            foreach (var item in listBoxAllData.SelectedItems.Cast<DataRowView>())
            {
                
                DataRow dRow = dtTagNameAll.NewRow();
                string k= item.Row[1].ToString();
                dRow["TagNameAll"] = item.Row[1].ToString();
                //counter= counter+1;
                dtTagNameAll.Rows.Add(dRow);
            }
           // counter = m;


               

            if (cmbType.SelectedItem.ToString() == "Hour")
            {
                FromDate = Convert.ToString(dtFromDate.Value.Date + dtFromDateTime.Value.TimeOfDay);
                ToDate = Convert.ToString(dtToDate.Value.Date + dtToDateTime.Value.TimeOfDay);
            }
            else
            {
                FromDate = Convert.ToString(dtFromDate.Value.Date);
                ToDate = Convert.ToString(dtToDate.Value.Date);
            }
            Type = cmbType.SelectedItem.ToString();
            TagLocationSet();
            workfolder = "C:\\testfolder\\";
            //PictureBox
            #region Image
            string name = "5";
            int width = PictureBox.Width;
            int height = PictureBox.Height;
            PictureBox.Image = Image.FromFile(workfolder + "Image\\" + name + ".jpeg", true);


            var filePath = workfolder + "Image\\" + name + ".jpeg";
            Bitmap bmap = new Bitmap(filePath);

            if (Width < PictureBox.Image.Width || height < PictureBox.Image.Height)
            {
                this.PictureBox.Size = new System.Drawing.Size(PictureBoxActualWidth, PictureBoxActualHeight);
                PictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            else
            {
                PictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
                fillPictureBox(PictureBox, bmap, width, height);
            }

            Bitmap OriginalBitmap = new Bitmap(filePath);

            float scale = Math.Min((float)width / (float)OriginalBitmap.Width, (float)height / (float)OriginalBitmap.Height);
            int widthToScale = (int)(OriginalBitmap.Width * scale);
            int heightToScale = (int)(OriginalBitmap.Height * scale);
            float x1 = (width - widthToScale) / 2;
            var resized = new Bitmap(PictureBox.Width, PictureBox.Height);
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
            PictureBox.Image = resized;

            //var resized = new Bitmap(PictureBox.Width, PictureBox.Height);
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
                            g1.DrawImage(arrowBitmap1, new Point(taguSingle.pointx, taguSingle.pointy));
                        }
                        else if (taguSingle.tagtype == 2)
                        {
                            g2.DrawImage(arrowBitmap, new Point(taguSingle.pointx, taguSingle.pointy));
                        }
                    }

                    foreach (tagu taguSingle in item.taglist)
                    {
                        // January Test                       
                        mapTagName = mapTagName + " " + taguSingle.tagname;
                    }

                }

            }

            // Heat Map

            // COlor
            System.Drawing.Color c = System.Drawing.ColorTranslator.FromHtml("#F5F7F8");
            String strHtmlColor = System.Drawing.ColorTranslator.ToHtml(c);

            string[] BlueColor = { "#ccd9ff", "#b3c6ff", "#99b3ff", "#809fff", "#668cff", "#4d79ff", "#3366ff", "#1a53ff", "#0040ff", "#0039e6" };
            string[] RedColor = { "#ffcccc", "#ffb3b3", "#ff9999", "#ff8080", "#ff8080", "#ff6666", "#3366ff", "#ff4d4d", "#ff3333", "#ff1a1a" };


            Graphics gs = Graphics.FromImage(copy);

            if (name == "5")
            {
                int colorCountBlue = 9;
                for (int i = 0; i < HeatMapSorted.Rows.Count / 2; i++)
                {
                    for (int j = 0; j < HeatMapUnSorted.Rows.Count; j++)
                    {
                        if (HeatMapSorted.Rows[i]["Name"].ToString() == HeatMapUnSorted.Rows[j]["tagId"].ToString())
                        {
                            if (colorCountBlue < 0)
                            {
                                colorCountBlue = 0;
                            }
                            //Color c1 = Color.FromArgb(100, Color.Blue);
                            Color c1 = Color.FromArgb(100, System.Drawing.ColorTranslator.FromHtml(BlueColor[colorCountBlue]));
                            gs.FillEllipse(new SolidBrush(c1), Convert.ToUInt32(HeatMapUnSorted.Rows[j]["pointx"].ToString()), Convert.ToUInt32(HeatMapUnSorted.Rows[j]["pointy"].ToString()), 30, 30);
                            colorCountBlue--;
                        }
                    }
                }

                int colorCountRed = 9;
                for (int i = HeatMapSorted.Rows.Count - 1; i > HeatMapSorted.Rows.Count / 2; i--)
                {
                    for (int j = 0; j < HeatMapUnSorted.Rows.Count; j++)
                    {
                        if (HeatMapSorted.Rows[i]["Name"].ToString() == HeatMapUnSorted.Rows[j]["tagId"].ToString())
                        {
                            //Color c1 = Color.FromArgb(100, Color.Red);
                            if (colorCountRed < 0)
                            {
                                colorCountRed = 0;
                            }
                            Color c1 = Color.FromArgb(100, System.Drawing.ColorTranslator.FromHtml(RedColor[colorCountRed]));
                            //g.FillEllipse(System.Drawing.ColorTranslator.FromHtml(RedColor[colorCountRed]), Convert.ToUInt32(HeatMapUnSorted.Rows[j]["pointx"].ToString()), Convert.ToUInt32(HeatMapUnSorted.Rows[j]["pointy"].ToString()), 30, 30);
                            gs.FillEllipse(new SolidBrush(c1), Convert.ToUInt32(HeatMapUnSorted.Rows[j]["pointx"].ToString()), Convert.ToUInt32(HeatMapUnSorted.Rows[j]["pointy"].ToString()), 30, 30);
                            colorCountRed--;
                        }
                    }
                }
            }

            PictureBox.Image = copy;
            #endregion

            this.Close();


        }
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
        void TagLocationSet()
        {
            string FilePath = workfolder + "Contentid.CSV";
            DataTable csvData = GetDataTabletFromCSVFile(FilePath);


            string name = "";
            name = "3";
            var targetMap = gitems.Where(o => o.MapFileName == name);
            string mapTagName = "";
            Map map = new Map("", "");
            List<HeatMap> HeatMapList = new List<HeatMap>();
            foreach (var item in targetMap)
            {
                map = new Map(item.MapFileName, item.MapName);
                if (item.taglist != null)
                {
                    taglist = item.taglist;
                    foreach (tagu taguSingle in item.taglist)
                    {
                        //for (int i = 0; i < csvData.Rows.Count; i++)
                        //{
                        //    if (taguSingle.tagId.ToString() == csvData.Rows[i]["Id"].ToString())
                        //    {
                                HeatMap htMap = new HeatMap();
                                htMap.tagId = taguSingle.tagId;
                                htMap.tagname = taguSingle.tagname;
                                htMap.pointx = taguSingle.pointx;
                                htMap.pointy = taguSingle.pointy;
                                htMap.tagtype = taguSingle.tagtype;
                                HeatMapList.Add(htMap);
                        //    }
                        //}

                    }

                    foreach (HeatMap htMap in HeatMapList)
                    {
                        // March Test
                        HeatMap htMap2 = new HeatMap();
                        htMap2 = htMap;
                    }
                    var table = ListToDataTable(HeatMapList);
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
                                .GroupBy(r => new { tagId = r["tagId"], tagname = r["tagname"], pointx = r["pointx"], pointy = r["pointy"] })
                                .Select(g =>
                                {
                                    var row = table.NewRow();

                                    //row["PK"] = g.Min(r => r.Field<int>("PK"));
                                    row["tagId"] = g.Key.tagId;
                                    row["tagname"] = g.Key.tagname;
                                    row["pointx"] = g.Key.pointx;
                                    row["pointy"] = g.Key.pointy;

                                    return row;

                                })
                                .CopyToDataTable();
                    HeatMapUnSorted = query2;
                    // print result

                    HeatMapSorted = CreateDataTable(query);
                    foreach (var salesman in query)
                    {
                        var s = salesman;
                        //Console.WriteLine("{0}\t{1}", salesman.Name, salesman.CountOfClients);
                    }

                }
            }
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
            foreach (HeatMap item in list)
            {
                DataRow dtrRS = dt.NewRow();
                //dtrRS["xPositionValue"] = sit.u32CID.ToString("X8");
                //dtrRS["yPositionValue"] = sit.nTotalAccessNum.ToString();
                dtrRS["tagId"] = item.tagId;
                dtrRS["tagname"] = item.tagname;
                dtrRS["pointx"] = item.pointx;
                dtrRS["pointy"] = item.pointy;
                dtrRS["tagtype"] = item.tagtype;
                dt.Rows.Add(dtrRS);
            }
            //ds.Tables.Add(dt);
            return dt;
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
        //public DataTable ListToDataTable(List<HeatMap> list)
        //{
        //    //DataSet ds = new DataSet();
        //    DataTable dt = new DataTable();
        //    dt.TableName = "ChartTable";
        //    dt.Columns.Add("tagId", typeof(string));
        //    dt.Columns.Add("pointx", typeof(string));
        //    dt.Columns.Add("pointy", typeof(string));
        //    dt.Columns.Add("tagtype", typeof(string));
        //    foreach (HeatMap item in list)
        //    {
        //        DataRow dtrRS = dt.NewRow();
        //        //dtrRS["xPositionValue"] = sit.u32CID.ToString("X8");
        //        //dtrRS["yPositionValue"] = sit.nTotalAccessNum.ToString();
        //        dtrRS["tagId"] = item.tagId;
        //        dtrRS["pointx"] = item.pointx;
        //        dtrRS["pointy"] = item.pointy;
        //        dtrRS["tagtype"] = item.tagtype;
        //        dt.Rows.Add(dtrRS);
        //    }
        //    //ds.Tables.Add(dt);
        //    return dt;
        //}
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

        private void GetItemsData()
        {
            string FilePath = workfolder + "Contentid.CSV";
            DataTable csvData = GetDataTabletFromCSVFile(FilePath);
            string name = "";
            name = "3";
            var targetMap = gitems.Where(o => o.MapFileName == name);
            string mapTagName = "";
            Map map = new Map("", "");
            //map = targetMap.;
            listBoxAllData.DataSource = HeatMapUnSorted;
            listBoxAllData.DisplayMember = "tagname";
            listBoxAllData.ValueMember = "tagId";
            listBoxAllData.SelectionMode = SelectionMode.MultiSimple;

            //string fileName = workfolder + "Image\\obj";
            //if (File.Exists(fileName))
            //{
            //    //List<Map> gitem = (List<Map>)LoadFromBinaryFile(fileName); // load 
            //    gitems = null;
            //    gitems = (List<Map>)LoadFromBinaryFile(fileName); // load                 
            //  listBoxAllData.DataSource = gitems;
            //    listBoxAllData.DisplayMember = "MapName";
            //    listBoxAllData.ValueMember = "MapFileName";
            //    listBoxAllData.SelectionMode = SelectionMode.MultiSimple;
            //}
        }
        private void HeatMapGraph_Load(object sender, EventArgs e)
        {
            PictureBoxActualWidth = PictureBox.Width;
            PictureBoxActualHeight = PictureBox.Height;
            //InitializeComponent();
            dtFromDateTime.Format = DateTimePickerFormat.Time;
            dtFromDateTime.ShowUpDown = true;
            dtToDateTime.Format = DateTimePickerFormat.Time;
            dtToDateTime.ShowUpDown = true;
            dtFromDateTime.Visible = false;
            dtToDateTime.Visible = false;
            dtFromDate.Visible = false;
            dtToDate.Visible = false;
            button2.Visible = false;
            button1.Visible = false;
            cmbType.SelectedIndex = 1;

            TagLocationSet();
            GetItemsData();


        }

        private void HeatMapGraph_Click(object sender, EventArgs e)
        {

        }

        private void cmbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbType.SelectedItem.ToString() == "Hour")
            {
                dtFromDateTime.Visible = true;
                dtToDateTime.Visible = true;
                dtFromDate.Visible = true;
                dtToDate.Visible = true;

                button2.Visible = true;
                button1.Visible = true;
            }
            else
            {
                dtFromDate.Visible = true;
                dtToDate.Visible = true;
                dtFromDateTime.Visible = false;
                dtToDateTime.Visible = false;

               

                button2.Visible = true;
                button1.Visible = true;

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //private void button1_Click(object sender, EventArgs e)
        //{

        //}

        //private void btnShow_Click_1(object sender, EventArgs e)
        //{

        //}

    }
}
