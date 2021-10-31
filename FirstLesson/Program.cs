using System;

namespace FirstLesson
{
    class Program
    {
        public class TestCase
        {
            public int X { get; set; }
            public bool Expected { get; set; }
            public Exception ExpectedException { get; set; }
        }



        static void Test(TestCase testCase)
        {
            try
            {
               var actual = isPrime(testCase.X);

                if (actual == testCase.Expected)
                {
                    Console.WriteLine("VALID TEST");
                }
                else
                {
                    Console.WriteLine("INVALID TEST");
                }
            }
            catch (ArgumentException ex)
            {
                if (testCase.ExpectedException != null & ex.GetType() == testCase.ExpectedException.GetType())
                {
                    Console.WriteLine("VALID TEST");
                }
                else
                {
                    Console.WriteLine("INVALID TEST");
                }
            }
            catch (Exception)
            {
                Console.WriteLine("INVALID TEST");
            }
        }


        static bool isPrime(int n)
        {
            if (n <= 0)
            {
                throw new ArgumentException("Please enter positive number more than 0"); 
            }
            var d = 0;
            for (int i = 2; i < n; i++)
            {
                if (n % i == 0)
                {
                    d++;
                }
                else
                {
                    i++;
                }
            }
            if (d == 0) { Console.WriteLine($"Number {n} is simple"); return true; }
            else { Console.WriteLine($"Number {n} is not simple"); return false; }
        }

        static void Main()
        {
            var testCase1 = new TestCase()
            {
                X = 1,
                Expected = true,
                ExpectedException = null
            };

            var testCase2 = new TestCase()
            {
                X = 8,
                Expected = false,
                ExpectedException = null
            };

            var testCase3 = new TestCase()
            {
                X = 0,
                Expected = false,
                ExpectedException = new ArgumentException()
            };

            var testCase4 = new TestCase()
            {
                X = -1,
                Expected = false,
                ExpectedException = new ArgumentException()
            };
            
            Test(testCase1);
            Test(testCase2);
            Test(testCase3);
            Test(testCase4);

            do
            {
                try
                {
                    Console.WriteLine($"Enter number");
                    isPrime(Int32.Parse(Console.ReadLine()));
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    continue;
                }
            }
            while (true);
        }
    }
}
