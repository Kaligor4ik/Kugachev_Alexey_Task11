using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task01;

namespace Task02
{
    class FileEditor : BaseFileEditor
    {
        public FileEditor(bool isEdit)
        {
            Dir = Dir;
            if (isEdit) _fileName = ChooseFileFromDirectory();
            else FileName = FileName;
            
        }

        public string Text { get; set; }
        public string Dir {
            get { return _dir; }
            set
            {
                Console.WriteLine("Укажите путь к файлу");
                _dir = Console.ReadLine();
                if(_dir.Last() != '\\')
                {
                    _dir = _dir + "\\";
                }
            }
        }
        public string FileName {
            get { return _fileName; }
            set
            {
                Console.WriteLine("Укажите имя файла с расширением");
                _fileName = Console.ReadLine();
            }
        }

        public void WriteFile(bool isRewrite)
        {
            if(isRewrite) FileUtils.RewriteToPath(Dir + FileName, Text);
            else FileUtils.WriteToPath(Dir + FileName, Text);
            new HistoryFileEditor(_fileName).WriteFile(ReadFromFile());
        }
    }
}
