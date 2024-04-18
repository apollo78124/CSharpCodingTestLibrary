using System;
using System.Collections.Generic;
using System.Linq;

namespace practicem
{
    public static class MagicSquare
    {
        public static IEnumerable<List<int>>
        Permutations(List<int> lst)
        {
            if (lst.Count <= 1)
            {
                yield return lst;
            }
            else
            {
                foreach (var perm in Permutations(
                    lst.Skip(1).ToList()))
                {
                    for (int i = 0; i < lst.Count; i++)
                    {
                        yield return perm.Take(i)
                            .Concat(new List<int> { lst[0] })
                            .Concat(perm.Skip(i))
                            .ToList();
                    }
                }
            }
        }

        // Return if given list denote the magic square or not.
        public static bool IsMagicSquare(List<int> lst)
        {
            int[][] a = new int[][] { new int[] { 0, 0, 0 },
                                  new int[] { 0, 0, 0 },
                                  new int[] { 0, 0, 0 } };

            // Convert list into 3 X 3 matrix
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    a[i][j] = lst[3 * i + j];
                }
            }

            int s = a[0].Sum();

            // Checking if each row sum is same
            for (int i = 1; i < 3; i++)
            {
                int tmp = a[i].Sum();
                if (tmp != s)
                {
                    return false;
                }
            }

            // Checking if each column sum is same
            for (int j = 0; j < 3; j++)
            {
                int tmp = a.Sum(row => row[j]);
                if (tmp != s)
                {
                    return false;
                }
            }

            // Checking if diagonal 1 sum is same
            int tmp1 = a[0][0] + a[1][1] + a[2][2];
            if (tmp1 != s)
            {
                return false;
            }

            // Checking if diagonal 2 sum is same
            int tmp2 = a[0][2] + a[1][1] + a[2][0];
            if (tmp2 != s)
            {
                return false;
            }

            return true;
        }

        // Generating all magic square
        public static List<List<int>> FindMagicSquares()
        {
            List<List<int>> magicSquares
                = new List<List<int>>();
            List<int> lst
                = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            // Producing all permutation of list
            // and checking if it denotes a magic square or not.
            foreach (var v in Permutations(lst))
            {
                if (IsMagicSquare(v))
                {
                    magicSquares.Add(v);
                }
            }

            return magicSquares;
        }
        // Return sum of difference between each element of two
        // list
        public static int Diff(List<int> a, List<int> b)
        {
            return a.Select((x, i) => Math.Abs(x - b[i]))
                .Sum();
        }

        // Wrapper function
        public static int Wrapper(List<List<int>> v)
        {
            List<int> inglemat  = new List<int>();

            foreach (var v2 in v)
            {
                foreach (var v3 in v2)
                {
                    inglemat.Add(v3);
                }
            }


            int res = int.MaxValue;
            List<List<int>> magicSquares = FindMagicSquares();

            foreach (var magicSquare in magicSquares)
            {
                // Finding the difference with each magic square
                // and assigning the minimum value.
                res = Math.Min(res, Diff(inglemat, magicSquare));
            }

            return res;
        }

        //public static void Main(string[] args)
        //{
        //    List<int> lst
        //            = new List<int> { 4, 9, 2, 3, 5, 7, 8, 1, 5 };
        //    int res = MagicSquare.Wrapper(lst);

        //    Console.WriteLine(res);
        //}
    }
}