using System;
using BenchmarkDotNet.Attributes;
using Distance;

namespace Benchmark
{
    [RankColumn]
    public class BenchmarkTest
    {

       // public GetDistance distance = new GetDistance();
        private GetDistance.PointStruct pointOneStruct = new () { X = new Random().Next(-50, 50), Y = new Random().Next(-50, 50) };
        private GetDistance.PointStruct pointTwoStruct = new () { X = new Random().Next(-50, 50), Y = new Random().Next(-50, 50) };

        private GetDistance.PointClass pointOneClass = new() { X = new Random().Next(-50, 50), Y = new Random().Next(-50, 50) };
        private GetDistance.PointClass pointTwoClass = new() { X = new Random().Next(-50, 50), Y = new Random().Next(-50, 50) };



        [Benchmark]
        public void TestPointStructDistance()
        {


            GetDistance.PointStructDistance(pointOneStruct, pointTwoStruct);
        }

        [Benchmark]
        public void TestPointClassDistance()
        {
           
            GetDistance.PointClassDistance(pointOneClass, pointTwoClass);
        }

        [Benchmark]
        public void TestPointDistanceDouble()
        {
           
            GetDistance.PointDistanceDouble(pointOneStruct, pointTwoStruct);
        }

        [Benchmark]
        public void TestPointDistanceShort()
        {
           

            GetDistance.PointDistanceShort(pointOneStruct, pointTwoStruct);
        }

    }
}
