using System;
using System.Collections.Generic;
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
    }
}
