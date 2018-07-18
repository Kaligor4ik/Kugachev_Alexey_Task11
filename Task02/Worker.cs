using System;
using System.Windows.Forms;

namespace Task02
{
    class Worker
    {
        private const string First = "1";
        private FileEditor _fe;
        private FileHistory _hfe;

        public Worker()
        {
            _fe = new FileEditor();
            _hfe = new FileHistory(_fe.FileInfo);
        }

        public void OpenFile()
        {
            _fe.Print();
        }

        public void RestoreFromHistory()
        {
            string update = _hfe.Value.GetValue();
            _fe.WriteToFile(update);
        }

        public void EdidFile()
        {
            Console.WriteLine("Введите текст");
            string text = Console.ReadLine();
            _fe.WriteToFile(text);
            _hfe.WriteToFile(_fe.ReadFromFile());
        }

        public void DoWork()
        {
            String mode;
            do
            {
                Console.WriteLine("Укажите режим работы:\n1)Режим наблюдения\n2)Режим отката изменений");
                Console.WriteLine();
                mode = Console.ReadLine();
                switch (mode)
                {
                    case First:
                        OpenFile();
                        EdidFile();
                        break;
                    default:
                        RestoreFromHistory();
                        break;
                }
                Console.WriteLine("Продолжить работу(y/n)? 'n' для выхода");
            }
            while (Console.ReadLine().Equals("y") );
        }
    }
}
