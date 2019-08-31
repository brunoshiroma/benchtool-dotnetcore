using System;
using bench;
using System.Threading;

namespace benchtool_dotnetcore
{
    class Program
    {
        static void Main(string[] args)
        {

            var loopCount = "99999";

            IBench bench = null;

            Thread runnerThread = null;

            BenchResult<Object> result = null;

            if(args?.Length >= 2){
                loopCount = args[1];
                int benchType = int.Parse(args[0]);

                switch(benchType){
                    case 1:
                        bench = new SimpleFibonacciLoopBench();
                        runnerThread = new Thread(()=>{
                            result = bench.run(loopCount);
                        });
                        break;
                    default:    
                        bench = new SimpleFibonacciBench();
                        runnerThread = new Thread(()=>{
                            result = bench.run(loopCount);
                        }, 1024 * 1024 * 1024);//changes the thread stack size for the recursive
                        break;
                }

            }
            else
            {
                bench = new SimpleFibonacciLoopBench();

                runnerThread = new Thread(()=>{
                    result = bench.run(loopCount);
                });
            }

            runnerThread.Start();
            runnerThread.Join();

            Console.WriteLine(result.value);
            Console.WriteLine(result.RunningMilliseconds);

        }
    }
}
