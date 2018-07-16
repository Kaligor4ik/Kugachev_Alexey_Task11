using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task01
{
    public class FileUtils
    {
        public static void RewriteToPath(string path, string value)
        {
            using (FileStream fs = new FileStream(path, FileMode.Create))
            {
                byte[] arr = new UTF8Encoding(true).GetBytes(value);
                fs.Write(arr, 0, arr.Length);
            }
        }

        public static void WriteToPath(string path, string value)
        {
            using (StreamWriter sw = new StreamWriter(path, true, System.Text.Encoding.UTF8))
            {
                sw.Write(value);
            }
        }

        public static string ReadAllFromPath(string path)
        {
            using (StreamReader sr = new StreamReader(path))
            {
                return sr.ReadToEnd();
            }
        }
    }
}
