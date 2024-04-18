using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPractice
{
    public static class StringOperation
    {
        public static string appendAndDelete(string s, string t, int k)
        {
            int deleteOp = 0;
            int addOp = 0;
            int stopped = 0;

            for (;  stopped < t.Length; stopped++)
            {
                if (!(stopped < s.Length))
                {
                    break;
                }
                else if (s[stopped] != t[stopped])
                {
                    break;
                }
            }

            deleteOp = s.Length - stopped;

            if (t.Length > stopped)
            {
                addOp = t.Length - stopped;
            }

            if ((addOp + deleteOp) > k)
            {
                return "No";
            } else
            {
                return "Yes";
            }
        }

        //private static void Main(string[] args)
        //{
        //    //Yes
        //    string result = StringOperation.appendAndDelete("zzzzz", "zzzzzzz", 7);
        //    Console.WriteLine(result);
        //}
    }
}
