using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace infraredCommApp
{
    public class Common
    {
        // Mr Paul
        public static List<T> ReadCsvFile<T>(string filePath, Func<string[], T> mappingFunc)
        {
            List<T> data = new List<T>();

            using (var reader = new StreamReader(filePath))
            {
                string line;
                bool isFirstLine = true;

                while ((line = reader.ReadLine()) != null)
                {
                    if (isFirstLine)
                    {
                        isFirstLine = false;
                        continue; // Skip the header line
                    }

                    string[] fields = line.Split(',');
                    try
                    {
                        T item = mappingFunc(fields);
                        data.Add(item);
                    }
                    catch
                    {

                    }

                }
            }

            return data;
        }

        // Mr Paul
        public static void WriteCsvFile<T>(List<T> data, string filePath)
        {
            using (var writer = new StreamWriter(filePath))
            {
                var properties = typeof(T).GetProperties().ToList();

                writer.WriteLine(string.Join(",", properties.Select(p => p.Name)));

                for (int i = data.Count - 1; i >= 0; i--)
                {
                    T item = data[i];
                    string line = string.Join(",", properties.Select(p => {
                        var val = p.GetValue(item);
                        if (val != null && val.GetType() == typeof(DateTime))
                        {
                            return ((DateTime)val).ToString("dd/MM/yyyy");
                        }
                        else
                        {
                            return p.GetValue(item)?.ToString();
                        }
                    }));
                    writer.WriteLine(line);
                }
            }
        }

        // Mr Paul
        public static void ExportToCsv(List<Dictionary<string, string>> data)
        {
            if (data == null || data.Count == 0)
            {
                throw new ArgumentException("Data cannot be null or empty.");
            }

            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "CSV File (*.csv)|*.csv";
                saveFileDialog.DefaultExt = "csv";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = saveFileDialog.FileName;
                    var columnHeaders = data.First().Keys.ToList();
                    var csvContent = new List<string>();
                    csvContent.Add(string.Join(",", columnHeaders));
                    foreach (var rowData in data)
                    {
                        var rowValues = columnHeaders.Select(header => rowData.ContainsKey(header) ? rowData[header] : string.Empty);
                        csvContent.Add(string.Join(",", rowValues));
                    }
                    File.WriteAllLines(filePath, csvContent, Encoding.UTF8);
                    MessageBox.Show("CSV file exported successfully!");
                }
            }
        }

        // Mr Paul
        public static List<ContentPlayResultModel> ReadCsvFile(string filePath)
        {
            List<ContentPlayResultModel> data = new List<ContentPlayResultModel>();

            using (var reader = new StreamReader(filePath))
            {
                string line;
                bool isFirstLine = true;

                while ((line = reader.ReadLine()) != null)
                {
                    if (isFirstLine)
                    {
                        isFirstLine = false;
                        continue; // Skip the header line
                    }

                    string[] fields = line.Split(',');

                    try
                    {
                        ContentPlayResultModel csvData = new ContentPlayResultModel
                        {
                            UserSN = int.Parse(fields[0]),
                            ContentID = int.Parse(fields[1]),
                            Date = DateTime.ParseExact(fields[2], "dd/MM/yyyy", CultureInfo.InvariantCulture),
                            Time = TimeSpan.Parse(fields[3]),
                            PlayTime = int.Parse(fields[4]),
                            EndMode = int.Parse(fields[5]),
                            IsQuiz = bool.Parse(fields[6]),
                            IsCorrectAns = bool.Parse(fields[7]),
                            InputedAns = int.Parse(fields[8])
                        };
                        data.Add(csvData);
                    }
                    catch
                    {
                    }

                }
            }

            return data;
        }

        // Mr Paul
        static public DateTime GetValidDateTime(string dateTimeString)
        {
            if (DateTime.TryParse(dateTimeString, out DateTime parsedDateTime))
            {
                return parsedDateTime;
            }
            else
            {
                var invalidDateString = dateTimeString.Split('/');
                dateTimeString = $"{invalidDateString[1]}/{invalidDateString[0]}/{invalidDateString[2]}";
                return DateTime.Parse(dateTimeString);
            }
        }

        // Mr Paul
        static public void PopulateListView<T>(ListView listView, List<T> dataList)
        {
            if (dataList == null || dataList.Count == 0)
            {
                throw new ArgumentException("Data cannot be null or empty.");
            }

            listView.Items.Clear();
            listView.Columns.Clear();

            listView.View = View.Details;
            listView.HeaderStyle = ColumnHeaderStyle.Nonclickable;

            var properties = typeof(T).GetProperties().ToList();

            foreach (var property in properties)
            {
                listView.Columns.Add(property.Name, 100); // Set the default column width to 100
            }

            foreach (var dataItem in dataList)
            {
                ListViewItem item = new ListViewItem();

                foreach (var property in properties)
                {
                    var propertyValue = property.GetValue(dataItem, null);
                    if (property.Name == "u32CID")
                    {
                        item.SubItems.Add(((UInt32) propertyValue).ToString("X8"));
                    }
                    else
                    {
                        item.SubItems.Add(propertyValue.ToString());
                    }
                }
                listView.Items.Add(item);
            }
        }
        // Mr Paul
        static public Bitmap FillPictureBox(PictureBox pbox, Bitmap bmp)
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

        // Mr Paul
        static public void DrawImageAndTags(String workfolder, Bitmap imageToDrawTags, List<tagu> taglist, PictureBox pictureBox)
        {
            Bitmap arrowBitmap1 = new Bitmap(workfolder + "Resources\\1.png");
            Bitmap arrowBitmap2 = new Bitmap(workfolder + "Resources\\2.png");

            Graphics graphics = Graphics.FromImage(imageToDrawTags);

            foreach (tagu taguSingle in taglist)
            {
                if (taguSingle.tagtype == 1)
                {
                    graphics.DrawImage(arrowBitmap1, new Point(taguSingle.pointx, taguSingle.pointy));
                }
                else if (taguSingle.tagtype == 2)
                {
                    graphics.DrawImage(arrowBitmap2, new Point(taguSingle.pointx, taguSingle.pointy));
                }
            }

            pictureBox.Image = imageToDrawTags;
        }


        //private void doForOnly5(Bitmap resizedImage, string mapFileName)
        //{
        //    Bitmap arrowBitmap = new Bitmap(workfolder + "Resources\\2.png");
        //    Bitmap copy = new Bitmap(resizedImage);
        //    Graphics g2 = Graphics.FromImage(copy);
        //    Bitmap arrowBitmap1 = new Bitmap(workfolder + "Resources\\1.png");
        //    Graphics g1 = Graphics.FromImage(copy);
        //    var targetMap = gitems.Where(o => o.MapFileName == mapFileName);
        //    Map map = new Map("", "");
        //    string mapTagName = "";
        //    foreach (var item in targetMap)
        //    {
        //        if (item.taglist != null)
        //        {
        //            taglist = item.taglist;
        //            foreach (tagu taguSingle in item.taglist)
        //            {
        //                if (taguSingle.tagtype == 1)
        //                {
        //                    // g1.DrawImage(arrowBitmap1, new Point(taguSingle.pointx, taguSingle.pointy));
        //                    g1.DrawImage(arrowBitmap1, new Point(taguSingle.pointx + Convert.ToInt32((Convert.ToDouble(taguSingle.pointx) * 0.365)), taguSingle.pointy + Convert.ToInt32((Convert.ToDouble(taguSingle.pointy) * 0.30))));
        //                }
        //                else if (taguSingle.tagtype == 2)
        //                {
        //                    // g2.DrawImage(arrowBitmap, new Point(taguSingle.pointx, taguSingle.pointy));
        //                    g2.DrawImage(arrowBitmap, new Point(taguSingle.pointx + Convert.ToInt32((Convert.ToDouble(taguSingle.pointx) * 0.365)), taguSingle.pointy + Convert.ToInt32((Convert.ToDouble(taguSingle.pointy) * 0.30))));
        //                }
        //                mapTagName = mapTagName + " " + taguSingle.tagname;
        //                lblTagNameTest.Text = mapTagName;
        //            }


        //        }
        //    }

        //}

        //private void doAsGeneric(Bitmap resizedImage, string mapFileName)
        //{

        //    var targetMap = gitems.Where(o => o.MapFileName == mapFileName);
        //    foreach (var item in targetMap)
        //    {
        //        if (item.taglist != null)
        //        {
        //            taglist = item.taglist;
        //            Common.DrawImageAndTags(workfolder, new Bitmap(resizedImage), taglist, pictureBox1);

        //        }
        //    }
        //}

        //private void AllWorkDoneForImage5(string mapFileName, Bitmap imageToDraw, DataTable dtTagNameAllOwn, int divider, int div, int position, int positionYellow)
        //{
        //    Graphics imageGraphics = Graphics.FromImage(imageToDraw);

        //    if (mapFileName == "5")
        //    {
        //        if (Type == "Day")
        //        {
        //            lblFromDate.Text = Convert.ToDateTime(FromDate).Date.ToString("dd/MM/yyyy");
        //            lblToDate.Text = Convert.ToDateTime(ToDate).Date.ToString("dd/MM/yyyy");
        //        }
        //        else
        //        {
        //            lblFromDate.Text = FromDate;
        //            lblToDate.Text = ToDate;
        //        }


        //        int colorCountBlue = 9;
        //        int colorCountRGB = 0;
        //        string Count = "";

        //        for (int i = 0; i < HeatMapSorted.Rows.Count; i++)
        //        {

        //            for (int j = 0; j < HeatMapUnSorted.Rows.Count; j++)
        //            {

        //                //double Ni, Nmin, Nmax, Vr, Vb,X;
        //                for (int m = 0; m < HeatMapSortedIndividual.Rows.Count; m++)
        //                {
        //                    int dividerPosition;
        //                    dividerPosition = 800 / HeatMapSortedIndividual.Rows.Count;

        //                    Nmin = Convert.ToInt32(HeatMapSortedIndividual.Rows[0]["CountOfClients"].ToString());
        //                    Nmax = Convert.ToInt32(HeatMapSortedIndividual.Rows[HeatMapSortedIndividual.Rows.Count - 1]["CountOfClients"].ToString());
        //                    if (Nmax == Nmin)
        //                    {
        //                        Nmax = Nmax + 1;
        //                    }
        //                    Ni = ((Convert.ToInt32(HeatMapSortedIndividual.Rows[m]["CountOfClients"].ToString()) - Nmin) / (Nmax - Nmin)) * 100;
        //                    //X = Ni;
        //                    Vr = (Ni * 255) / 100;
        //                    Vb = ((100 - Ni) * 255) / 100;
        //                    if (Vr > 255)
        //                    {
        //                        Vr = 255;
        //                    }
        //                    else if (Vr < 0)
        //                    {
        //                        Vr = 0;
        //                    }
        //                    if (Vb > 255)
        //                    {
        //                        Vb = 255;
        //                    }
        //                    else if (Vb < 0)
        //                    {
        //                        Vb = 0;
        //                    }
        //                    if (HeatMapSorted.Rows[i]["Name"].ToString() == HeatMapUnSorted.Rows[j]["tagId"].ToString() && HeatMapSorted.Rows[i]["CountOfClients"].ToString() == HeatMapSortedIndividual.Rows[m]["CountOfClients"].ToString())
        //                    {
        //                        int u = Convert.ToInt16(Convert.ToDateTime(HeatMapUnSorted.Rows[j]["tagDate"].ToString()).Month);
        //                        lblMonth.Text = tagDateFirstMonth.ToString();
        //                        //lblDate.Text = HeatMapUnSorted.Rows[j]["tagDate"].ToString();
        //                        for (int htm = tagInitialDateFirstMonth; htm <= tagDateFirstMonth; htm++)
        //                        {
        //                            //Days

        //                            if (Type == "Day")
        //                            {
        //                                for (int htn = FirstDay; htn <= Month; htn++)
        //                                {
        //                                    lblDate.Text = htn.ToString() + "/" + htm.ToString() + "/" + "2023";
        //                                    int day = Convert.ToInt16(Convert.ToDateTime(HeatMapUnSorted.Rows[j]["tagDate"].ToString()).Day);
        //                                    if (htm == Convert.ToInt16(Convert.ToDateTime(HeatMapUnSorted.Rows[j]["tagDate"].ToString()).Month) && htn == day)
        //                                    {

        //                                        if (colorCountBlue < 0)
        //                                        {
        //                                            colorCountBlue = 0;
        //                                        }
        //                                        int fg = 0;// Lagbe
        //                                        for (int dti = 0; dti < dtTagNameAll.Rows.Count; dti++)
        //                                        {
        //                                            fg = 0;
        //                                            string tgn1 = HeatMapUnSorted.Rows[j]["tagname"].ToString();
        //                                            string tgn2 = dtTagNameAll.Rows[dti]["TagNameAll"].ToString();
        //                                            if (HeatMapUnSorted.Rows[j]["tagname"].ToString() == dtTagNameAll.Rows[dti]["TagNameAll"].ToString())
        //                                            {
        //                                                Color c1 = Color.FromArgb(200, Convert.ToInt32(Vr), 0, Convert.ToInt32(Vb));
        //                                                //gs.FillEllipse(new SolidBrush(c1), Convert.ToUInt32(HeatMapUnSorted.Rows[j]["pointx"].ToString()), Convert.ToUInt32(HeatMapUnSorted.Rows[j]["pointy"].ToString()), 30, 30);
        //                                                int RatioX = Convert.ToInt32((Convert.ToDouble(Convert.ToUInt32(HeatMapUnSorted.Rows[j]["pointx"].ToString())) * 0.365));
        //                                                int RatioY = Convert.ToInt32((Convert.ToDouble(Convert.ToUInt32(HeatMapUnSorted.Rows[j]["pointy"].ToString())) * 0.30));
        //                                                imageGraphics.FillEllipse(new SolidBrush(c1), Convert.ToUInt32(HeatMapUnSorted.Rows[j]["pointx"].ToString()) + RatioX, Convert.ToUInt32(HeatMapUnSorted.Rows[j]["pointy"].ToString()) + RatioY, 30, 30);
        //                                                //Convert.ToInt32((Convert.ToDouble(taguSingle.pointx) * 0.365))
        //                                                string id = HeatMapSorted.Rows[i]["Name"].ToString();
        //                                                string x = HeatMapUnSorted.Rows[j]["pointx"].ToString();
        //                                                string y = HeatMapUnSorted.Rows[j]["pointy"].ToString();
        //                                                fg = 1;

        //                                                DataRow dRow = dtTagNameAllOwn.NewRow();
        //                                                string k = tgn1;
        //                                                dRow["TagNameAll"] = tgn1;
        //                                                //counter= counter+1;
        //                                                dtTagNameAllOwn.Rows.Add(dRow);
        //                                            }

        //                                        }
        //                                        //if(fg==0)
        //                                        //{
        //                                        //    Color c2 = Color.FromArgb(255, 255, 0);
        //                                        //    gs.FillEllipse(new SolidBrush(c2), Convert.ToUInt32(HeatMapUnSorted.Rows[j]["pointx"].ToString()), Convert.ToUInt32(HeatMapUnSorted.Rows[j]["pointy"].ToString()), 30, 30);

        //                                        //    string id = HeatMapSorted.Rows[i]["Name"].ToString();
        //                                        //    string x = HeatMapUnSorted.Rows[j]["pointx"].ToString();
        //                                        //    string y = HeatMapUnSorted.Rows[j]["pointy"].ToString();

        //                                        //}
        //                                    }
        //                                }
        //                            }
        //                            else
        //                            {
        //                                for (int htn = FirstDay; htn <= Month; htn++)
        //                                {
        //                                    // Hour
        //                                    for (int hto = 1; hto <= HourCount; hto++)
        //                                    {
        //                                        //lblDate.Text = htn.ToString() + "/" + htm.ToString() + "/" + "2023";
        //                                        string time = Convert.ToDateTime(HeatMapUnSorted.Rows[j]["tagDate"].ToString()).TimeOfDay.ToString();
        //                                        //lblDate.Text = htn.ToString() + "/" + htm.ToString() + "/" + "2023 "+ time;
        //                                        int day = Convert.ToInt16(Convert.ToDateTime(HeatMapUnSorted.Rows[j]["tagDate"].ToString()).Day);
        //                                        int hour = Convert.ToInt16(Convert.ToDateTime(HeatMapUnSorted.Rows[j]["tagDate"].ToString()).Hour);
        //                                        lblDate.Text = htn.ToString() + "/" + htm.ToString() + "/" + "2023 " + hto.ToString() + ":00:00";

        //                                        if (htm == Convert.ToInt16(Convert.ToDateTime(HeatMapUnSorted.Rows[j]["tagDate"].ToString()).Month) && htn == day && hto == hour)
        //                                        {

        //                                            if (colorCountBlue < 0)
        //                                            {
        //                                                colorCountBlue = 0;
        //                                            }
        //                                            for (int dti = 0; dti < dtTagNameAll.Rows.Count; dti++)
        //                                            {

        //                                                string tgn1 = HeatMapUnSorted.Rows[j]["tagname"].ToString();
        //                                                string tgn2 = dtTagNameAll.Rows[dti]["TagNameAll"].ToString();
        //                                                if (HeatMapUnSorted.Rows[j]["tagname"].ToString() == dtTagNameAll.Rows[dti]["TagNameAll"].ToString())
        //                                                {
        //                                                    Color c1 = Color.FromArgb(200, Convert.ToInt32(Vr), 0, Convert.ToInt32(Vb));
        //                                                    imageGraphics.FillEllipse(new SolidBrush(c1), Convert.ToUInt32(HeatMapUnSorted.Rows[j]["pointx"].ToString()), Convert.ToUInt32(HeatMapUnSorted.Rows[j]["pointy"].ToString()), 30, 30);

        //                                                    string id = HeatMapSorted.Rows[i]["Name"].ToString();
        //                                                    string x = HeatMapUnSorted.Rows[j]["pointx"].ToString();
        //                                                    string y = HeatMapUnSorted.Rows[j]["pointy"].ToString();

        //                                                    DataRow dRow = dtTagNameAllOwn.NewRow();
        //                                                    string k = tgn1;
        //                                                    dRow["TagNameAll"] = tgn1;
        //                                                    //counter= counter+1;
        //                                                    dtTagNameAllOwn.Rows.Add(dRow);
        //                                                }

        //                                            }


        //                                            //Color c1 = Color.FromArgb(200, Convert.ToInt32(Vr), 0, Convert.ToInt32(Vb));
        //                                            //gs.FillEllipse(new SolidBrush(c1), Convert.ToUInt32(HeatMapUnSorted.Rows[j]["pointx"].ToString()), Convert.ToUInt32(HeatMapUnSorted.Rows[j]["pointy"].ToString()), 30, 30);

        //                                            //string id = HeatMapSorted.Rows[i]["Name"].ToString();
        //                                            //string x = HeatMapUnSorted.Rows[j]["pointx"].ToString();
        //                                            //string y = HeatMapUnSorted.Rows[j]["pointy"].ToString();
        //                                        }
        //                                    }
        //                                }
        //                            }
        //                        }


        //                        string htIv = HeatMapSortedIndividual.Rows[m]["CountOfClients"].ToString();
        //                        divider = 800 / HeatMapSortedIndividual.Rows.Count;

        //                        if (htIv != Count.ToString())
        //                        {
        //                            colorCountRGB++;
        //                            div = div + 1;
        //                            using (Font myFont = new Font("Arial", 10))
        //                            {
        //                                Color c2 = Color.FromArgb(200, Convert.ToInt32(Vr), 0, Convert.ToInt32(Vb));
        //                                //position = position + divider;
        //                                position = position - divider;
        //                                imageGraphics.DrawString(div.ToString(), myFont, Brushes.Green, new Point(1530, position + dividerPosition / 2));
        //                                //gs.FillRectangle(new SolidBrush(c2), 1200, position, 30, dividerPosition);
        //                                imageGraphics.FillRectangle(new SolidBrush(c2), 1550, position, 30, dividerPosition);

        //                                Color c3 = Color.FromArgb(255, 255, 0);
        //                                imageGraphics.DrawString("0", myFont, Brushes.Green, new Point(1530, positionYellow + dividerPosition / 4));
        //                                //gs.FillRectangle(new SolidBrush(c3), 1200, positionYellow, 30, dividerPosition);
        //                                imageGraphics.FillRectangle(new SolidBrush(c3), 1550, positionYellow, 30, dividerPosition);
        //                            }
        //                        }

        //                        if (HeatMapSorted.Rows[i]["CountOfClients"].ToString() != Count.ToString())
        //                        {
        //                            colorCountBlue--;
        //                            Count = HeatMapSorted.Rows[i]["CountOfClients"].ToString();
        //                        }
        //                    }
        //                }

        //            }
        //            Count = HeatMapSorted.Rows[i]["CountOfClients"].ToString();


        //        }

        //        // Other Color
        //        DataTable dtTagNameAllExtra = new DataTable();
        //        dtTagNameAllExtra.Columns.Add("TagNameAll", typeof(String));

        //        for (int i = 0; i < dtTagNameAll.Rows.Count; i++)
        //        {
        //            int flag = 0;
        //            string flName = "";
        //            for (int j = 0; j < dtTagNameAllOwn.Rows.Count; j++)
        //            {
        //                string tgn1 = dtTagNameAll.Rows[i]["TagNameAll"].ToString();
        //                string tgn2 = dtTagNameAllOwn.Rows[j]["TagNameAll"].ToString();

        //                if (tgn1 == tgn2)
        //                {
        //                    flag = 1;

        //                }
        //                flName = tgn1;
        //            }
        //            if (flag == 0)
        //            {
        //                DataRow dRow = dtTagNameAllExtra.NewRow();
        //                string k = flName;
        //                dRow["TagNameAll"] = flName;
        //                dtTagNameAllExtra.Rows.Add(dRow);
        //            }
        //        }

        //        for (int i = 0; i < dtTagNameAllExtra.Rows.Count; i++)
        //        {

        //            for (int j = 0; j < HeatMapUnSortedAll.Rows.Count; j++)
        //            {
        //                if (HeatMapUnSortedAll.Rows[j]["tagname"].ToString() == dtTagNameAllExtra.Rows[i]["TagNameAll"].ToString())
        //                {
        //                    //Color c1 = Color.FromArgb(200, Convert.ToInt32(Vr), 0, Convert.ToInt32(Vb));
        //                    Color c1 = Color.FromArgb(255, 255, 0);
        //                    //gs.FillEllipse(new SolidBrush(c1), Convert.ToUInt32(HeatMapUnSortedAll.Rows[j]["pointx"].ToString()), Convert.ToUInt32(HeatMapUnSortedAll.Rows[j]["pointy"].ToString()), 30, 30);
        //                    int RatioX = Convert.ToInt32((Convert.ToDouble(Convert.ToUInt32(HeatMapUnSortedAll.Rows[j]["pointx"].ToString())) * 0.365));
        //                    int RatioY = Convert.ToInt32((Convert.ToDouble(Convert.ToUInt32(HeatMapUnSortedAll.Rows[j]["pointy"].ToString())) * 0.30));
        //                    //gs.FillEllipse(new SolidBrush(c1), Convert.ToUInt32(HeatMapUnSorted.Rows[j]["pointx"].ToString()) + RatioX, Convert.ToUInt32(HeatMapUnSorted.Rows[j]["pointy"].ToString()) + RatioY, 30, 30);

        //                    imageGraphics.FillEllipse(new SolidBrush(c1), Convert.ToUInt32(HeatMapUnSortedAll.Rows[j]["pointx"].ToString()) + RatioX, Convert.ToUInt32(HeatMapUnSortedAll.Rows[j]["pointy"].ToString()) + RatioY, 30, 30);

        //                }
        //            }
        //        }
        //        // Other color end

        //        if (tagDateLastMonth == tagDateFirstMonth)
        //        {
        //            if (Month < LastDay)
        //            {
        //                Month++;
        //                if (Type == "Day")
        //                {
        //                    percentOfDays++;
        //                    double totaldays = (Convert.ToDateTime(ToDate) - Convert.ToDateTime(FromDate)).TotalDays;
        //                    double percent = (percentOfDays / totaldays) * 100;
        //                    ProgressBarTagLoad(percent);
        //                }
        //            }
        //            else
        //            {
        //                Month = 1;
        //                if (tagDateFirstMonth < tagDateLastMonth)
        //                {
        //                    tagDateFirstMonth++;
        //                }
        //                else
        //                {
        //                    tagDateFirstMonth = Convert.ToInt16(Convert.ToDateTime(FromDate == "" ? DateTime.Now.ToString() : FromDate).Month);
        //                    percentOfDays = 0;
        //                }
        //                if (Type == "Day")
        //                {
        //                    percentOfDays++;
        //                    double totaldays = (Convert.ToDateTime(ToDate) - Convert.ToDateTime(FromDate)).TotalDays;
        //                    double percent = (percentOfDays / totaldays) * 100;
        //                    ProgressBarTagLoad(percent);
        //                }

        //            }
        //        }
        //        else
        //        {

        //            if (Month < 31)
        //            {
        //                Month++;
        //                if (Type == "Day")
        //                {
        //                    percentOfDays++;
        //                    double totaldays = (Convert.ToDateTime(ToDate) - Convert.ToDateTime(FromDate)).TotalDays;
        //                    double percent = (percentOfDays / totaldays) * 100;
        //                    ProgressBarTagLoad(percent);
        //                }
        //            }
        //            else
        //            {
        //                Month = 1;
        //                if (tagDateFirstMonth < tagDateLastMonth)
        //                {
        //                    tagDateFirstMonth++;
        //                }
        //                else
        //                {
        //                    tagDateFirstMonth = Convert.ToInt16(Convert.ToDateTime(FromDate).Month);
        //                    //percentOfDays = 0;
        //                }
        //                if (Type == "Day")
        //                {
        //                    percentOfDays++;
        //                    double totaldays = (Convert.ToDateTime(ToDate) - Convert.ToDateTime(FromDate)).TotalDays;
        //                    double percent = (percentOfDays / totaldays) * 100;
        //                    ProgressBarTagLoad(percent);
        //                }
        //            }
        //        }
        //        if (Type == "Hour")
        //        {
        //            if (HourCount < 24)
        //            {
        //                HourCount++;

        //                double TotalHours = (Convert.ToDateTime(ToDate) - Convert.ToDateTime(FromDate)).TotalHours;
        //                if (percentOfHours < TotalHours)
        //                {
        //                    percentOfHours++;
        //                    //double TotalHours = (Convert.ToDateTime(ToDate) - Convert.ToDateTime(FromDate)).TotalHours;
        //                    double percent = (percentOfHours / TotalHours) * 100;
        //                    ProgressBarTagLoad(percent);
        //                }
        //                else
        //                {
        //                    percentOfHours = 0;
        //                }

        //            }
        //            else
        //            {
        //                HourCount = 1;
        //            }
        //        }

        //    }
        //}

    }
}
