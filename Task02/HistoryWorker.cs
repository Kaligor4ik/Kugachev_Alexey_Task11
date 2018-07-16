using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task02
{
    class HistoryWorker : BaseFileWorker
    {
        private const string DefaultHistoryDirectory = "";

        public HistoryWorker(string fileName, string directory = DefaultHistoryDirectory) : base(fileName, directory) { }

        public override void WriteFile()
        {
            base.WriteFile();
        }
    }
}
