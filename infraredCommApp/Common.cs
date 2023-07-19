using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public static DateTime GetValidDateTime(string dateTimeString)
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
