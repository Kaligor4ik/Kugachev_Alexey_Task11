using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task01;

namespace Task02
{
   abstract class BaseFileEditor
    {
        protected string _dir;
        protected string _fileName;
        protected string text;

        public void ChooseFileFromDirectory()
        {
            DirectoryInfo dir = new DirectoryInfo(_dir);
            FileInfo[] txtFiles = dir.GetFiles("*.txt", SearchOption.AllDirectories);

            for (int i = 0; i < txtFiles.Length; i++)
            {
                Console.WriteLine("Id - {0}, name - {1}", i, txtFiles[i].Name);
            }

            Console.WriteLine("Выберите Id файла");
            
            FileInfo fi = txtFiles[int.Parse(Console.ReadLine())];

            _dir = fi.DirectoryName;
            _fileName = fi.Name;
        }

        public void ReadFromFile()
        {
            text = FileUtils.ReadAllFromPath(_dir + _fileName);
        }

        public void CreateDirectory()
        {
            Directory.CreateDirectory(_dir);
        }

        public void Print()
        {
            Console.WriteLine(text);       
        }
    }
}
