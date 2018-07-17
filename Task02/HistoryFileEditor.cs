using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using Task01;

namespace Task02
{
    class HistoryFileEditor : BaseFileEditor
    {
        private const string DefaultHistoryDirectory = "..\\..\\History\\";
        private const int MaxValue = 10;

        private readonly BinaryFormatter formatter;

        internal History History { get; private set; }

        public HistoryFileEditor()
        {
            formatter = new BinaryFormatter();
            _dir = DefaultHistoryDirectory;
            _fileName = ChooseFileFromDirectory();
        }

        public HistoryFileEditor(string name)
        {
            formatter = new BinaryFormatter();
            _dir = DefaultHistoryDirectory;
            _fileName = name;
        }

        public void WriteFile(string text)
        {
            ReadFromFile();
            if (History.Count >= MaxValue) History = new History(text);
            else
            {
                History = new History(text, History);
            }
            using (FileStream fs = new FileStream(_dir + _fileName, FileMode.Create))
            {
                formatter.Serialize(fs, History);
            }
        }

        public new void ReadFromFile()
        {
            using (FileStream fs = new FileStream(_dir + _fileName, FileMode.OpenOrCreate))
            {
                if (fs.Length == 0) History = new History();
                else History = (History)formatter.Deserialize(fs);
            }
        }

        public void PrintHistory()
        {
            int i = 0;
            foreach (KeyValuePair<DateTime, string> d in History)
            {
                Console.WriteLine("Id = {0, 3}, Key = {1}, Value = {2}", i, d.Key, d.Value);
                Console.WriteLine(new string('-', 30));
                i++;
            }
        }

        public string GetByKey(string key)
        {
            return History[DateTime.Parse(key)];
        }

        public string GetById(string id)
        {
            return History.ElementAt(int.Parse(id)).Value;
        }
    }
}