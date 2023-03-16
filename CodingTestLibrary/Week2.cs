﻿using System;
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

        /**
         *  Convert a decimal number to 32 digit binary number. 
         *  Then flip all bits in the 32 bigit binary number
         *  Then convert the number back to decimal
         *  return the decimal number
         *              long result = flippingBits(9);
         */
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

        /**
         * arr is a matrix. 
         * 
         * e.g. 
         * 
         * 1 2 3
         * 4 5 6
         * 9 8 9
         * 
         * left to right diagonal is 1 + 5 + 9  = 15
         * right to left diagonal is 3 + 5 + 9 = 17
         * 
         * their absolute difference is | 15 - 17 | = 2
         * 
         * Get absolute difference difference of diagonals for any matrix passed. 
         * 
         *  List<List<int>> arr = new List<List<int>>
            {
                new List<int> { 1, 2, 3 },
                new List<int> { 4, 5, 6 },
                new List<int> { 9, 8, 9 },
            };

            int result = diagonalDifference(arr);
         * 
         */
        public static int diagonalDifference(List<List<int>> arr)
        {
            int leftToRightDiagonal = 0;
            int rightToLeftDiagonal = 0;

            int leftToRightCounter = 0;
            int rightToLeftCounter = arr.Count - 1;

            foreach (List<int> list1 in arr)
            {
                leftToRightDiagonal = leftToRightDiagonal + list1[leftToRightCounter];
                leftToRightCounter++;
                rightToLeftDiagonal = rightToLeftDiagonal + list1[rightToLeftCounter];
                rightToLeftCounter--;
            }

            int difference = leftToRightDiagonal - rightToLeftDiagonal;
            if (difference < 0)
            {
                difference = 0 - difference;
            }
            return difference;

        }


        /**
         * Sort by counting the occurance of each number in an array. 
         * Return a list of ints that contains occurances of each numbers in a range of numbers
         * e.g.
         * 
         */
        public static List<int> countingSort(List<int> arr, int n)
        {   
            List<int> result = new List<int>();
            for (int i = 0; i < n; i++)
            {
                result.Add(0);
            }

            foreach (int i in arr)
            {
                result[i]++;
            }
            if (n > 100)
            {
                for (int i = result.Count - 1; i > -1; i--)
                {
                    if (result[i] == 0)
                    {
                        result.RemoveAt(i);
                    }
                    else if (result[i] > 0)
                    {
                        break;
                    }
                }
            }


            return result;
        }

        /*
         * Complete the 'countingValleys' function below.
         *
         * The function is expected to return an INTEGER.
         * The function accepts following parameters:
         *  1. INTEGER steps
         *  2. STRING path
         *  
         *  
         *  
         */

        public static int countingValleys(int steps, string path)
        {
            int numberOfValleys = 0;
            int altitude = 0;

            bool isInValley = false;

            foreach (char c in path)
            {
                if (c == 'D')
                {
                    altitude--;
                } else if (c == 'U')
                {
                    altitude++;
                }

                if (altitude < 0)
                {
                    if (!isInValley)
                    {
                        isInValley = true;
                        numberOfValleys++;
                    }

                } else if (altitude >= 0)
                {
                    isInValley = false;
                }

            }

            return numberOfValleys;
        }

        /*
         * Complete the 'pangrams' function below.
         *
         * The function is expected to return a STRING.
         * The function accepts STRING s as parameter.
         * 
         * Pangram is a sentence that contains every letter in an english alphabet. 
         * When input is pangram, return "pangram"
         * 
         */

        public static string pangrams(string s)
        {
            List<string> alphabets = new List<string>
            {
                "a","b","c","d","e","f","g","h","i","j","k","l","m","n","o","p","q","r","s","t","u","v","w","x","y","z"
            };

            s = s.ToLower();

            foreach(var alph in alphabets)
            {
                if (!s.Contains(alph))
                {
                    return "not pangram";
                }
            }

            return "pangram";
        }

        static void Main(string[] args)
        {
            var result = pangrams("We promptly judged antique ivory buckles for the next prize");

            Console.WriteLine(result);  
        }
    }
}
