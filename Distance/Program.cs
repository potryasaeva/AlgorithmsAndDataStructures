using System;
using System.Collections.Generic;

namespace Distance
{
    class Program
    {


        static void Main(string[] args)
        {
                      
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(GetDistance.PointStructDistance(new() { X = new Random().Next(-50, 50), Y = new Random().Next(-50, 50) }, new() { X = new Random().Next(-50, 50), Y = new Random().Next(-50, 50) }));
                Console.WriteLine(GetDistance.PointClassDistance(new() { X = new Random().Next(-50, 50), Y = new Random().Next(-50, 50) }, new() { X = new Random().Next(-50, 50), Y = new Random().Next(-50, 50) }));
                Console.WriteLine(GetDistance.PointDistanceDouble(new() { X = new Random().Next(-50, 50), Y = new Random().Next(-50, 50) }, new() { X = new Random().Next(-50, 50), Y = new Random().Next(-50, 50) }));
                Console.WriteLine(GetDistance.PointDistanceShort(new() { X = new Random().Next(-50, 50), Y = new Random().Next(-50, 50) }, new() { X = new Random().Next(-50, 50), Y = new Random().Next(-50, 50) }));
            }
        }







    }

}
