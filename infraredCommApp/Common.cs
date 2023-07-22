﻿using System;
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

            var filePath = "Exported";
            if (string.IsNullOrWhiteSpace(filePath))
            {
                throw new ArgumentException("File path cannot be null or empty.");
            }

            var columnHeaders = data.First().Keys.ToList();
            var csvContent = new StringBuilder();
            csvContent.AppendLine(string.Join(",", columnHeaders));
            foreach (var rowData in data)
            {
                var rowValues = columnHeaders.Select(header => rowData.ContainsKey(header) ? rowData[header] : string.Empty);
                csvContent.AppendLine(string.Join(",", rowValues));
            }
            File.WriteAllText(filePath, csvContent.ToString());
        }

        public static void ExportToCsv(List<Dictionary<string, string>> data, string fileNameStarting)
        {
            if (data == null || data.Count == 0)
            {
                throw new ArgumentException("Data cannot be null or empty.");
            }

            // Create an instance of the FolderBrowserDialog
            using (FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog())
            {
                if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    // Get the selected folder path
                    string folderPath = folderBrowserDialog.SelectedPath;

                    // Generate a unique file name
                    string fileName = $"{fileNameStarting}_{DateTime.Now:yyyyMMdd_HHmmss}.csv";

                    // Construct the file path
                    string filePath = Path.Combine(folderPath, fileName);

                    // Get the column headers from the first dictionary
                    var columnHeaders = data.First().Keys.ToList();

                    // Create a CSV string
                    var csvContent = new List<string>();

                    // Add the column headers to the CSV string
                    csvContent.Add(string.Join(",", columnHeaders));

                    // Add the data rows to the CSV string
                    foreach (var rowData in data)
                    {
                        var rowValues = columnHeaders.Select(header => rowData.ContainsKey(header) ? rowData[header] : string.Empty);
                        csvContent.Add(string.Join(",", rowValues));
                    }

                    // Write the CSV string to the file
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
    }
}
