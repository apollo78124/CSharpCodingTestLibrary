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

        public static List<int> gradingStudents(List<int> grades)
        {   
            List<int> result = new List<int>();
            int dec = 0;
            int det = 0;
            foreach (var score in grades)
            {
                if (score < 38)
                {   
                    result.Add(score);
                } 
                else
                {
                    dec = score / 10;
                    det = score % 10;
                    if (det == 3 || det == 4)
                    {
                        det = 5;
                    } 
                    else if (det == 8 || det == 9)
                    {
                        det = 10;
                    }
                    result.Add(dec * 10 + det);
                }
            }
            return result;
    }

        public static int findMedian(List<int> arr)
        {
            arr.Sort();
            return arr[arr.Count / 2 + 1];
        }

        public static long flippingBits(long n)
        {
            string binary = Convert.ToString(n, 2);

            if (binary.Length < 32)
            {
                for (int i = binary.Length; i < 32; i++)
                {
                    binary = "0" + binary;

                }
            }

            string result = "";

            for(int i = 0; i < binary.Length; i++)
            {
                if (binary[i] == '0')
                {
                    result = result + "1";
                } 
                else 
                if (binary[i] == '1')
                {
                    result = result + "0";
                }
            }
            long longResult = 0;
            int counter = 0;
            for (int i = result.Length - 1; i > -1; i--)
            {
                if (result[i] == '1')
                {
                    longResult =  longResult + (long) Math.Pow(2, counter);
                }
                counter++;
            }

            

            return longResult;
        }


        static void Main(string[] args)
        {
            long result = flippingBits(9);

            Console.WriteLine(result);  
        }
    }
}
