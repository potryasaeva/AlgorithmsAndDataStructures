using System;

namespace Fibonacci
{
    class Program
    {

        public class TestCase
        {
            public int X { get; set; }
            public int Expected { get; set; }
            public Exception ExpectedException { get; set; }
        }


        static int fibonacci(int n)
        {
            if (n < 0)
            {
                throw new ArgumentException("The number you are entered less than 0") ;
            }
            else if (n == 0)
            {
                return 0;
            }
            else if (n == 1)
            {
                return 1;
            }
            else
            {
                return fibonacci(n - 1) + fibonacci(n - 2);
            }


        }

        static void TestFibonacci(TestCase testCase)
        {
            try
            {
                var actual = fibonacci(testCase.X);

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
            catch (Exception) {
                Console.WriteLine("INVALID TEST");
            }
        }

        static void Main(string[] args)
        {
            var testCase1 = new TestCase()
            {
                X = 6,
                Expected = 8,
                ExpectedException = null
            };

            var testCase2 = new TestCase()
            {
                X = 0,
                Expected = 0,
                ExpectedException = null
            };

            var testCase3 = new TestCase()
            {
                X = -1,
                Expected = 0,
                ExpectedException = new ArgumentException()
            };

            var testCase4 = new TestCase()
            {
                X = 01,
                Expected = 1,
                ExpectedException = null
            };

            TestFibonacci(testCase1);
            TestFibonacci(testCase2);
            TestFibonacci(testCase3);
            TestFibonacci(testCase4);


        }
    }
}
