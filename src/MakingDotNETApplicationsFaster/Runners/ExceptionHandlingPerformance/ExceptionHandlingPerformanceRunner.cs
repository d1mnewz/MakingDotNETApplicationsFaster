using System;
using MakingDotNETApplicationsFaster.Infrastructure;

namespace MakingDotNETApplicationsFaster.Runners.ExceptionHandlingPerformance
{
    sealed class ExceptionHandlingPerformanceRunner : IRunner
    {
        public void Run()
        {
            const int length = 10000;

            new PerformanceTests
            {
                {_ => { TryCatchInsideInnerLoop(length); }, "TryCatchInsideInnerLoop"},
                {_ => { TryCatchOutsideInnerLoop(length); }, "TryCatchOutsideInnerLoop"}
            }.Run(1000000);
        }

        static void TryCatchInsideInnerLoop(int length)
        {
            for (var i = 0; i < length; i++)
            {
                try
                {
                    var value = i * 100;
                    if (value == -1)
                    {
                        throw new Exception();
                    }
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception.ToString());
                }
            }
        }

        static void TryCatchOutsideInnerLoop(int length)
        {
            try
            {
                for (var i = 0; i < length; i++)
                {
                    var value = i * 100;
                    if (value == -1)
                    {
                        throw new Exception();
                    }
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.ToString());
            }
        }
    }
}