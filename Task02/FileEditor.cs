using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task01;

namespace Task02
{
    internal class FileEditor : BaseReader
    {
        private string _value;

        public FileEditor() : base() { }

        public override void Print()
        {
            ReadFromFile();
            Console.WriteLine(_value);
        }

        public override string ReadFromFile()
        {
            _value = FileUtils.ReadAllFromPath(FileInfo.FullName);
            return _value;
        }

        public void WriteToFile(string text)
        {
            Console.WriteLine("Укажите действие:\n1)Добавить текст в файл\n2)Перезаписать файл");
            string choose = Console.ReadLine();
            if (choose.Equals("2"))
            {
                FileUtils.RewriteToPath(FileInfo.FullName, text);
            }
            else
            {
                FileUtils.WriteToPath(FileInfo.FullName, text);
            }
        }
    }
}
