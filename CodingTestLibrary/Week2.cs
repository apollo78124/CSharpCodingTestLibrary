using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingTestLibrary
{
    public class Week2
    {

        public static int lonelyinteger(List<int> a)
        {
            a.Sort();

            for (int i = 0; i < a.Count; i = i + 2)
            {
                if (i + 1 > a.Count - 1 || a[i] != a[i + 1])
                {
                    return a[i];
                }
            }

            return 0;
        }

        public static int findMedian(List<int> arr)
        {
            arr.Sort();
            return arr[arr.Count / 2 + 1];
        }


        static void Main(string[] args)
        {
            List<int> input = new List<int>
            {
                5, 3, 1, 2, 4
            };

            int result = findMedian(input);
            Console.WriteLine(result);  
        }
    }
}
