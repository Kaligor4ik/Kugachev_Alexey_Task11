using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Task01
{
    class ReplaceUtils
    {
        public static string ReplaceIf(string str, Func<char, bool> condition, Func<string, string> action)
        {
            StringBuilder sb = new StringBuilder(str.Length);
            char[] arr = str.ToArray();
            for (int i = 0; i < arr.Length; i++)
            {
                if (condition.Invoke(arr[i]))
                {
                    string s = "";
                    while (condition.Invoke(arr[i]))
                    {
                        s = s + arr[i];
                        if (i < arr.Length - 1) { i++; }
                        else { i++; break; };
                    }
                    sb.Append(action.Invoke(s));
                    i--;
                }
                else
                {
                    sb.Append(arr[i]);
                }
            }
            return sb.ToString();
        }
    }
}
