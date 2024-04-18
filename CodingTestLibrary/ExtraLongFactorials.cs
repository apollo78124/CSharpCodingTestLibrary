using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPractice
{
    public static class ExtraLongFactorials
    {
        /*
         * Complete the 'extraLongFactorials' function below.
         *
         * The function accepts INTEGER n as parameter.
         */
        public static Dictionary<int, BigInteger> cache = new Dictionary<int, BigInteger>();
        public static void extraLongFactorials(int n)
        {   
            if (cache.ContainsKey(n))
            {
                Console.Write(cache[n].ToString());
                return;
            } 
            else if (cache.Count > 0)
            {
                int maxKey = cache.Keys.FirstOrDefault();

                foreach (var key in cache.Keys)
                {
                    if (key < n && key > maxKey)
                    {
                        maxKey = key;
                    }
                }

                BigInteger result = cache[maxKey];
                for (BigInteger calc = maxKey; calc <= n; calc++)
                {
                    result = result * calc;
                }
                cache.Add(n, result);
                Console.WriteLine(result.ToString());
            } 
            else
            {
                BigInteger result = 1;
                for (BigInteger calc = 2; calc <= n; calc++)
                {
                    result = result * calc;
                }
                cache.Add(n, result);
                Console.WriteLine(result.ToString());
            }
        }

        //private static void Main(string[] args)
        //{

        //    //3628800
        //    ExtraLongFactorials.extraLongFactorials(10);


        //    //2432902008176640000
        //    ExtraLongFactorials.extraLongFactorials(20);

        //    //2658271574788448768043625811014615890319638528000000000
        //    ExtraLongFactorials.extraLongFactorials(44);

        //    //185482642257398439114796845645546284380220968949399346684421580986889562184028199319100141244804501828416633516851200000000000000000000
        //    ExtraLongFactorials.extraLongFactorials(88);

        //}
    }
}
