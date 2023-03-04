using System;
using System.Collections.Generic;

namespace CodingTestLibrary
{
    class Program
    {
        /**
         * Print the ratio of positive, negative and 0 in the array. 
         */
        public static void plusMinus(List<int> arr)
        {
            int neg = 0;
            int pos = 0;
            int zero = 0;
            foreach (int e in arr)
            {
                if (e < 0)
                {
                    neg++;
                }
                else if (e > 0)
                {
                    pos++;
                }
                else if (e == 0)
                {
                    zero++;
                }
            }
            double positivePro = (double)pos / arr.Count;
            Console.WriteLine("{0:N6}", positivePro);
            double negativePro = (double)neg / arr.Count;
            Console.WriteLine("{0:N6}", negativePro);
            double zeroPro = (double)zero / arr.Count;
            Console.WriteLine("{0:N6}", zeroPro);
        }


        /**
         * Printing the highest possible addition of 4 elements and lowest possible sum of 4 elements. 
         */
        public static void miniMaxSum(List<int> arr)
        {
            arr.Sort();
            long min = (long)arr[0] + arr[1] + arr[2] + arr[3];
            long max = (long)arr[arr.Count - 4] + arr[arr.Count - 3] + arr[arr.Count - 2] + arr[arr.Count - 1];
            Console.WriteLine(min + " " + max);

        }

        /**
         * Converting string that displays time to AM or PM format. 
         */
        public static string timeConversion(string s)
        {
            int length = s.Length;
            String time = s.Substring(0, length - 2);
            String ampm = s.Substring(length - 2, 2);
            string[] timeEach = time.Split(':');
            int hour = Int32.Parse(timeEach[0]);
            if (ampm == "PM")
            {
                hour = hour + 12;
                if (hour == 24)
                {
                    hour = 12;
                }
            }
            else
            {
                if (hour == 12)
                {
                    hour = 00;
                }
            }

            String result = "" + hour.ToString("D2") + ":" + timeEach[1] + ":" + timeEach[2];

            return result;
        }

        /**
         *  List<int> scores = new List<int> { 12, 24, 10, 24};
            breakingRecords(scores);
         */
        public static List<int> breakingRecords(List<int> scores)
        {
            int index = 0;
            int min = scores[0];
            int max = scores[0];

            int maxCount = 0;
            int minCount = 0;

            foreach (int score in scores.GetRange(1, (scores.Count - 1)))
            {
                
                if ((score < min) || (score > max))
                {
                    if (score < min)
                    {
                        min = score;
                        minCount++;
                    }

                    if (score > max)
                    {
                        max = score;
                        maxCount++;
                    }
                }

                index++;
            }

            List<int> result = new List<int> { maxCount, minCount };

            return result;
        }


        /**
         * Convert camel case string to regular space split string or convert reguar string to camel case string with no space
         * 
         * Example input: S;M;plasticCup()
         * 
         * First Character can be:
         * S: Split (Split camel case to regular string)
         * C: Combine (Combine to camel case)
         * 
         * Second character can be:
         * M: Method (Convert from or to Method i.e methodName1()
         * C: Class (Convert from or to Calss i.e. ClassName1) (First char of class is uppercase)
         * V: Variable (Convert from or to variable i.e. variableName1
         * 
         */
        public static void CamelCase4(List<string> stdIn)
        {
            List<string> result = new List<string>();

            foreach (string value in stdIn)
            {
                String[] splited = value.Split(';');
                var reg = "";
                if (splited[0] == "S")
                {
                    reg = CamelToRegular(splited[1], splited[2]);
                } else if (splited[0] == "C")
                {
                    reg = RegularToCamal(splited[1], splited[2]);
                }
                Console.WriteLine(reg);
            }

        }

        public static string CamelToRegular(string operand1, string value)
        {   
            if (operand1 == "M")
            {
                value = value.Replace("()", "");
            }

            if (operand1 == "C")
            {
                var temp = value.Substring(0, 1).ToLower();
                value = value.Remove(0, 1).Insert(0, temp);
            }

            for(int i = 0; i < value.Length; i++)
            {
                if (Char.IsUpper(value[i]))
                {
                    value = value.Replace(value[i].ToString(), " " + value[i].ToString().ToLower());
                }
            }

            return value;
        }

        public static string RegularToCamal(string operand1, string value)
        {
            if (operand1 == "C")
            {
                var temp = value.Substring(0, 1).ToUpper();
                value = value.Remove(0, 1).Insert(0, temp);
            }

            for (int i = 0; i < value.Length; i++)
            {
                if (value[i] == ' ')
                {
                    var temp = value.Substring(i + 1, 1).ToUpper();
                    value = value.Remove(i, 2).Insert(i, temp);
                }
            }

            if (operand1 == "M")
            {
                value = value.Insert(value.Length, "()");
            }

            return value;
        }

        /**
         * 
         * int n: the length of array 
         * int ar[n]: an array of integers
         * int k: the integer divisor
         * 
         * Find any pair of int a and b in array ar where ar[a] + ar[b] is divisible by k and b > a
         */
        public static int divisibleSumPairs(int n, int k, List<int> ar)
        {   
            List<List<int>> result = new List<List<int>>();
            for (int i = 0; i < n; i++)
            {
                for (int j = i + 1; j < n; j++)
                {
                    if ((ar[j] + ar[i]) % k == 0)
                    {
                        result.Add(
                                new List<int> { i, j }
                            );
                    }
                }
            }

            return result.Count;
        }



        static void Main(string[] args)
        {
            List<string> result = new List<string> {
                "S;V;iPad",
                "C;M;mouse pad",
                "C;C;code swarm",
                "S;C;OrangeHighlighter",
                "S;M;plasticCup()"

            };
            CamelCase4(result);
        }


    }
}
