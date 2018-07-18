using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Task02
{
    public class FileHistory
    {
        private const string DefaultHistoryDirectory = "..\\..\\History\\";
        private const int MaxValue = 5;

        public string FileName { get; set; }
        public HistoryList Value { get; set; }


        public FileHistory(FileInfo fileInfo)
        {
            FileName = fileInfo.Name;
            ReadFromFile();
        }

        public void ReadFromFile()
        {
            using (FileStream fs = new FileStream(DefaultHistoryDirectory + FileName, FileMode.OpenOrCreate))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                if (fs.Length == 0) Value = new HistoryList(null, new StreamingContext(StreamingContextStates.File));
                else Value = (HistoryList)formatter.Deserialize(fs);
            }
        }

        public void WriteToFile(string text)
        {
            Value.Add(DateTime.Now, text);
            while (Value.Count >= MaxValue) Value.Remove(Value.First().Key);

            using (FileStream fs = new FileStream(DefaultHistoryDirectory + FileName, FileMode.Create))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(fs, Value);
            }
        }
    }

    [Serializable]
    public class HistoryList : Dictionary<DateTime, string>
    {
        public HistoryList(SerializationInfo info, StreamingContext context) : base(info, context) { }
        public string GetValue()
        {
            int i = 0;
            foreach (KeyValuePair<DateTime, string> d in this)
            {
                Console.WriteLine("Id = {0, 3}, Key = {1}, Value = {2}", i, d.Key, d.Value);
                Console.WriteLine(new string('-', 30));
                i++;
            }
            Console.WriteLine("Введите номер записи");
            return this.ElementAt(int.Parse(Console.ReadLine())).Value;
        }
    }
}
