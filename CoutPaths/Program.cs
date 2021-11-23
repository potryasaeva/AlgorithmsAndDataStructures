using System;
/*Для прямоугольного поля размера M на N клеток, 
         * подсчитать количество путей из верхней левой клетки в правую нижнюю. 
         * Известно что ходить можно только на одну клетку вправо или вниз.*/
namespace CoutPaths
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine($"Please enter N - field width");
            int n = Int32.Parse(Console.ReadLine());
            Console.WriteLine($"Please enter M - field depth");
            int m = Int32.Parse(Console.ReadLine());
            Console.WriteLine(paths(n, m));


            static int helper(int n, int m, int[,] arr)
            {
                if (n < 1 || m < 1)
                {
                    return 0;
                }
                if (n == 1 && m == 1)
                {
                    return 1;
                }
                if (arr[n, m] != 0)
                {
                    return arr[n, m];
                }
                arr[n, m] = helper(n - 1, m, arr) + helper(n, m - 1, arr);
                return arr[n, m];
            }
            static int paths(int n, int m)
            {
                var arr = new int[n + 1, m + 1];
                return helper(n, m, arr);
            }
        }
    }
}
