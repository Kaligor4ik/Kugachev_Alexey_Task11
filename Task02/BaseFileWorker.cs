using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task01;

namespace Task02
{
    abstract class BaseFileWorker
    {
        protected string text;
        protected string directory;
        protected string fileName;


        public BaseFileWorker(string fileName, string directory)
        {
            this.directory = directory;
            this.fileName = fileName;
        }

        public virtual void WriteFile()
        {
            FileUtils.WriteToPath(text, directory + fileName);
        }

        public virtual void ReadFromFile()
        {
            text = FileUtils.ReadAllFromPath(directory + fileName);
        }

        public virtual void CleanFile()
        {
            text = FileUtils.ReadAllFromPath(directory + fileName);
        }
    }
}
