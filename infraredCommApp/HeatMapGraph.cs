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
        public static List<string> SelectedTags = new List<string>();
        public static string workfolder = "";
        public static DataTable HeatMapSorted = new DataTable();
        public static DataTable HeatMapUnSorted = new DataTable();
        private readonly Map CurrentMap;

        public HeatMapGraph(string mapName)
        {
            InitializeComponent();
            string fileName = "C:\\testfolder\\Image\\obj";
            workfolder = "C:\\testfolder\\";
            var mapDataList = (List<Map>)LoadFromBinaryFile(fileName);
            CurrentMap = mapDataList.FirstOrDefault(x => x.MapFileName == mapName);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SelectedTags.Clear();
            if (!dtTagNameAll.Columns.Contains("TagNameAll"))
            {
                dtTagNameAll.Columns.Add("TagNameAll", typeof(String));
            }

            foreach (var item in listBoxAllData.SelectedItems.Cast<DataRowView>())
            {
                
                DataRow dRow = dtTagNameAll.NewRow();
                dRow["TagNameAll"] = item.Row[1].ToString();
                dtTagNameAll.Rows.Add(dRow);
                SelectedTags.Add(item.Row[1].ToString());
            }
            



            if (dayHourComboBox.SelectedItem.ToString() == "Hour")
            {
                FromDate = Convert.ToString(dtFromDate.Value.Date + dtFromDateTime.Value.TimeOfDay);
                ToDate = Convert.ToString(dtToDate.Value.Date + dtToDateTime.Value.TimeOfDay);
            }
            else
            {
                FromDate = Convert.ToString(dtFromDate.Value.Date);
                ToDate = Convert.ToString(dtToDate.Value.Date);
            }
            Type = dayHourComboBox.SelectedItem.ToString();
            
            this.DialogResult = DialogResult.OK;
            this.Close();

        }

        private void AllSelectionToggle(bool isSelectAll)
        {
            for (int i = 0; i < listBoxAllData.Items.Count; i++)
            {
                listBoxAllData.SetSelected(i, isSelectAll);
            }
        }

        DataTable GetListItemData()
        {
            if (CurrentMap != null && CurrentMap.taglist != null && CurrentMap.taglist.Any())
            {
                List<HeatMap> heatMapList = new List<HeatMap>();
                foreach (tagu taguSingle in CurrentMap.taglist)
                {
                    HeatMap htMap = new HeatMap();
                    htMap.tagId = taguSingle.tagId;
                    htMap.tagname = taguSingle.tagname;
                    htMap.pointx = taguSingle.pointx;
                    htMap.pointy = taguSingle.pointy;
                    htMap.tagtype = taguSingle.tagtype;
                    heatMapList.Add(htMap);
                }

                var table = ListToDataTable(heatMapList);

                var dataTable = table.AsEnumerable()
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
                return dataTable;
            }
            return null;
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
        private void HeatMapGraph_Load(object sender, EventArgs e)
        {
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
            dayHourComboBox.SelectedIndex = 1;

            var data = GetListItemData();
            if(data != null)
            {
                listBoxAllData.DataSource = data;
                listBoxAllData.DisplayMember = "tagname";
                listBoxAllData.ValueMember = "tagId";
                listBoxAllData.SelectionMode = SelectionMode.MultiSimple;
            }
        }

        private void DayHourComboBoxChange(object sender, EventArgs e)
        {
            if (dayHourComboBox.SelectedItem.ToString() == "Hour")
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

        private void HeatMapDialogCancel(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void UnSelectAllClick(object sender, EventArgs e)
        {
            AllSelectionToggle(false);
        }

        private void SelectAllClick(object sender, EventArgs e)
        {
            AllSelectionToggle(true);
        }
    }
}
