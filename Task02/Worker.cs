using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task01;

namespace Task02
{
    class Worker : BaseFileWorker
    {
        public Worker(string fileName, string directory) : base(fileName, directory)
        {
        } 

        public void TypeText()
        {
            text = Console.ReadLine();
        }

        public void RewriteFile()
        {
            FileUtils.RewriteToPath(text, directory + fileName);
        }

        public void CreateDirectory()
        {
            Directory.CreateDirectory(directory);
        }
    }
}
