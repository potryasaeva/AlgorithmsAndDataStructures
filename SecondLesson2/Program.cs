using System;

namespace SecondLesson2
{
    class Program

    {

        public class TestCase
        {
            public int[] X { get; set; }
            public int Y { get; set; }
            public int Expected { get; set; }
            public Exception ExpectedException { get; set; }
        }


        // O(log(n))
        public static int BinarySearch(int[] inputArray, int searchValue)
        {
            int min = 0;
            int max = inputArray.Length - 1;
            while (min <= max)
            {
                int mid = (min + max) / 2;
                if (searchValue == inputArray[mid])
                {
                    return mid;
                }
                else if (searchValue < inputArray[mid])
                {
                    max = mid - 1;
                }
                else
                {
                    min = mid + 1;
                }
            }
            return -1;
        }


        static void TestBinarySearch(TestCase testCase)
        {
            try
            {
                var actual = BinarySearch(testCase.X, testCase.Y);

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
        static void Main(string[] args)
        {
            var testCase1 = new TestCase()
            {
                X = new[] { 1, 2, 3, 4, 5, 6, 10 },
                Y = 1,
                Expected = 0,
                ExpectedException = null
            };
            var testCase2 = new TestCase()
            {
                X = new[] { -2, -1, 2, 3, 4, 5, 6, 10 },
                Y = -1,
                Expected = 1,
                ExpectedException = null
            };
            var testCase3 = new TestCase()
            {
                X = new[] { 1, 2, 3, 4, 5, 6, 10 },
                Y = 8,
                Expected = -1,
                ExpectedException = null
            };
            var testCase4 = new TestCase()
            {
                X = new[] { 5, 2, 7, 10, 3, 1, 20 },
                Y = 3,
                Expected = -1,
                ExpectedException = null
            };
            var testCase5 = new TestCase()
            {
                X = new[] { 1, 2, 2, 4, 5, 6, 10 },
                Y = 2,
                Expected = 1,
                ExpectedException = null
            };

            TestBinarySearch(testCase1);
            TestBinarySearch(testCase2);
            TestBinarySearch(testCase3);
            TestBinarySearch(testCase4);
            TestBinarySearch(testCase5);



            var arr = new[] { 1, 3, 5, 6, 7, 8, 9, 52, 65, 98, 123, 456, 789, 25896, 12121212 };
            int result;
            Console.WriteLine("Please enter number for search");
            while (!int.TryParse(Console.ReadLine(), out result))
            {
                Console.WriteLine("Please, enter correct value. Check in list:");
                foreach (var item in arr)
                {
                    Console.WriteLine(item);
                }
            }
            var a = BinarySearch(arr, result);
            Console.WriteLine($"the index of the element you are looking for is {a}");



        }
    }
}
