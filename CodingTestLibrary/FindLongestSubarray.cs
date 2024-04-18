using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPractice
{
    /**
     * Given an array of integers, find the longest subarray where the absolute difference between any two elements is less than or equal to 1.
     */
    public static class FindLongestSubarray
    {

        public static int pickingNumbers(List<int> a)
        {
            int maxRecord = 0;
            int currentRecord = 0;
            a.Sort();

            var grouped = a.GroupBy(x => x);
            grouped = grouped.OrderBy(x => x.Key);

            if (a.Count > 0)
            {

                var prev = grouped.FirstOrDefault();
                currentRecord = prev.Count();
                foreach (var group in grouped.Skip(1))
                {
                    if (Math.Abs(group.Key - prev.Key) < 2)
                    {
                        currentRecord = group.Count() + prev.Count();
                        maxRecord = Math.Max(maxRecord, currentRecord);
                    } else
                    {
                        maxRecord = Math.Max(maxRecord, group.Count());
                    }
                    prev = group;
                }
                maxRecord = Math.Max(maxRecord, currentRecord);
                return maxRecord;
            }

            return 0;
        }

        //private static void Main(string[] args)
        //{
        //    List<int> lst
        //            = new List<int> { 1, 1, 2, 2, 4, 4, 5, 5, 5 };
        //    int res = FindLongestSubarray.pickingNumbers(lst);

        //    Console.WriteLine(res);

        //    lst = new List<int> { 4, 6, 5, 3, 3, 1 };
        //    res = FindLongestSubarray.pickingNumbers(lst);

        //    Console.WriteLine(res);

        //    lst = new List<int> { 66, 66, 66, 66, 66, 66, 66, 66, 66, 66, 66, 66 };
        //    res = FindLongestSubarray.pickingNumbers(lst);

        //    Console.WriteLine(res);

        //    lst = new List<int> { 84, 43, 11, 41, 2, 99, 31, 32, 56, 53, 42, 14, 98, 27, 64, 57, 16, 33, 48, 21, 46, 61, 87, 90, 28, 12, 62, 49, 29, 77, 82, 70, 80, 89, 95, 52, 13, 19, 9, 79, 35, 67, 51, 39, 7, 1, 66, 8, 17, 85, 71, 97, 34, 73, 75, 6, 91, 40, 96, 65, 37, 74, 20, 68, 23, 47, 76, 55, 24, 3, 30, 22, 55, 5, 69, 86, 54, 50, 10, 59, 15, 4, 36, 38, 83, 60, 72, 63, 78, 58, 88, 93, 45, 18, 94, 44, 92, 81, 25, 26 };

        //    res = FindLongestSubarray.pickingNumbers(lst);

        //    Console.WriteLine(res);

        //    lst = new List<int> { 4, 97, 5, 97, 97, 4, 97, 4, 97, 97, 97, 97, 4, 4, 5, 5, 97, 5, 97, 99, 4, 97, 5, 97, 97, 97, 5, 5, 97, 4, 5, 97, 97, 5, 97, 4, 97, 5, 4, 4, 97, 5, 5, 5, 4, 97, 97, 4, 97, 5, 4, 4, 97, 97, 97, 5, 5, 97, 4, 97, 97, 5, 4, 97, 97, 4, 97, 97, 97, 5, 4, 4, 97, 4, 4, 97, 5, 97, 97, 97, 97, 4, 97, 5, 97, 5, 4, 97, 4, 5, 97, 97, 5, 97, 5, 97, 5, 97, 97, 97 };

        //    res = FindLongestSubarray.pickingNumbers(lst);

        //    Console.WriteLine(res);

        //}
    }
}
