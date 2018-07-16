using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task01
{
    class Program
    {
        static void Main(string[] args)
        {
            FileUtils.RewriteToPath(@"test.txt", "\r\nтестовый документ2\r\n3h3h22'wwcwwr");
            Console.WriteLine("Запись №1: " + FileUtils.ReadAllFromPath(@"test.txt"));
            FileUtils.WriteToPath(@"test.txt", "\r\nтестовый документ01e210");

            string str = FileUtils.ReadAllFromPath(@"test.txt");
            Console.WriteLine("\nЗапись №2(после добавления): {0}\n", str);
            
            Func<char, bool> isNumber = c => Char.IsNumber(c);
            Func<string, string> secondDegree = s => Math.Pow(int.Parse(s), 2).ToString();

            string newstr = ReplaceUtils.ReplaceIf(str, isNumber, secondDegree);
            Console.WriteLine("\nСтрока после возведения чисел во вторые степени: {0}\n", newstr);

            FileUtils.RewriteToPath(@"test.txt", newstr);
            Console.WriteLine("\nЗапись №3(после перезаписи): " + FileUtils.ReadAllFromPath(@"test.txt"));

            Console.ReadKey();
        }
    }
}
