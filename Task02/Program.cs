using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task02
{
    class Program
    {
        private const string First = "1";
        static FileEditor fe;
        static HistoryFileEditor hfe;

        static void Main(string[] args)
        {
            ChooseMode();
            Console.WriteLine("Введите текст");
            string str = Console.ReadLine();
            fe.Text = str;
            fe.WriteFile(true);
            fe.Print();





            Console.ReadKey();
        }

        public static void ChooseMode()
        {
            Console.WriteLine("Укажите режим работы:\n1)Режим наблюдения\n2)Режим отката изменений");
            String mode = Console.ReadLine();

            switch (mode)
            {
                case First:
                    Console.WriteLine("Укажите вариант работы:\n1)Создать новый файл\n2)Редактировать существующий файл");
                    String option = Console.ReadLine();
                    if (option == First)
                    {
                        fe = new FileEditor(false);
                    }
                    else
                    {
                        fe = new FileEditor(true);
                    }
                    break;
                default:
                    hfe = new HistoryFileEditor();
                    break;
            }
        }
    }
}
