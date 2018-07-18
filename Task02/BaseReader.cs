using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task01;

namespace Task02
{
    abstract class BaseReader
    {
        public FileInfo FileInfo { get; set; }

        public BaseReader()
        {
            ChooseFileFromDirectory();
        }

        public void ChooseFileFromDirectory()
        {
            Console.WriteLine("Укажите каталог, где находится файл");
            DirectoryInfo dir = new DirectoryInfo(Console.ReadLine());
            FileInfo[] txtFiles = dir.GetFiles("*.txt", SearchOption.AllDirectories);

            for (int i = 0; i < txtFiles.Length; i++)
            {
                Console.WriteLine("Id - {0}, name - {1}", i, txtFiles[i].Name);
            }

            Console.WriteLine("Выберите Id файла");

            FileInfo = txtFiles[int.Parse(Console.ReadLine())];
        }

        public abstract string ReadFromFile();

        public abstract void Print();
    }
}
