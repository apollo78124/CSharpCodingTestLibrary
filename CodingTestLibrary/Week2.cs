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


        static void Main(string[] args)
        {
            List<int> input = new List<int>
            {
                84, 29, 57
            };

            List<int> result = gradingStudents(input);
            Console.WriteLine(result);  
        }
    }
}
