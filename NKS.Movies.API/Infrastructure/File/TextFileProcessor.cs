namespace NKS.Movies.API.Infrastructure.File
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Serilog;

    public class TextFileProcessor
    {
        public static List<T> LoadFromTextFile<T>(string filePath) where T : class, new()
        {
            var lines = System.IO.File.ReadAllLines(filePath).ToList();
            List<T> output = new List<T>();
            T entry = new T();
            var cols = entry.GetType().GetProperties();

            if (lines.Count < 2)
            {
                throw new IndexOutOfRangeException("The file was either empty or missing.");
            }

            var headers = lines[0].Split(',');
            lines.RemoveAt(0);

            foreach (var row in lines)
            {
                try
                {
                    output.Add(GetEntity<T>(cols, headers, row));
                }
                catch (Exception e)
                {
                    Log.Logger.Error("CSV row is ignored due incorrect data.");
                }
            }
            return output;
        }

        private static T GetEntity<T>(System.Reflection.PropertyInfo[] cols, string[] headers, string row) where T : class, new()
        {
            T entry = new T();
            var vals = row.Split(',');
            //if (headers.Length !=vals.Length)
            //    return null;

            for (var i = 0; i < headers.Length; i++)
            {
                foreach (var col in cols)
                {
                    if (col.Name.ToUpper() == headers[i].ToUpper())
                    {
                        col.SetValue(entry, Convert.ChangeType(vals[i], col.PropertyType));
                    }
                }
            }

            return entry;
        }

        public static void SaveToTextFile<T>(List<T> data, string filePath) where T : class, new()
        {
            List<string> lines = new List<string>();
            StringBuilder line = new StringBuilder();

            if (data == null || data.Count == 0)
            {
                throw new ArgumentNullException("data", "You must populate the data parameter with at least one value.");
            }
            var cols = data[0].GetType().GetProperties();

            foreach (var col in cols)
            {
                line.Append(col.Name);
                line.Append(",");
            }

            lines.Add(line.ToString().Substring(0, line.Length - 1));

            foreach (var row in data)
            {
                line = new StringBuilder();

                foreach (var col in cols)
                {
                    line.Append(col.GetValue(row));
                    line.Append(",");
                }

                lines.Add(line.ToString().Substring(0, line.Length - 1));
            }
            System.IO.File.WriteAllLines(filePath, lines);
        }
    }
}
